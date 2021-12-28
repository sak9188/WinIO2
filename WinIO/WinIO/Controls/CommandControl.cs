using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WinIO.Controls
{
    /// <summary>
    /// Interaction logic for CommandControl.xaml
    /// </summary>
    public partial class CommandControl : UserControl
    {
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
           "Icon", typeof(string), typeof(CommandControl));
        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
            "Header", typeof(double), typeof(CommandControl));
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

        public CommandControl()
        {
            InitializeComponent();
        }
    }
}
