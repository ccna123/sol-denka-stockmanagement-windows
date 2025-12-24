using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Database
{
    public class TagStatusType
    {
        public int Tag_status_id {  get; set; }
        public string Status_code { get; set; }
        public string Status_name { get; set; }
        public string Created_at { get; set; }
        public string Updated_at { get; set; }

        // -- Navigation --
        public List<Tag> Tags { get; set; }
    }
}
