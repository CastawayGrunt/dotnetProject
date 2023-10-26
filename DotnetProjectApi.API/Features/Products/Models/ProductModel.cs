using System.ComponentModel.DataAnnotations;

namespace DotnetProjectApi.API.Features.Products.Models
{
    public class ProductModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Stock { get; set; }
        public int Sold { get; set; }
        public string ImageUrl { get; set; } = "";
    }
}