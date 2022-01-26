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
        static void Main(string[] args)
        {
            InitPythonPath(args);
            PythonEngine.Initialize();
            app = new App();
            app.InitializeComponent();
            app.MainWindow = new MainWindow();
            InitPythonEntry(args);
            app.MainWindow.Show();
            var state = PythonEngine.BeginAllowThreads();
            app.Run();
            PythonEngine.EndAllowThreads(state);
            PythonEngine.Shutdown();
        }

        internal static string GetPythonPath(string[] args)
        {
            if(args.Length >= 1)
            {
                return args[0];
            }
            return ".";
        }
        internal static string GetPythonEntry(string[] args)
        {
            if(args.Length >= 2)
            {
                return args[1];
            }
            return "WinIOMain";
        }

        internal static void InitPythonPath(string[] args)
        {
            // Debug ../../../Scripts
            var path = GetPythonPath(args);
            var beforePath = Environment.GetEnvironmentVariable("PYTHONPATH");
            Environment.SetEnvironmentVariable("PYTHONPATH", beforePath + ";" + path, EnvironmentVariableTarget.Process);
        }

        private static void InitPythonEntry(string[] args)
        {
            var entry = GetPythonEntry(args);
            _entry = Py.Import(entry);
        }
    }
}
