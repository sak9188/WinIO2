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

        [STAThread]
        static void Main()
        {
            InitPythonPath();
            PythonEngine.Initialize();
            var str = PythonEngine.PythonPath;
            App app = new App();
            app.InitializeComponent();
            app.Run();
            PythonEngine.Shutdown();
        }

        internal static void InitPythonPath()
        {
            var beforePath = Environment.GetEnvironmentVariable("PYTHONPATH");
            Environment.SetEnvironmentVariable("PYTHONPATH", beforePath + ";../../../Scripts", EnvironmentVariableTarget.Process);
        }
    }
}
