using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sol_denka_stockmanagement.Models
{
    public class UsbFileInfo : INotifyPropertyChanged
    {
        public string FileName { get; set; }
        public string UpdateTime { get; set; }
        public string Status { get; set; }

        private bool _isSelected;
        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsSelected)));
            }
        }
        public bool IsLinked {  get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
