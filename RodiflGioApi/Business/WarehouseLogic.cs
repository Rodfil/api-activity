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

        public void UpdateData(WarehouseDTO warehouseDTO)
        {
            var exist = _dbcontext.Warehouse.Find(warehouseDTO.WarehouseId);

            if (exist != null)
            {
                exist.WarehouseName = warehouseDTO.WarehouseName;
                exist.WarehouseCode = warehouseDTO.WarehouseCode;

                _dbcontext.SaveChanges();
            }
            else
            {
                throw new Exception("Warehouse not found");
            }
        }

        public void DeleteData(Guid WarehouseId)
        {
            try
            {
                var existWarehouse = _dbcontext.Warehouse.FirstOrDefault(w => w.WarehouseId == WarehouseId);

                if (existWarehouse == null)
                {
                    throw new Exception("Not Found");
                }
                /* var warehousePeople = _dbcontext.WarehousePeople.Where(wp => wp.WarehouseId == WarehouseId);


                 foreach (var wp in warehousePeople)
                 {
                     wp.WarehouseId = new Guid("00000000-0000-0000-0000-000000000000");
                 }*/

                _dbcontext.Remove(existWarehouse);
                _dbcontext.SaveChanges();

            }
            catch
            {
                throw new Exception("Error deleting warehouse");
            }

        }
    }
}
