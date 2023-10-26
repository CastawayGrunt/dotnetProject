using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper;
using DotnetProjectApi.API.Data;
using DotnetProjectApi.API.Features.Products.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace DotnetProjectApi.API.Features.Products
{
    public class UpdateProduct
    {
        public record Command : IRequest
        {
            [JsonIgnore]
            [ValidateNever]
            public Guid Id { get; init; }

            [Required]
            public string? Name { get; init; }
            public string? Description { get; init; }
            public decimal? Price { get; init; }
            public int? Stock { get; init; }
            public string? ImageUrl { get; init; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DotnetProjectDbContext _context;
            private readonly IMapper _mapper;

            public Handler(DotnetProjectDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken ct = default)
            {
                var product = await _context.Products.FindAsync(request.Id);

                if (product is null)
                {
                    throw new KeyNotFoundException($"Product with id {request.Id} not found");
                }

                _mapper.Map(request, product);
                await _context.SaveChangesAsync();

                return default;
            }
        }

        public class UpdateMappingProfile : Profile
        {
            public UpdateMappingProfile()
            {
                CreateMap<Command, ProductModel>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.Sold, opt => opt.Ignore());
            }
        }
    }
}