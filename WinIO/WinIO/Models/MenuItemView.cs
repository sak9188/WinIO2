using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinIO.Models
{
    public class MenuItemView
    {
        private string _icon;
        private string _title;
        private bool _checkable;
        private bool _check;

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
    }
}
