using System.ComponentModel.DataAnnotations;

namespace RodiflGioApi.DTO
{
    public class RoleDTO
    {
        [Key]
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleCode { get; set; }
    }
}
