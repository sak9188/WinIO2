using System;
using System.Windows;
using System.Windows.Controls;
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

        public DockingManager DockMgr => this.MainDock;

        public LayoutDocumentPane MainDockPane => MainDockPanel;

        public EventHandler AfterClosed;

        public MainWindow()
        {
            app = Application.Current as App;
            InitializeComponent();
            this.Closed += MainWindow_Closed;
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

