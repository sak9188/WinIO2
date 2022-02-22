using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Linq;
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
        #region PublicField
        private static Color _imageFallColor = Color.FromArgb(153, 0, 0, 0);

        private EditCommandWindow _editCommandWindow;

        private Color _originalFallColor;

        private Separator _menuSeperator;

        // MenuItemView的观察者集合
        private ObservableCollection<object> _menuItemViews = new ObservableCollection<object>();
        #endregion

        #region PublicField
        public static App app;

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
            this.Closed += MainWindowClosed;

            // 初始化子组件
            _editCommandWindow = new EditCommandWindow();
            _editCommandWindow.AfterAddCommand += AfterAddCommand;
            _editCommandWindow.AfterRemoveCommand += AfterRemoveCommand;
            ToolMenu.ItemsSource = _menuItemViews;

            // 面板重排算法
            var eightView = new MenuItemView();
            eightView.Title = "AllIn One";
            eightView.Click += (o,e) => ColumnsResort(1, 1);
            _menuItemViews.Add(eightView);

            eightView = new MenuItemView();
            eightView.Title = "两行两列";
            eightView.Click += (o,e) => ColumnsResort(2, 2);
            _menuItemViews.Add(eightView);

            eightView = new MenuItemView();
            eightView.Title = "两行四列";
            eightView.Click += (o,e) => ColumnsResort(2, 4);
            _menuItemViews.Add(eightView);

            eightView = new MenuItemView();
            eightView.Title = "三行三列";
            eightView.Click += (o,e) => ColumnsResort(3, 3);
            _menuItemViews.Add(eightView);
        
            // 分割线
            _menuSeperator = new Separator();
            _menuItemViews.Add(_menuSeperator);

            // 命令View
            var commandView = new MenuItemView();
            commandView.Title = "指令编辑";
            commandView.Icon = "Assets/Icons/plus.png";
            commandView.Click += AddShortcutCommand;
            _menuItemViews.Add(commandView);
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

        #region Exposure
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
        }

        public void ColumnsResort(int row, int col)
        {
            // Check一下
            if (row <= 0) row = 1;
            if (col <= 0) col = 1;

            // 排列算法
            // 获得所有的子窗口
            var anchors = MainDock.Layout.Descendents().OfType<CustomeDocument>().Where(x => !x.BanResort).ToList();

            // 没有窗口的话，排个吉尔
            if (anchors.Count == 0)
                return;

            var group = MainPanelGroup;
            group.RemoveAllChild();

            // 然后干掉它们的父亲节点
            foreach (var anchor in anchors)
            {
                // 先全部移除子节点
                anchor.Parent.RemoveChild(anchor);
            }
            int maxNum = row * col; 
            if(anchors.Count >= maxNum)
            {
                // 创建容器
                var paneGroups = new List<LayoutDocumentPaneGroup>();
                var panes = new List<LayoutDocumentPane>();
                for (int j = 0; j < col; j++)
                {
                    var newGroup = new LayoutDocumentPaneGroup();
                    newGroup.Orientation = Orientation.Vertical;
                    
                    for(int k = 0; k < row; k++)
                    {
                        var child = new LayoutDocumentPane();
                        newGroup.InsertChildAt(0, child);
                        panes.Add(child);
                    }

                    paneGroups.Add(newGroup);
                }

                // 插入已经弄好的容器
                int i = 0;
                foreach (var item in anchors)
                {
                    panes[i % maxNum].InsertChildAt(0, item);
                    i += 1;
                }
                
                // 插入容器里
                group.Orientation = Orientation.Horizontal;
                foreach(var panegroup in paneGroups)
                {
                    group.InsertChildAt(0, panegroup);
                }
            }
            else if(anchors.Count >= col)
            {
                // 创建容器
                var paneGroups = new List<LayoutDocumentPaneGroup>();
                var panes = new List<LayoutDocumentPane>();
                for (int j = 0; j < col; j++)
                {
                    var newGroup = new LayoutDocumentPaneGroup();
                    newGroup.Orientation = Orientation.Vertical;
                    paneGroups.Add(newGroup);
                }

                for(int k = 0; k < anchors.Count; k++)
                {
                    var paneGroup = paneGroups[k % row];
                    var pane = new LayoutDocumentPane();
                    pane.InsertChildAt(0, anchors[k]);
                    group.InsertChildAt(0, pane);
                }

                // 插入容器里
                foreach(var panegroup in paneGroups)
                {
                    group.InsertChildAt(0, panegroup);
                }
            }
            else
            {
                foreach(var anchor in anchors)
                {
                    var pane = new LayoutDocumentPane();
                    pane.InsertChildAt(0, anchor);
                    group.InsertChildAt(0, pane);
                }
            }

            // 收集一下垃圾
            MainDock.Layout.CollectGarbage();
        }

        public void AddPanel(LayoutAnchorable anchorable)
        {
            var pane = this.MainDock.Layout.Descendents().OfType<LayoutDocumentPane>().First();
            if(pane == null)
            {
                pane = new LayoutDocumentPane();
                MainPanelGroup.InsertChildAt(0, pane);
            }
            pane.InsertChildAt(0, anchorable);
        }

        public void RemovePanel(LayoutAnchorable anchorable)
        {
            anchorable.Parent?.RemoveChild(anchorable);
        }

        #endregion

        #region EventHandler
        private void MainWindowClosed(object sender, EventArgs e)
        {
            if(AfterClosed != null)
            {
                AfterClosed.Invoke(sender, e);
            }
            
            // 只要主界面退出, 那么整个应用程序直接退出
            app.Shutdown();
        }

        private void AddShortcutCommand(object sender, RoutedEventArgs e)
        {
            _editCommandWindow.ShowDialog();
        }

        private void AfterAddCommand(object sender, RoutedEventArgs e)
        {
            CommandView view = e.Source as CommandView;

            MenuItemView menuView = new MenuItemView();
            menuView.CommandView = view;

            // -1 是倒数第二个
            _menuItemViews.Insert(_menuItemViews.Count - 1, menuView);
        }
        private void AfterRemoveCommand(object sender, RoutedEventArgs e)
        {
            CommandView view = e.Source as CommandView;

            var query = from o in _menuItemViews.OfType<MenuItemView>().ToList()
                        where o.CommandView == view select o;

            if (query.First() != null)
            {
                // -1 是倒数第二个
                _menuItemViews.Remove(query.First());
            }
        }
        #endregion
    }
}

