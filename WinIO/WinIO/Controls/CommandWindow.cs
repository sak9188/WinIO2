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

        private Dictionary<TreeItemView, OutputDocument> _viewOutpanels
            = new Dictionary<TreeItemView, OutputDocument>();

        public OutputDocument Output => OutPanel;

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

        private void LeftTreeSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            var view = LeftTree.SelectedItem as TreeItemView;
        
            // 这里切换面板
            OutputDocument panel;
            if(!this._viewOutpanels.TryGetValue(view, out panel))
            {
                panel = new OutputDocument();
                this._viewOutpanels[view] = panel;
            }
            OutPanel = panel;
        }
    }
}
