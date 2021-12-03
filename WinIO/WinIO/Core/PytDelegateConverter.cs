using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WinIO.Core
{
    public class PytDelegateConverter
    {
        public static RoutedEventHandler ToHandler(dynamic pyObject)
        {
            return new RoutedEventHandler((o, a) => pyObject(o, a));
        }
    }
}
