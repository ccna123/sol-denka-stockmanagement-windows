using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Database
{
    public class ProcessType
    {
        public int? Process_type_id { get; set; }
        public string Process_code { get; set; }
        public string Process_name { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }

        // -- Navigation --
        public List<LedgerItemEvent> LedgerItemEvent { get; set; }
    }
}
