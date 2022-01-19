using System;
using System.Collections.Generic;
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

namespace WinIO.Controls
{
    /// <summary>
    /// Interaction logic for ComandWindow.xaml
    /// </summary>
    public partial class ComandWindow : AcrylicWindow
    {
        public ComandWindow()
        {
            InitializeComponent();
        
            // 初始化选项
            textEditor.Options.ShowColumnRuler = true;
            textEditor.Options.ShowEndOfLine = true;
            textEditor.Options.ShowTabs = true;
            textEditor.Options.ShowSpaces = true;
        }
    }
}
