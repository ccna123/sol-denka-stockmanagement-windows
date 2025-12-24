using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Models
{
    public  class ItemMaster
    {
        public string ItemName { get; set; }
        public string ItemCode { get; set; }
        public string Category { get; set; }
        public string Unit { get; set; }
        public string Grade { get; set; }
        public double Ratio { get; set; }
        public string Packing { get; set; }
        public string Remarks { get; set; }
    }
}
