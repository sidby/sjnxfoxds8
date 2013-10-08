namespace Rent
{
    partial class OptionsForm
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
            this.tabOptions = new System.Windows.Forms.TabControl();
            this.tabCommon = new System.Windows.Forms.TabPage();
            this.lblThreadSleepRandomMaxTimeSign = new System.Windows.Forms.Label();
            this.lblThreadSleepRandomMinTimeSign = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblThreadSleepRandomMinTime = new System.Windows.Forms.Label();
            this.nThreadSleepRandomMaxTime = new System.Windows.Forms.NumericUpDown();
            this.nThreadSleepRandomMinTime = new System.Windows.Forms.NumericUpDown();
            this.cbUseProxy = new System.Windows.Forms.CheckBox();
            this.lblPriceSign = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.nPrice = new System.Windows.Forms.NumericUpDown();
            this.lblMailTo = new System.Windows.Forms.Label();
            this.txtEmailTo = new System.Windows.Forms.TextBox();
            this.tabIrrBy = new System.Windows.Forms.TabPage();
            this.nIrrByItemsPerPageMin = new System.Windows.Forms.NumericUpDown();
            this.lblIrrByItemsPerPageMin = new System.Windows.Forms.Label();
            this.lblIrrByItemsPerPage = new System.Windows.Forms.Label();
            this.nIrrByItemsPerPage = new System.Windows.Forms.NumericUpDown();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtAdOwnerLoginNameFilter = new System.Windows.Forms.TextBox();
            this.lblAdOwnerLoginNameFilter = new System.Windows.Forms.Label();
            this.txtAdDescriptionFilter = new System.Windows.Forms.TextBox();
            this.lblAdDescriptionFilter = new System.Windows.Forms.Label();
            this.tabOptions.SuspendLayout();
            this.tabCommon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nThreadSleepRandomMaxTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nThreadSleepRandomMinTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPrice)).BeginInit();
            this.tabIrrBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nIrrByItemsPerPageMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIrrByItemsPerPage)).BeginInit();
            this.SuspendLayout();
            // 
            // tabOptions
            // 
            this.tabOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabOptions.Controls.Add(this.tabCommon);
            this.tabOptions.Controls.Add(this.tabIrrBy);
            this.tabOptions.Location = new System.Drawing.Point(8, 6);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.SelectedIndex = 0;
            this.tabOptions.Size = new System.Drawing.Size(343, 403);
            this.tabOptions.TabIndex = 0;
            // 
            // tabCommon
            // 
            this.tabCommon.Controls.Add(this.lblAdDescriptionFilter);
            this.tabCommon.Controls.Add(this.txtAdDescriptionFilter);
            this.tabCommon.Controls.Add(this.lblAdOwnerLoginNameFilter);
            this.tabCommon.Controls.Add(this.txtAdOwnerLoginNameFilter);
            this.tabCommon.Controls.Add(this.lblThreadSleepRandomMaxTimeSign);
            this.tabCommon.Controls.Add(this.lblThreadSleepRandomMinTimeSign);
            this.tabCommon.Controls.Add(this.label2);
            this.tabCommon.Controls.Add(this.lblThreadSleepRandomMinTime);
            this.tabCommon.Controls.Add(this.nThreadSleepRandomMaxTime);
            this.tabCommon.Controls.Add(this.nThreadSleepRandomMinTime);
            this.tabCommon.Controls.Add(this.cbUseProxy);
            this.tabCommon.Controls.Add(this.lblPriceSign);
            this.tabCommon.Controls.Add(this.lblPrice);
            this.tabCommon.Controls.Add(this.nPrice);
            this.tabCommon.Controls.Add(this.lblMailTo);
            this.tabCommon.Controls.Add(this.txtEmailTo);
            this.tabCommon.Location = new System.Drawing.Point(4, 22);
            this.tabCommon.Name = "tabCommon";
            this.tabCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tabCommon.Size = new System.Drawing.Size(335, 377);
            this.tabCommon.TabIndex = 0;
            this.tabCommon.Text = "Общие";
            this.tabCommon.UseVisualStyleBackColor = true;
            // 
            // lblThreadSleepRandomMaxTimeSign
            // 
            this.lblThreadSleepRandomMaxTimeSign.AutoSize = true;
            this.lblThreadSleepRandomMaxTimeSign.Location = new System.Drawing.Point(310, 118);
            this.lblThreadSleepRandomMaxTimeSign.Name = "lblThreadSleepRandomMaxTimeSign";
            this.lblThreadSleepRandomMaxTimeSign.Size = new System.Drawing.Size(13, 13);
            this.lblThreadSleepRandomMaxTimeSign.TabIndex = 11;
            this.lblThreadSleepRandomMaxTimeSign.Text = "с";
            // 
            // lblThreadSleepRandomMinTimeSign
            // 
            this.lblThreadSleepRandomMinTimeSign.AutoSize = true;
            this.lblThreadSleepRandomMinTimeSign.Location = new System.Drawing.Point(310, 94);
            this.lblThreadSleepRandomMinTimeSign.Name = "lblThreadSleepRandomMinTimeSign";
            this.lblThreadSleepRandomMinTimeSign.Size = new System.Drawing.Size(13, 13);
            this.lblThreadSleepRandomMinTimeSign.TabIndex = 10;
            this.lblThreadSleepRandomMinTimeSign.Text = "с";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Макс. случайное время запуска опроса сайта";
            // 
            // lblThreadSleepRandomMinTime
            // 
            this.lblThreadSleepRandomMinTime.AutoSize = true;
            this.lblThreadSleepRandomMinTime.Location = new System.Drawing.Point(16, 94);
            this.lblThreadSleepRandomMinTime.Name = "lblThreadSleepRandomMinTime";
            this.lblThreadSleepRandomMinTime.Size = new System.Drawing.Size(236, 13);
            this.lblThreadSleepRandomMinTime.TabIndex = 8;
            this.lblThreadSleepRandomMinTime.Text = "Мин. случайное время запуска опроса сайта";
            // 
            // nThreadSleepRandomMaxTime
            // 
            this.nThreadSleepRandomMaxTime.Location = new System.Drawing.Point(259, 115);
            this.nThreadSleepRandomMaxTime.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.nThreadSleepRandomMaxTime.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.nThreadSleepRandomMaxTime.Name = "nThreadSleepRandomMaxTime";
            this.nThreadSleepRandomMaxTime.Size = new System.Drawing.Size(48, 20);
            this.nThreadSleepRandomMaxTime.TabIndex = 7;
            this.nThreadSleepRandomMaxTime.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // nThreadSleepRandomMinTime
            // 
            this.nThreadSleepRandomMinTime.Location = new System.Drawing.Point(257, 89);
            this.nThreadSleepRandomMinTime.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nThreadSleepRandomMinTime.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nThreadSleepRandomMinTime.Name = "nThreadSleepRandomMinTime";
            this.nThreadSleepRandomMinTime.Size = new System.Drawing.Size(50, 20);
            this.nThreadSleepRandomMinTime.TabIndex = 6;
            this.nThreadSleepRandomMinTime.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // cbUseProxy
            // 
            this.cbUseProxy.AutoSize = true;
            this.cbUseProxy.Checked = true;
            this.cbUseProxy.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUseProxy.Location = new System.Drawing.Point(18, 68);
            this.cbUseProxy.Name = "cbUseProxy";
            this.cbUseProxy.Size = new System.Drawing.Size(138, 17);
            this.cbUseProxy.TabIndex = 5;
            this.cbUseProxy.Text = "Использовать прокси";
            this.cbUseProxy.UseVisualStyleBackColor = true;
            // 
            // lblPriceSign
            // 
            this.lblPriceSign.AutoSize = true;
            this.lblPriceSign.Location = new System.Drawing.Point(192, 38);
            this.lblPriceSign.Name = "lblPriceSign";
            this.lblPriceSign.Size = new System.Drawing.Size(13, 13);
            this.lblPriceSign.TabIndex = 4;
            this.lblPriceSign.Text = "$";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(15, 40);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(81, 13);
            this.lblPrice.TabIndex = 3;
            this.lblPrice.Text = "Цена не более";
            // 
            // nPrice
            // 
            this.nPrice.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nPrice.Location = new System.Drawing.Point(131, 35);
            this.nPrice.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nPrice.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nPrice.Name = "nPrice";
            this.nPrice.Size = new System.Drawing.Size(56, 20);
            this.nPrice.TabIndex = 2;
            this.nPrice.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
            // 
            // lblMailTo
            // 
            this.lblMailTo.AutoSize = true;
            this.lblMailTo.Location = new System.Drawing.Point(14, 12);
            this.lblMailTo.Name = "lblMailTo";
            this.lblMailTo.Size = new System.Drawing.Size(112, 13);
            this.lblMailTo.TabIndex = 1;
            this.lblMailTo.Text = "Уведомлять на email";
            // 
            // txtEmailTo
            // 
            this.txtEmailTo.Location = new System.Drawing.Point(132, 8);
            this.txtEmailTo.Name = "txtEmailTo";
            this.txtEmailTo.Size = new System.Drawing.Size(197, 20);
            this.txtEmailTo.TabIndex = 0;
            // 
            // tabIrrBy
            // 
            this.tabIrrBy.Controls.Add(this.nIrrByItemsPerPageMin);
            this.tabIrrBy.Controls.Add(this.lblIrrByItemsPerPageMin);
            this.tabIrrBy.Controls.Add(this.lblIrrByItemsPerPage);
            this.tabIrrBy.Controls.Add(this.nIrrByItemsPerPage);
            this.tabIrrBy.Location = new System.Drawing.Point(4, 22);
            this.tabIrrBy.Name = "tabIrrBy";
            this.tabIrrBy.Padding = new System.Windows.Forms.Padding(3);
            this.tabIrrBy.Size = new System.Drawing.Size(335, 377);
            this.tabIrrBy.TabIndex = 1;
            this.tabIrrBy.Text = "irr.by";
            this.tabIrrBy.UseVisualStyleBackColor = true;
            // 
            // nIrrByItemsPerPageMin
            // 
            this.nIrrByItemsPerPageMin.Location = new System.Drawing.Point(241, 26);
            this.nIrrByItemsPerPageMin.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nIrrByItemsPerPageMin.Name = "nIrrByItemsPerPageMin";
            this.nIrrByItemsPerPageMin.Size = new System.Drawing.Size(65, 20);
            this.nIrrByItemsPerPageMin.TabIndex = 3;
            this.nIrrByItemsPerPageMin.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // lblIrrByItemsPerPageMin
            // 
            this.lblIrrByItemsPerPageMin.AutoSize = true;
            this.lblIrrByItemsPerPageMin.Location = new System.Drawing.Point(20, 30);
            this.lblIrrByItemsPerPageMin.Name = "lblIrrByItemsPerPageMin";
            this.lblIrrByItemsPerPageMin.Size = new System.Drawing.Size(203, 13);
            this.lblIrrByItemsPerPageMin.TabIndex = 2;
            this.lblIrrByItemsPerPageMin.Text = "Мин. кол-во предложений на странице";
            // 
            // lblIrrByItemsPerPage
            // 
            this.lblIrrByItemsPerPage.AutoSize = true;
            this.lblIrrByItemsPerPage.Location = new System.Drawing.Point(19, 9);
            this.lblIrrByItemsPerPage.Name = "lblIrrByItemsPerPage";
            this.lblIrrByItemsPerPage.Size = new System.Drawing.Size(177, 13);
            this.lblIrrByItemsPerPage.TabIndex = 1;
            this.lblIrrByItemsPerPage.Text = "Кол-во предложений на странице";
            // 
            // nIrrByItemsPerPage
            // 
            this.nIrrByItemsPerPage.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nIrrByItemsPerPage.Location = new System.Drawing.Point(241, 6);
            this.nIrrByItemsPerPage.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nIrrByItemsPerPage.Name = "nIrrByItemsPerPage";
            this.nIrrByItemsPerPage.Size = new System.Drawing.Size(65, 20);
            this.nIrrByItemsPerPage.TabIndex = 0;
            this.nIrrByItemsPerPage.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(189, 424);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 29);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(277, 424);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // txtAdOwnerLoginNameFilter
            // 
            this.txtAdOwnerLoginNameFilter.Location = new System.Drawing.Point(139, 146);
            this.txtAdOwnerLoginNameFilter.Name = "txtAdOwnerLoginNameFilter";
            this.txtAdOwnerLoginNameFilter.Size = new System.Drawing.Size(190, 20);
            this.txtAdOwnerLoginNameFilter.TabIndex = 12;
            this.txtAdOwnerLoginNameFilter.Text = "агент;агенство;agent";
            // 
            // lblAdOwnerLoginNameFilter
            // 
            this.lblAdOwnerLoginNameFilter.AutoSize = true;
            this.lblAdOwnerLoginNameFilter.Location = new System.Drawing.Point(15, 149);
            this.lblAdOwnerLoginNameFilter.Name = "lblAdOwnerLoginNameFilter";
            this.lblAdOwnerLoginNameFilter.Size = new System.Drawing.Size(118, 13);
            this.lblAdOwnerLoginNameFilter.TabIndex = 13;
            this.lblAdOwnerLoginNameFilter.Text = "Фильтр по владельцу";
            // 
            // txtAdDescriptionFilter
            // 
            this.txtAdDescriptionFilter.Location = new System.Drawing.Point(139, 172);
            this.txtAdDescriptionFilter.Name = "txtAdDescriptionFilter";
            this.txtAdDescriptionFilter.Size = new System.Drawing.Size(190, 20);
            this.txtAdDescriptionFilter.TabIndex = 14;
            this.txtAdDescriptionFilter.Text = "агент по";
            // 
            // lblAdDescriptionFilter
            // 
            this.lblAdDescriptionFilter.AutoSize = true;
            this.lblAdDescriptionFilter.Location = new System.Drawing.Point(15, 175);
            this.lblAdDescriptionFilter.Name = "lblAdDescriptionFilter";
            this.lblAdDescriptionFilter.Size = new System.Drawing.Size(115, 13);
            this.lblAdDescriptionFilter.TabIndex = 15;
            this.lblAdDescriptionFilter.Text = "Фильтр по описанию";
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 468);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tabOptions);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.tabOptions.ResumeLayout(false);
            this.tabCommon.ResumeLayout(false);
            this.tabCommon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nThreadSleepRandomMaxTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nThreadSleepRandomMinTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nPrice)).EndInit();
            this.tabIrrBy.ResumeLayout(false);
            this.tabIrrBy.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nIrrByItemsPerPageMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nIrrByItemsPerPage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabOptions;
        private System.Windows.Forms.TabPage tabCommon;
        private System.Windows.Forms.TabPage tabIrrBy;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblMailTo;
        private System.Windows.Forms.TextBox txtEmailTo;
        private System.Windows.Forms.Label lblIrrByItemsPerPage;
        private System.Windows.Forms.NumericUpDown nIrrByItemsPerPage;
        private System.Windows.Forms.NumericUpDown nPrice;
        private System.Windows.Forms.Label lblIrrByItemsPerPageMin;
        private System.Windows.Forms.Label lblPriceSign;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.NumericUpDown nIrrByItemsPerPageMin;
        private System.Windows.Forms.CheckBox cbUseProxy;
        private System.Windows.Forms.Label lblThreadSleepRandomMaxTimeSign;
        private System.Windows.Forms.Label lblThreadSleepRandomMinTimeSign;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblThreadSleepRandomMinTime;
        private System.Windows.Forms.NumericUpDown nThreadSleepRandomMaxTime;
        private System.Windows.Forms.NumericUpDown nThreadSleepRandomMinTime;
        private System.Windows.Forms.Label lblAdDescriptionFilter;
        private System.Windows.Forms.TextBox txtAdDescriptionFilter;
        private System.Windows.Forms.Label lblAdOwnerLoginNameFilter;
        private System.Windows.Forms.TextBox txtAdOwnerLoginNameFilter;
    }
}