using System;
using System.Windows.Forms;
using BatteryStatus.Forms;

namespace BatteryStatus
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain(args.Length == 0));
        }
    }
}
