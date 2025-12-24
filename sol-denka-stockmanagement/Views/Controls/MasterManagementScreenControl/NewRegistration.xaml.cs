using MaterialDesignThemes.Wpf;
using Microsoft.EntityFrameworkCore;
using sol_denka_stockmanagement.Commons;
using sol_denka_stockmanagement.Database;
using sol_denka_stockmanagement.Models;
using sol_denka_stockmanagement.Views.Dialogs;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace sol_denka_stockmanagement.Views.Controls.MasterManagementScreenControl
{
    /// <summary>
    /// NewRegistration.xaml の相互作用ロジック
    /// </summary>
    public partial class NewRegistration : UserControl
    {
        public ObservableCollection<ReceiptItem> _ReceiptItem { get; set; }
        public string MasterType { get; set; }

        public NewRegistration()
        {
            InitializeComponent();

            _ReceiptItem = new ObservableCollection<ReceiptItem>
            {
                new ReceiptItem{ Name="重量" },         // 重量
                new ReceiptItem{ Name="長さ" },         // 長さ
                new ReceiptItem{ Name="厚さ" },      // 厚さ
                new ReceiptItem{ Name="巾" },          // 巾
                new ReceiptItem{ Name="数量" },       // 数量
                new ReceiptItem{ Name="巻取機" },         // 巻取機
                new ReceiptItem{ Name="発生理由" }, // 発生理由
                new ReceiptItem{ Name="Lot No" },
                new ReceiptItem{ Name="発生日時" },
                new ReceiptItem{ Name="処理日時" },
            };

            DataContext = this;
            LoadUnits();
        }

        //戻るボタン押下時の処理
        private async void BackPage_Click(object sender, RoutedEventArgs e)
        {
            ConfirmDiscardClearAndBack();
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
            main.NewRegistration.Visibility = Visibility.Collapsed;
        }

        private void Check_button(object sender, RoutedEventArgs e)
        {
            Dispatcher.InvokeAsync(async () =>
            {
                var result = await DialogHost.Show(new CompletionDialog()) ?? "";
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

        private void LoadUnits()
        {
            using (var db = new AppDbContext())
            {
                WightUnitComboBox.ItemsSource = BuildUnitOptions(db, UnitCategory.Weight);
                CountUnitComboBox.ItemsSource = BuildUnitOptions(db, UnitCategory.Count);

                var categories = db.ItemCatetories.ToList();
                CategoryConboBox.ItemsSource = categories;
            }
        }

        private List<UnitOption> BuildUnitOptions(AppDbContext db, UnitCategory category)
        {
            var units = db.ItemUnits
                .Where(u => u.Unit_category == (int)category)
                .Select(u => new UnitOption { 
                    Id = u.Item_unit_id,
                    Code = u.Item_unit_code
                }).ToList();

            units.Insert(0, new UnitOption { Id = null, Code = "未選択" });
            return units;
        }

        /// <summary>
        /// 登録ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (MasterType == "品目マスタ＋項目設定マスタ")
            {
                RegisterItemMaster();   // ← 品目マスタの登録処理
            }
            else if (MasterType == "保管場所マスタ")
            {
                RegisterLocationMaster();   // ← 保管場所マスタの登録処理
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            ConfirmDiscardClearAndBack();
        }

        private void ConfirmDiscardClearAndBack()
        {
            if (!HasAnyInputByMasterType())
            {
                ClearByMaterType();
                BackToPreviousScreen();
                return;
            }

            var result = MessageBox.Show(
                Messages.DiscardAndBackConfirm,
                Messages.ConfirmTitle,
                MessageBoxButton.YesNo,
                MessageBoxImage.Question
            );

            if (result != MessageBoxResult.Yes) return;

            ClearByMaterType();
            BackToPreviousScreen();
        }

        private bool HasAnyInputByMasterType()
        {
            if (MasterType == "品目マスタ＋項目設定マスタ")
            {
                return HasAnyInputItemType();
            }
            else if (MasterType == "保管場所マスタ")
            {
                return HasAnyInputLocation();
            }

            return false;
        }

        //private bool HasAnyInputItemType()

        private bool HasAnyInputItemType()
        {
            return HasAnyText(
                    ItemNameBox,
                    ItemCodeBox,
                    GradeBox,
                    SpecificGravityBox,
                    PackingStyleBox)
                || HasAnySelected(
                    CategoryConboBox,
                    CountUnitComboBox,
                    WightUnitComboBox
                );
        }

        private bool HasAnyInputLocation()
        {
            return HasAnyText(
                    LocationNameBox,
                    LocationCodeBox,
                    LocationMemoBox
                );
        }

        private bool HasAnyText(params TextBox[] boxes)
        {
            return boxes.Any(box => !string.IsNullOrWhiteSpace(box.Text));
        }

        private bool HasAnySelected(params Selector[] selectors)
        {
            return selectors.Any(selector => selector.SelectedValue != null);
        }


        private void ClearByMaterType()
        {
            if (MasterType == "品目マスタ＋項目設定マスタ")
            {
                ClearItemInputFields();
            }
            else if (MasterType == "保管場所マスタ")
            {
                ClearLocationInputFields();
            }
        }

        private void RegisterItemMaster()
        {
            // 必須チェック
            string name = ItemNameBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("品目名を入力してください。");
                return;
            }

            int? categoryId = CategoryConboBox.SelectedValue as int?;
            if (categoryId == null)
            {
                MessageBox.Show("区分を選択してください。");
                return;
            }

            string? code = string.IsNullOrWhiteSpace(ItemCodeBox.Text) ? null : ItemCodeBox.Text.Trim();
            string? grade = string.IsNullOrWhiteSpace(GradeBox.Text) ? null : GradeBox.Text.Trim();
            string? specificGravity = string.IsNullOrWhiteSpace(SpecificGravityBox.Text) ? null : SpecificGravityBox.Text.Trim();
            string? packingStyle = string.IsNullOrWhiteSpace(PackingStyleBox.Text) ? null : PackingStyleBox.Text.Trim();
            int? countUnitId = CountUnitComboBox.SelectedValue as int?;
            int? weightUnitId = WightUnitComboBox.SelectedValue as int?;

            var now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            var newItem = new ItemType
            {
                Item_type_name = name,
                Item_type_code = code,
                Item_count_unit_id = countUnitId,
                Item_weight_unit_id = weightUnitId,
                Item_category_id = categoryId.Value,
                Grade = grade,
                Specific_gravity = specificGravity,
                Packing_type = packingStyle,
                Is_active = 1,
                Created_at = now,
                Updated_at = now,
            };

            using (var db = new AppDbContext())
            using (var tx = db.Database.BeginTransaction())
            {
                try
                {
                    // 品目テーブルへの挿入
                    db.ItemTypes.Add(newItem);
                    db.SaveChanges();

                    // 項目設定テーブルへの挿入
                    var fields = db.FieldMasters.ToList();
                    foreach (var obj in listView.Items)
                    {

                        var field = obj as ReceiptItem;
                        if (field == null) continue;

                        // FieldMaster から Field_id を取得
                        var fm = fields.FirstOrDefault(x => x.Field_name == field.Name);
                        if (fm == null) continue; // 一致しない場合スキップ

                        var setting = new ItemTypeFieldSetting
                        {
                            Item_type_id = newItem.Item_type_id,
                            Field_id = fm.Field_id,
                            Is_visible = field.表示 ? 1 : 0,
                            Is_required = field.必須 ? 1 : 0,
                            Created_at = now,
                            Updated_at = now,
                        };

                        db.ItemTypeFieldSettings.Add(setting);
                    }

                    var memoFieldId = fields.FirstOrDefault(x => x.Field_name == "備考")!.Field_id;
                    db.ItemTypeFieldSettings.Add(new ItemTypeFieldSetting
                    {
                        Item_type_id = newItem.Item_type_id,
                        Field_id = memoFieldId,
                        Is_visible = 1,
                        Is_required = 0,
                        Created_at = now,
                        Updated_at = now,
                    });

                    var locationFieldId = fields.FirstOrDefault(x => x.Field_name == "保管場所")!.Field_id;
                    db.ItemTypeFieldSettings.Add(new ItemTypeFieldSetting
                    {
                        Item_type_id = newItem.Item_type_id,
                        Field_id = locationFieldId,
                        Is_visible = 1,
                        Is_required = 1,
                        Created_at = now,
                        Updated_at = now,
                    });

                    db.SaveChanges();
                    tx.Commit();

                    MessageBox.Show("完了しました");

                    var main = Window.GetWindow(this) as MainWindow;
                    if (main != null)
                    {
                        main.MasterMagamentScreenControl.AddNewItem(new Item
                        {
                            Id = newItem.Item_type_id,
                            Name = newItem.Item_type_name,
                            Code = newItem.Item_type_code,
                        });
                    }
                    ClearItemInputFields();
                }
                catch (DbUpdateException ex)
                {
                    tx.Rollback();

                    MessageBox.Show(Messages.DbSaveFailed);
                    string error = $"[ERROR] {ex.Message}";
                    if (ex.InnerException != null)
                    {
                        error += $"\n[INNER] {ex.InnerException.Message}";
                    }
                    // クリップボードにコピー
                    Clipboard.SetText(error);
                    
                    // ログ出力実装
                }
                catch (Exception ex)
                {
                    tx.Rollback();

                    MessageBox.Show(Messages.UnexpectedError);
                    string error = $"[ERROR] {ex.Message}";
                    if (ex.InnerException != null)
                    {
                        error += $"\n[INNER] {ex.InnerException.Message}";
                    }
                    // クリップボードにコピー
                    Clipboard.SetText(error);

                    // ログ出力実装
                }
            }
        }

        private void ClearItemInputFields()
        {
            ItemNameBox.Text = "";
            ItemCodeBox.Text = "";
            CountUnitComboBox.SelectedIndex = -1;
            WightUnitComboBox.SelectedIndex = -1;
            CategoryConboBox.SelectedIndex = -1;
            GradeBox.Text = "";
            SpecificGravityBox.Text = "";
            PackingStyleBox.Text = "";
            ItemMemoBox.Text = "";
            foreach (var item in listView.Items)
            {
                if (item is ReceiptItem r)
                {
                    r.表示 = false;
                    r.任意 = true;
                    r.必須 = false;
                }  
            }
            // ListView を更新
            listView.Items.Refresh();
        }

        private void RegisterLocationMaster()
        {
            string locationName = LocationNameBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(locationName))
            {
                MessageBox.Show(Messages.LocationNameRequired);
            }

            string? locationCode = string.IsNullOrWhiteSpace(LocationCodeBox.Text) ? null : LocationCodeBox.Text.Trim();
            string? memo = string.IsNullOrWhiteSpace(LocationMemoBox.Text) ? null : LocationMemoBox.Text.Trim();
            var now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            var location = new Location
            {
                Location_name = locationName,
                Location_code = locationCode,
                Memo = memo,
                Is_active = 1,
                Created_at = now,
                Updated_at = now,
            };

            try
            {
                using (var db = new AppDbContext())
                {
                    db.Locations.Add(location);
                    db.SaveChanges();
                }

                MessageBox.Show(Messages.LocationRegistered);

                var main = Window.GetWindow(this) as MainWindow;
                if (main != null)
                {
                    main.MasterMagamentScreenControl.AddNewLocation(new Item
                    {
                        Id = location.Location_id,
                        Name = location.Location_name,
                        Code = location.Location_code,
                        Note = location.Memo
                    });
                }
                ClearLocationInputFields();
            }
            catch(DbUpdateException ex)
            {
                MessageBox.Show(Messages.DbSaveFailed);
                // ログ出力実装
            }
            catch (Exception ex)
            {
                MessageBox.Show(Messages.UnexpectedError);
                // ログ出力実装
            }
        }

        private void ClearLocationInputFields()
        {
            LocationNameBox.Text = "";
            LocationCodeBox.Text = "";
            LocationMemoBox.Text = "";
        }

        public void SetMasterType(string masterType)
        {
            MasterType = masterType;

            // まず全て非表示にする
            ItemRegistration.Visibility = Visibility.Collapsed;
            LocationRegistration.Visibility = Visibility.Collapsed;

            if (MasterType == "品目マスタ＋項目設定マスタ")
            {
                ItemRegistration.Visibility = Visibility.Visible;
                LocationRegistration.Visibility = Visibility.Collapsed;
            }
            else if (MasterType == "保管場所マスタ")
            {
                LocationRegistration.Visibility = Visibility.Visible;
                ItemRegistration.Visibility = Visibility.Collapsed;
            }
        }
    }
}
