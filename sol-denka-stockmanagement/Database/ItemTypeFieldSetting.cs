using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Database
{
    public class ItemTypeFieldSetting
    {
        public int Item_type_id { get; set; } //PK
        public int Field_id { get; set; } //PK
        public int Is_required { get; set; }
        public int Is_visible { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }

        // -- Navigation --
        public ItemType ItemType { get; set; }
        public FieldMaster FieldMaster { get; set; }
    }
}
