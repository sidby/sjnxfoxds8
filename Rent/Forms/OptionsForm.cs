using Rent.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rent
{
    public partial class OptionsForm : Form
    {
        public OptionsForm()
        {
            InitializeComponent();
            PrepareGUI();

        }

        private void PrepareGUI()
        {
            txtEmailTo.Text = Settings.Default.MailTo;
            nPrice.Value = Settings.Default.LessThanInUSD;
            cbUseProxy.Checked = Settings.Default.UseProxy;
            nThreadSleepRandomMinTime.Value = Settings.Default.PollingRandomSleepMin;
            nThreadSleepRandomMaxTime.Value = Settings.Default.PollingRandomSleepMax;
            txtAdOwnerLoginNameFilter.Text = Settings.Default.AdOwnerLoginNameFilter;
            txtAdDescriptionFilter.Text = Settings.Default.AdDescriptionFilter;
                
            PrepareIrrBySettings();
        }

        #region irr.by settings

        private void PrepareIrrBySettings()
        {
            nIrrByItemsPerPage.Value = Settings.Default.IrrByItemsPerPage;
            nIrrByItemsPerPageMin.Value = Settings.Default.IrrByItemsPerPageMin;
        }

        private void SaveIrrBySettings()
        {
            Settings.Default.IrrByItemsPerPage = (int)nIrrByItemsPerPage.Value;
            Settings.Default.IrrByItemsPerPageMin = (int)nIrrByItemsPerPageMin.Value;
        }

        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            Settings.Default.MailTo = txtEmailTo.Text;
            Settings.Default.LessThanInUSD = (int)nPrice.Value;
            Settings.Default.UseProxy = cbUseProxy.Checked;
            Settings.Default.PollingRandomSleepMin = (int)nThreadSleepRandomMinTime.Value;
            Settings.Default.PollingRandomSleepMax = (int)nThreadSleepRandomMaxTime.Value;
            Settings.Default.AdOwnerLoginNameFilter = txtAdOwnerLoginNameFilter.Text;
            Settings.Default.AdDescriptionFilter = txtAdDescriptionFilter.Text;

            SaveIrrBySettings();

            Properties.Settings.Default.Save();

            this.Close();
        }
    }
}
