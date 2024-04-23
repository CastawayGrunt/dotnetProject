namespace DotnetProjectApi.API.Features.Orders.Models
{
  public class OrderViewModel
  {
    public Guid Id { get; set; }
    public List<Guid> Products { get; set; } = new();
    public AddressViewModel ShippingAddress { get; set; } = new();
    public DateTime? OrderPlacedDateTime { get; set; }
    public decimal OrderTotal { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public Guid OrderNumber { get; set; }
    // Add when user is implemented
    // public Guid UserId { get; set; }
  }
}