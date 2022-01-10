using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace WinIO.Controls
{
    public partial class EditCommandWindow : ReuseWindow
    {
        private List<CommandControl> _commandControls = new List<CommandControl>();

        private CommandControl _currentControl;

        private ModifyIconWindow _modifyIconWindow = new ModifyIconWindow();
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
        private void ModifyCommandIcon(object sender, EventArgs arggs)
        {
            if(_currentControl != null)
            {
                var curcontrl = _currentControl;

                _modifyIconWindow.SelectControl = curcontrl;
                _modifyIconWindow.ShowDialog();
            }
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
        }
    }
}
