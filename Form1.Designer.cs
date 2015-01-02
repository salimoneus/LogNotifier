namespace LogNotifier
{
    partial class Form1
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
            this.buttonLogfile = new System.Windows.Forms.Button();
            this.textBoxFiltersInclude = new System.Windows.Forms.TextBox();
            this.comboBoxService = new System.Windows.Forms.ComboBox();
            this.textBoxCell = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.textBoxPass = new System.Windows.Forms.TextBox();
            this.textBoxAccount = new System.Windows.Forms.TextBox();
            this.textBoxFiltersExclude = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageFilters = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxPlaySound = new System.Windows.Forms.CheckBox();
            this.checkBoxEnabled = new System.Windows.Forms.CheckBox();
            this.checkBoxStopNotifications = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.tabPageSent = new System.Windows.Forms.TabPage();
            this.buttonClear = new System.Windows.Forms.Button();
            this.listViewSent = new System.Windows.Forms.ListView();
            this.labelStatus = new System.Windows.Forms.Label();
            this.labelProcessed = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageFilters.SuspendLayout();
            this.tabPageConfig.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPageSent.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonLogfile
            // 
            this.buttonLogfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogfile.Location = new System.Drawing.Point(12, 183);
            this.buttonLogfile.Name = "buttonLogfile";
            this.buttonLogfile.Size = new System.Drawing.Size(313, 23);
            this.buttonLogfile.TabIndex = 0;
            this.buttonLogfile.Text = "<Select Logfile>";
            this.buttonLogfile.UseVisualStyleBackColor = true;
            this.buttonLogfile.Click += new System.EventHandler(this.buttonLogfile_Click);
            // 
            // textBoxFiltersInclude
            // 
            this.textBoxFiltersInclude.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFiltersInclude.Location = new System.Drawing.Point(12, 28);
            this.textBoxFiltersInclude.Multiline = true;
            this.textBoxFiltersInclude.Name = "textBoxFiltersInclude";
            this.textBoxFiltersInclude.Size = new System.Drawing.Size(152, 140);
            this.textBoxFiltersInclude.TabIndex = 1;
            this.textBoxFiltersInclude.TextChanged += new System.EventHandler(this.textBoxFilters_TextChanged);
            // 
            // comboBoxService
            // 
            this.comboBoxService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxService.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxService.FormattingEnabled = true;
            this.comboBoxService.Location = new System.Drawing.Point(143, 21);
            this.comboBoxService.Name = "comboBoxService";
            this.comboBoxService.Size = new System.Drawing.Size(145, 21);
            this.comboBoxService.TabIndex = 2;
            // 
            // textBoxCell
            // 
            this.textBoxCell.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCell.Location = new System.Drawing.Point(23, 22);
            this.textBoxCell.Name = "textBoxCell";
            this.textBoxCell.Size = new System.Drawing.Size(93, 20);
            this.textBoxCell.TabIndex = 4;
            this.textBoxCell.Text = "1235551212";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxService);
            this.groupBox1.Controls.Add(this.textBoxCell);
            this.groupBox1.Location = new System.Drawing.Point(19, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 56);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "10-Digit Cell Number and Provider";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Account:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pass:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Server:";
            // 
            // textBoxServer
            // 
            this.textBoxServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxServer.Location = new System.Drawing.Point(67, 44);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(128, 20);
            this.textBoxServer.TabIndex = 2;
            this.textBoxServer.Text = "smtp.gmail.com";
            // 
            // textBoxPass
            // 
            this.textBoxPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPass.Location = new System.Drawing.Point(68, 72);
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.PasswordChar = '*';
            this.textBoxPass.Size = new System.Drawing.Size(128, 20);
            this.textBoxPass.TabIndex = 1;
            // 
            // textBoxAccount
            // 
            this.textBoxAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAccount.Location = new System.Drawing.Point(68, 16);
            this.textBoxAccount.Name = "textBoxAccount";
            this.textBoxAccount.Size = new System.Drawing.Size(220, 20);
            this.textBoxAccount.TabIndex = 0;
            this.textBoxAccount.Text = "myaccount@gmail.com";
            // 
            // textBoxFiltersExclude
            // 
            this.textBoxFiltersExclude.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxFiltersExclude.Location = new System.Drawing.Point(182, 28);
            this.textBoxFiltersExclude.Multiline = true;
            this.textBoxFiltersExclude.Name = "textBoxFiltersExclude";
            this.textBoxFiltersExclude.Size = new System.Drawing.Size(143, 140);
            this.textBoxFiltersExclude.TabIndex = 7;
            this.textBoxFiltersExclude.TextChanged += new System.EventHandler(this.textBoxFiltersExclude_TextChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageFilters);
            this.tabControl.Controls.Add(this.tabPageConfig);
            this.tabControl.Controls.Add(this.tabPageSent);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(346, 247);
            this.tabControl.TabIndex = 8;
            // 
            // tabPageFilters
            // 
            this.tabPageFilters.Controls.Add(this.label6);
            this.tabPageFilters.Controls.Add(this.label5);
            this.tabPageFilters.Controls.Add(this.buttonLogfile);
            this.tabPageFilters.Controls.Add(this.textBoxFiltersExclude);
            this.tabPageFilters.Controls.Add(this.textBoxFiltersInclude);
            this.tabPageFilters.Location = new System.Drawing.Point(4, 22);
            this.tabPageFilters.Name = "tabPageFilters";
            this.tabPageFilters.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFilters.Size = new System.Drawing.Size(338, 221);
            this.tabPageFilters.TabIndex = 0;
            this.tabPageFilters.Text = "Filters";
            this.tabPageFilters.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(179, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Strings to exclude:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Strings to match:";
            // 
            // tabPageConfig
            // 
            this.tabPageConfig.Controls.Add(this.groupBox2);
            this.tabPageConfig.Controls.Add(this.groupBox3);
            this.tabPageConfig.Controls.Add(this.groupBox1);
            this.tabPageConfig.Location = new System.Drawing.Point(4, 22);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConfig.Size = new System.Drawing.Size(338, 221);
            this.tabPageConfig.TabIndex = 1;
            this.tabPageConfig.Text = "Config";
            this.tabPageConfig.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxPlaySound);
            this.groupBox2.Controls.Add(this.checkBoxEnabled);
            this.groupBox2.Controls.Add(this.checkBoxStopNotifications);
            this.groupBox2.Location = new System.Drawing.Point(19, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 42);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Notifications";
            // 
            // checkBoxPlaySound
            // 
            this.checkBoxPlaySound.AutoSize = true;
            this.checkBoxPlaySound.Location = new System.Drawing.Point(107, 16);
            this.checkBoxPlaySound.Name = "checkBoxPlaySound";
            this.checkBoxPlaySound.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxPlaySound.Size = new System.Drawing.Size(80, 17);
            this.checkBoxPlaySound.TabIndex = 10;
            this.checkBoxPlaySound.Text = "Play Sound";
            this.checkBoxPlaySound.UseVisualStyleBackColor = true;
            // 
            // checkBoxEnabled
            // 
            this.checkBoxEnabled.AutoSize = true;
            this.checkBoxEnabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxEnabled.Checked = true;
            this.checkBoxEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEnabled.Location = new System.Drawing.Point(17, 16);
            this.checkBoxEnabled.Name = "checkBoxEnabled";
            this.checkBoxEnabled.Size = new System.Drawing.Size(74, 17);
            this.checkBoxEnabled.TabIndex = 8;
            this.checkBoxEnabled.Text = "Enabled:  ";
            this.checkBoxEnabled.UseVisualStyleBackColor = true;
            // 
            // checkBoxStopNotifications
            // 
            this.checkBoxStopNotifications.AutoSize = true;
            this.checkBoxStopNotifications.Location = new System.Drawing.Point(196, 16);
            this.checkBoxStopNotifications.Name = "checkBoxStopNotifications";
            this.checkBoxStopNotifications.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxStopNotifications.Size = new System.Drawing.Size(91, 17);
            this.checkBoxStopNotifications.TabIndex = 9;
            this.checkBoxStopNotifications.Text = "Stop after first";
            this.checkBoxStopNotifications.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBoxPort);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBoxAccount);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.textBoxPass);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.textBoxServer);
            this.groupBox3.Location = new System.Drawing.Point(19, 54);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(301, 100);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Email";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(214, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Port:";
            // 
            // textBoxPort
            // 
            this.textBoxPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPort.Location = new System.Drawing.Point(243, 44);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(44, 20);
            this.textBoxPort.TabIndex = 6;
            this.textBoxPort.Text = "587";
            // 
            // tabPageSent
            // 
            this.tabPageSent.Controls.Add(this.buttonClear);
            this.tabPageSent.Controls.Add(this.listViewSent);
            this.tabPageSent.Location = new System.Drawing.Point(4, 22);
            this.tabPageSent.Name = "tabPageSent";
            this.tabPageSent.Size = new System.Drawing.Size(338, 221);
            this.tabPageSent.TabIndex = 2;
            this.tabPageSent.Text = "Processed";
            this.tabPageSent.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClear.Location = new System.Drawing.Point(18, 185);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(305, 23);
            this.buttonClear.TabIndex = 11;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // listViewSent
            // 
            this.listViewSent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewSent.Location = new System.Drawing.Point(18, 20);
            this.listViewSent.Name = "listViewSent";
            this.listViewSent.Size = new System.Drawing.Size(305, 145);
            this.listViewSent.TabIndex = 0;
            this.listViewSent.UseCompatibleStateImageBehavior = false;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(12, 262);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(40, 13);
            this.labelStatus.TabIndex = 9;
            this.labelStatus.Text = "Status:";
            // 
            // labelProcessed
            // 
            this.labelProcessed.AutoSize = true;
            this.labelProcessed.Location = new System.Drawing.Point(287, 262);
            this.labelProcessed.Name = "labelProcessed";
            this.labelProcessed.Size = new System.Drawing.Size(60, 13);
            this.labelProcessed.TabIndex = 10;
            this.labelProcessed.Text = "Processed:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 278);
            this.Controls.Add(this.labelProcessed);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "LogNotifier";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageFilters.ResumeLayout(false);
            this.tabPageFilters.PerformLayout();
            this.tabPageConfig.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPageSent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogfile;
        private System.Windows.Forms.TextBox textBoxFiltersInclude;
        private System.Windows.Forms.ComboBox comboBoxService;
        private System.Windows.Forms.TextBox textBoxCell;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxPass;
        private System.Windows.Forms.TextBox textBoxAccount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.TextBox textBoxFiltersExclude;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageFilters;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabPageConfig;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TabPage tabPageSent;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label labelProcessed;
        private System.Windows.Forms.ListView listViewSent;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxEnabled;
        private System.Windows.Forms.CheckBox checkBoxStopNotifications;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.CheckBox checkBoxPlaySound;

    }
}

