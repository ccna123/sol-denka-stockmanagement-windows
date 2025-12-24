using Microsoft.EntityFrameworkCore;
using sol_denka_stockmanagement.Database;
using sol_denka_stockmanagement.Models;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;

namespace sol_denka_stockmanagement.Views.Controls
{
    public class ShareViewModel
    {
        private static ShareViewModel _instance;
        public static ShareViewModel Instance => _instance ??= new ShareViewModel();

        // 取得したCSVからデータを抽出
        public async Task ImportCsvToDbAsync(string filePath)
        {
            if (!File.Exists(filePath)) return;

            string fileName = Path.GetFileName(filePath);

            var lines = File.ReadAllLines(filePath); // CSVの中身を取得

            using (var db = new AppDbContext())
            {
                // ファイル単位でタスクコードを決める
                string taskCode = GetCsvTaskCodeFromFileName(fileName);
                if (taskCode == null) return;

                // CsvTaskType 登録
                var taskType = db.CsvTaskTypes.FirstOrDefault(x => x.Csv_task_code == taskCode);
                if (taskType == null)
                {
                    taskType = new CsvTaskType
                    {
                        Csv_task_code = taskCode,
                        Csv_task_name = GetTaskName(taskCode),
                        Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    };
                    db.CsvTaskTypes.Add(taskType);
                    await db.SaveChangesAsync();
                }

                // CsvHistory 登録
                var history = new CsvHistory
                {
                    Csv_task_type_id = taskType.Csv_task_type_id,
                    File_name = fileName,
                    Direction = "IMPORT",
                    Target = "Android",
                    Result = "SUCCESS",
                    Recode_num = lines.Length,
                    Error_message = "",
                    Device_id = "Android_ID",
                    Executed_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                };
                db.CsvHistories.Add(history);
                await db.SaveChangesAsync();

                //CSVによって格納する先を切り替える
                switch (taskCode)
                {
                    //入庫
                    case "IN":
                        await ImportInboundCsv(db, filePath);
                        break;
                    //出庫
                    case "OUT":
                        await ImportOutboundCsv(db, filePath);
                        break;
                    //保管場所
                    case "Location":
                        await ImportLocationCsv(db, filePath);
                        break;
                    //品目
                    case "Item":
                        await ImportItemCsv(db, filePath);
                        break;
                    //品目単位
                    case "ItemUnit":
                        await ImportItemUnitCsv(db, filePath);
                        break;
                    //タグ
                    case "Tag":
                        await ImportTagCsv(db, filePath);
                        break;
                    default:
                        MessageBox.Show($"未対応のCSVタスク:{taskCode}");
                        break;
                } 
            }
        }

        /// <summary>
        /// 正式なファイル名 → タスクコード の判定処理
        /// </summary>
        private string GetCsvTaskCodeFromFileName(string fileName)
        {
            fileName = fileName.ToLower();

            if (fileName.Contains("inbound_result")) return "IN";
            if (fileName.Contains("outbound_result")) return "OUT";
            if (fileName.Contains("inventory_result")) return "INVENTORY";
            if (fileName.Contains("location_change_result")) return "LOCATION_CHANGE";

            if (fileName.Contains("item_type_master")) return "Item";
            if (fileName.Contains("field_master")) return "Field";
            if (fileName.Contains("field_setting_master")) return "Field-Setting";
            if (fileName.Contains("location_master")) return "Location";
            if (fileName.Contains("tag_master")) return "Tag";
            if (fileName.Contains("ledger_item_master")) return "Ledger";
            if (fileName.Contains("item_unit_master")) return "ItemUnit";

            return null;
        }

        /// <summary>
        /// タスクコードに対応する名称を返す
        /// </summary>
        private string GetTaskName(string taskCode)
        {
            return taskCode switch
            {
                "IN" => "入庫",
                "OUT" => "出庫",
                "INVENTORY" => "棚卸",
                "LOCATION_CHANGE" => "保管場所変更",

                "Item" => "品目",
                "Field" => "項目",
                "Field-Setting" => "品目項目設定",
                "Location" => "保管場所",
                "Tag" => "タグ",
                "Ledger" => "台帳アイテム",
                "ItemUnit" => "単位",
                _ => "Unknown"
            };
        }

        /// <summary>
        /// 入庫結果CSV　取得時処理
        /// </summary>
        /// <param name="db"></param>
        /// <param name="lines"></param>
        /// <returns></returns>
        private async Task ImportInboundCsv(AppDbContext db, string filePath)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines.Skip(1))
                {
                    // ===== CSV 分割 =====
                    var cols = line.Split(',');

                    // ===== 列数チェック（必須）=====
                    if (cols.Length < 16)
                    {
                        MessageBox.Show(
                            $"CSV列数不足:\n{line}",
                            "CSVエラー",
                            MessageBoxButton.OK,
                            MessageBoxImage.Warning
                        );
                        continue;
                    }

                    int tagId = ParseInt(cols[0]);
                    int itemTypeId = ParseInt(cols[1]);
                    int locationId = ParseInt(cols[2]);
                    int winderId = ParseInt(cols[3]);

                    // ===== Tag 取得 =====
                    var existingTag = await db.Tags.FirstOrDefaultAsync(t => t.Tag_id == tagId);

                    // ===== マスタ存在チェック =====
                    if (!db.ItemTypes.Any(i => i.Item_type_id == itemTypeId))
                        throw new Exception($"ItemType not found: {itemTypeId}");

                    if (!db.Locations.Any(l => l.Location_id == locationId))
                        throw new Exception($"Location not found: {locationId}");

                    if (!db.Winders.Any(w => w.Winder_id == winderId))
                        winderId = 8; // その他

                    // ===== LedgerItem 登録 =====
                    var item = new LedgerItem
                    {
                        Item_type_id = itemTypeId,
                        Location_id = locationId,
                        Winder_id = winderId,
                        Is_in_stock = 1,
                        Weight = ParseInt(cols[5]),
                        Width = ParseInt(cols[6]),
                        Length = ParseInt(cols[7]),
                        Thickness = ParseInt(cols[8]),
                        Lot_no = cols[9],
                        Occurrence_reason = cols[10],
                        Quantity = ParseInt(cols[11]),
                        Memo = cols[12],
                        Is_active = 1,
                        Occurred_at = NormalizeDateTimeString(cols[13]),
                        Processed_at = NormalizeDateTimeString(cols[14]),
                        Registered_at = NormalizeDateTimeString(cols[15]),
                        Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    };

                    db.LedgerItems.Add(item);
                    await db.SaveChangesAsync(); // PK確定

                    // ===== Tag 更新（INSERTしない）=====
                    existingTag.Ledger_item_id = item.Ledger_item_id;
                    existingTag.Tag_status_id = 2;
                    existingTag.Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    existingTag.Is_active = 1;
                    await db.SaveChangesAsync();

                    // ===== LedgerItemEvent ====
                    var events = new LedgerItemEvent
                    {
                        Ledger_item_id = item.Ledger_item_id,
                        Event_type_id = 1,
                        Location_id = item.Location_id,
                        Occurred_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Registered_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Memo = "入庫",
                    };
                    db.LedgerItemEvents.Add(events);
                    await db.SaveChangesAsync();

                    // ===== Tag History 更新　======
                    var taghistory = new TagHistory
                    {
                        Tag_id = tagId,
                        Ledger_item_id = item.Ledger_item_id,
                        Tag_event_id = 2,
                        Occured_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                    };
                    db.TagHistories.Add(taghistory);
                    await db.SaveChangesAsync();

                    // Stock
                    var now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    var ledgerGroups = db.LedgerItems
                        .Where(x => x.Is_active == 1)
                        .GroupBy(x => new { x.Item_type_id, x.Location_id })
                        .Select(g => new
                        {
                            ItemTypeId = g.Key.Item_type_id,
                            LocationId = g.Key.Location_id,

                            
                            Quantity = g.Select(x => x.Weight ?? 0).FirstOrDefault(),
                            TotalQuantity = g.Select(x => (x.Weight ?? 0) * (x.Quantity ?? 0)).FirstOrDefault()

                        })
                        .ToList();

                    foreach (var g in ledgerGroups)
                    {
                        var stock = db.Stocks.FirstOrDefault(s =>
                            s.Item_type_id == g.ItemTypeId &&
                            s.Location_id == g.LocationId);

                        if (stock == null)
                        {
                            stock = new Stock
                            {
                                Item_type_id = g.ItemTypeId,
                                Location_id = g.LocationId,
                                Quantity = g.Quantity,
                                Total_quantity = g.TotalQuantity,
                                Created_at = now,
                                Updated_at = now
                            };

                            db.Stocks.Add(stock);
                        }
                    }

                    await db.SaveChangesAsync();
                }

                MessageBox.Show(
                    "CSV取込処理が完了しました。",
                    "完了",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information
                );
            }
            catch (Exception ex)
            {
                var errorText =
                    "CSV取込中にエラーが発生しました。\n\n" +
                    ex.ToString(); // ★ これが超重要

                Clipboard.SetText(errorText);

                MessageBox.Show(
                    errorText + "\n\n※内容はクリップボードにコピーされています。",
                    "致命的エラー",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }


        }

        //出庫
        private async Task ImportOutboundCsv(AppDbContext db, string filePath)
        {
            try
            {
                var lines = File.ReadAllLines(filePath);

                foreach (var line in lines.Skip(1))
                {
                    var cols = line.Split(',');

                    int ledgerItemId = ParseInt(cols[0]);
                    int tagId = ParseInt(cols[1]);
                    int processTypeId = ParseInt(cols[2]);
                    string deviceId = cols[3];
                    string memo = cols[4];
                    string processedAt = NormalizeDateTimeString(cols[5]);
                    string registeredAt = NormalizeDateTimeString(cols[6]);

                    // --- LedgerItem 取得 ---
                    var ledgerItem = await db.LedgerItems
                        .FirstOrDefaultAsync(x => x.Ledger_item_id == ledgerItemId);

                    if (ledgerItem == null)
                        throw new Exception($"LedgerItem not found: {ledgerItemId}");

                    // --- 出庫更新 ---
                    ledgerItem.Is_in_stock = 0;
                    ledgerItem.Is_active = 0;
                    ledgerItem.Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    ledgerItem.Quantity = 0;
                    ledgerItem.Weight = 0;

                    // --- Tag 更新 ---
                    var tag = await db.Tags.FirstOrDefaultAsync(t => t.Tag_id == tagId);
                    if (tag == null)
                        throw new Exception($"Tag not found: {tagId}");

                    tag.Is_active = 0;
                    tag.Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    // --- LedgerItemEvent ---
                    var ledgerEvent = new LedgerItemEvent
                    {
                        Ledger_item_id = ledgerItemId,
                        Event_type_id = 2,
                        Process_type_id = processTypeId,
                        Location_id = ledgerItem.Location_id,
                        Occurred_at = processedAt,
                        Registered_at = registeredAt,
                        Memo = "出庫"
                    };
                    db.LedgerItemEvents.Add(ledgerEvent);

                    // --- TagHistory ---
                    var tagHistory = new TagHistory
                    {
                        Tag_id = tagId,
                        Ledger_item_id = ledgerItemId,
                        Tag_event_id = 2,
                        Occured_at = registeredAt
                    };
                    db.TagHistories.Add(tagHistory);

                    await db.SaveChangesAsync();
                }

                MessageBox.Show("出庫CSVの取込が完了しました");
            }
            catch (Exception ex)
            {
                Clipboard.SetText(ex.ToString());

                MessageBox.Show(
                    ex.ToString() + "\n\n※内容はクリップボードにコピーされています。",
                    "出庫CSVエラー",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }


        //保管場所
        private async Task ImportLocationCsv(AppDbContext db, string filePath)
        {
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines.Skip(1))
            {
                var cols = line.Split(',');

                var item = new Location
                {
                    Location_code = cols[0],
                    Location_name = cols[1],
                    Is_active = 1,
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                };
                db.Locations.Add(item);
            }

            await db.SaveChangesAsync();
            MessageBox.Show("完了しました");
        }

        //アイテム単位
        private async Task ImportItemUnitCsv(AppDbContext db, string filePath)
        {
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines.Skip(1))
            {
                var cols = line.Split(',');

                var item = new ItemUnit
                {
                    Item_unit_code = cols[0],
                    Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                };
                db.ItemUnits.Add(item);
            }
            await db.SaveChangesAsync();
            MessageBox.Show("完了しました");
        }

        //品目
        private async Task ImportItemCsv(AppDbContext db, string filePath)
        {
            try
            {
                var lines = File.ReadAllLines(filePath, Encoding.GetEncoding("shift_jis"));

                foreach (var line in lines.Skip(1))
                {
                    var cols = line.Split(',');
                    string itemCode = cols[0];
                    string itemName = cols[1];

                    var item = new ItemType
                    {
                        Item_type_code = itemCode,
                        Item_type_name = itemName,
                        Is_active = 1,
                        Created_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        Updated_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    };

                    db.ItemTypes.Add(item);
                }

                //await db.SaveChangesAsync();
                MessageBox.Show("完了しました");
            }
            catch (Exception ex)
            {
                string errorText = $"【メッセージ】{ex.Message}\n【詳細】{ex.StackTrace}";

                // クリップボードにコピー
                Clipboard.SetText(errorText);

                MessageBox.Show(
                    "エラー内容をクリップボードにコピーしました。\nそのまま貼り付けできます。",
                    "例外エラー",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        //アイテム単位
        private async Task ImportTagCsv(AppDbContext db, string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            int row = 1;

            try
            {
                foreach (var line in lines)
                {
                    try
                    {
                        var cols = line.Split(',');

                        int? ledgerItemId = null;
                        if (ledgerItemId == 0) ledgerItemId = null;

                        int tagStatusId = 1;
                        int tagEventId = 1;

                        // --- マスタチェック ---
                        if (!db.TagStatusTypes.Any(ts => ts.Tag_status_id == tagStatusId))
                            throw new Exception($"TagStatusType not found: {tagStatusId}");

                        if (!db.TagEventTypes.Any(te => te.Tag_event_id == tagEventId))
                            throw new Exception($"TagEventType not found: {tagEventId}");

                        var now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        // --- Tag ---
                        var tag = new Tag
                        {
                            Ledger_item_id = ledgerItemId,
                            Tag_status_id = tagStatusId,
                            Epc = cols[0],
                            Is_active = 1,
                            Created_at = now,
                            Updated_at = now,
                        };
                        db.Tags.Add(tag);
                        await db.SaveChangesAsync();

                        // --- Tag history ---
                        var taghistory = new TagHistory
                        {
                            Tag_id = tag.Tag_id,
                            Ledger_item_id = tag.Ledger_item_id,
                            Tag_event_id = tagEventId,
                            Occured_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        };
                        db.TagHistories.Add(taghistory);
                        await db.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"【DBエラー】\n行番号: {row}\n内容: {line}\n詳細: {ex.Message}",
                            "Tag CSV エラー",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error
                        );
                        return;
                    }

                    row++;
                }

                MessageBox.Show("完了しました");
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"致命的エラー:\n{ex.Message}",
                    "エラー",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }

        // --- 補助 ---
        private int ParseInt(string value)
        {
            return int.TryParse(value, out int result) ? result : 0;
        }

        private string NormalizeDateTimeString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (DateTime.TryParse(value.Trim(), out var dt))
                return dt.ToString("yyyy-MM-dd HH:mm:ss");

            // 変換できない場合（保険）
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

    }
}