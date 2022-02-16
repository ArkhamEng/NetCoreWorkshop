using GigaWorkshop.Shared.Entities;

namespace GigaWorkshop.Shared.Repositories
{
    public interface IProductRepository:IRepository<Product,int>
    {
        ICollection<Product> Find(string filter, int page, int pageSize);
    }
}
