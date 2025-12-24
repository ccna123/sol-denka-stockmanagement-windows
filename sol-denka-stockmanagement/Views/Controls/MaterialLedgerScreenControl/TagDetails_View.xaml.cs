using Microsoft.EntityFrameworkCore;
using sol_denka_stockmanagement.Database;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using static MaterialDesignThemes.Wpf.Theme;
using static sol_denka_stockmanagement.Views.Controls.MasterManagementScreenControl.EditRegistration;

namespace sol_denka_stockmanagement.Views.Controls.MaterialLedgerScreenControl
{
    public partial class TagDetails_View : UserControl
    {
        private bool isEditing = false;
        private int _currentItemTypeId;
        private bool? _beforeCheckState;
        public ObservableCollection<LedgerItemEventViewModel> listView { get; set; }

        public TagDetails_View()
        {
            InitializeComponent();
        }

        ///データ読み込み
        public void LoadData(int code)
        {
            using (var db = new AppDbContext())
            {
                var ledgerItem = db.LedgerItems
                    .Include(x => x.ItemType)
                        .ThenInclude(x => x.ItemCategory)
                    .Include(x => x.Winder)
                    .Include(x => x.Location)
                    .Include(x => x.Tags)
                    .FirstOrDefault(x => x.Ledger_item_id == code);

                if (ledgerItem == null)
                {
                    MessageBox.Show("台帳データが見つかりません");
                    return;
                }

                _currentItemTypeId = ledgerItem.Ledger_item_id;

                // ★ Binding 用
                DataContext = ledgerItem;

                // Tags 表示
                ItemCodeName.Text = ledgerItem.Tags != null && ledgerItem.Tags.Any()
                    ? string.Join(", ", ledgerItem.Tags.Select(t => t.Epc))
                    : "";

                _beforeCheckState = ledgerItem.Tags.Any(t => t.Tag_status_id == 4);

                CheckBox.IsChecked = _beforeCheckState;

                // 履歴リストを初期化
                if (listView == null)
                    listView = new ObservableCollection<LedgerItemEventViewModel>();
                else
                    listView.Clear();

                // 正しい JOIN カラムを確認する
                var histories = db.LedgerItemEvents
                    .Include(h => h.EventType)
                    .Include(h => h.LedgerItem)
                        .ThenInclude(li => li.Location)
                    .Where(h => h.Ledger_item_id == _currentItemTypeId)
                    .OrderByDescending(h => h.Occurred_at)
                    .Select(h => new LedgerItemEventViewModel
                    {
                        EventDateTime = h.Occurred_at,
                        EventName = h.EventType.Event_name,
                        Location = h.LedgerItem.Location.Location_name,
                        Memo = h.Memo
                    })
                    .ToList();

                foreach (var h in histories)
                {
                    listView.Add(h);
                }

                listView2.ItemsSource = listView;
            }
        }

        //戻る処理
        private void BackPage_Click(object sender, RoutedEventArgs e)
        {
            var main = Window.GetWindow(this) as MainWindow;
            if (main == null) return;

            main.MaterialLedgerScreenControl.Visibility = Visibility.Visible;
            main.TagDetailsView.Visibility = Visibility.Collapsed;
            main.HomeScreenControl.Visibility = Visibility.Collapsed;
            main.StockListScreenControl.Visibility = Visibility.Collapsed;
            main.CsvImportScreenControl.Visibility = Visibility.Collapsed;
            main.CsvExportScreenControl.Visibility = Visibility.Collapsed;
            main.MasterMagamentScreenControl.Visibility = Visibility.Collapsed;
            main.SettingScreenControl.Visibility = Visibility.Collapsed;
        }

        //編集・更新
        private void EditPage_Click(object sender, RoutedEventArgs e)
        {
            if (isEditing)
            {
                SaveEdit();
            }

            isEditing = !isEditing;
            EditButton.Content = isEditing ? "確定" : "編集";

            LotNoBox.IsEnabled = isEditing;
            OccurrenceReasonBox.IsEnabled = isEditing;
            OccurredAtBox.IsEnabled = isEditing;
            ProcessedAtBox.IsEnabled = isEditing;
            ThicknessBox.IsEnabled = isEditing;
            WidthBox.IsEnabled = isEditing;
            LengthBox.IsEnabled = isEditing;
            QuantityBox.IsEnabled = isEditing;
            WeightBox.IsEnabled = isEditing;
            MemoBox.IsEnabled = isEditing;
            WinderBox.IsEnabled = isEditing;
            LocationBox.IsEnabled = isEditing;
            ItemCodeName.IsEnabled = isEditing;
            CheckBox.IsEnabled = isEditing;
            InStock.IsEnabled = isEditing;
            NotStock.IsEnabled = isEditing;
        }

        private async void SaveEdit()
        {
            using (var db = new AppDbContext())
            {
                var ledgerItem = db.LedgerItems
                    .Include(x => x.Winder)
                    .Include(x => x.Location)
                    .Include(x => x.Tags)
                    .FirstOrDefault(x => x.Ledger_item_id == _currentItemTypeId);

                if (ledgerItem == null)
                {
                    MessageBox.Show("台帳データが見つかりません");
                    return;
                }

                // ===== LedgerItemEvent ====
                var events = new LedgerItemEvent
                {
                    Ledger_item_id = ledgerItem.Ledger_item_id,
                    Event_type_id = 7,
                    Occurred_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Registered_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Memo = "ステータス変更",
                };
                db.LedgerItemEvents.Add(events);
                await db.SaveChangesAsync();

                // =============================
                // EPC 差分判定（削除のみ）
                // =============================
                var inputEpcs = ItemCodeName.Text
                    .Split(',')
                    .Select(x => x.Trim())
                    .Where(x => !string.IsNullOrEmpty(x))
                    .ToList();

                var dbEpcs = ledgerItem.Tags
                    .Where(t => t.Is_active == 1)
                    .Select(t => t.Epc)
                    .ToList();

                var removedEpcs = dbEpcs.Except(inputEpcs).ToList();

                foreach (var epc in removedEpcs)
                {
                    var tag = ledgerItem.Tags.FirstOrDefault(t => t.Epc == epc);
                    if (tag == null) continue;

                    // Tag 更新（要件どおり）
                    tag.Tag_status_id = 3;
                    tag.Ledger_item_id = null;
                    tag.Is_active = 0;
                    tag.Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    // TagHistory 追加
                    db.TagHistories.Add(new TagHistory
                    {
                        Tag_id = tag.Tag_id,
                        Tag_event_id = 3,
                        Ledger_item_id = null,
                        Occured_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    });
                }

                // ===============================
                // CheckBox 状態変化時の TagHistory 追加
                // ===============================
                if (_beforeCheckState != CheckBox.IsChecked)
                {
                    foreach (var tag in ledgerItem.Tags.Where(t => t.Is_active == 1))
                    {
                        int tagEventId;

                        if (CheckBox.IsChecked == true)
                        {
                            // チェック ON
                            tagEventId = 4;
                            tag.Tag_status_id = 4;
                            tag.Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        }
                        else
                        {
                            // チェック OFF → 一つ前のイベントに戻す
                            tagEventId = GetPreviousTagEventId(db, tag.Tag_id);
                            tag.Tag_status_id = GetPreviousTagEventId(db, tag.Tag_id);
                            tag.Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        }

                        db.TagHistories.Add(new TagHistory
                        {
                            Tag_id = tag.Tag_id,
                            Ledger_item_id = ledgerItem.Ledger_item_id,
                            Tag_event_id = tagEventId,
                            Occured_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        });
                    }
                }


                // =============================
                // LedgerItem 更新（既存処理）
                // =============================
                ledgerItem.Lot_no = LotNoBox.Text.Trim();
                ledgerItem.Occurrence_reason = OccurrenceReasonBox.Text.Trim();
                ledgerItem.Occurred_at = OccurredAtBox.Text.Trim();
                ledgerItem.Processed_at = ProcessedAtBox.Text.Trim();
                ledgerItem.Is_in_stock = InStock.IsChecked == true ? 1 : 0;
                ledgerItem.Thickness = ParseNullableInt(ThicknessBox.Text);
                ledgerItem.Width = ParseNullableInt(WidthBox.Text);
                ledgerItem.Length = ParseNullableInt(LengthBox.Text);
                ledgerItem.Quantity = ParseNullableInt(QuantityBox.Text);
                ledgerItem.Weight = ParseNullableInt(WeightBox.Text);
                ledgerItem.Memo = MemoBox.Text.Trim();
                ledgerItem.Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                if (ledgerItem.Winder != null)
                    ledgerItem.Winder.Winder_name = WinderBox.Text.Trim();

                if (ledgerItem.Location != null)
                    ledgerItem.Location.Location_name = LocationBox.Text.Trim();

                db.SaveChanges();
            }
            MessageBox.Show("更新しました");

            var main = Window.GetWindow(this) as MainWindow;
            if (main != null)
            {
                main.MasterMagamentScreenControl.ReloadCurrentMaster();
                main.MaterialLedgerScreenControl.ReloadLedgerItems();
            }

        }

        //型変換
        private int? ParseNullableInt(string text)
        {
            return int.TryParse(text, out int v) ? v : (int?)null;
        }

        // ===============================
        // TagHistory：一つ前のイベントID取得
        // ===============================
        private int GetPreviousTagEventId(AppDbContext db, int tagId)
        {
            var histories = db.TagHistories
                .Where(h => h.Tag_id == tagId)
                .OrderByDescending(h => h.Occured_at)
                .Take(2)
                .ToList();

            // 履歴が無い場合
            if (histories.Count == 0)
                return 0;

            // 履歴が1件のみの場合
            if (histories.Count == 1)
                return histories[0].Tag_event_id ?? 0;

            // 2件目が「一つ前」
            return histories[1].Tag_event_id ?? 0;
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
            if (listView2.View is GridView gridView)
            {
                int columnCount = gridView.Columns.Count;
                if (columnCount == 0) return;

                double totalWidth = listView2.ActualWidth - 5; // 余白分調整
                double columnWidth = totalWidth / columnCount;

                foreach (var column in gridView.Columns)
                {
                    column.Width = columnWidth;
                }
            }
        }

        public class LedgerItemEventViewModel
        {
            public string EventDateTime { get; set; }
            public string EventName { get; set; }
            public string Location { get; set; }
            public string Memo { get; set; }

        }
    }

    public class StockToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null)
                return false;

            return value.ToString() == parameter.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // RadioButton が ON になったときだけ値を返す
            if ((bool)value == true && parameter != null)
            {
                return int.Parse(parameter.ToString()); // 1 or 0
            }

            return Binding.DoNothing;
        }
    }
}