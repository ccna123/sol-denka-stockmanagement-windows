using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Database
{
    public class Winder
    {
        public int Winder_id { get; set; }
        public string? Winder_name { get; set; }
        public string? Created_at { get; set; }
        public string? Updated_at { get; set; }

        // -- Navigation --
        public List<LedgerItem> LedgerItems { get; set; }
    }
}
