namespace DotnetProjectApi.API.Features.Products.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Sold { get; set; }
        public string ImageUrl { get; set; } = "";
    }
}