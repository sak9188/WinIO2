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
            // 优先初始化Python， 然后在是WPF
            // 这里测试一下Python
            PythonEngine.Initialize();
            App app = new App();
            app.InitializeComponent();
            app.Run();
            PythonEngine.Shutdown();
        }
    }
}
