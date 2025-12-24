using MaterialDesignThemes.Wpf;
using sol_denka_stockmanagement.Database;
using sol_denka_stockmanagement.Models;
using sol_denka_stockmanagement.Views.Dialogs;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace sol_denka_stockmanagement.Views.Controls.CsvImportScreenControl
{
    public partial class CsvImportScreenControl : UserControl
    {
        private ObservableCollection<CsvInputItem> _allItems = new ObservableCollection<CsvInputItem>(); // 元データ
        private int _pageSize = 10;
        private int _currentPage = 1;
        private int _totalPages;

        public CsvImportScreenControl()
        {
            InitializeComponent();
            EnsureImportFolders();

            //_allItems = new List<CsvInputItem>();

            _totalPages = (int)Math.Ceiling(_allItems.Count / (double)_pageSize);

        }

        private void EnsureImportFolders()
        {
            try
            {
                string baseImportPath = @"C:\DenkaStockManagement\Import";

                var required = new[]
                {
                    "inboundEvent",
                    "TagMaster",
                    "outboundEvent",
                    "LocationMaster"
                };

                Directory.CreateDirectory(baseImportPath);

                foreach (var name in required)
                {
                    var dir = Path.Combine(baseImportPath, name);
                    Directory.CreateDirectory(dir);
                }
            } 
            catch(Exception e) 
            {
                MessageBox.Show("フォルダ作成に失敗しました");
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            // 初期ページサイズ
            _pageSize = 3;
            pageSizeCombo.SelectedIndex = 1;

            _currentPage = 1;
            _totalPages = (int)Math.Ceiling(_allItems.Count / (double)_pageSize);

            // ボタンスタイル

            LoadCsvHistory();

            UpdateList();
            CreatePageButtons();
        }

        /// <summary>
        /// リストページ切り替え
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

        /// <summary>
        /// リストの更新
        /// </summary>
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
            AdjustColumnWidthsCommon(listView, true, 100);
        }

        private void AdjustColumnWidthsCommon(ListView listView, bool hasFixedLastColumn, double fixedWidth = 0)
        {
            if (listView.View is GridView gridView)
            {
                int columnCount = gridView.Columns.Count;
                if (columnCount == 0) return;

                double totalWidth = listView.ActualWidth - 5; // マージン調整
                int variableColumnCount = columnCount;

                int lastColumnIndex = columnCount - 1;

                // 右端列を固定幅にする場合
                if (hasFixedLastColumn && columnCount > 1)
                {
                    gridView.Columns[lastColumnIndex].Width = fixedWidth;
                    totalWidth -= fixedWidth;
                    variableColumnCount -= 1;
                }

                if (variableColumnCount <= 0) return;

                double columnWidth = totalWidth / variableColumnCount;

                for (int i = 0; i < lastColumnIndex; i++)
                {
                    gridView.Columns[i].Width = columnWidth;
                }
            }
        }

        private void Check_button(object sender, RoutedEventArgs e)
        {
            Dispatcher.InvokeAsync(async () =>
            {
                var result = await DialogHost.Show(new ProgressDialog()) ?? "";
            });
        }

        private async void FileSync_button(object sender, RoutedEventArgs e)
        {
            try
            {
                string baseImportPath = @"C:\DenkaStockManagement\Import";


                if (!Directory.Exists(baseImportPath))
                {
                    Directory.CreateDirectory(baseImportPath);
                    MessageBox.Show("CSVファイルが存在しません。");
                    return;
                }

                int importedCount = 0;

                using (var db = new AppDbContext())
                {
                    foreach (var folderPath in Directory.GetDirectories(baseImportPath))
                    {
                        foreach ( var filePath in Directory.GetFiles(folderPath, "*.csv"))
                        {
                            string fileName = Path.GetFileName(filePath);
                            string taskCode = GetCsvTaskCodeFromFileName(fileName);

                            if (taskCode == null) continue;

                            string expectedFolder = GetImportSubFolder(taskCode);

                            string actualFolder = new DirectoryInfo(folderPath).Name;

                            if (!string.Equals(actualFolder, expectedFolder, StringComparison.OrdinalIgnoreCase))
                            {
                                MessageBox.Show(
                                    $"CSV「{fileName}」は {expectedFolder} フォルダに配置してください。",
                                    "フォルダ不一致",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning
                                );
                                continue;
                            }

                            // ===== 既に取り込み済みCSVチェック =====
                            bool alreadyImported = db.CsvHistories
                                .Any(h => h.File_name == fileName);

                            if (alreadyImported)
                            {
                                MessageBox.Show(
                                    $"ファイル「{fileName}」はすでに格納されています。",
                                    "CSV重複",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning
                                );
                                continue;
                            }

                            bool hasTag = db.Tags.Any();
                            if (!hasTag && !fileName.Contains("tag_master", StringComparison.OrdinalIgnoreCase))
                            {
                                MessageBox.Show(
                                    $"タグの情報がありません。Tag_masterをいれてください",
                                    "ファイル名エラー",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning
                                );
                                return;
                            }

                            bool hasItemType = db.ItemTypes.Any();
                            bool hasLocation = db.Locations.Any();

                            if (!hasItemType || !hasLocation)
                            {
                                string message = "";

                                if (!hasItemType)
                                    message += "・ItemType マスタにデータが存在しません。\n";

                                if (!hasLocation)
                                    message += "・Location マスタにデータが存在しません。\n";

                                message += "\n先にマスタ登録を行ってください。";

                                MessageBox.Show(
                                    message,
                                    "マスタ不足",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Warning
                                );
                                return;
                            }

                            var lines = File.ReadAllLines(filePath);

                            // ===== すでに使用中チェック =====
                            if (taskCode == "Tag")
                            {
                                foreach (var line in lines.Skip(1))
                                {
                                    var cols = line.Split(',');
                                    int tagId = int.Parse(cols[0]);

                                    var existingTag = db.Tags.FirstOrDefault(t => t.Tag_id == tagId);

                                    if (existingTag != null &&
                                        existingTag.Ledger_item_id.HasValue &&
                                        existingTag.Ledger_item_id.Value != 0)
                                    {
                                        MessageBox.Show(
                                            $"タグID {tagId} はすでに他の在庫に紐づけられています。",
                                            "タグ重複",
                                            MessageBoxButton.OK,
                                            MessageBoxImage.Warning
                                        );
                                        return;
                                    }
                                }
                            }

                            // DB登録
                            await ShareViewModel.Instance.ImportCsvToDbAsync(filePath);

                            int recordCount = lines.Length > 0 ? lines.Length - 1 : 0;

                            // UIリストに反映
                            _allItems.Insert(0, new CsvInputItem
                            {
                                ImportDate_at = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                Task_type = GetTaskName(taskCode),
                                File_name = fileName,
                                Status = "成功",
                                Records = recordCount.ToString(),
                            });

                            importedCount++;
                        }
                    }

                    if (importedCount == 0)
                    {
                        MessageBox.Show("取り込むCSVが存在しません。");
                        return;
                    }

                    // ページ情報更新
                    _totalPages = (int)Math.Ceiling(_allItems.Count / (double)_pageSize);
                    _currentPage = 1;
                    UpdateList();
                    CreatePageButtons();

                    MessageBox.Show("CSV取り込み完了！");

                    var main = Window.GetWindow(this) as MainWindow;
                    main?.StockListScreenControl.Reload();
                    main?.MaterialLedgerScreenControl.ReloadLedgerItems();
                    main?.HomeScreenControl.CsvLinkageHistory.ReloadCsvHistory();
                    main?.HomeScreenControl.LatestDataImport.ReloadCsvHistory();
                    main?.HomeScreenControl.LedgeEvent.ReloadCsvHistory();
                    main?.HomeScreenControl.MaterialType.ReloadCsvHistory();
                    main?.HomeScreenControl.TotalInventory.ReloadCsvHistory();
                }
            }
            catch (Exception ex)
            {
                Clipboard.SetText(ex.ToString());
                MessageBox.Show(
                    "予期しないエラーが発生しました。\n詳細はクリップボードにコピーされています。",
                    "エラー",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
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

        private string GetImportSubFolder(string taskCode)
        {
            return taskCode switch
            {
                "IN" => "inboundEvent",
                "Tag" => "TagMaster",
                "OUT" => "outboundEvent",
                "Location" => "LocationMaster",
                _ => throw new InvalidOperationException("不明なCSV種別です")
            };
        }

        private void LoadCsvHistory()
        {
            _allItems.Clear();

            using (var db = new AppDbContext())
            {
                var histories = db.CsvHistories
                    .OrderByDescending(h => h.Executed_at)
                    .Select(h => new CsvInputItem
                    {
                        ImportDate_at = h.CsvTaskType.Created_at,
                        Task_type = h.CsvTaskType.Csv_task_name,
                        File_name = h.File_name,
                        Status = h.Result,
                        Records = h.Recode_num.ToString(),
                    })
                    .ToList();

                foreach (var h in histories)
                {
                    _allItems.Add(h);
                }
            }

            _totalPages = (int)Math.Ceiling(_allItems.Count / (double)_pageSize);
        }

    }
}
