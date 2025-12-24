using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Models
{
    internal class InventoryDetailsCondition
    {
        public string Item_name { get; set; }
        public string Material_code { get; set; }
        public string Material_name { get; set; }
        public string Status { get; set; }
        public string Scan_at { get; set; }
    }
}
