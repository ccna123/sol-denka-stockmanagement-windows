using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Database
{
    public class FieldMaster
    {
        public int Field_id { get; set; }
        public string Field_name { get; set; }
        public string Field_code { get; set; }
        public string Data_type { get; set; }
        public string Control_type { get; set; }
        public int Is_active { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }

        // -- Navigation --
        public List<ItemTypeFieldSetting> ItemTypeFieldSettings { get; set; }
    }
}
