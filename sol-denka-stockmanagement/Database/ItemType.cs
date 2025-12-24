using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Database
{
    public class ItemType
    {
        public int Item_type_id { get; set; } // PK
        public string? Item_type_code { get; set; } //UK
        public string Item_type_name { get; set; }

        public int? Item_count_unit_id { get; set; } // FK
        public int? Item_weight_unit_id { get; set; } // FK

        public int Item_category_id { get; set; } //FK
        public string? Specific_gravity { get; set; } 
        public string? Grade { get; set; }
        public string? Packing_type { get; set; }
        public int Is_active { get; set; }
        public string Created_at {  get; set; }
        public string Updated_at { get; set; }

        // -- Navigation --
        [ForeignKey("Item_count_unit_id")]
        public ItemUnit? Item_count_unit { get; set; }
        [ForeignKey("Item_weight_unit_id")]
        public ItemUnit? Item_weight_unit { get; set; }

        public ItemCategory ItemCategory { get; set; }
        public List<Stock> Stocks { get; set; }
        public List<LedgerItem> LedgerItems { get; set; }
        public List<ItemTypeFieldSetting> ItemTypeFieldSettings { get; set; }
    }
}