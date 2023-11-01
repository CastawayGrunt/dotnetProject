using System.ComponentModel.DataAnnotations;

namespace DotnetProjectApi.API.Features.Orders.Models
{
    public class AddressModel
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Street { get; set; } = "";
        public string City { get; set; } = "";
        public string Province { get; set; } = "";
        public string Country { get; set; } = "";
        public string PostalCode { get; set; } = "";
    }
}