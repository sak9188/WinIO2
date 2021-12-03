using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WinIO.Models;

namespace WinIO.Controls
{
    public class MenuItemContainerStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            
            var me = container as MenuItem;
            var view = item as MenuItemView;
            Style dt = base.SelectStyle(item, container);

            if (view != null && me != null)
            {
                me.IsCheckable = view.Checkable;
                me.Header = view.Title;
                me.ItemsSource = view.Children;
                me.Click += (o, a) => { view.Click(o, a); };
                if (!string.IsNullOrEmpty(view.Icon))
                {
                    me.Icon = new Image()
                    {
                        Source = new BitmapImage(new Uri(view.Icon, UriKind.Relative))
                    };
                    dt = me.FindResource("MenuItemIconStyle") as Style;
                }
            }

            return dt;
        }
    }
}
