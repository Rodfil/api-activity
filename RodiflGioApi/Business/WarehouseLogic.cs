using RodiflGioApi.DataAccess;
using RodiflGioApi.DTO;
using RodiflGioApi.Models;

namespace RodiflGioApi.Business
{
    public class WarehouseLogic
    {
        private readonly ApiDbContext _dbcontext;
        public WarehouseLogic(ApiDbContext context)
        {
            _dbcontext = context;
        }

        public List<WarehouseDTO> ToWarehouseDTO()
        {
            var addModels = new List<WarehouseDTO>();
            var people = _dbcontext.Warehouse.ToList();

            foreach (var item in people)
            {
                var dto = new WarehouseDTO();
                dto.WarehouseId = item.WarehouseId;
                dto.WarehouseName = item.WarehouseName;
                dto.WarehouseCode = item.WarehouseCode;

                addModels.Add(dto);

            }
            return addModels;
        }

        public void InsertData(Warehouse_PostDTO data)
        {
            Warehouse warehouse = new Warehouse
            {
                WarehouseId = Guid.NewGuid(),
                WarehouseName = data.WarehouseName,
                WarehouseCode = data.WarehouseCode
            };

            _dbcontext.Warehouse.Add(warehouse);
            _dbcontext.SaveChanges();

        }

       
    }
}
