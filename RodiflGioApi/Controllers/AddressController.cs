using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RodiflGioApi.Business;
using RodiflGioApi.DataAccess;
using RodiflGioApi.DTO;

namespace RodiflGioApi.Controllers
{
    [Route("api/Address")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ApiDbContext _dbContext;
        private readonly AddressLogic _addressLogic;

        public AddressController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _addressLogic = new AddressLogic(_dbContext);


        }
        [HttpGet]
        public async Task<ActionResult<List<AddressDTO>>> GetAllAddress()
        {
            return _addressLogic.ToAddressDTO();
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddressPostDTO data)
        {
            _addressLogic.InsertData(data);
            return Ok();
        }

        [HttpPut("{AddressId}")]
        public IActionResult UpdateData(AddressDTO addressId)
        {
            _addressLogic.UpdateData(addressId);
            return Ok();
        }

        [HttpDelete("{AddressId}")]
        public async Task<ActionResult<List<AddressDTO>>> DeleteAddress(Guid AddressId)
        {
            _addressLogic.DeleteData(AddressId);
            return Ok();
        }
    }
}
