using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using WinIO.FluentWPF;

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
        private ReuseWindow _commandTextWindow;
        private TextBox _commandBox; 
        public CommandControl()
        {
            InitializeComponent();
            if(_defaultImage == null)
            {
                _defaultImage = GResources.GetImage("folder").Source;
            }
            Icon = _defaultImage;
            CommandString = "# 输入指令";
        }

        private void CommandInputMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            if (_commandTextWindow == null)
            { 
                ReuseWindow window = new ReuseWindow();
                StackPanel stackPanel = new StackPanel();
                window.Content = stackPanel;
                TextBox textbox = new TextBox();
                _commandTextWindow = window;
                _commandTextWindow.Owner = Window.GetWindow(this);
                _commandTextWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                _commandBox = textbox;
                _commandBox.Style = this.FindResource("TextBoxRevealStyle") as Style;
                _commandBox.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                _commandBox.HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;

                Binding binding = new Binding();
                binding.Source = this;
                binding.Path = new PropertyPath("CommandString");
                binding.Mode = BindingMode.TwoWay;
                _commandBox.SetBinding(TextBox.TextProperty, binding);

                stackPanel.Children.Add(textbox);
                textbox.AcceptsReturn = true;
                textbox.AcceptsTab = true;
                textbox.Width = 400;
                textbox.Height = 400;
                window.Height = 450;
                window.Width = 450;
            }
            _commandTextWindow.ShowDialog();
        }
    }
}
