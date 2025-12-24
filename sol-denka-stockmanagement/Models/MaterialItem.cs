using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Models
{
    public class MaterialItem
    {
        public int Ledger_item_id {  get; set; }
        public string Item_Code { get; set; }
        public string Item_Name { get; set; }
        public string Status { get; set; }
        public string Location_name { get; set; }
        public DateTime Updated_at { get; set; }
    }
}
