using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WinIO.Core
{
    public class PyDelegateConverter
    {
        public static RoutedEventHandler ToRoutedEventHandler(dynamic pyObject)
        {
            return new RoutedEventHandler((o, a) => pyObject(o, a));
        }
        public static EventHandler ToEventHandler(dynamic pyObject)
        {
            return new EventHandler((o, a) => pyObject(o, a));
        }
    }
}
