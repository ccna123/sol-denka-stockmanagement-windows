using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Database
{
    public class ItemCategory
    {
        public int? Item_category_id { get; set; }
        public string Item_category_name { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }

        // -- Navigation --
        public List<ItemType> ItemTypes { get; set; }
        public string? Keyword { get; set; }
    }
}
