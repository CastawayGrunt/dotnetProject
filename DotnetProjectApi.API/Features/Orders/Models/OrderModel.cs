using System.ComponentModel.DataAnnotations;

namespace DotnetProjectApi.API.Features.Orders.Models
{
    public class OrderModel
    {
        [Key]
        public Guid Id { get; set; }

        public List<OrderDetailModel> Products { get; set; } = new();
        public AddressModel ShippingAddress { get; set; } = new();
        public DateTime? OrderPlacedDateTime { get; set; }

        public decimal OrderTotal { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public Guid OrderNumber { get; set; }
        // Add when user is implemented
        // public Guid UserId { get; set; }

    }
}