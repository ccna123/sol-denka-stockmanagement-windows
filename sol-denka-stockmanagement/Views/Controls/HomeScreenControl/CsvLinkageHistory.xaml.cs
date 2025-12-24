using sol_denka_stockmanagement.Database;
using System;
using Microsoft.EntityFrameworkCore;
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
using static MaterialDesignThemes.Wpf.Theme;

namespace sol_denka_stockmanagement.Views.Controls.HomeScreenControl
{
    /// <summary>
    /// CsvLinkageHistory.xaml の相互作用ロジック
    /// </summary>
    public partial class CsvLinkageHistory : UserControl
    {
        public CsvLinkageHistory()
        {
            InitializeComponent();
            LoadLatestCsvHistory();
        }

        private void LoadLatestCsvHistory()
        {
            using (var db = new AppDbContext())
            {
                var list = db.CsvHistories
                    .Include(x => x.CsvTaskType)
                    .OrderByDescending(x => x.Executed_at)   
                    .Take(3)                                  
                    .Select(x => new CsvLinkageItem
                    {
                        DateTime = x.Executed_at,
                        Type = x.CsvTaskType.Csv_task_name,       
                        CsvName = x.File_name,
                        Condition = ConvertResult(x.Result)
                    })
                    .ToList();

                CsvLinkageList.ItemsSource = list;
            }
        }

        private static string ConvertResult(string result)
        {
            return result switch
            {
                "SUCCESS" => "成功",
                "FAILED" => "失敗",
                _ => result
            };
        }


        /// <summary>
        /// リスト表示の横幅調整
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            AdjustColumnWidths();
        }

        private void AdjustColumnWidths()
        {
            if (CsvLinkageList.View is GridView gridView)
            {
                int columnCount = gridView.Columns.Count;
                if (columnCount == 0) return;

                double totalWidth = CsvLinkageList.ActualWidth - 5; // 余白分調整
                double columnWidth = totalWidth / columnCount;

                foreach (var column in gridView.Columns)
                {
                    column.Width = columnWidth;
                }
            }
        }

        private async void move_click(object sender, RoutedEventArgs e)
        {
            var main = Window.GetWindow(this) as MainWindow;
            if (main == null) return;

            // TagDetailsView を表示
            main.CsvImportScreenControl.Visibility = Visibility.Visible;

            // 他を隠す
            main.HomeScreenControl.Visibility = Visibility.Collapsed;
            main.StockListScreenControl.Visibility = Visibility.Collapsed;
            main.CsvExportScreenControl.Visibility = Visibility.Collapsed;
            main.MasterMagamentScreenControl.Visibility = Visibility.Collapsed;
            main.SettingScreenControl.Visibility = Visibility.Collapsed;
            main.TagDetailsEdit.Visibility = Visibility.Collapsed;
            main.MaterialLedgerScreenControl.Visibility = Visibility.Collapsed;
        }

        public void ReloadCsvHistory()
        {
            LoadLatestCsvHistory();
        }

    }

    public class CsvLinkageItem
    {
        public String DateTime { get; set; }
        public string Type { get; set; }
        public string CsvName { get; set; }
        public string Condition { get; set; }
    }
}
