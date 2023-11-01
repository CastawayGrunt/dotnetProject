using System.ComponentModel.DataAnnotations;

namespace DotnetProjectApi.API.Features.Orders
{
    public class OrderDetailModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }
    }
}