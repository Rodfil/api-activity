using System.ComponentModel.DataAnnotations;

namespace RodiflGioApi.Models
{
    public class Warehouse
    {
        [Key]
        public Guid WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public string WarehouseCode { get; set; }
    }
}
