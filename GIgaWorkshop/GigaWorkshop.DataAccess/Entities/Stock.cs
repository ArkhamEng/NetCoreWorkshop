using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigaWorkshop.DataAccess.Entities
{
    public class Stock
    {
        public int Id { get; set; }

        public float Quantity { get; set; }

        public float LastQuantity { get; set; }

        public int ProductId { get; set; }

        public int WarehouseId { get; set; }

        #region Navigation properties
        public Product Product { get; set; }

        public Warehouse Warehouse { get; set; }
        #endregion
    }
}
