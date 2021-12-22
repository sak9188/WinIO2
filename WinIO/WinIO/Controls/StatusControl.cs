using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WinIO.Controls
{
    public class StatusControl : UserControl
    {
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof(string), typeof(StatusControl));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty CurrentValueProperty = DependencyProperty.Register(
            "CurrentValue", typeof(double), typeof(StatusControl));
        public double CurrentValue
        {
            get { return (double)GetValue(CurrentValueProperty); }
            set { SetValue(CurrentValueProperty, value); }
        }

        public static readonly DependencyProperty ShowProgressBarProperty = DependencyProperty.Register(
            "ShowProgressBar", typeof(Visibility), typeof(StatusControl),
            new FrameworkPropertyMetadata(Visibility.Visible, FrameworkPropertyMetadataOptions.AffectsRender));
        public Visibility ShowProgressBar
        {
            get { return (Visibility)GetValue(ShowProgressBarProperty); }
            set { SetValue(ShowProgressBarProperty, value); }
        }

        static StatusControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StatusControl), new FrameworkPropertyMetadata(typeof(StatusControl)));
        }

        public StatusControl()
        {
            this.Margin = new Thickness(2, 0, 2, 2);
        }
    }
}
