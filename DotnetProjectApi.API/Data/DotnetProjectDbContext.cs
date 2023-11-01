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
        modelBuilder.Entity<ProductModel>().HasData(
            new ProductModel()
            {
                Id = Guid.NewGuid(),
                Name = "Product 1",
                Description = "Product 1 Description",
                Price = 10.00m,
                Stock = 10,
                Sold = 0,
                ImageUrl = "https://via.placeholder.com/150"
            },
            new ProductModel()
            {
                Id = Guid.NewGuid(),
                Name = "Product 2",
                Description = "Product 2 Description",
                Price = 20.00m,
                Stock = 20,
                Sold = 0,
                ImageUrl = "https://via.placeholder.com/150"
            },
            new ProductModel()
            {
                Id = Guid.NewGuid(),
                Name = "Product 3",
                Description = "Product 3 Description",
                Price = 30.00m,
                Stock = 30,
                Sold = 0,
                ImageUrl = "https://via.placeholder.com/150"
            }

        );
        base.OnModelCreating(modelBuilder);
    }
}