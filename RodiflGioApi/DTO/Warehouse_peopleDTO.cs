using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RodiflGioApi.DTO
{
    public class Warehouse_peopleDTO
    {
        [Key]
        public Guid Warehouse_People_ID { get; set; }
      /*  [ForeignKey("PeopleId")]
        public Guid People_ID { get; set; }*/
        [ForeignKey("WarehouseId")]
        public Guid WarehouseId { get; set; }
    }
}
