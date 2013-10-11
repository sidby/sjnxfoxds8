using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;
using BrightIdeasSoftware;
using System.Diagnostics;
using System.Threading;
using Rent.IrrBy;
using log4net;
using Rent.Properties;
using System.Threading.Tasks;
using Rent.Updates;

namespace Rent
{
    public partial class MainRentForm : Form
    {
        //// this event is used for reporting completion event from the BackgroundWorker
        //private event EventHandler BackgroundWorkFinished;

        public MainRentForm()
        {
            InitializeComponent();

            // check for settings and display them accordingly
            PrepareGUI();

         //   this.BackgroundWorkFinished += new EventHandler(backgroundWorker1_RunWorkerCompleted);
        }

        private volatile bool _shouldStop;
        
           
        #region Event Overrides

        protected override void OnLoad(EventArgs e)
        {
            NativeMethods.SendMessage(NativeMethods.GetTopLevelOwner(Handle), NativeMethods.WM_SETICON, NativeMethods.ICON_BIG, Icon.Handle);
            NativeMethods.SendMessage(NativeMethods.GetTopLevelOwner(Handle), NativeMethods.WM_SETICON, NativeMethods.ICON_SMALL, notifyIcon1.Icon.Handle);
            NativeMethods.SendMessage(NativeMethods.GetTopLevelOwner(Handle), NativeMethods.WM_SETTEXT, 0, Text);
            base.OnLoad(e);
        }

        protected override void OnClosed(EventArgs e)
        {
            NativeMethods.SendMessage(NativeMethods.GetTopLevelOwner(Handle), NativeMethods.WM_SETICON, NativeMethods.ICON_BIG, IntPtr.Zero);
            NativeMethods.SendMessage(NativeMethods.GetTopLevelOwner(Handle), NativeMethods.WM_SETICON, NativeMethods.ICON_SMALL, IntPtr.Zero);
            NativeMethods.SendMessage(NativeMethods.GetTopLevelOwner(Handle), NativeMethods.WM_SETTEXT, 0, null);

            base.OnClosed(e);
        }

        #endregion

        private void btnFind_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "получение данных с сайта";

            RentedApartmentCollection items = GetApartments(Settings.Default.IrrByItemsPerPage);

            if (items.apartments.Count > 0)
            {
                olvApartments.Reset();
                BindOListView(items.apartments.Where(x => x.IsFiltered == false).ToList());
                toolStripStatusLabel1.Text = "данные получены - " + DateTime.Now.ToString("HH:mm:ss");
            }
        }

        private void BindOListView(IList<RentedApartment> apartments)
        {
            //if (ObjectListView.IsVistaOrLater)
            //    this.Font = new Font("Segoe UI", 10);

            this.olvApartments.ShowGroups = false;
            this.olvApartments.HeaderWordWrap = true;
            this.olvApartments.RowHeight = 80;   

            BindApartmentsColumns();

            this.olvApartments.SetObjects(apartments);

            // Install a RowFormatter to setup a tooltip on the item
            this.olvApartments.RowFormatter = delegate(OLVListItem lvi)
            {
                lvi.ToolTipText = String.Format("{0}", lvi.Text);
            };
        }

        private void BindApartmentsColumns()
        {
            OLVColumn colAdCreated = new OLVColumn("Создано", "AdCreated");
            colAdCreated.Width = 80;
            colAdCreated.AspectToStringFormat = "{0:HH:mm dd.MM.yyyy}";

            OLVColumn colAdOwnerLoginName = new OLVColumn("Владелец", null);
            colAdOwnerLoginName.Width = 80;
            colAdOwnerLoginName.AspectGetter = delegate(object x) {
                string returnValue = ((RentedApartment)x).AdOwnerId + "\n" + ((RentedApartment)x).AdOwnerLoginName;
                return returnValue; 
            };

            OLVColumn colPrice = new OLVColumn("Цена", "Price");
            colPrice.Width = 40;

            OLVColumn colDescription = new OLVColumn("Описание", null);
            colDescription.AspectGetter = delegate(object x) {
                string returnValue = ((RentedApartment)x).Title + "\r\n" + ((RentedApartment)x).Description;
                return returnValue;
            };

            colDescription.Width = 400;
            colDescription.WordWrap = true;

            this.olvApartments.AllColumns.Add(colAdCreated);
            this.olvApartments.AllColumns.Add(colAdOwnerLoginName);
            this.olvApartments.AllColumns.Add(colPrice);
            this.olvApartments.AllColumns.Add(colDescription);

            this.olvApartments.RebuildColumns();
        }

        private void olvApartments_CellClick(object sender, CellClickEventArgs e)
        {
            OLVColumn col = e.Column;
            //?? e.ListView.GetColumn(3);
            if (e.Model != null)
            {
                string stringValue = col.GetStringValue(e.Model);

                // Open Ad
                if (col.Index == 3)
                {
                    string url = ((RentedApartment)(e.Model)).AdUrl;
                    Process.Start( url);
                } // Open user Ads
                else if (col.Index == 1)
                {
                    string url = ((RentedApartment)(e.Model)).AdOwnerUserUrl;
                    Process.Start(url);
                }
            }
        }

        private void frmRentView_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                RunCheckSiteWork();
            }
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Set the WindowState to normal if the form is minimized.
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;
            this.Show();
            this.Activate();
            _shouldStop = true;
        }

        public void RunCheckSiteWork()
        {
            _shouldStop = true;
            this.ShowInTaskbar = false;
            this.Hide();
            if (this.backgroundWorker1.IsBusy != true)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(3000);
            
                _shouldStop = false;
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Пожалуйста, подождите " + Settings.Default.PollingRandomSleepMin + " - " + 
                    Settings.Default.PollingRandomSleepMax + " секунд" +
                    " пока не завершится фоновый процесс опроса сайта. По завершении работы фонового процесса, окно программы появится автоматически. " + 
                    " После этого вы снова сможете его свернуть.");
            }
        }

        delegate void EnableFormCallBack();

        private void EnableForm()
        {
            if (this.InvokeRequired)
            {
                EnableFormCallBack d = new EnableFormCallBack(EnableForm);
                this.Invoke(d);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Handle the case where an exception was thrown.
            if (e.Error != null)
            {
                Logging.Log.Error(e.Error.Message);
            }
            
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon1.Visible = false;

            RentedApartmentCollection data = GetApartments(Settings.Default.IrrByItemsPerPage);

            if (data.apartments.Count > 0)
            {
                olvApartments.Reset();
                BindOListView(data.apartments.Where(x => x.IsFiltered == false).ToList());
                toolStripStatusLabel1.Text = "данные получены - " + DateTime.Now.ToString("HH:mm:ss");
            }

            this.TopMost = true;
            this.Show();
            this.Focus();
        }

        //private void MainForm_BackgroundWorkFinished(object sender, EventArgs e)
        //{

        //}

        private RentedApartmentCollection GetApartments(int itemsPerPageMin)
        {
            IrrBySiteRentData parser = new IrrBySiteRentData();
            parser.UseProxy = Settings.Default.UseProxy;
            parser.AdOwnerLoginNameFilter = Settings.Default.AdOwnerLoginNameFilter;
            parser.AdDescriptionFilter = Settings.Default.AdDescriptionFilter;
            RentedApartmentCollection data = parser.GetData(itemsPerPageMin, Settings.Default.LessThanInUSD);

            return data;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime now = DateTime.Now;
            BackgroundWorker worker = sender as BackgroundWorker;
            while (!_shouldStop)
            {
                if (worker.CancellationPending == true)
                {
                    _shouldStop = true;
                    e.Cancel = true;
                    break;
                }
                else
                {
                    RentedApartmentCollection data = GetApartments(Settings.Default.IrrByItemsPerPageMin);

                    if (data.apartments.Count > 0)
                    {
                        // Check all ads. Because at the top may be promo ads
                        foreach (var apartment in data.apartments)
                        {
                            if(!apartment.IsFiltered)
                            if (apartment.AdCreated > now)
                            {
                                _shouldStop = true;
                                string mailto = Settings.Default.MailTo;
                                if (!String.IsNullOrEmpty(mailto))
                                    NotificationHelper.NotifyMe(mailto, apartment, data.SiteDomain);
                                break;
                            }
                        }
                    }
                    else
                    {
                        Logging.Log.Warn("Фоновый процесс не смог получить данные с сайта " + data.SiteDomain);
                        _shouldStop = true;
                    }

                    if (!_shouldStop)
                    {
                        // use random time to sleep
                        Random rnd = new Random();
                        int sleepSec = rnd.Next(Settings.Default.PollingRandomSleepMin, Settings.Default.PollingRandomSleepMax);

                        Thread.Sleep(sleepSec * 1000);
                    }
                }
            }
        }

        private void PrepareGUI()
        {
            //cacheBox.Value = Properties.Settings.Default.cacheSize;
            //logFileNameBox.Text = Properties.Settings.Default.logFile;

            this.Refresh();
        }
      
        private static void SetUnhandledExceptions()
        {
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomainUnhandledException);
            Application.ThreadException += new ThreadExceptionEventHandler(ApplicationThreadException);
        }

        private static void CurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ShowApplicationExit(e.ExceptionObject);
        }

        private static void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ShowApplicationExit(e.Exception);
        }

        private static void ShowApplicationExit(object messageToLog)
        {
            Logging.Log.Fatal(messageToLog);
            Logging.Log.Fatal("Application has to be terminated.");
            UnhandledTerminationForm.ShowRipDialog();
            Environment.Exit(-1);
        }

        private void mItemAbout_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            AboutRentForm about = new AboutRentForm();
            about.ShowDialog();
        }

        private void mItemSettings_Click(object sender, EventArgs e)
        {
            this.TopMost = false;
            OptionsForm options = new OptionsForm();
            options.ShowDialog();
        }

        private void MainRentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _shouldStop = true;
            if (this.backgroundWorker1.IsBusy == true)
            {
                MessageBox.Show("Пожалуйста, подождите " + Settings.Default.PollingRandomSleepMin + " - " +
                             Settings.Default.PollingRandomSleepMax + " секунд" +
                             " пока не завершится фоновый процесс опроса сайта. " +
                             " После этого вы снова сможете его закрыть.");
                e.Cancel = true;
            }
        }

        private void CheckForNewRelease()
        {
            Task<ReleaseInfo> downloadTask = UpdateManager.CheckForUpdates(true);
            downloadTask.ContinueWith(this.CheckForNewRelease, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void CheckForNewRelease(Task<ReleaseInfo> downloadTask)
        {
            ReleaseInfo downloaded = downloadTask.Result;
            this.UpdateReleaseToolStripItem(downloaded);
        }

        private void UpdateReleaseToolStripItem(ReleaseInfo downloaded)
        {
            if (this.toolStripStatusLabel1 != null)
            {
                if (downloaded.NewAvailable)
                {
                    string newText = String.Format("Доступна новая версия приложения - '{0}'", downloaded.Version);
                    this.toolStripStatusLabel1.Text = newText;
                }
            }
        }

        private void MainRentForm_Load(object sender, EventArgs e)
        {
            this.CheckForNewRelease();
        }
    }
}
