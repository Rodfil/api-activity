using RodiflGioApi.DataAccess;
using RodiflGioApi.DTO;
using System.ComponentModel.DataAnnotations.Schema;

namespace RodiflGioApi.Business
{
    public class PeopleLogic
    {
        private readonly ApiDbContext _dbcontext;
        public PeopleLogic(ApiDbContext context)
        {
            _dbcontext = context;
        }
        public List<PeopleDTO> ToPeopleDTO()
        {
            var addModels = new List<PeopleDTO>();
            var people = _dbcontext.People.ToList();

            foreach (var item in people)
            {
                var dto  = new PeopleDTO();
                dto.PeopleId = item.PeopleId;
                dto.Name = item.Name;
                dto.PhoneNumber = item.PhoneNumber;
                dto.EmailAddress = item.EmailAddress;
                dto.Age = item.Age;
                dto.AddressId = item.AddressId;
                dto.RoleId = item.RoleId;

                addModels.Add(dto);   
            }
            return addModels;
        }
    }
   /* public void AddPeople(List<PeopleDTO> data)
    {
        var add = new List<PeopleDTO>
        {
            PeopleId = data.PeopleId;
            
        }
    }*/
}
