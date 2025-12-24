using MaterialDesignThemes.Wpf;
using sol_denka_stockmanagement.Models;
using sol_denka_stockmanagement.Views.Dialogs;
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

namespace sol_denka_stockmanagement.Views.Controls.MaterialLedgerScreenControl
{
    /// <summary>
    /// TagDetails_Edit.xaml の相互作用ロジック
    /// </summary>
    public partial class TagDetails_Edit : UserControl
    {
        //private List<TagHistory> _allItems;   // 元データ
        public TagDetails_Edit()
        {
            InitializeComponent();

/*            _allItems = new List<TagHistory>
        {
            new TagHistory { occurred_at="2025/10/25 09:15", ledger_item_id="入庫",location ="保管場所A", tag_action_id = "入庫" },
            new TagHistory { occurred_at="2025/10/28 19:30", ledger_item_id="編集", tag_action_id="ステータス変更" },
            new TagHistory { occurred_at="2025/10/31 13:54", ledger_item_id="保管場所変更",location ="保管場所B"},
            new TagHistory { occurred_at="2025/10/31 13:54", ledger_item_id="出庫", tag_action_id="出庫" },
        };
            listView.ItemsSource = _allItems;*/

        }

        private async void BackPage_Click(object sender, RoutedEventArgs e)
        {
            var main = Window.GetWindow(this) as MainWindow;
            if (main == null) return;

            // TagDetailsView を表示
            main.TagDetailsView.Visibility = Visibility.Visible;

            // 他を隠す
            main.HomeScreenControl.Visibility = Visibility.Collapsed;
            main.MaterialLedgerScreenControl.Visibility = Visibility.Collapsed;
            main.StockListScreenControl.Visibility = Visibility.Collapsed;
            main.CsvImportScreenControl.Visibility = Visibility.Collapsed;
            main.CsvExportScreenControl.Visibility = Visibility.Collapsed;
            main.MasterMagamentScreenControl.Visibility = Visibility.Collapsed;
            main.SettingScreenControl.Visibility = Visibility.Collapsed;
            main.TagDetailsEdit.Visibility = Visibility.Collapsed;
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
            if (listView.View is GridView gridView)
            {
                int columnCount = gridView.Columns.Count;
                if (columnCount == 0) return;

                double totalWidth = listView.ActualWidth - 5; // 余白分調整
                double columnWidth = totalWidth / columnCount;

                foreach (var column in gridView.Columns)
                {
                    column.Width = columnWidth;
                }
            }
        }

        private void Check_button(object sender, RoutedEventArgs e)
        {
            Dispatcher.InvokeAsync(async () =>
            {
                var result = await DialogHost.Show(new CompletionDialog()) ?? "";
            });
        }
    }

}
