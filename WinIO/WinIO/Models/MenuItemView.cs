using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WinIO.Models
{
    public class MenuItemView : INotifyPropertyChanged
    {
        // 最大层级

        #region Field

        public event PropertyChangedEventHandler PropertyChanged;

        private string _icon;
        private Image _image;
        private string _title;
        private bool _checkable;
        private bool _check;
        public RoutedEventHandler Click;

        private List<MenuItemView> _childViewList = new List<MenuItemView>();

        public string Icon
        {
            get => _icon;
            set
            {
                _icon = value;

                if (!string.IsNullOrEmpty(_icon))
                {
                    _image = new Image()
                    {
                        Source = new BitmapImage(new Uri(_icon, UriKind.Relative))
                    };
                }

                if (PropertyChanged != null)
                {

                    PropertyChanged(this, new PropertyChangedEventArgs("Image"));
                }
            }
        }

        public Image Image
        {
            get => _image;
        }

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Title"));
                }
            }
        }

        public bool Checkable
        {
            get => _checkable;
            set => _checkable = value;
        }

        public bool Check
        {
            get => _check;
            set => _check = value;
        }

        public IEnumerable<MenuItemView> Children
        {
            get
            {
                foreach (var child in this._childViewList) yield return child;
            }
        }

        public void Add(MenuItemView view)
        {
            this._childViewList.Add(view);
        }

        public void Insert(int index, MenuItemView view)
        {
            this._childViewList.Insert(index, view);
        }
        #endregion
    }
}
