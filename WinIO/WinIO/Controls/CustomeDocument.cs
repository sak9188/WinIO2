using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinIO.AvalonDock.Layout;

namespace WinIO.Controls
{
    public class CustomeDocument : LayoutDocument
    {
        private bool _canRealClose;
        
        public bool CanRealClose
        {
            get { return _canRealClose; }
            set
            {
                _canRealClose = value;
            }
        }

        public CustomeDocument()
        {
        }

        private void CustomeDocument_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(!this.CanRealClose)
            {
                e.Cancel = true;
                this.Parent.RemoveChild(this);
            }
        }
    }
}
