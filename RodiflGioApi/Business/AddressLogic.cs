using Microsoft.EntityFrameworkCore;
using RodiflGioApi.DataAccess;
using RodiflGioApi.DTO;
using RodiflGioApi.Models;

namespace RodiflGioApi.Business
{
    public class AddressLogic
    {
        private readonly ApiDbContext _dbcontext;
        public AddressLogic(ApiDbContext context)
        {
            _dbcontext = context;
        }

        public List<AddressDTO> ToAddressDTO()
        {
            var addModels = new List<AddressDTO>();
            var address = _dbcontext.Address.ToList();

            foreach (var item in address)
            {
                var dto = new AddressDTO();
                dto.AddressId = item.AddressId;
                dto.PostalCode = item.PostalCode;
                dto.Street = item.Street;
                dto.City = item.City;
                dto.State = item.State;
                dto.Country = item.Country;

                addModels.Add(dto);

            }
            return addModels;
        }

        public void InsertData(AddressPostDTO data)
        {
            Address address = new Address
            {
                AddressId = Guid.NewGuid(),
                City = data.City,
                Country= data.Country,
                State = data.State,
                PostalCode = data.PostalCode,
                Street = data.Street,
            };

            _dbcontext.Address.Add(address);
            _dbcontext.SaveChanges();

        }

        public void UpdateData(AddressDTO addressDTO)
        {
            var exist = _dbcontext.Address.Find(addressDTO.AddressId);

            if (exist != null)
            {
                exist.Street = addressDTO.Street;
                exist.City = addressDTO.City;
                exist.Country = addressDTO.Country;
                exist.State = addressDTO.State;
                exist.PostalCode = addressDTO.PostalCode;


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
                var address = _dbcontext.Address.FirstOrDefault(a => a.AddressId == id);

          
                var peopleAddressToDelete = _dbcontext.People.Where(a => a.AddressId == id).ToList();

                foreach (var person in peopleAddressToDelete)
                {
                    person.AddressId = new Guid("00000000-0000-0000-0000-000000000000");
                }
                _dbcontext.SaveChanges();

                _dbcontext.Address.Remove(address);
                _dbcontext.SaveChanges();
               
            }
            catch
            {
                throw new Exception("Error deleting warehouse");
            }

        }
    }
}
