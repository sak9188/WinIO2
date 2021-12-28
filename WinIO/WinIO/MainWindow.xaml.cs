using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WinIO.AvalonDock;
using WinIO.AvalonDock.Layout;
using WinIO.Controls;
using WinIO.FluentWPF;

namespace WinIO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    internal partial class MainWindow : AcrylicWindow 
    {
        public static App app;

        public Menu PanelMenu => this.MainMenu;

        public Menu WindowMenu => this.HeadMenu;

        public DockingManager DockMgr => this.MainDock;

        public LayoutDocumentPane MainDockPane => MainDockPanel;

        public LayoutAnchorablePane LeftMainDockPane => LeftMainDockPanel;

        public EventHandler AfterClosed;

        private EditCommandWindow _editCommandWindow = new EditCommandWindow();

        private Color _originalFallColor;

        private static Color _imageFallColor = Color.FromArgb(153, 0, 0, 0);

        public MainWindow()
        {
            app = Application.Current as App;
            InitializeComponent();
            this.Closed += MainWindow_Closed;
            _originalFallColor = this.FallbackColor;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            if(AfterClosed != null)
            {
                AfterClosed.Invoke(sender, e);
            }
        }

        public void SetBackground(string imgPath)
        {
            if(string.IsNullOrEmpty(imgPath))
            {
                this.Background = null;
                this.FallbackColor = this._originalFallColor;
                return;
            }
            var brush = new ImageBrush();
            try
            {
                brush.ImageSource = new BitmapImage(new Uri(imgPath, UriKind.Relative));
            }
            // 这里一般都是没有找到， 或者IO错误， 如果有问题就直接不管了
            catch (Exception)
            {
                return;
            }
            this.Background = brush;
            this.FallbackColor = _imageFallColor;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            // 这里是一个测试函数
            // AcrylicPopup acrylicPopup = new AcrylicPopup();
            // StackPanel stackPanel = new StackPanel();
            // acrylicPopup.Child = stackPanel;

            // stackPanel.Orientation = Orientation.Horizontal;

            // foreach(var img in GResources.GetImages())
            // {
            //     img.Style = FindResource("ShowIconStyle") as Style;
            //     stackPanel.Children.Add(img);
            // }

            // acrylicPopup.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            // acrylicPopup.PlacementTarget = sender as MenuItem;
            // acrylicPopup.PopupAnimation = System.Windows.Controls.Primitives.PopupAnimation.Fade;
            // acrylicPopup.IsOpen = true;
        }
        

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            _editCommandWindow.ShowDialog();
        }
    }
}

