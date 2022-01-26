using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WinIO.Models
{
    [Serializable]
    public class TreeItemView : INotifyPropertyChanged
    {
        #region Field
        public event PropertyChangedEventHandler PropertyChanged;

        private string _name;
        private bool _isChecked;
        private TreeItemView _parent;
       
        private ObservableCollection<TreeItemView> _children
            = new ObservableCollection<TreeItemView>();
        private ObservableCollection<TreeItemView> _selectChilds 
            = new ObservableCollection<TreeItemView>();

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

                foreach (TreeItemView child in this._children)
                {
                    child.IsChecked = value;
                }

                if(value)
                {
                    if(this.Parent != null)
                    {
                        // 加入选择的子节点
                        this.Parent._selectChilds.Add(this);
                        PropertyChanged?.Invoke(this.Parent, new PropertyChangedEventArgs("SelectedChildren"));
                    } 
                }
                else
                {
                    if(this.Parent != null)
                    {
                        this.Parent._isChecked = value;
                        PropertyChanged?.Invoke(this.Parent, new PropertyChangedEventArgs("IsChecked"));
                        // 移除选择的子节点
                        this.Parent._selectChilds.Remove(this);
                        PropertyChanged?.Invoke(this.Parent, new PropertyChangedEventArgs("SelectedChildren"));
                    } 
                }
            }
        }
        public TreeItemView Parent
        {
            get
            {
                return _parent;
            }

            set
            {
                this._parent= value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Parent"));
            }
        }
        public ObservableCollection<TreeItemView> Children
        {
            get
            {
                return this._children;
            }
        }
        public ObservableCollection<TreeItemView> SelectedChildren
        {
            get
            {
                return this._selectChilds;
            }
        }

        public void Add(TreeItemView child)
        {
            child.Parent = this;
            this._children.Add(child);
        }

        public void Remove(TreeItemView child)
        {
            if(this._children.Remove(child))
            {
                child.Parent = null;
            }
        }
        #endregion
    }
}
