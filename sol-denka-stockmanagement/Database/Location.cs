using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Database
{
    public class Location
    {
        public int Location_id {  get; set; } //PK
        public string? Location_code { get; set; }
        public string Location_name { get; set; }
        public string? Memo { get; set; }
        public int Is_active { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }

        // -- Navigation --
        public List<InventorySession> InventorySessions { get; set; }
        public List<InventoryResult> InventoryResults { get; set; }
        public List<LedgerItem> LedgerItems { get; set; }
        public List<Stock> Stocks { get; set; }
    }
}
