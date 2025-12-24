using MediaDevices;
using sol_denka_stockmanagement.Models;
using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
namespace sol_denka_stockmanagement.Views.Controls.UsbCooperationControl
{
    /// <summary>
    /// UsbCooperationControl.xaml の相互作用ロジック
    /// </summary>
    public partial class UsbCooperationControl : UserControl, INotifyPropertyChanged
    {
        private List<UsbFileInfo> _androidAllFiles = new List<UsbFileInfo>();
        private List<UsbFileInfo> _windowsAllFIles = new List<UsbFileInfo>();
        public bool IsUploadMode { get; set; } = false;
        private bool _isManualMode;
        public bool IsManualMode
        {
            get => _isManualMode;
            set
            {
                _isManualMode = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsManualMode)));
            }
        }

        public UsbCooperationControl()
        {
            InitializeComponent();

            _androidAllFiles = LoadAndroidFiles();
            _windowsAllFIles = LoadWindowsFiles();

            // 初期表示
            DownloadList_SelectionChanged(FileTypeCombo, null);
            UploadList_SelectionChanged(FileTypeCombo2, null);

            DataContext = this;
        }

        /// <summary>
        /// プルダウンによるリスト切り替え(ダウンロードタブ)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FileListView == null) return;

            // Android から未取得ならロード
            if (_androidAllFiles.Count == 0)
                _androidAllFiles = LoadAndroidFiles();

            var selected = (FileTypeCombo.SelectedItem as ComboBoxItem)?.Content.ToString();
            IEnumerable<UsbFileInfo> filtered = _androidAllFiles;

            switch (selected)
            {
                case "入庫結果CSV":
                    filtered = _androidAllFiles
                        .Where(x => x.FileName.Contains("inbound_result", StringComparison.OrdinalIgnoreCase));
                    break;

                case "出庫結果CSV":
                    filtered = _androidAllFiles
                        .Where(x => x.FileName.Contains("outbound_result", StringComparison.OrdinalIgnoreCase));
                    break;

                case "棚卸結果CSV":
                    filtered = _androidAllFiles
                        .Where(x => x.FileName.Contains("inventory_result", StringComparison.OrdinalIgnoreCase));
                    break;

                case "保管場所変更結果CSV":
                    filtered = _androidAllFiles
                        .Where(x => x.FileName.Contains("location_change_result", StringComparison.OrdinalIgnoreCase));
                    break;

                default:
                    break;
            }

            FileListView.ItemsSource = filtered.ToList();
        }

        /// <summary>
        /// プルダウンによるリスト切り替え(アップロードタブ)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UploadList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FileListView2 == null) return;

            // Android から未取得ならロード
            if (_windowsAllFIles.Count == 0)
                _windowsAllFIles = LoadWindowsFiles();

            var selected = (FileTypeCombo2.SelectedItem as ComboBoxItem)?.Content.ToString();
            IEnumerable<UsbFileInfo> filtered = _windowsAllFIles;

            switch (selected)
            {
                case "品目マスタCSV":
                    filtered = _windowsAllFIles
                        .Where(x => x.FileName.Contains("item_type_master", StringComparison.OrdinalIgnoreCase));
                    break;
                case "品目フィールド設定マスタCSV":
                    filtered = _windowsAllFIles
                        .Where(x => x.FileName.Contains("field_setting_master", StringComparison.OrdinalIgnoreCase));
                    break;
                case "保管場所マスタCSV":
                    filtered = _windowsAllFIles
                        .Where(x => x.FileName.Contains("location_master", StringComparison.OrdinalIgnoreCase));
                    break;

                case "タグマスタCSV":
                    filtered = _windowsAllFIles
                        .Where(x => x.FileName.Contains("tag_master", StringComparison.OrdinalIgnoreCase));
                    break;

                case "台帳アイテムCSV":
                    filtered = _windowsAllFIles
                        .Where(x => x.FileName.Contains("ledger_item_master", StringComparison.OrdinalIgnoreCase));
                    break;

                default:
                    break;
            }
            FileListView2.ItemsSource = filtered.ToList();
        }

        /// <summary>
        /// リスト表示の横幅調整
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Downloadlist_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            AdjustColumnWidthsCommon(FileListView, true, 60);
        }

        private void uploadlist_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            AdjustColumnWidthsCommon(FileListView2, true, 60);
        }

        private void AdjustColumnWidthsCommon(ListView listView, bool hasFixedFirstColumn, double fixedWidth = 0)
        {
            if (listView.View is GridView gridView)
            {
                int columnCount = gridView.Columns.Count;
                if (columnCount == 0) return;

                double totalWidth = listView.ActualWidth - 5; // マージン調整

                int startIndex = 0;

                // 先頭列が固定幅の場合
                if (hasFixedFirstColumn && columnCount > 1)
                {
                    gridView.Columns[0].Width = fixedWidth;
                    totalWidth -= fixedWidth;
                    startIndex = 1;
                }

                int variableColumnCount = columnCount - startIndex;
                if (variableColumnCount <= 0) return;

                double columnWidth = totalWidth / variableColumnCount;

                for (int i = startIndex; i < columnCount; i++)
                {
                    gridView.Columns[i].Width = columnWidth;
                }
            }
        }

        /// <summary>
        /// ヘッダー　チェックボックスの全選択(ダウンロードタブ)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaderCheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox headerCheckBox)
            {
                bool isChecked = headerCheckBox.IsChecked == true;

                foreach (var item in FileListView.Items)
                {
                    if (item is UsbFileInfo fileItem)
                    {
                        // ★ 未連携（IsLinked == false）のみまとめて選択 or 解除
                        if (!fileItem.IsLinked)
                        {
                            fileItem.IsSelected = isChecked;
                        }
                    }
                }

                // バインディング更新のため
                FileListView.Items.Refresh();
            }
        }

        /// <summary>
        /// ヘッダー　チェックボックスの全選択(アップロードタブ)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HeaderCheckBox2_Click(object sender, RoutedEventArgs e)
        {
            if (sender is CheckBox headerCheckBox)
            {
                bool isChecked = headerCheckBox.IsChecked == true;

                foreach (var item in FileListView2.Items)
                {
                    if (item is UsbFileInfo fileItem)
                    {
                        // ★ 未連携（IsLinked == false）のみまとめて選択 or 解除
                        if (!fileItem.IsLinked)
                        {
                            fileItem.IsSelected = isChecked;
                        }
                    }
                }

                // バインディング更新のため
                FileListView.Items.Refresh();
            }
        }


        /// <summary>
        /// 転送ボタン押下時の処理(ダウンロード版)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadProcess()
        {
            if (FileListView.Items.Count == 0)
            {
                MessageBox.Show("ファイルがありません。");
                return;
            }

            // ▼ 自動 / 手動で取得方法が変わる
            List<UsbFileInfo> targetFiles;

            if (!IsManualMode) // 自動転送
            {
                var selected = (FileTypeCombo.SelectedItem as ComboBoxItem)?.Content?.ToString();

                targetFiles = _androidAllFiles
                    .Where(x => x.Status == "未転送")
                    .Where(x =>
                        (selected == "入庫結果CSV" && x.FileName.Contains("inbound_result")) ||
                        (selected == "出庫結果CSV" && x.FileName.Contains("outbound_result")) ||
                        (selected == "棚卸結果CSV" && x.FileName.Contains("inventory_result")) ||
                        (selected == "保管場所変更結果CSV" && x.FileName.Contains("location_change_result"))
                    )
                    .ToList();
            }
            else // 手動転送
            {
                targetFiles = FileListView.Items
                    .Cast<UsbFileInfo>()
                    .Where(x => x.IsSelected && x.Status == "未転送")
                    .ToList();
            }

            if (!targetFiles.Any())
            {
                MessageBox.Show("転送対象のファイルがありません。");
                return;
            }

            var device = MediaDevice.GetDevices().FirstOrDefault();
            if (device == null)
            {
                MessageBox.Show("Androidデバイスが見つかりません。");
                return;
            }

            device.Connect();

            foreach (var file in targetFiles)
            {
                try
                {
                    // ★ ファイル名から保存先フォルダ判定
                    string folderName = GetTargetFolderByFileName2(file.FileName);
                    if (folderName == null)
                    {
                        MessageBox.Show($"保存先フォルダを判定できません。\n{file.FileName}");
                        continue;
                    }

                    // Android 側
                    string androidFolder =
                        $@"\内部共有ストレージ\Download\DenkaStockManagement\Export\{folderName}";

                    string androidPath = $"{androidFolder}\\{file.FileName}";

                    // Windows 側
                    string windowsFolder = Path.Combine(
                        @"C:\DenkaStockManagement\Import",
                        folderName
                    );

                    if (!Directory.Exists(windowsFolder))
                        Directory.CreateDirectory(windowsFolder);

                    string windowsPath = Path.Combine(windowsFolder, file.FileName);

                    using (var outStream = File.Create(windowsPath))
                    {
                        device.DownloadFile(androidPath, outStream);
                    }

                    file.Status = "連携済み";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"エラー: {file.FileName}\n{ex.Message}");
                }
            }

            device.Disconnect();

            FileListView.Items.Refresh();
            MessageBox.Show("ダウンロードが完了しました。");
        }


        /// <summary>
        /// 転送ボタン押下時の処理(アップロード版)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UploadProcess()
        {
            if (FileListView2.Items.Count == 0)
            {
                MessageBox.Show("ファイルがありません。");
                return;
            }

            // ▼ 自動 / 手動で取得方法が変わる
            List<UsbFileInfo> targetFiles;

            if (!IsManualMode) // 自動転送
            {
                var selected = (FileTypeCombo2.SelectedItem as ComboBoxItem)?.Content?.ToString();

                targetFiles = _windowsAllFIles
                    .Where(x => x.Status == "未転送")
                    .Where(x =>
                        (selected == "品目マスタCSV" && x.FileName.Contains("item_type_master")) ||
                        (selected == "品目フィールド設定マスタCSV" && x.FileName.Contains("field_setting_master")) ||
                        (selected == "保管場所マスタCSV" && x.FileName.Contains("location_master")) ||
                        (selected == "タグマスタCSV" && x.FileName.Contains("tag_master")) ||
                        (selected == "台帳アイテムCSV" && x.FileName.Contains("ledger_item_master"))
                    )
                    .ToList();
            }
            else // 手動転送
            {
                targetFiles = FileListView2.Items
                    .Cast<UsbFileInfo>()
                    .Where(x => x.IsSelected && x.Status == "未転送")
                    .ToList();
            }

            if (!targetFiles.Any())
            {
                MessageBox.Show("転送対象のファイルがありません。");
                return;
            }

            var device = MediaDevice.GetDevices().FirstOrDefault();
            if (device == null)
            {
                MessageBox.Show("Androidデバイスが見つかりません。");
                return;
            }

            device.Connect();

            foreach (var file in targetFiles)
            {
                try
                {
                    // ★ ファイル名からフォルダ判定
                    string folderName = GetTargetFolderByFileName(file.FileName);
                    if (folderName == null)
                    {
                        MessageBox.Show($"フォルダ判定できないファイルです。\n{file.FileName}");
                        continue;
                    }

                    // Windows 側
                    string windowsFolder = Path.Combine(
                        @"C:\DenkaStockManagement\Export",
                        folderName
                    );

                    // Android 側
                    string androidFolder = $@"\内部共有ストレージ\Download\DenkaStockManagement\Import\{folderName}";

                    if (!device.DirectoryExists(androidFolder))
                        device.CreateDirectory(androidFolder);

                    string windowsPath = Path.Combine(windowsFolder, file.FileName);
                    string androidPath = $"{androidFolder}\\{file.FileName}";

                    using (var inStream = File.OpenRead(windowsPath))
                    {
                        device.UploadFile(inStream, androidPath);
                    }

                    file.Status = "連携済み";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"エラー: {file.FileName}\n{ex.Message}");
                }
            }

            device.Disconnect();

            FileListView2.Items.Refresh();
            MessageBox.Show("アップロードが完了しました。");
        }


        /// <summary>
        /// USB連携　CSV取得
        /// </summary>
        /// <returns></returns>
        public List<UsbFileInfo> LoadAndroidFiles()
        {
            string baseAndroidFolder = @"\内部共有ストレージ\Download\DenkaStockManagement\Export";

            // CSVファイル名 → フォルダ名
            var folderMap = new Dictionary<string, string>
            {
                { "inbound_result", "InboundEvent" },
                { "outbound_result", "OutboundEvent" },
                { "location_change_result", "LocationChangeEvent" },
                { "inventory_result", "InventoryResult" }
            };

            var result = new List<UsbFileInfo>();

            var device = MediaDevice.GetDevices().FirstOrDefault();
            if (device == null) return result;

            device.Connect();

            try
            {
                foreach (var folder in folderMap.Values)
                {
                    string androidFolder = $@"{baseAndroidFolder}\{folder}";

                    if (!device.DirectoryExists(androidFolder))
                        continue;

                    var files = device.GetFiles(androidFolder);

                    foreach (var file in files)
                    {
                        var info = device.GetFileInfo(file);

                        result.Add(new UsbFileInfo
                        {
                            FileName = info.Name,
                            UpdateTime = info.LastWriteTime?.ToString("yyyy/MM/dd HH:mm") ?? "",
                            Status = "未転送"
                        });
                    }
                }
            }
            finally
            {
                device.Disconnect();
            }

            return result;
        }


        public List<UsbFileInfo> LoadWindowsFiles()
        {
            string baseFolder = @"C:\DenkaStockManagement\Export";

            // ファイル名（識別子） → フォルダ名
            var folderMap = new Dictionary<string, string>
            {
                { "item_type_master", "ItemTypeMaster" },
                { "field_setting_master", "ItemTypeFieldSettingMaster" },
                { "location_master", "LocationMaster" },
                { "tag_master","TagMaster" }
            };

            var result = new List<UsbFileInfo>();

            foreach (var map in folderMap)
            {
                string targetFolder = Path.Combine(baseFolder, map.Value);

                // ① フォルダがなければ作成（ファイルはまだ無いのでスキップ）
                if (!Directory.Exists(targetFolder))
                {
                    Directory.CreateDirectory(targetFolder);
                    continue;
                }

                // ② CSV ファイル取得
                var files = Directory.GetFiles(targetFolder, "*.csv");

                foreach (var f in files)
                {
                    var info = new FileInfo(f);

                    result.Add(new UsbFileInfo
                    {
                        FileName = info.Name,
                        UpdateTime = info.LastWriteTime.ToString("yyyy/MM/dd HH:mm"),
                        Status = "未転送"
                    });
                }
            }

            return result;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// ラジオボタン押下時の処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Automatic_Checked(object sender, RoutedEventArgs e)
        {
            // 送信元が Download 側 or Upload 側に関係なく「自動」が選ばれたら
            SyncTransferMode(true);
        }

        private void Manual_Checked(object sender, RoutedEventArgs e)
        {
            // 同上。手動が選ばれたら
            SyncTransferMode(false);
        }

        /// <summary>
        /// 自動(true) / 手動(false) を双方へ同期
        /// </summary>
        private void SyncTransferMode(bool isAutomatic)
        {
            // ======== ダウンロード側を同期 ========
            if (DownloadAutomatic != null)
                DownloadAutomatic.IsChecked = isAutomatic;
            if (DownloadManual != null)
                DownloadManual.IsChecked = !isAutomatic;

            // ======== アップロード側を同期 ========
            if (Automatic != null)
                Automatic.IsChecked = isAutomatic;
            if (Manual != null)
                Manual.IsChecked = !isAutomatic;

            // モード変更イベント（マニュアルチェックボックスの表示切替など）が
            // 必要ならここで呼ぶ
            UpdateManualMode(isAutomatic);
        }

        private void UpdateManualMode(bool isAutomatic)
        {
            // 自動モード = ManualMode false
            // 手動モード = ManualMode true
            IsManualMode = !isAutomatic;
        }


        //タブの切り替え
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.Source is TabControl)
            {
                var tab = (sender as TabControl);

                IsUploadMode = (tab.SelectedIndex == 1);
            }
        }

        /// <summary>
        /// 転送実行ボタンの押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Check_button(object sender, RoutedEventArgs e)
        {
            if (IsUploadMode)
            {
                UploadProcess();
            }
            else
            {
                DownloadProcess();
            }
        }

        /// <summary>
        /// ファイル名から転送先フォルダ名を判定
        /// </summary>
        private string GetTargetFolderByFileName(string fileName)
        {
            var folderMap = new Dictionary<string, string>
    {
        { "item_type_master", "ItemTypeMaster" },
        { "field_setting_master", "ItemTypeFieldSettingMaster" },
        { "location_master", "LocationMaster" },
        { "tag_master", "TagMaster" },
        { "ledger_item_master", "LedgerItemMaster" }
    };

            foreach (var map in folderMap)
            {
                if (fileName.Contains(map.Key, StringComparison.OrdinalIgnoreCase))
                {
                    return map.Value;
                }
            }

            return null; // 対象外
        }

        private string GetTargetFolderByFileName2(string fileName)
        {
            var folderMap = new Dictionary<string, string>
    {
        { "inbound_result", "InboundEvent" },
        { "outbound_result", "OutboundEvent" },
        { "inventory_result", "InventoryResult" },
        { "location_change_result", "LocationChangeEvent" }
    };

            foreach (var map in folderMap)
            {
                if (fileName.Contains(map.Key, StringComparison.OrdinalIgnoreCase))
                    return map.Value;
            }

            return null;
        }


    }
}

