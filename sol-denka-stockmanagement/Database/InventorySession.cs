using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Database
{
    public class InventorySession
    {
        public int Inventory_session_id { get; set; } //PK
        public int Location_id { get; set; } //FK
        public string Device_id { get; set; }
        public String Executed_at { get; set; }

        // -- Navigation --
        public List<InventoryResult> InventoryResults { get; set; }
        public Location Location { get; set; }
    }
}
