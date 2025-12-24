using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace sol_denka_stockmanagement.Views.Dialogs
{
    /// <summary>
    /// CompletionDialog.xaml の相互作用ロジック
    /// </summary>
    public partial class CompletionDialog : UserControl
    {
        public CompletionDialog()
        {
            InitializeComponent();
        }

        private async void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            var main = Window.GetWindow(this) as MainWindow;
            if (main == null) return;

            // TagDetailsView を表示
            main.HomeScreenControl.Visibility = Visibility.Visible;

            // 他を隠す
            main.StockListScreenControl.Visibility = Visibility.Collapsed;
            main.CsvExportScreenControl.Visibility = Visibility.Collapsed;
            main.MasterMagamentScreenControl.Visibility = Visibility.Collapsed;
            main.SettingScreenControl.Visibility = Visibility.Collapsed;
            main.TagDetailsEdit.Visibility = Visibility.Collapsed;
            main.MaterialLedgerScreenControl.Visibility = Visibility.Collapsed;
            main.EditRegistration.Visibility = Visibility.Collapsed;
            main.NewRegistration.Visibility = Visibility.Collapsed;

            DialogHost.CloseDialogCommand.Execute(true, this);
        }
    }
}
