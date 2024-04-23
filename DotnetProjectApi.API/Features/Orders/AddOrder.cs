using AutoMapper;
using DotnetProjectApi.API.Data;
using DotnetProjectApi.API.Features.Orders.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DotnetProjectApi.API.Features.Orders
{
    public class AddOrder
    {
        public record Command : IRequest
        {
            public List<Guid> Products { get; init; } = new();
            public AddressViewModel ShippingAddress { get; init; } = new();
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DotnetProjectDbContext _context;

            public Handler(DotnetProjectDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken ct = default)
            {
                var products = await _context.Products
                    .Where(x => request.Products.Contains(x.Id))
                    .ToListAsync(ct);

                var productIds = request.Products.Distinct();
                var productQuantities = productIds.ToDictionary(id => id, id => request.Products.Count(p => p == id));

                var productsWithQuantities = products
                    .Where(p => productQuantities.ContainsKey(p.Id))
                    .Select(p => new { Product = p, Quantity = productQuantities[p.Id] })
                    .ToList();

                var total = productsWithQuantities.Sum(x => x.Product.Price * x.Quantity);
                var order = new OrderModel
                {
                    Products = request.Products,
                    ShippingAddress = new AddressModel
                    {
                        Id = Guid.NewGuid(),
                        Street = request.ShippingAddress.Street,
                        City = request.ShippingAddress.City,
                        Country = request.ShippingAddress.Country,
                        FirstName = request.ShippingAddress.FirstName,
                        LastName = request.ShippingAddress.LastName,
                        PostalCode = request.ShippingAddress.PostalCode,
                        Province = request.ShippingAddress.Province
                    },
                    OrderTotal = total,
                    OrderPlacedDateTime = DateTime.UtcNow,
                    OrderStatus = OrderStatus.Pending,
                    OrderNumber = Guid.NewGuid()
                };

                _context.Orders.Add(order);

                productsWithQuantities.ForEach(pq =>
                {
                    var product = products.FirstOrDefault(x => x.Id == pq.Product.Id);
                    if (product != null)
                    {
                        product.Stock -= pq.Quantity;
                        product.Sold += pq.Quantity;
                    }
                });

                await _context.SaveChangesAsync(ct);

                return default;
            }
        }
    }

    public class AddMappingProfile : Profile
    {
        public AddMappingProfile()
        {
            CreateMap<AddOrder.Command, OrderModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.OrderPlacedDateTime, opt => opt.Ignore())
                .ForMember(dest => dest.OrderStatus, opt => opt.Ignore())
                .ForMember(dest => dest.OrderNumber, opt => opt.Ignore())
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products))
                .ForMember(dest => dest.ShippingAddress, opt => opt.MapFrom(src => src.ShippingAddress));
        }
    }
}