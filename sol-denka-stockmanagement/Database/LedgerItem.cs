using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Database
{
    public class LedgerItem
    {
        public int Ledger_item_id { get; set; } // PK
        public int Item_type_id { get; set; } // FK
        public int Location_id { get; set; } // FK
        public int Winder_id { get; set; } //FK 追加
        public int Is_in_stock { get; set; }
        public int? Weight { get; set; }
        public int? Width { get; set; }
        public int? Length { get; set; }
        public int? Thickness { get; set; }
        public string? Lot_no { get; set; } //追加
        public string? Occurrence_reason { get; set; } //追加
        public int? Quantity { get; set; }
        public string? Memo { get; set; } //追加
        public int Is_active { get; set; }
        public string? Occurred_at { get; set; } //追加
        public string? Processed_at { get; set; } //追加
        public string? Registered_at { get; set; } //追加
        public string? Updated_at { get; set; }

        // -- Navigation  --
        public Location Location { get; set; }
        public ItemType ItemType { get; set; }
        public Winder Winder { get; set; }
        public List<Tag> Tags { get; set; }
        public List<InventoryResult> InventoryResults { get; set; }
        public List<TagHistory> TagHistories { get; set; }
        public List<LedgerItemEvent> LedgerItemEvent { get; set; }
    }
}
