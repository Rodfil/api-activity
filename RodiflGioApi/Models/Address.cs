using System.ComponentModel.DataAnnotations;

namespace RodiflGioApi.Models
{
    public class Address
    {
        [Key]
        public Guid AddressId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
