using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using sol_denka_stockmanagement.Commons;
using sol_denka_stockmanagement.Database;
using sol_denka_stockmanagement.Models;
using sol_denka_stockmanagement.Views.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace sol_denka_stockmanagement.Views.Controls.MasterManagementScreenControl
{
    /// <summary>
    /// EditRegistration.xaml の相互作用ロジック
    /// </summary>
    public partial class EditRegistration : UserControl
    {
        public ObservableCollection<ReceiptItem> _ReceiptItem { get; set; }
        public ObservableCollection<TagHistoryViewModel> TagHistoryList { get; set; }

        public string MasterType { get; set; }
        private bool _isEditMode = false;
        private int _originalTagStatusId;
        private bool? _beforeCheckState;
        private int _currentItemTypeId;
        public bool IsEditMode
        {
            get => _isEditMode;
            set
            {
                _isEditMode = value;
                // 通知（最低限）
                this.DataContext = null;
                this.DataContext = this;
            }
        }

        public EditRegistration()
        {
            InitializeComponent();

            //品目＋項目マスタ選択時表示させるリスト
            _ReceiptItem = new ObservableCollection<ReceiptItem>
            {
                new ReceiptItem{ Name="重量" },
                new ReceiptItem{ Name="長さ" },
                new ReceiptItem{ Name="厚さ" },
                new ReceiptItem{ Name="巾" },
                new ReceiptItem{ Name="数量" },
                new ReceiptItem{ Name="巻取機" },
                new ReceiptItem{ Name="発生理由" },
                new ReceiptItem{ Name="Lot No" },
                new ReceiptItem{ Name="発生日時" },
                new ReceiptItem{ Name="処理日時" },
            };

            DataContext = this;
            TagHistoryList = new ObservableCollection<TagHistoryViewModel>();
            LoadUnits();
        }

        // ===== =====
        // マスタ選択
        // ===== =====
        public void SetMasterType(string masterType)
        {
            MasterType = masterType;

            // まず両方非表示
            ItemRegistration.Visibility = Visibility.Collapsed;
            LocationRegistration.Visibility = Visibility.Collapsed;
            TagRegistration.Visibility = Visibility.Collapsed;

            if (masterType == "品目マスタ＋項目設定マスタ")
            {
                ItemRegistration.Visibility = Visibility.Visible;
            }
            else if (masterType == "保管場所マスタ")
            {
                LocationRegistration.Visibility = Visibility.Visible;
            }
            else if (masterType == "タグマスタ")
            {
                TagRegistration.Visibility = Visibility.Visible;
            }
        }

        // ===== =====
        // データ読み込み
        // ===== =====
        private void LoadUnits()
        {
            using (var db = new AppDbContext())
            {
                WightUnitComboBox.ItemsSource = BuildUnitOptions(db, UnitCategory.Weight);
                CountUnitComboBox.ItemsSource = BuildUnitOptions(db, UnitCategory.Count);

                CategoryConboBox.ItemsSource = db.ItemCatetories.ToList();
            }
        }

        private List<UnitOption> BuildUnitOptions(AppDbContext db, UnitCategory category)
        {
            var units = db.ItemUnits
                .Where(u => u.Unit_category == (int)category)
                .Select(u => new UnitOption
                {
                    Id = u.Item_unit_id,
                    Code = u.Item_unit_code
                }).ToList();

            units.Insert(0, new UnitOption { Id = null, Code = "未選択" });
            return units;
        }

        public void LoadData(int id)
        {
            LoadByMasterType(id);
        }

        private void LoadByMasterType(int id)
        {
            if (MasterType == "品目マスタ＋項目設定マスタ")
            {
                LoadItemMaster(id);
            }
            else if (MasterType == "保管場所マスタ")
            {
                LoadLocationMaster(id);
            }
        }

        public void TagLoadData(string Name)
        {
            if (MasterType == "タグマスタ")
            {
                LoadTagMaster(Name);
            }
        }


        // ===== =====
        // 品目マスタ
        // ===== =====
        private void LoadItemMaster(int itemTypeId)
        {
            using (var db = new AppDbContext())
            {
                var item = db.ItemTypes
                .FirstOrDefault(x => x.Item_type_id == itemTypeId);

                if (item == null) return;

                // ===== 基本情報 =====
                _currentItemTypeId = item.Item_type_id;

                ItemNameBox.Text = item.Item_type_name;
                ItemCodeBox.Text = item.Item_type_code;
                WightUnitComboBox.SelectedValue = item.Item_weight_unit_id;
                CountUnitComboBox.SelectedValue = item.Item_count_unit_id;
                CategoryConboBox.SelectedValue = item.Item_category_id;
                GradeBox.Text = item.Grade;
                SpecificGravityBox.Text = item.Specific_gravity;
                PackingStyleBox.Text = item.Packing_type;
                CreatedAtText.Text = item.Created_at;
                UpdatedAtText.Text = item.Updated_at;
                if (item.Is_active == 1)
                {
                    ItemEnabledCheckBox.IsChecked = true;
                }
                else
                {
                    ItemEnabledCheckBox.IsChecked = false;
                }

                // ===== 可変項目設定 =====
                var settings = db.ItemTypeFieldSettings
                    .Where(x => x.Item_type_id == item.Item_type_id)
                    .ToList();

                var fields = db.FieldMasters.ToList();

                foreach (var r in _ReceiptItem)
                {
                    var field = fields.FirstOrDefault(f => f.Field_name == r.Name);
                    if (field == null)
                    {
                        r.表示 = false;
                        r.必須 = false;
                        r.任意 = true;
                        continue;
                    }

                    var setting = settings.FirstOrDefault(s => s.Field_id == field.Field_id);

                    if (setting != null)
                    {
                        r.表示 = setting.Is_visible == 1;
                        r.必須 = setting.Is_required == 1;
                        r.任意 = !r.必須;
                    }
                    else
                    {
                        r.表示 = false;
                        r.必須 = false;
                        r.任意 = true;
                    }
                }

                listView.Items.Refresh();

                listView.IsEnabled = true;
                listView.Visibility = Visibility.Visible;
            }
        }

        // ===== =====
        // 保管場所マスタ
        // ===== =====
        private void LoadLocationMaster(int locationId)
        {
            using (var db = new AppDbContext())
            {
                var location = db.Locations
                    .FirstOrDefault(x => x.Location_id == locationId);

                if (location == null)
                {
                    MessageBox.Show("保管場所データが見つかりません");
                    return;
                }

                // ===== ID保持（更新用）=====
                _currentItemTypeId = location.Location_id;

                // ===== 基本情報 =====
                LocationNameBox.Text = location.Location_name;
                LocationCodeBox.Text = location.Location_code;
                LocationRemarkBox.Text = location.Memo;

                // 品目用の項目は非表示 or 無効
                CountUnitComboBox.SelectedIndex = -1;
                CountUnitComboBox.IsEnabled = false;
                WightUnitComboBox.SelectedIndex = -1;
                WightUnitComboBox.IsEnabled = false;

                CategoryConboBox.SelectedIndex = -1;
                CategoryConboBox.IsEnabled = false;

                if (location.Is_active == 1)
                {
                    LocationEnabledCheckBox.IsChecked = true;
                }
                else
                {
                    LocationEnabledCheckBox.IsChecked = false;
                }

                // 備考（あれば）
                // 備考TextBox.Text = location.Remarks;

                // 登録・更新日時
                CreatedAtText2.Text = location.Created_at;
                UpdatedAtText2.Text = location.Updated_at;

                // ===== 右側の可変項目は不要なので無効化 =====
                listView.IsEnabled = false;
                listView.Visibility = Visibility.Collapsed;
            }
        }

        // ===== =====
        //　タグマスタ
        // ===== =====
        private void LoadTagMaster(string epc)
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var tag = db.Tags.FirstOrDefault(x => x.Epc == epc);
                    if (tag == null)
                    {
                        MessageBox.Show("タグデータが見つかりません");
                        return;
                    }

                    // ===== 基本情報 =====
                    _currentItemTypeId = tag.Tag_id;

                    TagEpcBox.Text = tag.Epc ?? "";
                    TagCreatedAtText.Text = tag.Created_at ?? "";
                    TagUpdatedAtText.Text = tag.Updated_at ?? "";

                    var status = db.TagStatusTypes.FirstOrDefault(s => s.Tag_status_id == tag.Tag_status_id);
                    TagStatusBox.Text = status?.Status_name ?? "未設定";

                    _beforeCheckState = tag.Tag_status_id == 4;

                    TagEnabledCheckBox.IsChecked = _beforeCheckState;

                    // 履歴リストを初期化
                    if (TagHistoryList == null)
                        TagHistoryList = new ObservableCollection<TagHistoryViewModel>();
                    else
                        TagHistoryList.Clear();

                    // 正しい JOIN カラムを確認する
                    var histories = db.TagHistories
                        .Where(h => h.Tag_id == tag.Tag_id)
                        .Join(db.TagEventTypes,
                              h => h.Tag_event_id,  // ← TagHistories 側の FK
                              e => e.Tag_event_id,  // ← TagEventTypes 側の PK
                              (h, e) => new
                              {
                                  CreatedAt = h.Occured_at ?? "",
                                  EventName = e.Event_name ?? "未設定"
                              })
                        .OrderByDescending(x => x.CreatedAt)
                        .ToList();

                    foreach (var h in histories)
                    {
                        TagHistoryList.Add(new TagHistoryViewModel
                        {
                            EventDateTime = h.CreatedAt,
                            EventName = h.EventName
                        });
                    }

                    // ===== 右側の可変項目は不要なので無効化 =====
                    listView.IsEnabled = false;
                    listView.Visibility = Visibility.Collapsed;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"タグ履歴読み込み中にエラーが発生しました。\n\n{ex.Message}",
                                "エラー", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        // ===== =====
        // 戻る処理
        // ===== =====
        private void BackPage_Click(object sender, RoutedEventArgs e)
        {
            if (IsEditMode)
            {
                if(!ConfirmDiscard(Messages.DiscardAndBackConfirm)) return;
                ExitEditModeWithoutSave();
            }
            BackToPreviousScreen();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            if (!IsEditMode) return;

            if(!ConfirmDiscard(Messages.DiscardAndExitEditMode)) return;
            ExitEditModeWithoutSave();
        }

        private bool ConfirmDiscard(string message)
        {
            var result = MessageBox.Show(
                message,
                Messages.ConfirmTitle,
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            return result == MessageBoxResult.Yes;
        }

        private void BackToPreviousScreen()
        {
            var main = Window.GetWindow(this) as MainWindow;
            if (main == null) return;

            // MasterMagament を表示
            main.MasterMagamentScreenControl.Visibility = Visibility.Visible;

            // 他を隠す
            main.HomeScreenControl.Visibility = Visibility.Collapsed;
            main.MaterialLedgerScreenControl.Visibility = Visibility.Collapsed;
            main.StockListScreenControl.Visibility = Visibility.Collapsed;
            main.CsvImportScreenControl.Visibility = Visibility.Collapsed;
            main.CsvExportScreenControl.Visibility = Visibility.Collapsed;
            main.SettingScreenControl.Visibility = Visibility.Collapsed;
            main.TagDetailsEdit.Visibility = Visibility.Collapsed;
            main.TagDetailsView.Visibility = Visibility.Collapsed;
            main.EditRegistration.Visibility = Visibility.Collapsed;
            main.NewRegistration.Visibility = Visibility.Collapsed;
        }

        private void ExitEditModeWithoutSave()
        {
            ExitEditMode();
            LoadByMasterType(_currentItemTypeId);
        }

        private void Check_button(object sender, RoutedEventArgs e)
        {
            Dispatcher.InvokeAsync(async () =>
            {
                await DialogHost.Show(new CompletionDialog());
            });
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
        private void listView_SizeChanged2(object sender, SizeChangedEventArgs e)
        {
            AdjustColumnWidths2();
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

        private void AdjustColumnWidths2()
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

        //編集・確定ボタン押下時処理
        private void EditSaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (!_isEditMode)
            {
                EnterEditMode();
            }
            else
            {
                SaveEdit();
            }
        }

        private void EnterEditMode()
        {
            IsEditMode = true;
            EditSaveButton.Content = "確定";

            // ===== 基本情報 =====
            ItemNameBox.IsReadOnly = false;
            ItemNameBox.IsEnabled = true;
            ItemCodeBox.IsReadOnly = false;
            ItemCodeBox.IsEnabled = true;

            LocationNameBox.IsReadOnly = false;
            LocationNameBox.IsEnabled = true;
            LocationCodeBox.IsReadOnly = false;
            LocationCodeBox.IsEnabled = true;
            LocationRemarkBox.IsReadOnly = false;
            LocationRemarkBox.IsEnabled = true;

            CountUnitComboBox.IsEnabled = true;
            WightUnitComboBox.IsEnabled = true;
            CategoryConboBox.IsEnabled = true;
            GradeBox.IsEnabled = true;
            SpecificGravityBox.IsEnabled = true;
            PackingStyleBox.IsEnabled = true;

            EditCancelButton.Visibility = Visibility.Visible;
            EditCancelButton.IsEnabled = true;
            listView.IsEnabled = true;
            if (MasterType == "品目マスタ＋項目設定マスタ")
            {
                ItemEnabledCheckBox.IsEnabled = true;
            }

            if (MasterType == "保管場所マスタ")
            {
                listView.IsEnabled = false;
                LocationEnabledCheckBox.IsEnabled = true;
            }


            if (MasterType == "タグマスタ")
            {
                listView.IsEnabled = false;
                TagStatusBox.IsEnabled = true;
                TagRemarkBox.IsReadOnly = false;
                TagEnabledCheckBox.IsEnabled = true;
            }

            foreach (var item in _ReceiptItem)
            {
                item.IsEditMode = true;
            }
        }

        private void ExitEditMode()
        {
            IsEditMode = false;
            EditSaveButton.Content = "編集";

            ItemNameBox.IsReadOnly = true;
            ItemNameBox.IsEnabled = false;
            ItemCodeBox.IsReadOnly = true;
            ItemCodeBox.IsEnabled = false;

            LocationNameBox.IsReadOnly = true;
            LocationNameBox.IsEnabled = false;
            LocationCodeBox.IsReadOnly = true;
            LocationCodeBox.IsEnabled = false;
            LocationRemarkBox.IsReadOnly= true;
            LocationRemarkBox.IsEnabled = false;

            CountUnitComboBox.IsEnabled = false;
            WightUnitComboBox.IsEnabled = false;
            CategoryConboBox.IsEnabled = false;
            GradeBox.IsEnabled = false;
            SpecificGravityBox.IsEnabled = false;
            PackingStyleBox.IsEnabled = false;

            EditCancelButton.Visibility = Visibility.Collapsed;
            EditCancelButton.IsEnabled = false;
            if (MasterType == "品目マスタ＋項目設定マスタ")
            {
                ItemEnabledCheckBox.IsEnabled = false;
            }
            if (MasterType == "保管場所マスタ")
            {
                listView.IsEnabled = false;
                LocationEnabledCheckBox.IsEnabled = false;
            }

            if (MasterType == "タグマスタ")
            {
                TagStatusBox.IsEnabled = false;
                TagRemarkBox.IsReadOnly = true;
                TagEnabledCheckBox.IsEnabled = false;
            }
            foreach (var item in _ReceiptItem)
            {
                item.IsEditMode = false;
            }
        }

        //保存
        private void SaveEdit()
        {
            if (MasterType == "品目マスタ＋項目設定マスタ")
            {
                SaveItemMaster();
            }
            else if (MasterType == "保管場所マスタ")
            {
                SaveLocationMaster();
            }
            else if (MasterType == "タグマスタ")
            {
                SaveTagMaster();
            }
        }

        //品目マスタ＋項目設定マスタ
        private void SaveItemMaster()
        {

            using (var db = new AppDbContext())
            using (var tx = db.Database.BeginTransaction())
            {
                try
                {
                    var item = db.ItemTypes
                        .FirstOrDefault(x => x.Item_type_id == _currentItemTypeId);

                    if (item == null)
                    {
                        MessageBox.Show(Messages.ItemNotFound);
                        return;
                    }

                    var name = ItemNameBox.Text.Trim();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        MessageBox.Show(Messages.ItemNameRequired);
                        return;
                    }

                    int? categoryId = CategoryConboBox.SelectedValue as int?;
                    if (categoryId == null)
                    {
                        MessageBox.Show(Messages.ItemCategoryRequired);
                        return;
                    }

                    var now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    // ===== 基本情報更新 =====
                    item.Item_type_name = name;
                    item.Item_type_code = string.IsNullOrWhiteSpace(ItemCodeBox.Text) ? null : ItemCodeBox.Text.Trim();
                    item.Item_count_unit_id = CountUnitComboBox.SelectedValue as int?;
                    item.Item_weight_unit_id = WightUnitComboBox.SelectedValue as int?;
                    item.Item_category_id = categoryId.Value;
                    item.Grade = string.IsNullOrWhiteSpace(GradeBox.Text) ? null : GradeBox.Text.Trim();
                    item.Specific_gravity = string.IsNullOrWhiteSpace(SpecificGravityBox.Text) ? null : SpecificGravityBox.Text.Trim();
                    item.Packing_type = string.IsNullOrWhiteSpace(PackingStyleBox.Text) ? null : PackingStyleBox.Text.Trim();
                    item.Is_active = ItemEnabledCheckBox.IsChecked == true ? 1 : 0;
                    item.Updated_at = now;

                    // ===== 可変項目更新 =====
                    var oldSettings = db.ItemTypeFieldSettings
                        .Where(x => x.Item_type_id == _currentItemTypeId);

                    db.ItemTypeFieldSettings.RemoveRange(oldSettings);

                    var fields = db.FieldMasters.ToList();

                    foreach (var r in _ReceiptItem)
                    {
                        var field = fields.FirstOrDefault(f => f.Field_name == r.Name);
                        if (field == null) continue;

                        db.ItemTypeFieldSettings.Add(new ItemTypeFieldSetting
                        {
                            Item_type_id = _currentItemTypeId,
                            Field_id = field.Field_id,
                            Is_visible = r.表示 ? 1 : 0,
                            Is_required = r.必須 ? 1 : 0,
                            Created_at = now,
                            Updated_at = now,
                        });
                    }

                    db.SaveChanges();
                    tx.Commit();
                    UpdatedAtText.Text = now;

                    var main = Window.GetWindow(this) as MainWindow;
                    main?.MasterMagamentScreenControl.LoadItems();
                    ExitEditMode();

                    MessageBox.Show(Messages.DbUpdateSuccess);
                }
                catch (DbUpdateException e)
                {
                    tx.Rollback();
                    MessageBox.Show(Messages.DbSaveFailed);
                }
                catch (Exception e)
                {
                    tx.Rollback();
                    MessageBox.Show(Messages.UnexpectedError);
                }
            }
        }

        //保管場所マスタ
        private void SaveLocationMaster()
        {
            try
            {
                using (var db = new AppDbContext())
                {
                    var location = db.Locations
                        .FirstOrDefault(x => x.Location_id == _currentItemTypeId);

                    if (location == null)
                    {
                        MessageBox.Show(Messages.LocationNotFound);
                        return;
                    }

                    if (string.IsNullOrWhiteSpace(LocationNameBox.Text))
                    {
                        MessageBox.Show(Messages.LocationNameRequired);
                        return;
                    }

                    location.Location_name = LocationNameBox.Text.Trim();
                    location.Location_code = string.IsNullOrWhiteSpace(LocationCodeBox.Text) ? null : LocationCodeBox.Text.Trim();
                    location.Memo = string.IsNullOrWhiteSpace(LocationRemarkBox.Text) ? null : LocationRemarkBox.Text.Trim();
                    location.Is_active = LocationEnabledCheckBox.IsChecked == true ? 1 : 0;
                    location.Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    db.SaveChanges();

                    UpdatedAtText.Text = location.Updated_at;
                }
                var main = Window.GetWindow(this) as MainWindow;
                main?.MasterMagamentScreenControl.LoadLocations();

                ExitEditMode();

                MessageBox.Show(Messages.DbUpdateSuccess);
            } 
            catch (DbUpdateException e)
            {
                MessageBox.Show(Messages.DbSaveFailed);
            }
            catch (Exception e)
            {
                MessageBox.Show(Messages.UnexpectedError);
            }

        }

        //タグマスタ
        private void SaveTagMaster()
        {
            using (var db = new AppDbContext())
            {
                var tag = db.Tags
                            .FirstOrDefault(x => x.Tag_id == _currentItemTypeId);

                if (tag == null)
                {
                    MessageBox.Show("タグデータが見つかりません");
                    return;
                }

                bool? currentCheckState = TagEnabledCheckBox.IsChecked;

                // ===============================
                // CheckBox 状態変化時の TagHistory 追加
                // ===============================
                if (_beforeCheckState != currentCheckState)
                {
                    int tagEventId;

                    if (currentCheckState == true)
                    {
                        // チェック ON（有効化）
                        tagEventId = 4; // 有効イベントID
                        tag.Tag_status_id = 4;
                    }
                    else
                    {
                        // チェック OFF（前の状態へ戻す）
                        tagEventId = GetPreviousTagEventId(db, tag.Tag_id);
                        tag.Tag_status_id = tagEventId;
                    }

                    tag.Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    db.TagHistories.Add(new TagHistory
                    {
                        Tag_id = tag.Tag_id,
                        Ledger_item_id = tag.Ledger_item_id, // null 可
                        Tag_event_id = tagEventId,
                        Occured_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    });
                }

                db.SaveChanges();

                // 保存後にステータス表示更新
                var status = db.TagStatusTypes
                                .FirstOrDefault(s => s.Tag_status_id == tag.Tag_status_id);
                TagStatusBox.Text = status != null ? status.Status_name : "未設定";
                TagUpdatedAtText.Text = tag.Updated_at;
            }

            var main = Window.GetWindow(this) as MainWindow;
            main?.MasterMagamentScreenControl.LoadTags();
            ExitEditMode();
            MessageBox.Show("更新しました");
        }

        //補助
        public class TagHistoryViewModel
        {
            public string EventDateTime { get; set; }
            public string EventName { get; set; }
        }

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

    }
}
