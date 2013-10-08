using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace RentUpdater
{
    public partial class UpdaterForm : Form
    {
        public UpdaterForm()
        {
            InitializeComponent();
        }

        private void Update(object state)
        { 
            Mutex mtx = new Mutex(false, "RentMutex");
            bool isAppRunning = true;

            while (isAppRunning)
            {
                isAppRunning = !mtx.WaitOne(0, false);
            }

            //wait for the process to completely end
            Thread.Sleep(5000);

            string source = Program.Args[0];
            string destination = Program.Args[1];

            DirectoryInfo dir = new DirectoryInfo(source);

            foreach (FileInfo file in dir.GetFiles())
            {
                string dest = Path.Combine(destination, file.Name);
                FileInfo fi = new FileInfo(dest);
                if (fi.CreationTime != file.CreationTime) file.CopyTo(dest, true);
            }

            System.Diagnostics.Process.Start(Path.Combine(destination, "Rent.exe"));

            Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UpdaterForm_Load(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(Update), null);
        }
    }
}
