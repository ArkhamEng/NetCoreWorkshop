using GigaWorkshop.Shared.Entities;
using GigaWorkshop.Shared.Repositories;

namespace GigaWorkshop.DataAccess.Repositories
{
    public class StockRepository : Repository<Stock, int>, IStockRepository
    {
        public StockRepository(WorkshopDbContext db) : base(db)
        {
            
        }
    }
}
