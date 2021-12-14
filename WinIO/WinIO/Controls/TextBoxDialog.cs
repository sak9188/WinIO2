using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WinIO.Controls
{
    public class TextBoxDialog : UserControl
    {
        private dynamic _pyObject;
        private TextBox _tbox;

        public TextBoxDialog(dynamic obj)
        {
            this._pyObject = obj;

            var stack = new StackPanel();
            var textBox = new TextBox() { Style=TryFindResource("TextBoxRevealStyle") as Style, Width=250 };
            Thickness margin = new Thickness(4, 3, 4, 3);
            var button = new Button() { Content="选择", Style=TryFindResource("ButtonRevealStyle") as Style, Padding=margin};

            stack.Orientation = Orientation.Horizontal;
            stack.Children.Add(textBox);
            stack.Children.Add(button);
            this.Content = stack;
            this._tbox = textBox;

            textBox.IsReadOnly = true;
            button.Click += Button_Click;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 这里需要弹出一个对话框
            var openFileDialog = new Microsoft.Win32.OpenFileDialog()
            {
                Filter = "图片文件 (.png)|*.png"
            };
            var result = openFileDialog.ShowDialog();
            if (result == true)
            {
                if(_pyObject)
                {
                    _tbox.Text = openFileDialog.FileName;
                    _pyObject.control = openFileDialog.FileName;
                }    
            }
        }
    }
}
