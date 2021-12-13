using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WinIO.AvalonDock;
using WinIO.AvalonDock.Layout;
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

        public EventHandler AfterClosed;

        public MainWindow()
        {
            app = Application.Current as App;
            InitializeComponent();
            this.Closed += MainWindow_Closed;
            TestCom.ItemsSource = new List<string>() { "AutoBike", "AutoSercke"};
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            if(AfterClosed != null)
            {
                AfterClosed.Invoke(sender, e);
            }
        }
    }
}

