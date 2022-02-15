using Microsoft.EntityFrameworkCore;

namespace GigaWorkshop.DataAccess.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string SKU { get; set; }

        
        public string Name { get; set; }

        
        public string Description { get; set; }

        
        public decimal Cost { get; set; }

        
        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        #region Navigation properties
        public Category Category { get; set; }

        public ICollection<Stock> Stocks { get; set; }

        public ICollection<Image> Images { get; set; }
        #endregion

    }
}
