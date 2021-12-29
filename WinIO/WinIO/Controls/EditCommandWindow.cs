using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WinIO.Controls
{
    public partial class EditCommandWindow : ReuseWindow
    {
        private List<CommandControl> _commandControls = new List<CommandControl>();

        private CommandControl _currentControl;

        public IEnumerable<CommandControl> Child => _commandControls;

        public EditCommandWindow()
        {
            InitializeComponent();

            Items.MouseLeave += ItemsMouseLeave;
        }
        public void AddQuickCommand(object sender, EventArgs arggs)
        {
            CommandControl command = new CommandControl();
            command.MouseEnter += MouseEventHandler;

            _commandControls.Add(command);
            Items.Children.Add(command);
        }

        private void ItemsMouseLeave(object sender, MouseEventArgs e)
        {
            _currentControl = null;
        }

        private void DeleteCommandControl(object sender, EventArgs arggs)
        {
            if(_currentControl != null)
            {
                Items.Children.Remove(_currentControl);
            }
        }

        private void MouseEventHandler(object sender, MouseEventArgs e)
        {
            _currentControl = sender as CommandControl;
            Console.WriteLine(_currentControl);
        }
    }
}
