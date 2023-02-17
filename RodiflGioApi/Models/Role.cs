using System.ComponentModel.DataAnnotations;

namespace RodiflGioApi.Models
{
    public class Role
    {
        [Key]
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleCode { get; set; }
    }
}
