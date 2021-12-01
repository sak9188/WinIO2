using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WinIO.FluentWPF;
using WinIO.Models;
using WinIO.PythonNet;

namespace WinIO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    internal partial class MainWindow : AcrylicWindow 
    {
        public static App app;

        public static void TestFun()
        {
            Console.WriteLine("you are the best member");
        }

        private dynamic pytest_mod; 

        public MainWindow()
        {
            app = Application.Current as App;
            InitializeComponent();

            var a = new MenuItemView();
            a.Title = "test0";
            a.Icon = "../../../splash.png";
            a.Add(new MenuItemView(){ Title = "nononono"});

            MainMenu.ItemsSource = new List<MenuItemView>()
            {
                a,
                new MenuItemView(){ Title = "test1"},
                //new MenuItemView(){ Title = "test2"},
                //new MenuItemView(){ Title = "test3"},
            };

            pytest_mod = Py.Import("test_test");
            Action<string, string> del = app.Notification;
            pytest_mod.test_obj.val = del;
            pytest_mod.test_obj.win = this;
            Console.WriteLine(pytest_mod.test_obj.val);
        }


        #region ComponentAddation
        public void AddButton()
        {
        }

        public void Recur()
        {
            pytest_mod.test_obj.recur();
        }
        #endregion

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            pytest_mod.test_obj.invoke();
            pytest_mod.test_obj.recur();
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("setset");
        }
    }
}

