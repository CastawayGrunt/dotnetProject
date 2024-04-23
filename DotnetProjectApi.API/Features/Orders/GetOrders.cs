using AutoMapper;
using DotnetProjectApi.API.Data;
using DotnetProjectApi.API.Features.Orders.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DotnetProjectApi.API.Features.Orders
{
  public static class Get
  {

    public record Query() : IRequest<Response>
    {
    }

    public record Response
    {
      public List<OrderModel> Orders { get; init; } = [];
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
        var orders = await _context.Orders.AsNoTracking()
          .Include(o => o.ShippingAddress)
          .ToListAsync(ct);

        return _mapper.Map<Response>(orders);
      }
    }
  }

  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<List<OrderModel>, Get.Response>()
          .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src));
    }
  }
}