using GigaWorkshop.DataAccess.Repositories;
using GigaWorkshop.Shared;
using GigaWorkshop.Shared.Repositories;

namespace GigaWorkshop.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Repositories
        public ICategoryRepository Categories { get; private set; }

        public IProductRepository Products { get; private set; }

        public IWarehouseRepository Warehouses { get; private set; }

        public IImageRepository Images { get; private set; }

        public IStockRepository Stocks { get; private set; }
        #endregion

        private readonly WorkshopDbContext db;

        public UnitOfWork(WorkshopDbContext db)
        {
            this.db = db;
            this.Initialize(db);
        }

        public void Save()
        {
            this.Save();
        }

        private void Initialize(WorkshopDbContext db)
        {
            this.Categories = new CategoryRepository(db);
            this.Stocks = new StockRepository(db);
            this.Products = new ProductRepository(db);
            this.Warehouses = new WarehouseRepository(db);
            this.Images = new ImageRepository(db);
        }
    }
}
