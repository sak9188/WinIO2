using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WinIO.FluentWPF;

namespace WinIO.Controls
{
    public class ReuseWindow : AcrylicWindow
    {
        private static List<ReuseWindow> _resuses = new List<ReuseWindow>();
        private bool CanClose = false;

        public event EventHandler AfterHidden;

        public ReuseWindow()
        {
            _resuses.Add(this);
        }

        public void RealClose()
        {
            CanClose = true;
            this.Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if(!CanClose)
            {
                e.Cancel = true; 
                this.Visibility = Visibility.Hidden;
                AfterHidden?.Invoke(this, e);
            }
        }
        public static void AppExitHandler(object sender, ExitEventArgs e)
        {
            foreach (var item in _resuses)
            {
                item.RealClose();
            }
        }
    }
}
