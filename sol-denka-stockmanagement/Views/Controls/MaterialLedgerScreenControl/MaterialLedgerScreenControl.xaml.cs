using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using sol_denka_stockmanagement.Database;
using sol_denka_stockmanagement.Models;
using sol_denka_stockmanagement.Views.Controls.MasterManagementScreenControl;
using sol_denka_stockmanagement.Views.Dialogs;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;


namespace sol_denka_stockmanagement.Views.Controls.MaterialLedgerScreenControl
{
    /// <summary>
    /// MaterialLedgerScreenControl.xaml の相互作用ロジック
    /// </summary>
    public partial class MaterialLedgerScreenControl : UserControl
    {
        private List<MaterialItem> _allItems;   // 元データ
        private int _pageSize = 10;
        private int _currentPage = 1;
        private int _totalPages;

        public ICommand DetailCommand { get; }

        public MaterialLedgerScreenControl()
        {
            InitializeComponent();

            DetailCommand = new RelayCommand<MaterialItem>(OnDetail);

            LoadLedgerItems();

            _totalPages = (int)Math.Ceiling(_allItems.Count / (double)_pageSize);

            UpdateList();
            CreatePageButtons();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            // シンプルなメッセージボックス
            MessageBox.Show("検索条件変更ダイアログを表示します。", "ダイアログ", MessageBoxButton.OK, MessageBoxImage.Information);

            // もしカスタムウィンドウを開く場合：
            // var dialog = new SearchConditionWindow();
            // dialog.ShowDialog();
        }

        private void LoadLedgerItems()
        {
            using (var db = new AppDbContext())
            {
                _allItems = db.LedgerItems
                    .OrderByDescending(x => x.Updated_at)
                    .Select(x => new MaterialItem
                    {
                        Ledger_item_id = x.Ledger_item_id,
                        Item_Code = x.ItemType.Item_type_code,         
                        Item_Name = x.ItemType.Item_type_name,
                        Status = x.Is_in_stock == 1 ? "在庫有(入庫状態)" : "在庫無(出庫状態)",
                        Location_name = x.Location.Location_name,
                        Updated_at = DateTime.Parse(x.Updated_at)
                    })
                    .ToList();
            }
        }


        private void UpdateList()
        {
            int skip = (_currentPage - 1) * _pageSize;
            var pageItems = _allItems.Skip(skip).Take(_pageSize).ToList();

            listView.ItemsSource = pageItems;
        }

        private void OnDetail(MaterialItem item)
        {
            MessageBox.Show($"{item.Item_Code} の詳細を開きます。");
        }

        /// <summary>
        /// ページ変更
        /// </summary>
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

        /// <summary>
        /// 検索条件変更ボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenSearchDialogButton_Click(object sender, RoutedEventArgs e)
        {
            Dispatcher.InvokeAsync(async () =>
            {
                var result = await DialogHost.Show(new MaterialSearchDialog()) ?? "";

                if (result is MaterialSearchCondition condition)
                {
                    ApplyFilter(condition);
                }
            });
        }

        /// <summary>
        /// 詳細ボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            if (button == null) return;

            var selectedItem = button.DataContext as MaterialItem;
            if (selectedItem == null) return;

            var main = Window.GetWindow(this) as MainWindow;
            if (main == null) return;

            main.TagDetailsView.LoadData(selectedItem.Ledger_item_id);

            // TagDetailsView を表示
            main.TagDetailsView.Visibility = Visibility.Visible;

            // 他を隠す
            main.HomeScreenControl.Visibility = Visibility.Collapsed;
            main.MaterialLedgerScreenControl.Visibility = Visibility.Collapsed;
            main.StockListScreenControl.Visibility = Visibility.Collapsed;
            main.CsvImportScreenControl.Visibility = Visibility.Collapsed;
            main.CsvExportScreenControl.Visibility = Visibility.Collapsed;
            main.MasterMagamentScreenControl.Visibility = Visibility.Collapsed;
            main.SettingScreenControl.Visibility = Visibility.Collapsed;
        }


        /// <summary>
        /// リストの絞り込み
        /// </summary>
        /// <param name="c"></param>
        private void ApplyFilter(MaterialSearchCondition c)
        {
            var filtered = _allItems.Where(x =>
                (string.IsNullOrEmpty(c.Item_Name) || x.Item_Name.Contains(c.Item_Name)) &&
                (string.IsNullOrEmpty(c.EPC) || x.Item_Code.Contains(c.EPC)) &&
                (string.IsNullOrEmpty(c.Storage) || x.Location_name == c.Storage) &&
                (!c.StartDate.HasValue || x.Updated_at.Date >= c.StartDate.Value.Date) &&
                (!c.EndDate.HasValue || x.Updated_at.Date <= c.EndDate.Value.Date)

            ).ToList();

            listView.ItemsSource = filtered;
        }

        public void ReloadLedgerItems()
        {
            LoadLedgerItems();

            _currentPage = 1;
            _totalPages = (int)Math.Ceiling(_allItems.Count / (double)_pageSize);

            UpdateList();
            CreatePageButtons();
        }


    }


    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;

        public RelayCommand(Action<T> execute)
        {
            _execute = execute;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
    }
}

