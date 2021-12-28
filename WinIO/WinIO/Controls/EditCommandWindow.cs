using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinIO.Controls
{
    public partial class EditCommandWindow : ReuseWindow
    {
        private List<CommandControl> commandControls = new List<CommandControl>();

        public IEnumerable<CommandControl> Child => commandControls;

        public EditCommandWindow()
        {
            InitializeComponent();
        }

        public void AddQuickCommand(object sender, EventArgs arggs)
        {
            CommandControl command = new CommandControl();
            commandControls.Add(command);

            Items.Children.Add(command);
        }
    }
}
