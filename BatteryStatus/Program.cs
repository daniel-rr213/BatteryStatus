using BatteryStatus.Forms;
using System;
using System.Windows.Forms;

namespace BatteryStatus
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain(args.Length == 0));
        }
    }
}