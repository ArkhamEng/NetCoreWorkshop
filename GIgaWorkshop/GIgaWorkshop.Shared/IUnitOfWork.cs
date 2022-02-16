using GigaWorkshop.Shared.Repositories;

namespace GigaWorkshop.Shared
{
    public interface IUnitOfWork
    {
         ICategoryRepository Categories { get;  }

         IProductRepository Products { get; }

         IWarehouseRepository Warehouses { get;  }

         IImageRepository Images { get; }

         IStockRepository Stocks { get;  }
        void Save();
    }
}
