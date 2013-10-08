namespace Rent
{
    partial class MainRentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainRentForm));
            this.btnFind = new System.Windows.Forms.Button();
            this.olvApartments = new BrightIdeasSoftware.ObjectListView();
            this.ttMainToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mItemParams = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.olvApartments)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFind.Location = new System.Drawing.Point(537, 578);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(143, 40);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Найти";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // olvApartments
            // 
            this.olvApartments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvApartments.FullRowSelect = true;
            this.olvApartments.HeaderUsesThemes = false;
            this.olvApartments.Location = new System.Drawing.Point(12, 46);
            this.olvApartments.MinimumSize = new System.Drawing.Size(660, 500);
            this.olvApartments.Name = "olvApartments";
            this.olvApartments.OverlayText.Alignment = System.Drawing.ContentAlignment.BottomLeft;
            this.olvApartments.OverlayText.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.olvApartments.OverlayText.BorderWidth = 2F;
            this.olvApartments.ShowGroups = false;
            this.olvApartments.ShowItemToolTips = true;
            this.olvApartments.Size = new System.Drawing.Size(660, 500);
            this.olvApartments.TabIndex = 5;
            this.olvApartments.UseAlternatingBackColors = true;
            this.olvApartments.UseCompatibleStateImageBehavior = false;
            this.olvApartments.View = System.Windows.Forms.View.Details;
            this.olvApartments.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.olvApartments_CellClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 621);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(692, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Enabled = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(207, 17);
            this.toolStripStatusLabel1.Text = "Нажмите Найти для получения данных";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Поиск квартир по частным объявлениям";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Сайт будет опрашиваться в фоновом режиме";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Нажмите для того, чтобы получить информацию по квартирам";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemParams,
            this.mItemHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(692, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mItemParams
            // 
            this.mItemParams.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemSettings});
            this.mItemParams.Name = "mItemParams";
            this.mItemParams.Size = new System.Drawing.Size(76, 20);
            this.mItemParams.Text = "Параметры";
            // 
            // mItemSettings
            // 
            this.mItemSettings.Name = "mItemSettings";
            this.mItemSettings.Size = new System.Drawing.Size(128, 22);
            this.mItemSettings.Text = "Настройка";
            this.mItemSettings.Click += new System.EventHandler(this.mItemSettings_Click);
            // 
            // mItemHelp
            // 
            this.mItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItemAbout});
            this.mItemHelp.Name = "mItemHelp";
            this.mItemHelp.Size = new System.Drawing.Size(62, 20);
            this.mItemHelp.Text = "Справка";
            // 
            // mItemAbout
            // 
            this.mItemAbout.Name = "mItemAbout";
            this.mItemAbout.Size = new System.Drawing.Size(138, 22);
            this.mItemAbout.Text = "О программе";
            this.mItemAbout.Click += new System.EventHandler(this.mItemAbout_Click);
            // 
            // MainRentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 643);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.olvApartments);
            this.Controls.Add(this.btnFind);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(700, 500);
            this.Name = "MainRentForm";
            this.Text = "Квартиры с irr.by";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainRentForm_FormClosing);
            this.Load += new System.EventHandler(this.MainRentForm_Load);
            this.Resize += new System.EventHandler(this.frmRentView_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.olvApartments)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFind;
        private BrightIdeasSoftware.ObjectListView olvApartments;
        private System.Windows.Forms.ToolTip ttMainToolTip;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mItemHelp;
        private System.Windows.Forms.ToolStripMenuItem mItemAbout;
        private System.Windows.Forms.ToolStripMenuItem mItemParams;
        private System.Windows.Forms.ToolStripMenuItem mItemSettings;
    }
}

