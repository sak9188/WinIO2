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
    public partial class CommandWindow : AcrylicWindow
    {
        public ObservableCollection<TreeItemView> Items 
            = new ObservableCollection<TreeItemView>();

        public static ObservableCollection<TreeItemView> Commands 
            = new ObservableCollection<TreeItemView>();

        public Button ExeButton => ExecuteButton;

        public string EditText => textEditor.Text;

        public CommandWindow()
        {
            InitializeComponent();
        
            // 初始化选项
            textEditor.Options.ShowColumnRuler = true;
            textEditor.Options.ShowEndOfLine = true;
            textEditor.Options.ShowTabs = true;
            textEditor.Options.ShowSpaces = true;
            
            // 左树初始化
            LeftTree.ItemsSource = Items;

            // 指令池
            CommandPool.ItemsSource = Commands;

            TreeItemView item0 = new TreeItemView();
            item0.Name = "直接杀死玩家";

            TreeItemView item1 = new TreeItemView();
            item1.Name = "杀死选中玩家";

            TreeItemView item = new TreeItemView();
            item.Name = "玩家";

            TreeItemView item10 = new TreeItemView();
            item10.Name = "超级指令";

            TreeItemView item11 = new TreeItemView();
            item11.Name = "直接起飞到天上";

            item.Add(item0);
            item.Add(item1);

            item10.Add(item11);

            Commands.Add(item);
            Commands.Add(item10);

            var a = new TreeViewItem();
        }
    }
}
