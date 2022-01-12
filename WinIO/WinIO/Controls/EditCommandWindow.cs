using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WinIO.Models;

namespace WinIO.Controls
{
    public partial class EditCommandWindow : ReuseWindow
    {
        private List<CommandControl> _commandControls = new List<CommandControl>();

        private CommandControl _currentControl;

        private ModifyIconWindow _modifyIconWindow = new ModifyIconWindow();

        public IEnumerable<CommandControl> Child => _commandControls;

        public static readonly RoutedEvent AddCommandEvent = EventManager.RegisterRoutedEvent(
        "AddCommand", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(EditCommandWindow));

        public RoutedEventHandler AfterAddCommand;

        public EditCommandWindow()
        {
            InitializeComponent();
            Items.MouseLeave += ItemsMouseLeave;
        }

        private void AddCommand(CommandView view = null)
        {
            CommandControl command = new CommandControl();
            command.MouseEnter += MouseEventHandler;

            _commandControls.Add(command);
            Items.Children.Add(command);
            
            if(view == null)
            {
                view = new CommandView();
            }
            command.View = view;

            AfterAddCommand?.Invoke(this, new RoutedEventArgs(AddCommandEvent, view));
        }
        public void AddQuickCommand(object sender, EventArgs arggs)
        {
            AddCommand();
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

        public void AddShortcutCommand(CommandView commandView)
        {
            // 这里是一个后端接口, 方便直接再代码层面操作
            AddCommand(commandView);
        }
    }
}
