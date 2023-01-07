using System;
using System.Collections.Generic;
using System.Data.HikHCNetSDK;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HikHCNetSDK.WinForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            HikHCNetSdk.Create();
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
