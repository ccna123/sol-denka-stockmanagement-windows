using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Database
{
    public class ItemUnit
    {
        public int Item_unit_id { get; set; }
        public int Unit_category {  get; set; }
        public string Item_unit_code { get; set; }
        public string item_unit_name { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }

        // -- Navigation --
        public List<ItemType> CountItemTypes { get; set; } // 個数用
        public List<ItemType> WeightItemTypes { get; set; } // 重量用
        public string? Keyword { get; set; }
    }
}
