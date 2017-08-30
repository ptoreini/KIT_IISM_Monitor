using EyeXFramework.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IISMWelcomeMonitorProject
{
    static class Program
    {
        private static FormsEyeXHost _eyeXHost = new FormsEyeXHost();
        public static FormsEyeXHost EyeXHost
        {
            get { return _eyeXHost; }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _eyeXHost.Start();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CalibrationForm());
            _eyeXHost.Dispose();
        }
    }
}
