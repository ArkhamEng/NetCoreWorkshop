using GigaWorkshop.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace GigaWorkshop.DataAccess
{
    //WorkshipDbContext is handled as a partial class in order to mantain a clean DbContext file, model configuration and initial data are written here
    public partial  class WorkshopDbContext
    {
        #region Initial Data
        private ICollection<Category> InitialCategories = new List<Category>
        {
            new Category { Id=1, Name = "Category One", IsActive=true},
            new Category { Id=2, Name = "Category Two", IsActive=true},
            new Category {Id=3,  Name = "Category Three", IsActive=true},
            new Category {Id=4,  Name="Category Four", ParentCategoryId=3, IsActive=true }
        };

        private ICollection<Warehouse> InitialWarehouses = new List<Warehouse>
        {
            new Warehouse { Id=1,  Name = "Warehouse North One", IsActive=true},
            new Warehouse { Id=2,  Name = "Warehouse East", IsActive=true},
            new Warehouse { Id=3,  Name = "Warehouse West", IsActive=true}
        };
        #endregion
        
        #region Model creation
        //this method is called when migrations add command is performed
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //defining default schema for all tables
            modelBuilder.HasDefaultSchema("Inventory");

            //mapping table  and properties
            modelBuilder.Entity<Category>(category =>
            {
                category.ToTable(nameof(Category));
                category.HasKey(c => c.Id);

                //recursive optional foreign key
                category.Property(c => c.ParentCategoryId).IsRequired(false);
                category.HasOne(p => p.ParentCategory).WithMany(c => c.Categories).HasForeignKey(c => c.ParentCategoryId).HasConstraintName("FK_Category_Category").OnDelete(DeleteBehavior.NoAction);

                category.Property(c => c.Name).HasColumnType("varchar(30)").IsRequired();
                //Applying Initial Data
                category.HasData(this.InitialCategories);
            });

            modelBuilder.Entity<Product>(product =>
            {
                product.ToTable(nameof(Product));

                product.Property(p => p.Id).ValueGeneratedNever();
                //setting fields data type
                product.Property(p => p.SKU).HasColumnType("varchar(10)").IsRequired();
                product.Property(p => p.Name).HasColumnType("varchar(30)").IsRequired(); ;
                product.Property(p => p.Description).HasColumnType("varchar(150)").IsRequired();
                product.Property(p => p.Cost).HasColumnType("decimal(10,3)").IsRequired();
                product.Property(p => p.Price).HasColumnType("decimal(10,3)").IsRequired();
                //creating foreign key
                product.HasOne(p => p.Category).WithMany(c => c.Products).HasForeignKey(c => c.CategoryId).HasConstraintName("FK_Category_Product");
                //creating composed index
                product.HasIndex(p => new { p.SKU, p.Name, p.Description }).HasDatabaseName("IDX_Name_Description");
            });

            modelBuilder.Entity<Warehouse>(warehouse =>
            {
                warehouse.ToTable(nameof(Warehouse));
                warehouse.HasKey(w => w.Id);
                warehouse.Property(w => w.Name).HasColumnType("varchar(30)");
                //Applying Initial Data
                warehouse.HasData(this.InitialWarehouses);
            });

            modelBuilder.Entity<Stock>(stock =>
            {
                stock.ToTable(nameof(Stock));
                stock.HasKey(s => s.Id);
                stock.HasOne(s => s.Product).WithMany(p => p.Stocks).HasForeignKey(s => s.ProductId).HasForeignKey("FK_Product_Stock");
                stock.HasOne(s => s.Warehouse).WithMany(w => w.Stocks).HasForeignKey(s => s.WarehouseId).HasForeignKey("FK_Product_Warehouse");
            });

            modelBuilder.Entity<Image>(image =>
            {
                image.ToTable(nameof(Image));
                image.HasKey(i => i.Id);
                image.Property(i => i.Name).HasColumnType("varchar(30)");
                image.Property(i => i.Path).HasColumnType("varchar(200)");
                image.HasOne(i => i.Product).WithMany(p => p.Images).HasForeignKey(i => i.ProductId).HasForeignKey("FK_Product_Image");
            });
        }
        #endregion
    }
}
