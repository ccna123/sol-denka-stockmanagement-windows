using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Database
{
    public class OperationEventType
    {
        public int Operation_event_id {  get; set; } //PK
        public string Event_code { get; set; }
        public string Event_name { get; set;}
        public string Created_at { get; set; }
        public string Updated_at { get; set; }

        public List<LedgerItemEvent> LedgerItemEvents { get; set; } // 個数用
    }
}
