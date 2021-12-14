using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinIO.FluentWPF;

namespace WinIO.Controls
{
    public class ReuseWindow : AcrylicWindow
    {
        private bool CanClose = false;

        public ReuseWindow()
        {
            
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
                this.Visibility = System.Windows.Visibility.Hidden;
            }
        }
    }
}
