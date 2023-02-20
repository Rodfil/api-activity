using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RodiflGioApi.Business;
using RodiflGioApi.DataAccess;
using RodiflGioApi.DTO;
using RodiflGioApi.Models;

namespace RodiflGioApi.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly ApiDbContext _dbContext;
        private readonly PeopleLogic _peopleLogic;


        public PeopleController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _peopleLogic = new PeopleLogic(_dbContext);
           
        }
        [HttpGet]
        public async Task<ActionResult<List<PeopleDTO>>> GetAlPeople()
        {
            return _peopleLogic.ToPeopleDTO();
        }

        [HttpPost]
        public IActionResult Create([FromBody] PeoplePostDTO data)
        {
            _peopleLogic.InsertData(data);
            return Ok();
        }
    }
}
