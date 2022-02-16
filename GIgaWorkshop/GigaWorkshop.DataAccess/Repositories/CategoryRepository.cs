using GigaWorkshop.Shared.Entities;
using GigaWorkshop.Shared.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GigaWorkshop.DataAccess.Repositories
{
    public class CategoryRepository : Repository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(WorkshopDbContext db) : base(db)
        {
        }

        public ICollection<Category> GetAll()
        {
           return this.db.Categories.Include(c=> c.ParentCategory).ToList();
        }
    }
}
