using sol_denka_stockmanagement.Models;
using System;
using System.Collections;
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

namespace sol_denka_stockmanagement.Views.Controls.InventoryResultControl
{
    /// <summary>
    /// InventoryDetails.xaml の相互作用ロジック
    /// </summary>
    public partial class InventoryDetails : UserControl
    {
        private List<InventoryDetailsCondition> ListA;
        private List<InventoryDetailsCondition> ListB;
        private List<InventoryDetailsCondition> ListC;
        private List<InventoryDetailsCondition> ListD;

        public InventoryDetails()
        {
            InitializeComponent();
            ListA = new List<InventoryDetailsCondition>
        {
            new InventoryDetailsCondition { Item_name="25000001", Material_code="A123456", Material_name="A1005", Status="正常一致", Scan_at="2025/11/20 11:38"},
            new InventoryDetailsCondition { Item_name="25000002", Material_code="A123456", Material_name="A1005", Status="正常一致", Scan_at="2025/11/20 11:38"},
            new InventoryDetailsCondition { Item_name="25000003", Material_code="A123456", Material_name="A1005", Status = "正常一致", Scan_at="2025/11/20 11:38" },
        };

            ListB = new List<InventoryDetailsCondition>
        {
            new InventoryDetailsCondition { Item_name="25000001", Material_code="A789012", Material_name="900mm紙管", Status="不足", Scan_at="2025/11/20 11:38"},
            new InventoryDetailsCondition { Item_name="25000002", Material_code="A789012", Material_name="900mm紙管", Status="不足", Scan_at="2025/11/20 11:38"},
        };


            SetButtonColor(BtnList1);
            MainList.ItemsSource = ListA;
        }

        private void List1_Click(object sender, RoutedEventArgs e)
        {
            SetButtonColor(BtnList1);
            MainList.ItemsSource = ListA;
        }
        private void List2_Click(object sender, RoutedEventArgs e)
        {
            SetButtonColor(BtnList2);
            MainList.ItemsSource = ListB;
        }

        private void List3_Click(object sender, RoutedEventArgs e)
        {
            SetButtonColor(BtnList3);
            MainList.ItemsSource = ListC;
        }

        private void List4_Click(object sender, RoutedEventArgs e)
        {
            SetButtonColor(BtnList4);
            MainList.ItemsSource = ListD;
        }
        private async void BackPage_Click(object sender, RoutedEventArgs e)
        {
            var main = Window.GetWindow(this) as MainWindow;
            if (main == null) return;

            // TagDetailsView を表示
            main.InventoryResult.Visibility = Visibility.Visible;

            // 他を隠す
            main.HomeScreenControl.Visibility = Visibility.Collapsed;
            main.MaterialLedgerScreenControl.Visibility = Visibility.Collapsed;
            main.StockListScreenControl.Visibility = Visibility.Collapsed;
            main.CsvImportScreenControl.Visibility = Visibility.Collapsed;
            main.CsvExportScreenControl.Visibility = Visibility.Collapsed;
            main.MasterMagamentScreenControl.Visibility = Visibility.Collapsed;
            main.SettingScreenControl.Visibility = Visibility.Collapsed;
            main.TagDetailsEdit.Visibility = Visibility.Collapsed;
            main.TagDetailsView.Visibility = Visibility.Collapsed;
            main.InventoryDetail.Visibility = Visibility.Collapsed;
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
            if (MainList.View is GridView gridView)
            {
                int columnCount = gridView.Columns.Count;
                if (columnCount == 0) return;

                double totalWidth = MainList.ActualWidth - 5; // 余白分調整
                double columnWidth = totalWidth / columnCount;

                foreach (var column in gridView.Columns)
                {
                    column.Width = columnWidth;
                }
            }
        }

        private void SetButtonColor(System.Windows.Controls.Button selectedButton)
        {
            // すべて白に戻す
            BtnList1.Background = Brushes.White;
            BtnList2.Background = Brushes.White;
            BtnList3.Background = Brushes.White;
            BtnList4.Background = Brushes.White;

            // 選択されたボタンだけ灰色
            selectedButton.Background = Brushes.LightGray;
        }
    }
}
