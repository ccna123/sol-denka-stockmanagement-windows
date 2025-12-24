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
    /// MaterialType.xaml の相互作用ロジック
    /// </summary>
    public partial class MaterialType : UserControl
    {
        public MaterialType()
        {
            InitializeComponent();
            LoadActiveItemTypeCount();
        }

        private void LoadActiveItemTypeCount()
        {
            using (var db = new AppDbContext())
            {
                int count = db.ItemTypes.Count(x => x.Is_active == 1);

                ActiveItemTypeCountText.Text = count.ToString();
            }
        }

        public void ReloadCsvHistory()
        {
            LoadActiveItemTypeCount();
        }


    }
}
