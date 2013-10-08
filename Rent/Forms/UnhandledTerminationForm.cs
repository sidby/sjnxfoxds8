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
    public partial class UnhandledTerminationForm : Form
    {
        public UnhandledTerminationForm()
        {
            InitializeComponent();
        }

        internal static void ShowRipDialog()
        {
            var form = new UnhandledTerminationForm();
            form.ShowDialog();
        }
    }
}
