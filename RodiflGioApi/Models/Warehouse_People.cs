using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RodiflGioApi.Models
{
    public class Warehouse_People
    {
        [Key]
        public Guid Warehouse_People_ID { get; set; }
        /*[ForeignKey("PeopleId")]
        public Guid People_ID { get; set; }*/
        [ForeignKey("WarehouseId")]
        public Guid WarehouseId { get; set; }
    }
}
