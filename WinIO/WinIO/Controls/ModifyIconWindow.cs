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
            "SelectImage", typeof(ImageSource), typeof(ModifyIconWindow));

        public ImageSource SelectImage
        {
            get { return (ImageSource)GetValue(SelectImageProperty); }
            set { SetValue(SelectImageProperty, value); }
        }

        public ModifyIconWindow()
        {
            InitializeComponent();
        }
    }
}
