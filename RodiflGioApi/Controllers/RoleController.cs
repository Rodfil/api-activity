using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RodiflGioApi.Business;
using RodiflGioApi.DataAccess;
using RodiflGioApi.DTO;

namespace RodiflGioApi.Controllers
{
    [Route("api/Role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ApiDbContext _dbContext;
        private readonly RoleLogic _roleLogic;

        public RoleController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _roleLogic = new RoleLogic(_dbContext);


        }
        [HttpGet]
        public async Task<ActionResult<List<RoleDTO>>> GetAllRole()
        {
            return _roleLogic.ToRoleDTO();
        }

        [HttpPost]
        public IActionResult Create([FromBody] RolePostDTO data)
        {
            _roleLogic.InsertData(data);
            return Ok();
        }
        [HttpPut("{RoleId}")]
        public IActionResult UpdateData(RoleDTO roleId)
        {
            _roleLogic.UpdateData(roleId);
            return Ok();
        }

        [HttpDelete("{RoleId}")]
        public async Task<ActionResult<List<RoleDTO>>> DeleteRole(Guid RoleId)
        {
            _roleLogic.DeleteData(RoleId);
            return Ok();
        }
    }
}
