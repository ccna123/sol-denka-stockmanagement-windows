using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Models
{
    class CsvInputItem
    {
        public string ImportDate_at { get; set; }
        public string Task_type { get; set; }
        public string File_name { get; set; }
        public string Status { get; set; }
        public string Records { get; set; }

    }
}
