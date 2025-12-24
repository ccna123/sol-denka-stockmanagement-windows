using sol_denka_stockmanagement.Database;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Threading;
using static MaterialDesignThemes.Wpf.Theme;

namespace sol_denka_stockmanagement.Views.Controls.MasterManagementScreenControl
{
    /// <summary>
    /// MasterManagementScreenControl.xaml の相互作用ロジック
    /// </summary>
    public partial class MasterManagementScreenControl : UserControl
    {
        // 表示するデータ
        public ObservableCollection<Item> ItemList { get; set; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> StorageList { get; set; } = new ObservableCollection<Item>();
        public ObservableCollection<Item> TagList { get; set; } = new ObservableCollection<Item>();


        public MasterManagementScreenControl()
        {
            InitializeComponent();

            //初回表示リスト
            comboBox.SelectedIndex = 0; 
            
        }

        public void AddNewItem(Item newItem)
        {
            ItemList.Add(newItem); 
        }

        public void AddNewLocation(Item newLocation)
        {
            StorageList.Add(newLocation);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!(comboBox.SelectedItem is ComboBoxItem item)) return;

            string selected = item.Content.ToString();

            // ListView を表示
            listView.Visibility = Visibility.Visible;

            // GridView をクリアして新規作成
            GridView gv = new GridView();

            switch (selected)
            {
                case "品目マスタ＋項目設定マスタ":
                    gv.Columns.Add(new GridViewColumn { Header = "資材名", DisplayMemberBinding = new Binding("Name") });
                    gv.Columns.Add(new GridViewColumn { Header = "品目コード", DisplayMemberBinding = new Binding("Code") });
                    gv.Columns.Add(new GridViewColumn { Header = "備考", DisplayMemberBinding = new Binding("Note") });
                    AddDetailButtonColumn(gv);
                    LoadItems();
                    listView.ItemsSource = ItemList;
                    RegistrationButton.IsEnabled = true;
                    //RegistrationButton.Background = new SolidColorBrush(System.Windows.Media.Colors.White);
                    break;

                case "保管場所マスタ":
                    gv.Columns.Add(new GridViewColumn { Header = "保管場所名", DisplayMemberBinding = new Binding("Name") });
                    gv.Columns.Add(new GridViewColumn { Header = "保管場所コード", DisplayMemberBinding = new Binding("Code") });
                    gv.Columns.Add(new GridViewColumn { Header = "備考", DisplayMemberBinding = new Binding("Note") });
                    AddDetailButtonColumn(gv);
                    LoadLocations();
                    listView.ItemsSource = StorageList;
                    RegistrationButton.IsEnabled = true;
                    //RegistrationButton.Background = new SolidColorBrush(System.Windows.Media.Colors.White);
                    break;

                case "タグマスタ":
                    gv.Columns.Add(new GridViewColumn { Header = "アイテムコード(EPC)", DisplayMemberBinding = new Binding("Name") });
                    gv.Columns.Add(new GridViewColumn { Header = "ステータス", DisplayMemberBinding = new Binding("Code") });
                    gv.Columns.Add(new GridViewColumn { Header = "登録日時", DisplayMemberBinding = new Binding("Note") });
                    AddDetailButtonColumn(gv);
                    LoadTags();
                    listView.ItemsSource = TagList;
                    RegistrationButton.IsEnabled = true;
                    //RegistrationButton.Background = new SolidColorBrush(System.Windows.Media.Colors.LightGray);
                    break;
                default:
                    listView.Visibility = Visibility.Collapsed;
                    RegistrationButton.IsEnabled = false;
                    RegistrationButton.Background = new SolidColorBrush(System.Windows.Media.Colors.LightGray);
                    break;
            }

            // 最後に ListView へ設定
            listView.View = gv;
            Dispatcher.InvokeAsync(() => AdjustColumnWidths(), DispatcherPriority.Background);

        }
        //詳細ボタンの追加
        private void AddDetailButtonColumn(GridView gv)
        {
            var detailCol = new GridViewColumn
            {
                Header = "",
                Width = 100,
                CellTemplate = (DataTemplate)FindResource("DetailButtonTemplate")
            };

            gv.Columns.Add(detailCol);
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

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            var main = Window.GetWindow(this) as MainWindow;
            if (main == null) return;

            // ComboBoxで選択されている値を取得
            string selectedMaster = (comboBox.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "";
            
            // NewRegistration にマスタ種類を渡す
            main.NewRegistration.SetMasterType(selectedMaster);

            // TagDetailsView を表示
            main.NewRegistration.Visibility = Visibility.Visible;

            // 他を隠す
            main.HomeScreenControl.Visibility = Visibility.Collapsed;
            main.MaterialLedgerScreenControl.Visibility = Visibility.Collapsed;
            main.StockListScreenControl.Visibility = Visibility.Collapsed;
            main.CsvImportScreenControl.Visibility = Visibility.Collapsed;
            main.CsvExportScreenControl.Visibility = Visibility.Collapsed;
            main.MasterMagamentScreenControl.Visibility = Visibility.Collapsed;
            main.SettingScreenControl.Visibility = Visibility.Collapsed;
            main.TagDetailsEdit.Visibility = Visibility.Collapsed;
            main.TagDetailsView.Visibility = Visibility.Collapsed;
        }

        private void DetailButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as System.Windows.Controls.Button;
            if (button == null) return;

            // ★ 押下された行のデータを取得
            var selectedItem = button.DataContext as Item;
            if (selectedItem == null) return;

            var main = Window.GetWindow(this) as MainWindow;
            if (main == null) return;

            string selectedMaster = (comboBox.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "";

            // マスタ種別を設定
            main.EditRegistration.SetMasterType(selectedMaster);
            main.EditRegistration.LoadData(selectedItem.Id);
            main.EditRegistration.TagLoadData(selectedItem.Name);

            // 編集画面を表示
            main.EditRegistration.Visibility = Visibility.Visible;

            // 他画面を非表示
            main.HomeScreenControl.Visibility = Visibility.Collapsed;
            main.MaterialLedgerScreenControl.Visibility = Visibility.Collapsed;
            main.StockListScreenControl.Visibility = Visibility.Collapsed;
            main.CsvImportScreenControl.Visibility = Visibility.Collapsed;
            main.CsvExportScreenControl.Visibility = Visibility.Collapsed;
            main.SettingScreenControl.Visibility = Visibility.Collapsed;
            main.MasterMagamentScreenControl.Visibility = Visibility.Collapsed;
            main.TagDetailsEdit.Visibility = Visibility.Collapsed;
            main.TagDetailsView.Visibility = Visibility.Collapsed;
        }


        public void LoadItems()
        {
            using (var db = new AppDbContext())
            {
                // DB から取得
                var items = db.ItemTypes
                    .OrderBy(i => i.Item_type_code)
                    .Select(i => new Item
                    {
                        Id = i.Item_type_id,
                        Name = i.Item_type_name,
                        Code = i.Item_type_code,
                    })
                    .ToList();

                // ObservableCollection を一旦クリアして再設定
                ItemList.Clear();
                foreach (var item in items)
                {
                    ItemList.Add(item);
                }
            }
        }


        public void LoadLocations()
        {
            using (var db = new AppDbContext())
            {
                // DB から取得
                var locations = db.Locations
                    .OrderBy(l => l.Location_code)
                    .Select(l => new Item
                    {
                        Id = l.Location_id,
                        Name = l.Location_name,
                        Code = l.Location_code,
                        Note = l.Memo
                    })
                    .ToList();
                StorageList.Clear();
                foreach (var loc in locations)
                {
                    StorageList.Add(loc);
                }
            }
        }

        // ===============================
        // マスタ一覧 再読込
        // ===============================
        public void ReloadCurrentMaster()
        {
            string selectedMaster = (comboBox.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "";

            switch (selectedMaster)
            {
                case "品目マスタ＋項目設定マスタ":
                    LoadItems();
                    listView.ItemsSource = ItemList;
                    break;

                case "保管場所マスタ":
                    LoadLocations();
                    listView.ItemsSource = StorageList;
                    break;

                case "タグマスタ":
                    LoadTags();
                    listView.ItemsSource = TagList;
                    break;
            }
        }


        public void LoadTags()
        {
            using (var db = new AppDbContext())
            {
                var tags = db.Tags
                    .Join(
                        db.TagStatusTypes,
                        t => t.Tag_status_id,
                        s => s.Tag_status_id,
                        (t, s) => new Item
                        {
                            Name = t.Epc,
                            Code = s.Status_name,
                            Note = t.Created_at
                        }
                    )
                    .ToList();
                TagList.Clear();
                foreach (var tag in tags)
                {
                    TagList.Add(tag);
                }
            }
        }
    }
    public class Item : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int Id { get; set; }

        private string _name;
        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(nameof(Name)); }
        }

        private string _code;
        public string Code
        {
            get => _code;
            set { _code = value; OnPropertyChanged(nameof(Code)); }
        }

        private string _note;
        public string Note 
        { 
            get => _note; 
            set { _note = value; OnPropertyChanged(nameof(Note)); } 
        }
        private void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
