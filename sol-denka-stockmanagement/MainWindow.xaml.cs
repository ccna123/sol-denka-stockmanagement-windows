using MaterialDesignThemes.Wpf;
using sol_denka_stockmanagement.Views.Controls.MaterialLedgerScreenControl;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sol_denka_stockmanagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SelectionListControl.MenuSelected += OnMenuSelected;
        }

        private void OnMenuSelected(object sender, string selectedMenu)
        {
            HomeScreenControl.Visibility = Visibility.Collapsed;
            MaterialLedgerScreenControl.Visibility = Visibility.Collapsed;
            StockListScreenControl.Visibility = Visibility.Collapsed;
            CsvImportScreenControl.Visibility = Visibility.Collapsed;
            CsvExportScreenControl.Visibility = Visibility.Collapsed;
            MasterMagamentScreenControl.Visibility = Visibility.Collapsed;
            SettingScreenControl.Visibility = Visibility.Collapsed;
            TagDetailsView.Visibility = Visibility.Collapsed;
            TagDetailsEdit.Visibility = Visibility.Collapsed;
            InventoryResult.Visibility = Visibility.Collapsed;
            UsbCooperation.Visibility = Visibility.Collapsed;
            InventoryDetail.Visibility = Visibility.Collapsed;
            NewRegistration.Visibility = Visibility.Collapsed;
            EditRegistration.Visibility = Visibility.Collapsed;

            switch (selectedMenu)
            {
                case "Home":
                    HomeScreenControl.Visibility = Visibility.Visible;
                    break;

                case "資材台帳":
                    MaterialLedgerScreenControl.Visibility = Visibility.Visible;
                    break;

                case "在庫一覧":
                    StockListScreenControl.Visibility = Visibility.Visible;
                    break;

                case "棚卸結果":
                    InventoryResult.Visibility = Visibility.Visible;
                    break;

                case "CSV取込":
                    CsvImportScreenControl.Visibility = Visibility.Visible;
                    break;

                case "CSV出力":
                    CsvExportScreenControl.Visibility = Visibility.Visible;
                    break;

                case "USB連携":
                    UsbCooperation.Visibility = Visibility.Visible;
                    break;

                case "マスタ管理":
                    MasterMagamentScreenControl.Visibility = Visibility.Visible;
                    break;

                case "設定":
                    SettingScreenControl.Visibility = Visibility.Visible;
                    break;

                default:
                    HomeScreenControl.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}