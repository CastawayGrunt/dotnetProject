using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper;
using DotnetProjectApi.API.Data;
using DotnetProjectApi.API.Features.Products.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace DotnetProjectApi.API.Features.Products
{
    public class AddProduct
    {
        public record Command : IRequest
        {
            [Required]
            public string Name { get; init; } = "";
            public string Description { get; init; } = "";
            [Required]
            public decimal Price { get; init; }
            [Required]
            public int Stock { get; init; }
            [JsonIgnore]
            public int Sold { get; init; }
            public string ImageUrl { get; init; } = "";
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
                var product = new ProductModel
                {
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    Stock = request.Stock,
                    Sold = 0,
                    ImageUrl = request.ImageUrl
                };

                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return default;
            }
        }
    }

    public class AddMappingProfile : Profile
    {
        public AddMappingProfile()
        {
            CreateMap<AddProduct.Command, ProductModel>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock))
                .ForMember(dest => dest.Sold, opt => opt.Ignore())
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.ImageUrl));
        }
    }
}