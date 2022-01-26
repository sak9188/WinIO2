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

        //public OutputDocument Output => OutPanel;

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

            LeftTree.ItemsSource = Items;
        }
    }
}
