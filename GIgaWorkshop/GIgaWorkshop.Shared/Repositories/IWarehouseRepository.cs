using GigaWorkshop.Shared.Entities;

namespace GigaWorkshop.Shared.Repositories
{
    public interface IWarehouseRepository:IRepository<Warehouse,int>
    {
        ICollection<Warehouse> GetAll();
    }
}
