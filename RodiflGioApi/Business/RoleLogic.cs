using RodiflGioApi.DataAccess;
using RodiflGioApi.DTO;
using RodiflGioApi.Models;

namespace RodiflGioApi.Business
{
    public class RoleLogic
    {
        private readonly ApiDbContext _dbcontext;
        public RoleLogic(ApiDbContext context)
        {
            _dbcontext = context;
        }

        public List<RoleDTO> ToRoleDTO()
        {
            var addModels = new List<RoleDTO>();
            var role = _dbcontext.Role.ToList();

            foreach (var item in role)
            {
                var dto = new RoleDTO();
                dto.RoleId = item.RoleId; 
                dto.RoleName = item.RoleName;
                dto.RoleCode = item.RoleCode;

                addModels.Add(dto);

            }
            return addModels;
        }

        public void InsertData(RolePostDTO data)
        {
            Role role = new Role
            {
                RoleId = Guid.NewGuid(),
                RoleName = data.RoleName,
                RoleCode = data.RoleCode
                
            };

            _dbcontext.Role.Add(role);
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

        public void DeleteData(Guid id)
        {
            try
            {
                var role = _dbcontext.Role.FirstOrDefault(a => a.RoleId == id);


                var roleDelete = _dbcontext.People.Where(a => a.RoleId == id).ToList();

                foreach (var person in roleDelete)
                {
                    person.RoleId = new Guid("00000000-0000-0000-0000-000000000000");
                }
                _dbcontext.SaveChanges();
                _dbcontext.Role.Remove(role);
                _dbcontext.SaveChanges();

            }
            catch
            {
                throw new Exception("Error deleting warehouse");
            }

        }
    }
}
