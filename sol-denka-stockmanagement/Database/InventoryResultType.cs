using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xaml.Schema;

namespace sol_denka_stockmanagement.Database
{
    public class InventoryResultType
    {
        public int Inventory_result_type_id {  get; set; } //PK
        public string Inventory_result_code { get; set; } 
        public string Inventory_result_name { get; set; }
        public int Is_active {  get; set; }
        public string Created_at {  get; set; }
        public string Updated_at { get; set; } 

        // -- Navigation --
        public List<InventoryResult> InventoryResults { get; set; }
    }
}
