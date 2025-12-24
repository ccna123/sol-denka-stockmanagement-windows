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

namespace sol_denka_stockmanagement.Views.Controls.SelectionListControl
{
    /// <summary>
    /// SelectionListControl.xaml の相互作用ロジック
    /// </summary>
    public partial class SelectionListControl : UserControl
    {
        public event EventHandler<string> MenuSelected;

        public SelectionListControl()
        {
            InitializeComponent();
        }

        private void SelectList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SelectList.SelectedItem is ListBoxItem item && item.Tag is string key)
            {
                MenuSelected?.Invoke(this, key);
            }
        }
    }
}
