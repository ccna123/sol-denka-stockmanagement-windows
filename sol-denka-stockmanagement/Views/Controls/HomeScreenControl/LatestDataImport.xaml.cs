using sol_denka_stockmanagement.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sol_denka_stockmanagement.Views.Controls.HomeScreenControl
{
    /// <summary>
    /// LatestDataImport.xaml の相互作用ロジック
    /// </summary>
    public partial class LatestDataImport : UserControl
    {
        public LatestDataImport()
        {
            InitializeComponent();
            LoadLatestCsvHistory();
        }

        private void LoadLatestCsvHistory()
        {
            using (var db = new AppDbContext())
            {
                var latest = db.CsvHistories
                    .OrderByDescending(x => x.Executed_at)
                    .Select(x => x.Executed_at)
                    .FirstOrDefault();

                if (latest != null)
                {
                    LatestImportDateText.Text = DateTime.Parse(latest).ToString("yyyy/MM/dd HH:mm:ss");



                }
                else
                {
                    LatestImportDateText.Text = "―";
                }
            }
        }

        public void ReloadCsvHistory()
        {
            LoadLatestCsvHistory();
        }


    }
}
