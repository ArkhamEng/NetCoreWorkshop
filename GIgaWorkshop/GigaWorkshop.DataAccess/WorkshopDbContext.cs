using GigaWorkshop.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace GigaWorkshop.DataAccess
{
    public partial class  WorkshopDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Warehouse> Warehouses { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<Image> Images { get; set; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //place here your connection string
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Workshop;Trusted_Connection=True;"); 
        }

    }
}
