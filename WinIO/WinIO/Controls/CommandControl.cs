using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WinIO.Controls
{
    /// <summary>
    /// Interaction logic for CommandControl.xaml
    /// </summary>
    public partial class CommandControl : UserControl
    {
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
           "Icon", typeof(ImageSource), typeof(CommandControl));
        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
            "Header", typeof(string), typeof(CommandControl));
        public string Header
        {
            get { return (string)GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        public static readonly DependencyProperty CommandStringProperty = DependencyProperty.Register(
            "CommandString", typeof(string), typeof(CommandControl));
        public string CommandString
        {
            get { return (string)GetValue(CommandStringProperty); }
            set { SetValue(CommandStringProperty, value); }
        }

        private static ImageSource _defaultImage;
        public CommandControl()
        {
            InitializeComponent();
            if(_defaultImage == null)
            {
                _defaultImage = GResources.GetImage("folder").Source;
            }
            Icon = _defaultImage;
            CommandString = "# 双击输入指令";
        }

        private void CommandInputMouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Console.WriteLine(this.Header);
        }
    }
}
