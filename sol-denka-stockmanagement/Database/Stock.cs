using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Database
{
    public class Stock
    {
        public int Stock_id { get; set; } //PK
        public int Item_type_id { get; set; } //FK
        public int Location_id { get; set; } //FK
        public int Quantity { get; set; }
        public int Total_quantity { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }

        // -- Navigation --
        public Location Location { get; set; }
        public ItemType ItemType { get; set; }
    }
}
