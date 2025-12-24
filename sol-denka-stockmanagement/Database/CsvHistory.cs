using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Database
{
    public class CsvHistory
    {
        public int Csv_history_id {  get; set; }
        public int Csv_task_type_id { get; set; }
        public string File_name { get; set; }
        public string Direction { get; set; }
        public string Target { get; set; }
        public string Result { get; set; }
        public int Recode_num { get; set; }
        public string Error_message { get; set; }
        public string Device_id { get; set; }
        public string Executed_at { get; set; }

        // -- Navigation --
        public CsvTaskType CsvTaskType { get; set; }
    }
}
