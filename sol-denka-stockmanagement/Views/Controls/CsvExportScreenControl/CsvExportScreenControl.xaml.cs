using Microsoft.EntityFrameworkCore;
using sol_denka_stockmanagement.Database;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace sol_denka_stockmanagement.Views.Controls.CsvExportScreenControl
{
    public partial class CsvExportScreenControl : UserControl
    {
        public CsvExportScreenControl()
        {
            InitializeComponent();

            Style btnStyle = (Style)FindResource("ButtonStyle");
            Button.Style = btnStyle;
        }

        private async void Check_button(object sender, RoutedEventArgs e)
        {
            bool isAnyChecked = false;

            if (ItemMasterCheckBox.IsChecked == true)
            {
                ExportItemMaster();
                isAnyChecked = true;
            }

            if (ItemSettingMasterCheckBox.IsChecked == true)
            {
                ExportItemSettingMaster();
                isAnyChecked = true;
            }

            if (StorageMasterCheckBox.IsChecked == true)
            {
                ExportStorageMaster();
                isAnyChecked = true;
            }

            if (TagMasterCheckBox.IsChecked == true)
            {
                ExportTagMaster();
                isAnyChecked = true;
            }

            if (LedgerMasterCheckBox.IsChecked == true)
            {
                ExportLedgerMaster();
                isAnyChecked = true;
            }

            if (!isAnyChecked)
            {
                MessageBox.Show("出力対象を選択してください。", "警告",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            ClearCheckBoxes();

            MessageBox.Show("CSV出力が完了しました。", "完了",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // ===============================
        // 品目マスター
        // ===============================
        private void ExportItemMaster()
        {
            string dir = @"C:\DenkaStockManagement\Export\ItemTypeMaster";
            Directory.CreateDirectory(dir);

            string path = Path.Combine(
                dir,
                $"item_type_master_{DateTime.Now:yyyyMMdd_HHmmss_fff}.csv");

            var lines = new List<string>
            {
                "品目ID,品目コード,品目名,数量単位ID,重量単位ID,品目区分ID,比重,グレード,荷姿"
            };

            using (var db = new AppDbContext())
            {
                foreach (var item in db.ItemTypes)
                {
                    lines.Add($"{item.Item_type_id},{item.Item_type_code},{item.Item_type_name}," +
                              $"{item.Item_count_unit_id},{item.Item_weight_unit_id},{item.Item_category_id}," +
                              $"{item.Specific_gravity},{item.Grade},{item.Packing_type}");
                }
            }

            File.WriteAllLines(path, lines, Encoding.UTF8);
        }

        // ===============================
        // 項目設定マスター
        // ===============================
        private void ExportItemSettingMaster()
        {
            string dir = @"C:\DenkaStockManagement\Export\ItemTypeFieldSettingMaster";
            Directory.CreateDirectory(dir);

            string path = Path.Combine(
                dir,
                $"field_setting_master_{DateTime.Now:yyyyMMdd_HHmmss_fff}.csv");

            var lines = new List<string>
            {
                "品目ID,項目ID,必須/任意,表示/非表示"
            };

            using (var db = new AppDbContext())
            {
                foreach (var item in db.ItemTypeFieldSettings)
                {
                    lines.Add($"{item.Item_type_id},{item.Field_id},{item.Is_required},{item.Is_visible}");
                }
            }

            File.WriteAllLines(path, lines, Encoding.UTF8);
        }

        // ===============================
        // 保管場所マスター
        // ===============================
        private void ExportStorageMaster()
        {
            string dir = @"C:\DenkaStockManagement\Export\LocationMaster";
            Directory.CreateDirectory(dir);

            string path = Path.Combine(
                dir,
                $"location_master_{DateTime.Now:yyyyMMdd_HHmmss_fff}.csv");

            var lines = new List<string>
            {
                "保管場所ID,保管場所コード,保管場所名"
            };

            using (var db = new AppDbContext())
            {
                foreach (var item in db.Locations)
                {
                    lines.Add($"{item.Location_id},{item.Location_code},{item.Location_name}");
                }
            }

            File.WriteAllLines(path, lines, Encoding.UTF8);
        }

        // ===============================
        // タグマスター
        // ===============================
        private void ExportTagMaster()
        {
            string dir = @"C:\DenkaStockManagement\Export\TagMaster";
            Directory.CreateDirectory(dir);

            string path = Path.Combine(
                dir,
                $"tag_master_{DateTime.Now:yyyyMMdd_HHmmss_fff}.csv");

            var lines = new List<string>
            {
                "タグID,タグステータス,EPC"
            };

            using (var db = new AppDbContext())
            {
                foreach (var item in db.Tags)
                {
                    lines.Add($"{item.Tag_id},{item.Tag_status_id},{item.Epc}");
                }
            }

            File.WriteAllLines(path, lines, Encoding.UTF8);
        }


        // ===============================
        // 台帳マスター
        // ===============================
        private void ExportLedgerMaster()
        {
            string dir = @"C:\DenkaStockManagement\Export\LedgerItemMaster";
            Directory.CreateDirectory(dir);

            string path = Path.Combine(
                dir,
                $"ledger_item_master_{DateTime.Now:yyyyMMdd_HHmmss_fff}.csv");

            var lines = new List<string>
{
    "台帳アイテムID,品目ID,保管場所ID,タグID,巻取機ID,在庫状況," +
    "重さ,巾,長さ,厚さ,Lot No,発生理由,数量,備考,発生日時,処理日時," +
    "登録日時,更新日時"
};


            using (var db = new AppDbContext())
            {
                var ledgerItems = db.LedgerItems
                    .Include(li => li.Tags)
                    .Include(li => li.Winder)
                    .ToList();

                foreach (var item in ledgerItems)
                {
                    var tagIdList = new List<string>();

                    foreach (var tag in item.Tags)
                    {
                        tagIdList.Add(tag.Tag_id.ToString());
                    }

                    var tagIds = string.Join(";", tagIdList);

                    lines.Add(
                        $"{item.Ledger_item_id}," +
                        $"{item.Item_type_id}," +
                        $"{item.Location_id}," +
                        $"{tagIds}," +
                        $"{item.Winder?.Winder_id}," +
                        $"{item.Is_in_stock}," +
                        $"{item.Weight}," +
                        $"{item.Width}" +
                        $"{item.Length}," +
                        $"{item.Thickness}," +
                        $"{item.Lot_no}," +
                        $"{item.Occurrence_reason}," +
                        $"{item.Quantity}," +
                        $"{item.Memo}," +
                        $"{item.Occurred_at}," +
                        $"{item.Processed_at}," +
                        $"{item.Registered_at}," +
                        $"{item.Updated_at}"
                    );
                }
            }


            File.WriteAllLines(path, lines, Encoding.UTF8);
        }

        // ===============================
        // チェックボックスの初期化
        // ===============================
        private void ClearCheckBoxes()
        {
            ItemMasterCheckBox.IsChecked = false;
            ItemSettingMasterCheckBox.IsChecked = false;
            StorageMasterCheckBox.IsChecked = false;
            TagMasterCheckBox.IsChecked = false;
            LedgerMasterCheckBox.IsChecked = false;
        }

    }
}
