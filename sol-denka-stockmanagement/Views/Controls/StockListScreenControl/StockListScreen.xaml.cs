using MaterialDesignThemes.Wpf;
using sol_denka_stockmanagement.Database;
using sol_denka_stockmanagement.Models;
using sol_denka_stockmanagement.Views.Dialogs;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace sol_denka_stockmanagement.Views.Controls.StockListScreenControl
{
    /// <summary>
    /// StockListScreen.xaml の相互作用ロジック
    /// </summary>
    public partial class StockListScreen : UserControl
    {
        private List<StockItem> _allItems = new();
        private List<StockItem> _filteredItems = new();
        private int _pageSize = 10;
        private int _currentPage = 1;
        private int _totalPages;

        public ICommand DetailCommand { get; }
        public StockListScreen()
        {
            InitializeComponent();
        }

        // ===============================
        // 検索条件ボタン押下時処理
        // ===============================
        private async void OpenSearchDialogButton_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.InvokeAsync(async () =>
            {
                var result = await DialogHost.Show(new StockSearchDialog()) ?? "";

                if (result is StockSearchCondition condition)
                {
                    ApplyFilter(condition);
                }
            });
        }

        private void ApplyFilter(StockSearchCondition c)
        {
            _filteredItems = _allItems.Where(x =>
                (string.IsNullOrEmpty(c.material_code) || x.material_code.Contains(c.material_code)) &&
                (string.IsNullOrEmpty(c.material_name) || x.material_name.Contains(c.material_name)) &&
                (string.IsNullOrEmpty(c.LotNo) || x.Status.Contains(c.LotNo))
            ).ToList();

            _currentPage = 1;
            _totalPages = (int)Math.Ceiling(_filteredItems.Count / (double)_pageSize);

            UpdateList();
            CreatePageButtons();
        }

        // ===============================
        // リスト関連
        // ===============================
        //ページ変更ボタンの処理
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

        //ページサイズ選択用 ComboBox の選択が変更時処理
        private void PageSizeCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!IsLoaded) return;

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

        // 現在のページ番号とページサイズに応じて ListView に表示するデータを更新
        private void UpdateList()
        {
            var source = _filteredItems.Any()
                ? _filteredItems
                : _allItems;

            int skip = (_currentPage - 1) * _pageSize;
            var pageItems = source.Skip(skip).Take(_pageSize).ToList();

            listView.ItemsSource = pageItems;
        }


        //リスト横幅の調整
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

                double totalWidth = listView.ActualWidth - 5;
                double columnWidth = totalWidth / columnCount;

                foreach (var column in gridView.Columns)
                {
                    column.Width = columnWidth;
                }
            }
        }

        // ===============================
        // 読み込み処理
        // ===============================
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadDataFromDb();

            Style btnStyle = (Style)FindResource("ButtonStyle");
            SearchButton.Style = btnStyle;

            _pageSize = 20;
            _currentPage = 1;
            _totalPages = (int)Math.Ceiling(_allItems.Count / (double)_pageSize);

            pageSizeCombo.SelectedIndex = 0;

            UpdateList();
            CreatePageButtons();
        }

        public void LoadDataFromDb()
        {
            using (var db = new AppDbContext())
            {
                var items = db.LedgerItems
                    .Select(l => new StockItem
                    {
                        material_code = l.ItemType.Item_type_code,
                        material_name = l.ItemType.Item_type_name,
                        Status = l.Lot_no,
                        Stock_Quantity = 1.ToString(),
                        total_inventory = l.Quantity.ToString(),
                        total_weight = l.Weight.ToString(),
                        unit = l.ItemType.Item_count_unit.item_unit_name
                    })
                    .ToList();


                if (_allItems != null) 
                { 
                    _allItems.Clear();
                    _allItems.AddRange(items); }
            }
        }

        // ===============================
        // 再読み込み処理
        // ===============================
        public void Reload()
        {
            LoadDataFromDb();
            _currentPage = 1;
            _totalPages = (int)Math.Ceiling(_allItems.Count / (double)_pageSize);

            UpdateList();
            CreatePageButtons();
        }
    }
}
