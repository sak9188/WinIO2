using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WinIO.Controls
{
    public partial class WinTreeView : TreeView
    {
        public WinTreeView()
        {
            this.MouseRightButtonDown += MouseRightButtonDownCallback;
        }

        private void MouseRightButtonDownCallback(object sender, MouseButtonEventArgs e)
        {
            var source = e.OriginalSource as DependencyObject;
            while (source != null && !(source is TreeViewItem))
                source = VisualTreeHelper.GetParent(source);

            TreeViewItem treeViewItem = source as TreeViewItem;

            if (treeViewItem != null)
            {
                treeViewItem.Focus();
                e.Handled = true;
            }
        }
    }
}
