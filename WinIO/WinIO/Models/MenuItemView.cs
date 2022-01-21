using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WinIO.Controls;
using WinIO.PythonNet;

namespace WinIO.Models
{
    public class MenuItemView : INotifyPropertyChanged
    {
        #region Field

        public event PropertyChangedEventHandler PropertyChanged;

        private string _icon;
        private Image _image;
        private string _title;
        private bool _checkable;
        private bool _check;
        private CommandView _commandView;

        public RoutedEventHandler Click;

        private ObservableCollection<MenuItemView> _childViewList = new ObservableCollection<MenuItemView>();

        public string Icon
        {
            get => _icon;
            set
            {
                _icon = value;

                _image = GResources.GetUriImage(value);

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Image"));
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title"));
            }
        }
        public CommandView CommandView
        {
            get => _commandView;
            set
            {
                if(_commandView != null)
                {
                    _commandView.PropertyChanged -= AfterViewPropertyChanged;
                    this.Click -= _commandView.AfterClickCommand;
                }
                
                if(value != null)
                {
                    value.PropertyChanged += AfterViewPropertyChanged;

                    this.Icon = value.Icon;
                    this.Title = value.Header;

                    this.Click += value.AfterClickCommand;
                }

                _commandView = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CommandView"));
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
    
        private void AfterViewPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CommandView view = sender as CommandView;
            switch (e.PropertyName)
            {
                case var s when s == "Icon":
                    this.Icon = view.Icon;
                    return;
                case var s when s == "Header":
                    this.Title = view.Header;
                    return;
            }
        }
    }
}
