using MaterialDesignThemes.Wpf;
using sol_denka_stockmanagement.Models;
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
    /// StockSearchDialog.xaml の相互作用ロジック
    /// </summary>
    public partial class StockSearchDialog : UserControl
    {
        public StockSearchDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 検索ボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var condition = new StockSearchCondition
            {
                material_code = ItemBox.Text,
                material_name = Item2Box.Text,
                LotNo = Item3Box.Text,

            };

            DialogHost.CloseDialogCommand.Execute(condition, this);
        }
    }
}
