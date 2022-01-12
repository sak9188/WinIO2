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
using WinIO.Models;

namespace WinIO.Controls
{
    /// <summary>
    /// Interaction logic for CommandControl.xaml
    /// </summary>
    public partial class CommandControl : UserControl
    {
        #region Property
        public static readonly DependencyProperty IconProperty = DependencyProperty.Register(
           "Icon", typeof(ImageSource), typeof(CommandControl), new PropertyMetadata(null, AfterIconPropertyChanged));
        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static void AfterIconPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CommandControl cc = d as CommandControl;
            cc.View.Icon = cc.Icon.ToString();
        }

        public static readonly DependencyProperty ViewProperty = DependencyProperty.Register(
            "View", typeof(CommandView), typeof(CommandControl), 
            new PropertyMetadata(new CommandView(), AfterViewPropertyChanged));
        public CommandView View
        {
            get { return (CommandView)GetValue(ViewProperty); }
            set { SetValue(ViewProperty, value); }
        }

        public static void AfterViewPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CommandControl cc = d as CommandControl;
            CommandView view = e.OldValue as CommandView;
            cc.View.Icon = cc.Icon.ToString();
            cc.View.Header = view.Header;
            cc.View.Command = view.Command;
        }
        #endregion

        #region Field
        private static ImageSource _defaultImage;
        private ReuseWindow _commandTextWindow;
        private TextBox _commandBox;
        #endregion

        public CommandControl()
        {
            InitializeComponent();
            if(_defaultImage == null)
            {
                _defaultImage = GResources.GetImage("folder").Source;
            }
            Icon = _defaultImage;
            View.Command = "# 输入指令";
            // CommandString = "# 输入指令";
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
                binding.Path = new PropertyPath("View.Command");
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
