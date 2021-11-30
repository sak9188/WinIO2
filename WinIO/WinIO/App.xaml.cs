using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

using NotifyIcon = System.Windows.Forms.NotifyIcon;
using ToolTipIcon = System.Windows.Forms.ToolTipIcon;

namespace WinIO
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region Field
        private readonly NotifyIcon _notifyIcon;

        #endregion

        public App()
        {
            // notifyIcon
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = System.Drawing.Icon.ExtractAssociatedIcon(Assembly.GetExecutingAssembly().Location);
            _notifyIcon.Visible = true;

            this.Exit += AppExitHandler;
            this.DispatcherUnhandledException += HandleDispatcherException;
            AppDomain.CurrentDomain.UnhandledException += HandelApplicationException; 
        }

        private void AppExitHandler(object sender, ExitEventArgs e)
        {
            _notifyIcon.Visible = false;
        }

        #region Notification
        public void Notification(int time, string title, string context, ToolTipIcon icon = ToolTipIcon.None)
        {
            _notifyIcon.ShowBalloonTip(time, title, context, icon);
        }

        public void Notification(string title, string context)
        {
            Notification(1000, title, context);
        }
        #endregion

        #region HandleExption
        private void HandelApplicationException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine(e.ToString());
        }

        private void HandleDispatcherException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            Console.WriteLine(e.Exception.StackTrace);
        }
        #endregion
    }
}
