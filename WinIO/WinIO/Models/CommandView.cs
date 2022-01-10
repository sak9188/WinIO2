using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinIO.Models
{
    public class CommandView : INotifyPropertyChanged
    {
        #region Field
        private string _header;
        private string _command;
        
        public event PropertyChangedEventHandler PropertyChanged;
            
        public string Header
        {
            get => _header;
            set
            {
                _header = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Header"));
                }
            }
        }

        public string Command
        {
            get => _command;
            set
            {
                _command = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("Command"));
                }
            }
        }
        #endregion
    }
}
