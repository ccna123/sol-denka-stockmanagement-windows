using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Database
{
     public class InventoryResult
    {
        public int Inventory_result_id { get; set; } //PK
        public int Inventory_session_id { get; set; } //FK
        public int Inventory_result_type_id { get ; set; } //FK
        public int Ledger_item_id { get; set; } //FK
        public int Tag_id { get; set; } //FK
        public int System_location_id_at_scan { get; set; } //FK
        public int System_is_in_stock_at_scan { get; set; }
        public string Scanned_at {  get; set; }

        // -- Navigation  --
        public LedgerItem LedgerItem { get; set; }
        public Tag Tag { get; set; }
        public InventoryResultType InventoryResultType { get; set; }
        public InventorySession InventorySession { get; set; }
        public Location Location { get; set; }
        public LedgerItemEvent LedgerItemEvent { get; set; }
    }
}
