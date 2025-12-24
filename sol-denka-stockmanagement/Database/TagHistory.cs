using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Database
{
    public class TagHistory
    {
        public int Tag_history_id { get; set; } //PK
        public int Tag_id { get; set; } //FK
        public int? Ledger_item_id { get; set; } //FK(Null許容)
        public int? Tag_event_id { get; set; } //FK
        public string Occured_at { get; set; }

        // -- Navigation --
        public LedgerItem LedgerItem { get; set; }
        public Tag Tag { get; set; }
        public TagEventType TagEventType { get; set; }
    }
}
