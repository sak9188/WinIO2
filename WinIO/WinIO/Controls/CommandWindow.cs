using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WinIO.FluentWPF;
using WinIO.Models;

namespace WinIO.Controls
{
    /// <summary>
    /// Interaction logic for ComandWindow.xaml
    /// </summary>
    public partial class ComandWindow : AcrylicWindow
    {
        public static readonly ObservableCollection<TreeItemView> Items
            = new ObservableCollection<TreeItemView>();

        public ComandWindow()
        {
            InitializeComponent();
        
            // 初始化选项
            textEditor.Options.ShowColumnRuler = true;
            textEditor.Options.ShowEndOfLine = true;
            textEditor.Options.ShowTabs = true;
            textEditor.Options.ShowSpaces = true;

            // 初始化TreeView
            TreeItemView view = new TreeItemView() { Name="测试1" };
            TreeItemView view1 = new TreeItemView() { Name="测试2" };
            TreeItemView view2 = new TreeItemView() { Name="测试3" };
            TreeItemView view3 = new TreeItemView() { Name="测试4" };

            // Items.Add();
            Items.Add(view1);
            view1.Children.Add(view);
            Items.Add(view2);
            Items.Add(view3);
            // Items.Add();

            LeftTree.ItemsSource = Items;
        }
    }
}
