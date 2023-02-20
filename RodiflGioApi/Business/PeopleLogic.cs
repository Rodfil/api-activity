using RodiflGioApi.DataAccess;
using RodiflGioApi.DTO;
using RodiflGioApi.Models;
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

        public void InsertData(PeoplePostDTO data)
        {
            People role = new People
            {
                PeopleId = Guid.NewGuid(),  
                Name = data.Name,
                PhoneNumber = data.PhoneNumber,
                EmailAddress = data.EmailAddress,
                Age = data.Age,
                AddressId = data.AddressId,
                RoleId = data.RoleId,
            };

            _dbcontext.People.Add(role);
            _dbcontext.SaveChanges();

        }

        public void UpdateData(RoleDTO roleDTO)
        {
            var exist = _dbcontext.Role.Find(roleDTO.RoleId);

            if (exist != null)
            {
                exist.RoleName = roleDTO.RoleName;
                exist.RoleCode = roleDTO.RoleCode;

                _dbcontext.SaveChanges();
            }
            else
            {
                throw new Exception("Warehouse not found");
            }
        }
    }
}
