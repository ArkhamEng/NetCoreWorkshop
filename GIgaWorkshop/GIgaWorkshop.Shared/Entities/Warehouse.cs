using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GigaWorkshop.Shared.Entities
{
    public class Warehouse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Stock> Stocks { get; set; }
    }
}
