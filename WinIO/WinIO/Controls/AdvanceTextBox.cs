using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WinIO.Controls
{
    public class AdvanceTextBox: TextBox
    {
        public enum EInputType
        {
            eString,
            eInteger,
            eDouble,
        }

        private static readonly Regex _integerRegex = new Regex("[^0-9-]+");
        private static readonly Regex _doubleRegex = new Regex("[^0-9.-]+");

        private EInputType _inputType;
        private dynamic _pyOjbect;

        public AdvanceTextBox(dynamic _pyobjct, EInputType inputType = EInputType.eString)
        {
            this._pyOjbect = _pyobjct;
            this._inputType = inputType;
            this.FormatValue(_pyobjct);
            this.MinWidth = 200;
            this.Style = TryFindResource("TextBoxRevealStyle") as Style;
        }

        private void FormatValue(dynamic pyobj)
        {
            string format = "F0";
            switch(this._inputType)
            {
                case EInputType.eInteger:
                    break;
                case EInputType.eDouble:
                    format = "F";
                    break;
                case EInputType.eString:
                    break;
            }
            double d = _pyOjbect?.control;
            this.Text = d.ToString(format);
        }

        private bool InputCheck(string text)
        {
            switch(this._inputType)
            {
                case EInputType.eInteger:
                    return _integerRegex.IsMatch(text);
                case EInputType.eDouble:
                    return _doubleRegex.IsMatch(text);
                case EInputType.eString:
                    return true;
            }
            return false;
        }
           
        protected override void OnPreviewTextInput(TextCompositionEventArgs e)
        {
            base.OnPreviewTextInput(e);
            e.Handled = InputCheck(e.Text);
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            try
            {
                double size = Convert.ToDouble(this.Text);
                if(size >= 5)
                {
                    if(_pyOjbect)
                    {
                        _pyOjbect.control = size;
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
