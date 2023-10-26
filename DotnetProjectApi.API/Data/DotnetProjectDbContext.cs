using Microsoft.EntityFrameworkCore;
using DotnetProjectApi.API.Features.Products.Models;

namespace DotnetProjectApi.API.Data;

public class DotnetProjectDbContext : DbContext
{
    public DbSet<ProductModel> Products { get; set; } = null!;

    public DotnetProjectDbContext(DbContextOptions<DotnetProjectDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductModel>();
        base.OnModelCreating(modelBuilder);
    }
}