using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace sol_denka_stockmanagement.Models
{
    public class ReceiptItem : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public bool Display {  get; set; }
        public bool Any { get; set; }
        public bool Required { get; set; }
        public int Field_id { get; set; }

        public ReceiptItem() 
        {
            任意 = true;
            必須 = false;
        }

        private bool _表示;
        public bool 表示
        {
            get => _表示;
            set {
                if (_表示 != value)
                {
                    _表示 = value;
                    OnPropertyChanged(nameof(表示));
                    OnPropertyChanged(nameof(DisplayTextColor));
                    // ★ チェックが外れたら「任意」に戻す
                    if (!_表示)
                    {
                        任意 = true;
                        必須 = false;
                    }
                }
            }
        }

        private bool _任意;
        public bool 任意
        {
            get => _任意;
            set { _任意 = value; OnPropertyChanged(nameof(任意)); }
        }

        private bool _必須;
        public bool 必須
        {
            get => _必須;
            set { _必須 = value; OnPropertyChanged(nameof(必須)); }
        }

        private bool _isEditMode;
        public bool IsEditMode
        {
            get => _isEditMode;
            set
            {
                if (_isEditMode != value)
                {
                    _isEditMode = value;
                    OnPropertyChanged(nameof(IsEditMode));
                    OnPropertyChanged(nameof(DisplayTextColor)); // 色を再評価
                }
            }
        }

        // DisplayTextColor を編集モードでも反映
        public Brush DisplayTextColor => 表示 || IsEditMode ? Brushes.Black : Brushes.Gray;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
