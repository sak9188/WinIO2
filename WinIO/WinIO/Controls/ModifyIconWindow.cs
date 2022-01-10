using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WinIO.Controls
{
    /// <summary>
    /// Interaction logic for ModifyIconWindow.xaml
    /// </summary>
    public partial class ModifyIconWindow : ReuseWindow
    {
        public static readonly DependencyProperty SelectImageProperty = DependencyProperty.Register(
            "SelectImage", typeof(ImageSource), typeof(ModifyIconWindow), new PropertyMetadata(null, OnSelectImageChange));

        public ImageSource SelectImage
        {
            get { return (ImageSource)GetValue(SelectImageProperty); }
            set
            { 
                SetValue(SelectImageProperty, value);
                SetSelectedImage(value);
            }
        }

        private CommandControl _selectControl;
        public CommandControl SelectControl
        {
            get 
            {
                return _selectControl;
            }
            set 
            {
                if(value != null)
                {
                    SelectImage = value.Icon;
                }
                _selectControl = value; 
            }
        }

        public ModifyIconWindow()
        {
            InitializeComponent();
            this.Closing += ModifyIconWindowClosing;
        }

        private void ModifyIconWindowClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SelectControl = null;
        }

        private void SetSelectedImage(ImageSource source)
        {
            for (int i = 0; i < SelectPanel.Items.Count; i++)
            {
                if (((Image)SelectPanel.Items[i]).Source == source)
                {
                    SelectPanel.SelectedIndex = i;
                    break;
                }
            }
        }

        private static void OnSelectImageChange(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            ModifyIconWindow window = sender as ModifyIconWindow;
            if(window.SelectControl != null)
            {
                window.SelectControl.Icon = window.SelectImage;
            }  
        }
    }
}
