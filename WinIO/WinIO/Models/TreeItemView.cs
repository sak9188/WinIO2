using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WinIO.Models
{
    public class TreeItemView : INotifyPropertyChanged
    {
        #region Field
        public ObservableCollection<TreeItemView> _children;

        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        private bool _isChecked;

        public RoutedEventHandler Click;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }

        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }

            set
            {
                this._isChecked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsChecked"));
                foreach (TreeItemView child in this.Children)
                {
                    child.IsChecked = value;
                }
            }
        }

        public ObservableCollection<TreeItemView> Children
        {
            get
            {
                return _children;
            }

            set
            {
                this._children = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Children"));
            }
        }
        #endregion

       public TreeItemView()
       {
            this._children = new ObservableCollection<TreeItemView>();
       }
    }
}
