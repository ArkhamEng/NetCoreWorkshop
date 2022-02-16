using GigaWorkshop.Shared.Entities;
using GigaWorkshop.Shared.Repositories;

namespace GigaWorkshop.DataAccess.Repositories
{
    public class WarehouseRepository : Repository<Warehouse, int>, IWarehouseRepository
    {
        public WarehouseRepository(WorkshopDbContext db) : base(db)
        {
        }

        public ICollection<Warehouse> GetAll()
        {
            return this.db.Warehouses.ToList();
        }
    }
}
