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
        private readonly WarehouseLogic _logic;

        public WarehouseController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _logic = new WarehouseLogic(_dbContext);


        }
        [HttpGet]
        public async Task<ActionResult<List<WarehouseDTO>>> GetAlPeople()
        {
            return _logic.ToWarehouseDTO();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Warehouse_PostDTO data)
        {
            if (data == null)
            {
                return BadRequest();
            }

            _logic.InsertData(data);

            return Ok();
        }

        [HttpPut("{WarehouseId}")]

        public async Task<ActionResult> UpdateData(Guid WarehouseId, [FromBody] WarehouseDTO updateData)
        {
            var exist = await _dbContext.Warehouse.FindAsync(WarehouseId);

            if (exist == null)
            {
                return BadRequest();
            }

            exist.WarehouseName = updateData.WarehouseName;
            exist.WarehouseCode = updateData.WarehouseCode;

            await _dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<WarehouseDTO>>> DeleteAddress(Guid id)  
        {
            var warehouse = _dbContext.Warehouse.FirstOrDefault(a => a.WarehouseId == id);

            if (warehouse == null)
            {
                return NotFound();
            }

            var warehousePeopleToDelete = _dbContext.Warehouse_People.Where(a => a.WarehouseId == id).ToList();

            foreach (var people in warehousePeopleToDelete)
            {
                _dbContext.Warehouse_People.Remove(people); 
            }

            _dbContext.Warehouse.Remove(warehouse);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }
}
