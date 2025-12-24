using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Database
{
    public class Tag
    {
        public int Tag_id { get; set; } // PK
        public int? Ledger_item_id { get; set; } // FK（NULL許容）
        public int Tag_status_id { get; set; } // FK
        public string Epc { get; set; } // UK
        public int Is_active { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }

        // -- Navigation  --
        public LedgerItem LedgerItem { get; set; }
        public TagStatusType TagStatusType { get; set; }
        public List<InventoryResult> InventoryResults { get; set; }
        public List<TagHistory> TagHistories { get; set; }
    }
}