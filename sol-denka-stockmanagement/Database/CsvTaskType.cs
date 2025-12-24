
namespace sol_denka_stockmanagement.Database
{
    public class CsvTaskType
    {
        public int Csv_task_type_id {  get; set; }
        public string Csv_task_code { get; set; }
        public string Csv_task_name { get; set; }
        public string? Created_at { get; set;}
        public string? Updated_at { get; set;}

        // -- Navigation --
        public List<CsvHistory> CsvHistory { get; set; }
    }
}
