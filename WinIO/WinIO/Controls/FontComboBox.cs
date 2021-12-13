using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace WinIO.Controls
{
    public class FontComboBox: ComboBox
    {
        private static FontFamily _defaultFont;

        private dynamic _pyObject;

        public FontComboBox(dynamic pyOjbect)
        {
            this._pyObject = pyOjbect;
            this.Style = TryFindResource("BaseSettingComboBox") as Style;
            this.ItemsSource = Fonts.SystemFontFamilies;
            if(_defaultFont == null)
            {
                _defaultFont = TryFindResource("OutputDefaultFontFamily") as FontFamily;
            }
            this.SelectedItem = _defaultFont;
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            base.OnLostFocus(e);

            var font = from f in Fonts.SystemFontFamilies where f.Source.Equals(this.Text) select f;
            if(font.Any())
            {
                var firstFont = font.First();
                this.SelectedItem = firstFont;
                if(_pyObject)
                {
                    // 这里应该是配置描述符
                    _pyObject.control = firstFont;
                }
            }
            else
            {
                this.Text = _defaultFont.Source;
            }
        }
    }
}
