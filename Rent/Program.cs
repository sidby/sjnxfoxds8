using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Rent
{
    internal static partial class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isFirstInstance;
            Mutex mutex = new Mutex(false, "Local\\SidByRent", out isFirstInstance);
            if (isFirstInstance)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                MainRentForm mainRentForm = new MainRentForm();
                mainRentForm.Closed += HandleMainCropFormClosed;
                Application.Run(mainRentForm);
                GC.KeepAlive(mutex);
            }
        }

        private static void HandleMainCropFormClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
