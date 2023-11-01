using System.Text.Json.Serialization;
using AutoMapper;
using DotnetProjectApi.API.Data;
using DotnetProjectApi.API.Features.Orders.Models;
using MediatR;

namespace DotnetProjectApi.API.Features.Orders
{
    public class AddOrder
    {
        public record Command : IRequest
        {
            public List<OrderDetailModel> Products { get; init; } = new();
            public AddressModel ShippingAddress { get; init; } = new();
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
                var order = new OrderModel
                {
                    Products = request.Products,
                    ShippingAddress = request.ShippingAddress,
                    OrderTotal = request.Products.Sum(x => x.ProductPrice * x.Quantity),
                    OrderPlacedDateTime = DateTime.UtcNow,
                    OrderStatus = OrderStatus.Pending,
                    OrderNumber = Guid.NewGuid()
                };

                _context.Orders.Add(order);

                foreach (var ProductOrdered in request.Products)
                {
                    var product = await _context.Products.FindAsync(ProductOrdered.ProductId);

                    if (product != null && product.Id == ProductOrdered.ProductId)
                    {
                        product.Stock -= ProductOrdered.Quantity;
                        product.Sold += ProductOrdered.Quantity;
                    }
                }

                await _context.SaveChangesAsync();

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