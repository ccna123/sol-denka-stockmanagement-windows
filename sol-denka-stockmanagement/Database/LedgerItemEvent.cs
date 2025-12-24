using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Database
{
    public class LedgerItemEvent
    {
        public int Event_id {  get; set; }
        public int Ledger_item_id { get; set; }
        public int? Event_type_id { get; set; }
        public int? Process_type_id { get; set; }
        public int Location_id { get; set; }
        public string Occurred_at { get; set; }
        public string Registered_at { get; set; }
        public string? Memo { get; set; }

        // -- Navigation --
        public LedgerItem LedgerItem { get; set; }
        public EventType EventType { get; set; }
        public ProcessType ProcessType { get; set; }
    }
}
