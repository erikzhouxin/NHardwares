namespace System.Data.ShenBanReader.WinForm
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PnlMain = new System.Windows.Forms.Panel();
            this.PnlConnect = new System.Windows.Forms.Panel();
            this.PnlConnectBtns = new System.Windows.Forms.Panel();
            this.BtnConnect = new System.Windows.Forms.Button();
            this.PnlConnectConfig = new System.Windows.Forms.Panel();
            this.GbxConnectNPort = new System.Windows.Forms.GroupBox();
            this.TxtConnectPort = new System.Windows.Forms.TextBox();
            this.GbxConnectIP = new System.Windows.Forms.GroupBox();
            this.TxtConnectIP = new System.Windows.Forms.TextBox();
            this.GbxContentRate = new System.Windows.Forms.GroupBox();
            this.CbxConnectRate = new System.Windows.Forms.ComboBox();
            this.GbxConnectSPort = new System.Windows.Forms.GroupBox();
            this.CbxConnectPort = new System.Windows.Forms.ComboBox();
            this.PnlConnectType = new System.Windows.Forms.Panel();
            this.GbxConnectType = new System.Windows.Forms.GroupBox();
            this.RBtnNetport = new System.Windows.Forms.RadioButton();
            this.RBtnRs232 = new System.Windows.Forms.RadioButton();
            this.PnlContent = new System.Windows.Forms.Panel();
            this.PnlLogArea = new System.Windows.Forms.Panel();
            this.PnlMain.SuspendLayout();
            this.PnlConnect.SuspendLayout();
            this.PnlConnectBtns.SuspendLayout();
            this.PnlConnectConfig.SuspendLayout();
            this.GbxConnectNPort.SuspendLayout();
            this.GbxConnectIP.SuspendLayout();
            this.GbxContentRate.SuspendLayout();
            this.GbxConnectSPort.SuspendLayout();
            this.PnlConnectType.SuspendLayout();
            this.GbxConnectType.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMain
            // 
            this.PnlMain.Controls.Add(this.PnlContent);
            this.PnlMain.Controls.Add(this.PnlLogArea);
            this.PnlMain.Controls.Add(this.PnlConnect);
            this.PnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMain.Location = new System.Drawing.Point(0, 0);
            this.PnlMain.Name = "PnlMain";
            this.PnlMain.Size = new System.Drawing.Size(784, 561);
            this.PnlMain.TabIndex = 0;
            // 
            // PnlConnect
            // 
            this.PnlConnect.Controls.Add(this.PnlConnectBtns);
            this.PnlConnect.Controls.Add(this.PnlConnectConfig);
            this.PnlConnect.Controls.Add(this.PnlConnectType);
            this.PnlConnect.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlConnect.Location = new System.Drawing.Point(0, 0);
            this.PnlConnect.Name = "PnlConnect";
            this.PnlConnect.Size = new System.Drawing.Size(784, 80);
            this.PnlConnect.TabIndex = 0;
            // 
            // PnlConnectBtns
            // 
            this.PnlConnectBtns.Controls.Add(this.BtnConnect);
            this.PnlConnectBtns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlConnectBtns.Location = new System.Drawing.Point(665, 0);
            this.PnlConnectBtns.Name = "PnlConnectBtns";
            this.PnlConnectBtns.Size = new System.Drawing.Size(119, 80);
            this.PnlConnectBtns.TabIndex = 1;
            // 
            // BtnConnect
            // 
            this.BtnConnect.Location = new System.Drawing.Point(7, 28);
            this.BtnConnect.Name = "BtnConnect";
            this.BtnConnect.Size = new System.Drawing.Size(100, 32);
            this.BtnConnect.TabIndex = 0;
            this.BtnConnect.Text = "连接读写器";
            this.BtnConnect.UseVisualStyleBackColor = true;
            this.BtnConnect.Click += new System.EventHandler(this.BtnConnect_Click);
            this.BtnConnect.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnConnect_MouseDown);
            // 
            // PnlConnectConfig
            // 
            this.PnlConnectConfig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlConnectConfig.Controls.Add(this.GbxConnectNPort);
            this.PnlConnectConfig.Controls.Add(this.GbxConnectIP);
            this.PnlConnectConfig.Controls.Add(this.GbxContentRate);
            this.PnlConnectConfig.Controls.Add(this.GbxConnectSPort);
            this.PnlConnectConfig.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlConnectConfig.Location = new System.Drawing.Point(225, 0);
            this.PnlConnectConfig.Name = "PnlConnectConfig";
            this.PnlConnectConfig.Size = new System.Drawing.Size(440, 80);
            this.PnlConnectConfig.TabIndex = 2;
            // 
            // GbxConnectNPort
            // 
            this.GbxConnectNPort.Controls.Add(this.TxtConnectPort);
            this.GbxConnectNPort.Enabled = false;
            this.GbxConnectNPort.Location = new System.Drawing.Point(353, 12);
            this.GbxConnectNPort.Name = "GbxConnectNPort";
            this.GbxConnectNPort.Size = new System.Drawing.Size(80, 54);
            this.GbxConnectNPort.TabIndex = 3;
            this.GbxConnectNPort.TabStop = false;
            this.GbxConnectNPort.Text = "端口号";
            // 
            // TxtConnectPort
            // 
            this.TxtConnectPort.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtConnectPort.Location = new System.Drawing.Point(6, 19);
            this.TxtConnectPort.Name = "TxtConnectPort";
            this.TxtConnectPort.Size = new System.Drawing.Size(68, 23);
            this.TxtConnectPort.TabIndex = 1;
            // 
            // GbxConnectIP
            // 
            this.GbxConnectIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GbxConnectIP.Controls.Add(this.TxtConnectIP);
            this.GbxConnectIP.Enabled = false;
            this.GbxConnectIP.Location = new System.Drawing.Point(218, 11);
            this.GbxConnectIP.Name = "GbxConnectIP";
            this.GbxConnectIP.Size = new System.Drawing.Size(120, 53);
            this.GbxConnectIP.TabIndex = 2;
            this.GbxConnectIP.TabStop = false;
            this.GbxConnectIP.Text = "IP地址";
            // 
            // TxtConnectIP
            // 
            this.TxtConnectIP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtConnectIP.Location = new System.Drawing.Point(6, 20);
            this.TxtConnectIP.Name = "TxtConnectIP";
            this.TxtConnectIP.Size = new System.Drawing.Size(108, 23);
            this.TxtConnectIP.TabIndex = 0;
            // 
            // GbxContentRate
            // 
            this.GbxContentRate.Controls.Add(this.CbxConnectRate);
            this.GbxContentRate.Location = new System.Drawing.Point(112, 12);
            this.GbxContentRate.Name = "GbxContentRate";
            this.GbxContentRate.Size = new System.Drawing.Size(100, 54);
            this.GbxContentRate.TabIndex = 1;
            this.GbxContentRate.TabStop = false;
            this.GbxContentRate.Text = "波特率";
            // 
            // CbxConnectRate
            // 
            this.CbxConnectRate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbxConnectRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxConnectRate.FormattingEnabled = true;
            this.CbxConnectRate.Location = new System.Drawing.Point(6, 20);
            this.CbxConnectRate.Name = "CbxConnectRate";
            this.CbxConnectRate.Size = new System.Drawing.Size(88, 25);
            this.CbxConnectRate.TabIndex = 0;
            // 
            // GbxConnectSPort
            // 
            this.GbxConnectSPort.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.GbxConnectSPort.Controls.Add(this.CbxConnectPort);
            this.GbxConnectSPort.Location = new System.Drawing.Point(6, 11);
            this.GbxConnectSPort.Name = "GbxConnectSPort";
            this.GbxConnectSPort.Size = new System.Drawing.Size(100, 53);
            this.GbxConnectSPort.TabIndex = 0;
            this.GbxConnectSPort.TabStop = false;
            this.GbxConnectSPort.Text = "串口号";
            // 
            // CbxConnectPort
            // 
            this.CbxConnectPort.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbxConnectPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxConnectPort.FormattingEnabled = true;
            this.CbxConnectPort.Location = new System.Drawing.Point(6, 21);
            this.CbxConnectPort.Name = "CbxConnectPort";
            this.CbxConnectPort.Size = new System.Drawing.Size(88, 25);
            this.CbxConnectPort.TabIndex = 0;
            // 
            // PnlConnectType
            // 
            this.PnlConnectType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PnlConnectType.Controls.Add(this.GbxConnectType);
            this.PnlConnectType.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlConnectType.Location = new System.Drawing.Point(0, 0);
            this.PnlConnectType.Name = "PnlConnectType";
            this.PnlConnectType.Size = new System.Drawing.Size(225, 80);
            this.PnlConnectType.TabIndex = 3;
            // 
            // GbxConnectType
            // 
            this.GbxConnectType.Controls.Add(this.RBtnNetport);
            this.GbxConnectType.Controls.Add(this.RBtnRs232);
            this.GbxConnectType.Location = new System.Drawing.Point(10, 10);
            this.GbxConnectType.Margin = new System.Windows.Forms.Padding(10);
            this.GbxConnectType.Name = "GbxConnectType";
            this.GbxConnectType.Padding = new System.Windows.Forms.Padding(10);
            this.GbxConnectType.Size = new System.Drawing.Size(205, 55);
            this.GbxConnectType.TabIndex = 0;
            this.GbxConnectType.TabStop = false;
            this.GbxConnectType.Text = "连接方式";
            // 
            // RBtnNetport
            // 
            this.RBtnNetport.AutoSize = true;
            this.RBtnNetport.Location = new System.Drawing.Point(107, 22);
            this.RBtnNetport.Name = "RBtnNetport";
            this.RBtnNetport.Size = new System.Drawing.Size(88, 21);
            this.RBtnNetport.TabIndex = 1;
            this.RBtnNetport.Text = "网口TCP/IP";
            this.RBtnNetport.UseVisualStyleBackColor = true;
            this.RBtnNetport.CheckedChanged += new System.EventHandler(this.RBtnNetport_CheckedChanged);
            // 
            // RBtnRs232
            // 
            this.RBtnRs232.AutoSize = true;
            this.RBtnRs232.Checked = true;
            this.RBtnRs232.Location = new System.Drawing.Point(15, 22);
            this.RBtnRs232.Name = "RBtnRs232";
            this.RBtnRs232.Size = new System.Drawing.Size(86, 21);
            this.RBtnRs232.TabIndex = 0;
            this.RBtnRs232.TabStop = true;
            this.RBtnRs232.Text = "串口RS232";
            this.RBtnRs232.UseVisualStyleBackColor = true;
            this.RBtnRs232.CheckedChanged += new System.EventHandler(this.RBtnRs232_CheckedChanged);
            // 
            // PnlContent
            // 
            this.PnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlContent.Location = new System.Drawing.Point(0, 80);
            this.PnlContent.Name = "PnlContent";
            this.PnlContent.Size = new System.Drawing.Size(784, 356);
            this.PnlContent.TabIndex = 1;
            // 
            // PnlLogArea
            // 
            this.PnlLogArea.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlLogArea.Location = new System.Drawing.Point(0, 436);
            this.PnlLogArea.Name = "PnlLogArea";
            this.PnlLogArea.Size = new System.Drawing.Size(784, 125);
            this.PnlLogArea.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.PnlMain);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "深坂RFID读写器";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.PnlMain.ResumeLayout(false);
            this.PnlConnect.ResumeLayout(false);
            this.PnlConnectBtns.ResumeLayout(false);
            this.PnlConnectConfig.ResumeLayout(false);
            this.GbxConnectNPort.ResumeLayout(false);
            this.GbxConnectNPort.PerformLayout();
            this.GbxConnectIP.ResumeLayout(false);
            this.GbxConnectIP.PerformLayout();
            this.GbxContentRate.ResumeLayout(false);
            this.GbxConnectSPort.ResumeLayout(false);
            this.PnlConnectType.ResumeLayout(false);
            this.GbxConnectType.ResumeLayout(false);
            this.GbxConnectType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.Forms.Panel PnlMain;
        private Windows.Forms.Panel PnlConnect;
        private Windows.Forms.GroupBox GbxConnectType;
        private Windows.Forms.RadioButton RBtnRs232;
        private Windows.Forms.RadioButton RBtnNetport;
        private Windows.Forms.Panel PnlConnectBtns;
        private Windows.Forms.Button BtnConnect;
        private Windows.Forms.Panel PnlConnectConfig;
        private Windows.Forms.Panel PnlConnectType;
        private Windows.Forms.GroupBox GbxConnectSPort;
        private Windows.Forms.GroupBox GbxContentRate;
        private Windows.Forms.ComboBox comboBox2;
        private Windows.Forms.ComboBox comboBox1;
        private Windows.Forms.GroupBox GbxConnectNPort;
        private Windows.Forms.GroupBox GbxConnectIP;
        private Windows.Forms.TextBox TxtConnectPort;
        private Windows.Forms.TextBox TxtConnectIP;
        private Windows.Forms.ComboBox CbxConnectRate;
        private Windows.Forms.ComboBox CbxConnectPort;
        private Windows.Forms.Panel PnlLogArea;
        private Windows.Forms.Panel PnlContent;
    }
}
