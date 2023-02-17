using System.ComponentModel.DataAnnotations;

namespace RodiflGioApi.DTO
{
    public class WarehouseDTO
    {
        [Key]
        public Guid WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public string WarehouseCode { get; set; }
    }

    public class Warehouse_PostDTO
    {
        public string WarehouseName { get; set; }
        public string WarehouseCode { get; set; }
    }
}
