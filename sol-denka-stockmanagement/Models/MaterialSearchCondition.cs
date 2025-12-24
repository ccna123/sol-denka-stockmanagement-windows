using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Models
{
    class MaterialSearchCondition
    {
        public string Item_Name { get; set; }
        public string EPC { get; set; }
        public string Storage { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate {  get; set; }
    }
}
