using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Models
{
    class FileInfoRecord
    {
        public string FileName { get; set; }
        public string UpdateTime { get; set; }
        public string Status { get; set; }
        public bool IsSelected { get; set; }
        public string FilePath { get; set; }
    }
}
