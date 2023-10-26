using AutoMapper;
using DotnetProjectApi.API.Data;
using DotnetProjectApi.API.Features.Products.Models;
using DotnetProjectApi.API.Features.Products.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DotnetProjectApi.API.Features.Products
{
    public static class Get
    {

        public record Query() : IRequest<Response>
        {
        }

        public record Response
        {
            public List<ProductModel> Products { get; init; } = new();
        }

        public class Handler : IRequestHandler<Query, Response>
        {
            private readonly DotnetProjectDbContext _context;
            private readonly IMapper _mapper;

            public Handler(DotnetProjectDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Response> Handle(Query request, CancellationToken ct = default)
            {
                var products = await _context.Products.AsNoTracking()
                    .ToListAsync(ct);

                return _mapper.Map<Response>(products);
            }
        }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<List<ProductModel>, Get.Response>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src));
        }
    }
}