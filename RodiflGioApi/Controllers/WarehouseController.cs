using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RodiflGioApi.Business;
using RodiflGioApi.DataAccess;
using RodiflGioApi.DTO;

namespace RodiflGioApi.Controllers
{
    [Route("api/Warehouse")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly ApiDbContext _dbContext;
        private readonly WarehouseLogic _warehouseLogic;

        public WarehouseController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _warehouseLogic = new WarehouseLogic(_dbContext);


        }
        [HttpGet]
        public async Task<ActionResult<List<WarehouseDTO>>> GetAlPeople()
        {
            return _warehouseLogic.ToWarehouseDTO();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Warehouse_PostDTO data)
        {
            _warehouseLogic.InsertData(data);
            return Ok();
        }

        [HttpPut("{WarehouseId}")]
        public IActionResult UpdateData(WarehouseDTO WarehouseId)
        {
            _warehouseLogic.UpdateData(WarehouseId);
            return Ok();
        }

        [HttpDelete("{WarehouseId}")]
        public IActionResult DeleteData(Guid WarehouseId)
        {
            _warehouseLogic.DeleteData(WarehouseId);
            return Ok();
        }
    }
}
