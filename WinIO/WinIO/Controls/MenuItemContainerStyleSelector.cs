using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using WinIO.Models;

namespace WinIO.Controls
{
    public class MenuItemContainerStyleSelector : StyleSelector
    {
        static Style MenuItemStyle;
        static Style SeperatorStyle;
        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (container is Separator)
            {
                var sep = container as Separator;
                if (SeperatorStyle == null) { SeperatorStyle = sep.FindResource("Separator") as Style; }
                return SeperatorStyle;
            }

            var me = container as MenuItem;

            Style dt;
            var view = item as MenuItemView;
            if(MenuItemStyle != null) { dt = MenuItemStyle; }
            else
            {
                dt = me.FindResource("MenuItemStyle") as Style;
                MenuItemStyle = dt;
            }
            if (view != null && me != null) { me.Click += (o, a) => { if(view.Click != null) view.Click(o, a); }; }

            return dt;
        }
    }
}
