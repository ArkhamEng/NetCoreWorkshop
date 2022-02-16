using GigaWorkshop.Shared.Entities;

namespace GigaWorkshop.Shared.Repositories
{
    public interface ICategoryRepository:IRepository<Category,int>
    {
       ICollection<Category> GetAll();
    }
}
