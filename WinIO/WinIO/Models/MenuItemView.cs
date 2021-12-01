using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinIO.Models
{
    public class MenuItemView
    {
        // 最大层级
        internal static readonly int MaxLayers = 5;

        #region Field

        private string _icon;
        private string _title;
        private bool _checkable;
        private bool _check;
        private int _level;

        private List<MenuItemView> _childViewList = new List<MenuItemView>();

        public string Icon
        {
            get => _icon;
            set => _icon = value;
        }

        public string Title
        {
            get => _title;
            set => _title = value;
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
