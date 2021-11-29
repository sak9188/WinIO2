using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WinIO.FluentWPF;

namespace WinIO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : AcrylicWindow
    {
        #region Field

        private readonly NotifyIcon _notifyIcon;

        #endregion

        
        public MainWindow()
        {
            InitializeComponent();
            
            // notifyIcon
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            _notifyIcon.BalloonTipClosed += (s, e) => _notifyIcon.Visible = false;
        }

        private void Notification(int time, string title, string context, ToolTipIcon icon = ToolTipIcon.None)
        {
            _notifyIcon.Visible = true;
            _notifyIcon.ShowBalloonTip(time, title, context, icon);
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            TestShowNotification();
        }


        private void TestShowNotification()
        {
            Notification(1000, "fuck:", "test");
        }
    }
}
