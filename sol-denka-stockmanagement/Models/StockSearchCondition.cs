using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Models
{
    class StockSearchCondition
    {
        public string material_code { get; set; }
        public string material_name { get; set; }
        public string LotNo { get; set; }
        public string Stock_Quantity { get; set; }
        public string total_inventory { get; set; }
        public string unit { get; set;}
    }
}
