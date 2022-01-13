using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinIO.AvalonDock.Layout;

namespace WinIO.Controls
{
    public class CustomeDocument : LayoutAnchorable
    {
        private bool _banResort;

        public bool BanResort
        {
            get => _banResort;
            set => _banResort = value;
        }
        public CustomeDocument()
        {
        }
    }
}
