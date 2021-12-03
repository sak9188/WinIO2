using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinIO.PythonNet;

namespace WinIO
{
    public static class MainProgram
    {
        public static App app;

        private static PyObject _entry; 

        [STAThread]
        static void Main()
        {
            InitPythonPath();
            PythonEngine.Initialize();
            app = new App();
            app.InitializeComponent();
            app.MainWindow = new MainWindow();
            InitPythonEntry();
            app.MainWindow.Show();
            app.Run();
            PythonEngine.Shutdown();
        }

        internal static void InitPythonPath()
        {
            var beforePath = Environment.GetEnvironmentVariable("PYTHONPATH");
            Environment.SetEnvironmentVariable("PYTHONPATH", beforePath + ";../../../Scripts", EnvironmentVariableTarget.Process);
        }

        private static void InitPythonEntry()
        {
            // TODO : 这个应该由系统传参进来 
            _entry = Py.Import("WinIOMain");
        }
    }
}
