using DotnetProjectApi.API.Data;
using DotnetProjectApi.API.Features.Products.Models;
using MediatR;

namespace DotnetProjectApi.API.Features.Products
{
    public class DeleteProduct
    {
        public class Command : IRequest
        {
            public Guid Id { get; init; }
        }

        public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly DotnetProjectDbContext _context;

            public Handler(DotnetProjectDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command command, CancellationToken ct)
            {
                var product = await _context.Products.FindAsync(command.Id) ?? throw new KeyNotFoundException();

                _context.Products.Remove(product);
                await _context.SaveChangesAsync(ct);

                return default;
            }
        }
    }
}