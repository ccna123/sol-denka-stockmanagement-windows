using sol_denka_stockmanagement.Database;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Data;

namespace sol_denka_stockmanagement.Views.Controls.HomeScreenControl
{
    /// <summary>
    /// LedgerEvent.xaml の相互作用ロジック
    /// </summary>
    public partial class LedgerEvent : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<LedgerEventItem> _ledgerEvents = new();

        //タイトルの文字列
        private string _titleText;
        public string TitleText
        {
            get => _titleText;
            set
            {
                if (_titleText != value)
                {
                    _titleText = value;
                    OnPropertyChanged(nameof(TitleText));
                }
            }
        }

      　//コンストラクタ
        public LedgerEvent()
        {
            InitializeComponent();
            LoadLatestLedgerEvents();
        }

        private void LoadLatestLedgerEvents()
        {
            using var db = new AppDbContext();

            var latestItems = db.LedgerItemEvents
                .Include(x => x.EventType)
                .Include(x => x.LedgerItem)
                    .ThenInclude(it => it.ItemType)
                .Include(x => x.LedgerItem)
                    .ThenInclude(it => it.Tags)
                .Where(x =>
                    x.EventType != null &&
                    !string.IsNullOrEmpty(x.EventType.Event_name) &&
                    !string.IsNullOrEmpty(x.Occurred_at)
                )
                .AsEnumerable()
                .OrderByDescending(x => DateTime.Parse(x.Occurred_at))
                .Take(3)
                .Select(x => new LedgerEventItem
                {
                    DateTime = DateTime.Parse(x.Occurred_at)
                                        .ToString("yyyy-MM-dd HH:mm:ss"),
                    Operation = x.EventType.Event_name,
                    ItemName = x.LedgerItem.ItemType?.Item_type_name ?? "",
                    EPC = x.LedgerItem.Tags?.FirstOrDefault()?.Epc ?? "",
                    Status = x.LedgerItem.Is_in_stock == 1 ? "入庫" : "出庫"
                })
                .ToList();


            LedgerEventList.ItemsSource = latestItems;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadLatestLedgerEvents();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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
            if (LedgerEventList.View is GridView gridView)
            {
                int columnCount = gridView.Columns.Count;
                if (columnCount == 0) return;

                double totalWidth = LedgerEventList.ActualWidth - 5; // 余白分調整
                double columnWidth = totalWidth / columnCount;

                foreach (var column in gridView.Columns)
                {
                    column.Width = columnWidth;
                }
            }
        }

        private async void move_click(object sender, RoutedEventArgs e)
        {
            var main = Window.GetWindow(this) as MainWindow;
            if (main == null) return;

            // TagDetailsView を表示
            main.MaterialLedgerScreenControl.Visibility = Visibility.Visible;

            // 他を隠す
            main.HomeScreenControl.Visibility = Visibility.Collapsed;
            main.StockListScreenControl.Visibility = Visibility.Collapsed;
            main.CsvImportScreenControl.Visibility = Visibility.Collapsed;
            main.CsvExportScreenControl.Visibility = Visibility.Collapsed;
            main.MasterMagamentScreenControl.Visibility = Visibility.Collapsed;
            main.SettingScreenControl.Visibility = Visibility.Collapsed;
            main.TagDetailsEdit.Visibility = Visibility.Collapsed;
        }

        public void ReloadCsvHistory()
        {
            LoadLatestLedgerEvents();
        }

    }

    public class LedgerEventItem
    {
        public String DateTime { get; set; }
        public string Operation { get; set; }
        public string ItemName { get; set; }
        public string EPC { get; set; }
        public string Status { get; set; }
    }
}
