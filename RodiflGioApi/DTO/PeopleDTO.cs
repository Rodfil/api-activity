using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RodiflGioApi.DataAccess;

namespace RodiflGioApi.DTO
{
    public class PeopleDTO
    {

        [Key]
        public Guid PeopleId { get; set; }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public int Age { get; set; }
        [ForeignKey("AddresId")]
        public Guid AddressId { get; set; }
        [ForeignKey("RoleId")]
        public Guid RoleId { get; set; }
    }
}
