using MaterialDesignThemes.Wpf;
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

namespace sol_denka_stockmanagement.Views.Dialogs
{
    /// <summary>
    /// ProgressDialog.xaml の相互作用ロジック
    /// </summary>
    public partial class ProgressDialog : UserControl
    {
        public ProgressDialog()
        {
            InitializeComponent();

            // 画面が描画された後で実行したいため Loaded を使う
            this.Loaded += ProgressDialog_Loaded;
        }

        private async void ProgressDialog_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(5000);

            // 自分自身を指定して閉じる
            DialogHost.CloseDialogCommand.Execute(true, this);
        }
    }
}
