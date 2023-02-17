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
        private readonly PeopleLogic _logic;


        public PeopleController(ApiDbContext dbContext)
        {
            _dbContext = dbContext;
            _logic = new PeopleLogic(_dbContext);
           
        }
        [HttpGet]
        public async Task<ActionResult<List<PeopleDTO>>> GetAlPeople()
        {
            return _logic.ToPeopleDTO();
        }

        /*public PeopleDTO Get_peopleDTO()
        {
            return _peopleDTO;
        }

        [HttpPost]*/
/*        public IActionResult Create([FromBody] PeopleDTO _peopleDTO)
        {
            if(peopleDTO == null)
            {
                return BadRequest();
            }
            var newData = new PeopleDTO
            {
                Name = peopleDTO.Name,
                PhoneNumber = peopleDTO.PhoneNumber,
                EmailAddress = peopleDTO.EmailAddress,
                Age = peopleDTO.Age,
            };
            _peopleDTO.PeopleDTO.Add(newData);
            _peopleDTO.peopleDTO.SaveChanges();

            return Ok();
        }*/
    
    }
}
