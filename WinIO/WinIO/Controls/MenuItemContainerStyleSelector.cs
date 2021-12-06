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
        public override Style SelectStyle(object item, DependencyObject container)
        {
            
            var me = container as MenuItem;
            var view = item as MenuItemView;
            var dt = me.FindResource("MenuItemStyle") as Style;

            if (view != null && me != null)
            {
                me.SetBinding(MenuItem.IsCheckableProperty, new Binding("Checkable") { Source=view });
                me.SetBinding(MenuItem.HeaderProperty, new Binding("Title") { Source = view });
                me.SetBinding(MenuItem.IconProperty, new Binding("Image") { Source = view });

                me.ItemsSource = view.Children;
                me.Click += (o, a) => { if(view.Click != null) view.Click(o, a); };

                // me.IsCheckable = view.Checkable;
            }

            return dt;
        }
    }
}
