using MaterialDesignThemes.Wpf;
using sol_denka_stockmanagement.Models;
using sol_denka_stockmanagement.Views.Controls.MaterialLedgerScreenControl;
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

namespace sol_denka_stockmanagement.Views.Controls.InventoryResultControl
{
    /// <summary>
    /// InventoryResultControl.xaml の相互作用ロジック
    /// </summary>
    public partial class InventoryResultControl : UserControl
    {
        private List<InventoryItem> _allItems;   // 元データ
        private int _pageSize = 10;
        private int _currentPage = 1;
        private int _totalPages;

        public InventoryResultControl()
        {
            InitializeComponent();

            _allItems = new List<InventoryItem>
        {
new InventoryItem { Location_name="保管場所A", Item_number="4", RegistrationItem="40", Scan="38", difference="-2", Status="未確認", Updated_at = new DateTime(2025, 10, 31, 11, 38, 00) },
new InventoryItem { Location_name="保管場所B", Item_number="6", RegistrationItem="67", Scan="62", difference="-5", Status="未確認", Updated_at = new DateTime(2025, 10, 31, 11, 38, 00) },
new InventoryItem { Location_name="保管場所C", Item_number="10", RegistrationItem="90", Scan="89", difference="-1", Status="確認済み", Updated_at = new DateTime(2025, 10, 30, 12, 0,00) }

        };

            _totalPages = (int)Math.Ceiling(_allItems.Count / (double)_pageSize);
            Style btnStyle = (Style)FindResource("ButtonStyle");
            SearchButton.Style = btnStyle;

            UpdateList();
            CreatePageButtons();
        }

        //ページ変更
        private void CreatePageButtons()
        {
            pagePanel.Children.Clear();

            Style btnStyle = (Style)FindResource("PagingButtonStyle");
            // ＜ ボタン
            Button prevBtn = new Button { Content = "<<", Style = btnStyle };
            prevBtn.Click += (s, e) =>
            {
                if (_currentPage > 1)
                {
                    _currentPage--;
                    UpdateList();
                    CreatePageButtons();
                }
            };
            pagePanel.Children.Add(prevBtn);


            int start, end;

            if (_totalPages <= 3)
            {
                start = 1;
                end = _totalPages;
            }
            else
            {
                if (_currentPage == 1)
                {
                    start = 1;
                    end = 3;
                }
                else if (_currentPage == _totalPages)
                {
                    start = _totalPages - 2;
                    end = _totalPages;
                }
                else
                {
                    start = _currentPage - 1;
                    end = _currentPage + 1;
                }
            }

            // 中央のページ番号ボタン
            for (int i = start; i <= end; i++)
            {
                Button pageBtn = new Button
                {
                    Content = i.ToString(),
                    Style = btnStyle,
                    Margin = new Thickness(3),
                    Background = (i == _currentPage)
                        ? Brushes.LightBlue
                        : Brushes.White
                };

                int page = i; // 重要：イベント内で i を保持
                pageBtn.Click += (s, e) =>
                {
                    _currentPage = page;
                    UpdateList();
                    CreatePageButtons();
                };

                pagePanel.Children.Add(pageBtn);
            }

            // ＞ ボタン
            Button nextBtn = new Button { Content = ">>", Style = btnStyle };
            nextBtn.Click += (s, e) =>
            {
                if (_currentPage < _totalPages)
                {
                    _currentPage++;
                    UpdateList();
                    CreatePageButtons();
                }
            };
            pagePanel.Children.Add(nextBtn);
        }

        private void UpdateList()
        {
            int skip = (_currentPage - 1) * _pageSize;
            var pageItems = _allItems.Skip(skip).Take(_pageSize).ToList();

            listView.ItemsSource = pageItems;
        }

        private void PageSizeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pageSizeCombo.SelectedItem is ComboBoxItem item)
            {
                if (int.TryParse(item.Content.ToString(), out int newSize))
                {
                    _pageSize = newSize;
                    _currentPage = 1; // 最初のページに戻す

                    _totalPages = (int)Math.Ceiling(_allItems.Count / (double)_pageSize);

                    UpdateList();
                    CreatePageButtons();
                }
            }
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

        private void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            var main = Window.GetWindow(this) as MainWindow;
            if (main == null) return;

            // TagDetailsView を表示
            main.InventoryDetail.Visibility = Visibility.Visible;

            // 他を隠す
            main.HomeScreenControl.Visibility = Visibility.Collapsed;
            main.MaterialLedgerScreenControl.Visibility = Visibility.Collapsed;
            main.InventoryResult.Visibility = Visibility.Collapsed;
            main.StockListScreenControl.Visibility = Visibility.Collapsed;
            main.CsvImportScreenControl.Visibility = Visibility.Collapsed;
            main.CsvExportScreenControl.Visibility = Visibility.Collapsed;
            main.MasterMagamentScreenControl.Visibility = Visibility.Collapsed;
            main.SettingScreenControl.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// 検索条件変更ボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenSearchDialogButton_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.InvokeAsync(async () =>
            {
                var result = await DialogHost.Show(new InventorySearchDialog()) ?? "";

                if (result is InventorySearchCondition condition)
                {
                    ApplyFilter(condition);
                }
            });
        }

        /// <summary>
        /// リストの絞り込み
        /// </summary>
        /// <param name="c"></param>
        private void ApplyFilter(InventorySearchCondition c)
        {
            var filtered = _allItems.Where(x =>
                (string.IsNullOrEmpty(c.Location) || x.Location_name.Contains(c.Location)) &&
                (string.IsNullOrEmpty(c.Status) || x.Status.Contains(c.Status)) &&
                (!c.StartDate.HasValue || x.Updated_at.Date >= c.StartDate.Value.Date) &&
                (!c.EndDate.HasValue || x.Updated_at.Date <= c.EndDate.Value.Date)

            ).ToList();

            listView.ItemsSource = filtered;
        }
    }
}
