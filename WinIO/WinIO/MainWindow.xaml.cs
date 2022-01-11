using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WinIO.AvalonDock;
using WinIO.AvalonDock.Layout;
using WinIO.Controls;
using WinIO.FluentWPF;
using WinIO.Models;

namespace WinIO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    internal partial class MainWindow : AcrylicWindow 
    {
        #region PrivateField
        private static Color _imageFallColor = Color.FromArgb(153, 0, 0, 0);

        public static App app;

        private EditCommandWindow _editCommandWindow;

        private Color _originalFallColor;

        private Separator _menuSeperator;

        // MenuItemView的观察者集合
        private ObservableCollection<object> _menuItemViews = new ObservableCollection<object>();
        #endregion

        #region PublicField
        public Menu PanelMenu => this.MainMenu;

        public Menu WindowMenu => this.HeadMenu;

        public DockingManager DockMgr => this.MainDock;

        public LayoutDocumentPane MainDockPane => MainDockPanel;

        public LayoutAnchorablePane LeftMainDockPane => LeftMainDockPanel;
        #endregion

        public EventHandler AfterClosed;

        public MainWindow()
        {
            // 初始化一些必要的资源
            app = Application.Current as App;
            InitializeComponent();
            _originalFallColor = this.FallbackColor;

            // 初始化事件
            this.Closed += MainWindow_Closed;

            // 初始化子组件
            _editCommandWindow = new EditCommandWindow();
            ToolMenu.ItemsSource = _menuItemViews;
        
            // 分割线
            _menuSeperator = new Separator();
            _menuItemViews.Add(_menuSeperator);

            // 命令View
            var commandView = new MenuItemView();
            commandView.Title = "添加一个快捷指令";
            commandView.Icon = "Assets/Icons/plus.png";
            commandView.Click += AddShortcutCommand;
            _menuItemViews.Add(commandView);
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            if(AfterClosed != null)
            {
                AfterClosed.Invoke(sender, e);
            }
            
            // 只要主界面退出, 那么整个应用程序直接退出
            app.Shutdown();
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
        

        private void AddShortcutCommand(object sender, RoutedEventArgs e)
        {
            _editCommandWindow.ShowDialog();
        }
        public void AddToolCommand(MenuItemView menuItemView)
        {
            // 这里是一个后端接口, 方便直接再代码层面操作
            // 增加一个前面的一个快捷命令，这个命令不可直接通过UI编辑
            _menuItemViews.Insert(_menuItemViews.IndexOf(_menuSeperator) - 1, menuItemView);
        }

        public void AddShortcutCommand(CommandView commandView)
        {
            // 这里是一个后端接口, 方便直接再代码层面操作
            _editCommandWindow.AddShortcutCommand(commandView);
            MenuItemView view = new MenuItemView();
            view.CommandView = commandView;

            // -1 是最后一个, -2是倒数第一个之前
            _menuItemViews.Insert(_menuItemViews.Count-2, view);
        }
    }
}

