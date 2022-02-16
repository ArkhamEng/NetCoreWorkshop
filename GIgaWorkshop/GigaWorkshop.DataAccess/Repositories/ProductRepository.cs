using GigaWorkshop.Shared.Entities;
using GigaWorkshop.Shared.Repositories;

namespace GigaWorkshop.DataAccess.Repositories
{
    public class ProductRepository : Repository<Product, int>,IProductRepository
    {
        public ProductRepository(WorkshopDbContext db) : base(db)
        {
        }

        public ICollection<Product> Find(string filter, int page, int pageSize)
        {
           var result = this.db.Products.Where(p => string.IsNullOrEmpty(filter) || 
                                    (p.Name.Contains(filter) || p.Description.Contains(filter))).Take(pageSize).Skip(page * pageSize);

            return result.ToList();
        }
    }
}
