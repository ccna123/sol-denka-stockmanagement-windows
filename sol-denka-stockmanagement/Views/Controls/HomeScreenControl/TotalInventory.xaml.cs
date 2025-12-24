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
    /// TotalInventory.xaml の相互作用ロジック
    /// </summary>
    public partial class TotalInventory : UserControl
    {
        public TotalInventory()
        {
            InitializeComponent();
            LoadTotalInventory();
        }

        private void LoadTotalInventory()
        {
            using (var db = new AppDbContext())
            {
                var total = db.LedgerItems
                    .Where(x => x.Is_in_stock == 1)
                    .Sum(x => x.Quantity);

                TotalInventoryText.Text = total.ToString();
            }
        }

        public void ReloadCsvHistory()
        {
            LoadTotalInventory();
        }

    }
}
