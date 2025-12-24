using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Models
{
    class InventoryItem
    {
        public string Location_name { get; set; }
        public string Item_number { get; set; }
        public string RegistrationItem { get; set; }
        public string Scan { get; set; }
        public string difference { get; set; }
        public string Status { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
