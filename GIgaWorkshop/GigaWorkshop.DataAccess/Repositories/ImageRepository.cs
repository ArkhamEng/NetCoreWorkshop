using GigaWorkshop.Shared.Entities;
using GigaWorkshop.Shared.Repositories;

namespace GigaWorkshop.DataAccess.Repositories
{
    public class ImageRepository : Repository<Image, int>, IImageRepository
    {
        public ImageRepository(WorkshopDbContext db) : base(db)
        {
        }
    }
}
