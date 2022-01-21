using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WinIO.PythonNet;

namespace WinIO.Models
{
    public class CommandView : INotifyPropertyChanged
    {
        #region Field
        private string _icon;
        private string _header;
        private string _command;
        
        public event PropertyChangedEventHandler PropertyChanged;
        public string Icon
        {
            get => _icon;
            set
            {
                _icon = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Icon"));
            }
        }
            
        public string Header
        {
            get => _header;
            set
            {
                _header = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Header"));
            }
        }

        public string Command
        {
            get => _command;
            set
            {
                _command = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Command"));
            }
        }
        #endregion
        public void AfterClickCommand(object sender, RoutedEventArgs e)
        {
            using(Py.GIL())
            {
                PythonEngine.ExecEx(this.Command);
            }
        }
    }
}
