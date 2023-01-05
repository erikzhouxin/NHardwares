namespace RecBarCodeModule.WinForm.Views
{
    partial class TestRecCodeR1
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PnlContent = new System.Windows.Forms.Panel();
            this.SplContent = new System.Windows.Forms.SplitContainer();
            this.PnlNetControl = new System.Windows.Forms.Panel();
            this.SplNetControl = new System.Windows.Forms.SplitContainer();
            this.GrbNetConfigArea = new System.Windows.Forms.GroupBox();
            this.PngNetConfig = new System.Windows.Forms.Panel();
            this.BtnNetConfigRemove = new System.Windows.Forms.Button();
            this.BtnNetConfigConnect = new System.Windows.Forms.Button();
            this.LblNetConfigPort = new System.Windows.Forms.Label();
            this.TxtNetConfigIp = new System.Windows.Forms.TextBox();
            this.TxtNetConfigPort = new System.Windows.Forms.TextBox();
            this.LblNetConfigIP = new System.Windows.Forms.Label();
            this.PnlNetConfigs = new System.Windows.Forms.Panel();
            this.LblNetReadSeconds = new System.Windows.Forms.Label();
            this.TxtNetSeconds = new System.Windows.Forms.TextBox();
            this.ChkNetReadBackground = new System.Windows.Forms.CheckBox();
            this.CbxNetConfigs = new System.Windows.Forms.ComboBox();
            this.GrbNetInfoContent = new System.Windows.Forms.GroupBox();
            this.GrbTxtLogger = new System.Windows.Forms.GroupBox();
            this.TxtLogger = new System.Windows.Forms.RichTextBox();
            this.CmsrLogger = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TsrmLoggerClear = new System.Windows.Forms.ToolStripMenuItem();
            this.PnlContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplContent)).BeginInit();
            this.SplContent.Panel1.SuspendLayout();
            this.SplContent.Panel2.SuspendLayout();
            this.SplContent.SuspendLayout();
            this.PnlNetControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplNetControl)).BeginInit();
            this.SplNetControl.Panel1.SuspendLayout();
            this.SplNetControl.Panel2.SuspendLayout();
            this.SplNetControl.SuspendLayout();
            this.GrbNetConfigArea.SuspendLayout();
            this.PngNetConfig.SuspendLayout();
            this.PnlNetConfigs.SuspendLayout();
            this.GrbTxtLogger.SuspendLayout();
            this.CmsrLogger.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlContent
            // 
            this.PnlContent.Controls.Add(this.SplContent);
            this.PnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlContent.Location = new System.Drawing.Point(0, 0);
            this.PnlContent.Name = "PnlContent";
            this.PnlContent.Size = new System.Drawing.Size(1080, 768);
            this.PnlContent.TabIndex = 1;
            // 
            // SplContent
            // 
            this.SplContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SplContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplContent.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplContent.IsSplitterFixed = true;
            this.SplContent.Location = new System.Drawing.Point(0, 0);
            this.SplContent.Name = "SplContent";
            // 
            // SplContent.Panel1
            // 
            this.SplContent.Panel1.Controls.Add(this.PnlNetControl);
            this.SplContent.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SplContent.Panel1MinSize = 512;
            // 
            // SplContent.Panel2
            // 
            this.SplContent.Panel2.Controls.Add(this.GrbTxtLogger);
            this.SplContent.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SplContent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SplContent.Size = new System.Drawing.Size(1080, 768);
            this.SplContent.SplitterDistance = 512;
            this.SplContent.TabIndex = 0;
            // 
            // PnlNetControl
            // 
            this.PnlNetControl.Controls.Add(this.SplNetControl);
            this.PnlNetControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlNetControl.Location = new System.Drawing.Point(0, 0);
            this.PnlNetControl.Name = "PnlNetControl";
            this.PnlNetControl.Size = new System.Drawing.Size(510, 766);
            this.PnlNetControl.TabIndex = 0;
            // 
            // SplNetControl
            // 
            this.SplNetControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplNetControl.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.SplNetControl.Location = new System.Drawing.Point(0, 0);
            this.SplNetControl.Name = "SplNetControl";
            this.SplNetControl.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplNetControl.Panel1
            // 
            this.SplNetControl.Panel1.AutoScroll = true;
            this.SplNetControl.Panel1.Controls.Add(this.GrbNetConfigArea);
            // 
            // SplNetControl.Panel2
            // 
            this.SplNetControl.Panel2.Controls.Add(this.GrbNetInfoContent);
            this.SplNetControl.Size = new System.Drawing.Size(510, 766);
            this.SplNetControl.SplitterDistance = 145;
            this.SplNetControl.TabIndex = 0;
            // 
            // GrbNetConfigArea
            // 
            this.GrbNetConfigArea.Controls.Add(this.PngNetConfig);
            this.GrbNetConfigArea.Controls.Add(this.PnlNetConfigs);
            this.GrbNetConfigArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbNetConfigArea.Location = new System.Drawing.Point(0, 0);
            this.GrbNetConfigArea.Name = "GrbNetConfigArea";
            this.GrbNetConfigArea.Size = new System.Drawing.Size(510, 145);
            this.GrbNetConfigArea.TabIndex = 0;
            this.GrbNetConfigArea.TabStop = false;
            this.GrbNetConfigArea.Text = "二维码识别器配置";
            // 
            // PngNetConfig
            // 
            this.PngNetConfig.Controls.Add(this.BtnNetConfigRemove);
            this.PngNetConfig.Controls.Add(this.BtnNetConfigConnect);
            this.PngNetConfig.Controls.Add(this.LblNetConfigPort);
            this.PngNetConfig.Controls.Add(this.TxtNetConfigIp);
            this.PngNetConfig.Controls.Add(this.TxtNetConfigPort);
            this.PngNetConfig.Controls.Add(this.LblNetConfigIP);
            this.PngNetConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PngNetConfig.Location = new System.Drawing.Point(3, 66);
            this.PngNetConfig.Name = "PngNetConfig";
            this.PngNetConfig.Size = new System.Drawing.Size(504, 76);
            this.PngNetConfig.TabIndex = 6;
            // 
            // BtnNetConfigRemove
            // 
            this.BtnNetConfigRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnNetConfigRemove.Location = new System.Drawing.Point(322, 32);
            this.BtnNetConfigRemove.Name = "BtnNetConfigRemove";
            this.BtnNetConfigRemove.Size = new System.Drawing.Size(75, 23);
            this.BtnNetConfigRemove.TabIndex = 5;
            this.BtnNetConfigRemove.Text = "移除";
            this.BtnNetConfigRemove.UseVisualStyleBackColor = true;
            this.BtnNetConfigRemove.Click += new System.EventHandler(this.BtnNetConfigRemove_Click);
            // 
            // BtnNetConfigConnect
            // 
            this.BtnNetConfigConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnNetConfigConnect.Location = new System.Drawing.Point(410, 32);
            this.BtnNetConfigConnect.Name = "BtnNetConfigConnect";
            this.BtnNetConfigConnect.Size = new System.Drawing.Size(75, 23);
            this.BtnNetConfigConnect.TabIndex = 4;
            this.BtnNetConfigConnect.Text = "连接";
            this.BtnNetConfigConnect.UseVisualStyleBackColor = true;
            this.BtnNetConfigConnect.Click += new System.EventHandler(this.BtnNetConfigConnect_Click);
            // 
            // LblNetConfigPort
            // 
            this.LblNetConfigPort.AutoSize = true;
            this.LblNetConfigPort.Location = new System.Drawing.Point(141, 11);
            this.LblNetConfigPort.Name = "LblNetConfigPort";
            this.LblNetConfigPort.Size = new System.Drawing.Size(56, 17);
            this.LblNetConfigPort.TabIndex = 3;
            this.LblNetConfigPort.Text = "端口号：";
            // 
            // TxtNetConfigIp
            // 
            this.TxtNetConfigIp.AutoCompleteCustomSource.AddRange(new string[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9"});
            this.TxtNetConfigIp.Location = new System.Drawing.Point(14, 32);
            this.TxtNetConfigIp.Name = "TxtNetConfigIp";
            this.TxtNetConfigIp.Size = new System.Drawing.Size(114, 23);
            this.TxtNetConfigIp.TabIndex = 0;
            this.TxtNetConfigIp.Text = "COM3";
            // 
            // TxtNetConfigPort
            // 
            this.TxtNetConfigPort.AutoCompleteCustomSource.AddRange(new string[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.TxtNetConfigPort.Location = new System.Drawing.Point(141, 32);
            this.TxtNetConfigPort.Name = "TxtNetConfigPort";
            this.TxtNetConfigPort.Size = new System.Drawing.Size(56, 23);
            this.TxtNetConfigPort.TabIndex = 2;
            this.TxtNetConfigPort.Text = "9600";
            // 
            // LblNetConfigIP
            // 
            this.LblNetConfigIP.AutoSize = true;
            this.LblNetConfigIP.Location = new System.Drawing.Point(14, 11);
            this.LblNetConfigIP.Name = "LblNetConfigIP";
            this.LblNetConfigIP.Size = new System.Drawing.Size(55, 17);
            this.LblNetConfigIP.TabIndex = 1;
            this.LblNetConfigIP.Text = "IP地址：";
            // 
            // PnlNetConfigs
            // 
            this.PnlNetConfigs.Controls.Add(this.LblNetReadSeconds);
            this.PnlNetConfigs.Controls.Add(this.TxtNetSeconds);
            this.PnlNetConfigs.Controls.Add(this.ChkNetReadBackground);
            this.PnlNetConfigs.Controls.Add(this.CbxNetConfigs);
            this.PnlNetConfigs.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlNetConfigs.Location = new System.Drawing.Point(3, 19);
            this.PnlNetConfigs.Name = "PnlNetConfigs";
            this.PnlNetConfigs.Size = new System.Drawing.Size(504, 47);
            this.PnlNetConfigs.TabIndex = 5;
            // 
            // LblNetReadSeconds
            // 
            this.LblNetReadSeconds.AutoSize = true;
            this.LblNetReadSeconds.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LblNetReadSeconds.Location = new System.Drawing.Point(459, 12);
            this.LblNetReadSeconds.Name = "LblNetReadSeconds";
            this.LblNetReadSeconds.Size = new System.Drawing.Size(26, 21);
            this.LblNetReadSeconds.TabIndex = 3;
            this.LblNetReadSeconds.Text = "秒";
            // 
            // TxtNetSeconds
            // 
            this.TxtNetSeconds.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TxtNetSeconds.Location = new System.Drawing.Point(417, 8);
            this.TxtNetSeconds.MaxLength = 2;
            this.TxtNetSeconds.Name = "TxtNetSeconds";
            this.TxtNetSeconds.Size = new System.Drawing.Size(36, 28);
            this.TxtNetSeconds.TabIndex = 2;
            this.TxtNetSeconds.Text = "10";
            // 
            // ChkNetReadBackground
            // 
            this.ChkNetReadBackground.AutoSize = true;
            this.ChkNetReadBackground.Checked = true;
            this.ChkNetReadBackground.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkNetReadBackground.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ChkNetReadBackground.Location = new System.Drawing.Point(315, 10);
            this.ChkNetReadBackground.Name = "ChkNetReadBackground";
            this.ChkNetReadBackground.Size = new System.Drawing.Size(93, 25);
            this.ChkNetReadBackground.TabIndex = 1;
            this.ChkNetReadBackground.Text = "后台读取";
            this.ChkNetReadBackground.UseVisualStyleBackColor = true;
            // 
            // CbxNetConfigs
            // 
            this.CbxNetConfigs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxNetConfigs.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbxNetConfigs.FormattingEnabled = true;
            this.CbxNetConfigs.Location = new System.Drawing.Point(14, 8);
            this.CbxNetConfigs.Name = "CbxNetConfigs";
            this.CbxNetConfigs.Size = new System.Drawing.Size(292, 29);
            this.CbxNetConfigs.TabIndex = 0;
            this.CbxNetConfigs.SelectedIndexChanged += new System.EventHandler(this.CbxNetConfigs_SelectedIndexChanged);
            // 
            // GrbNetInfoContent
            // 
            this.GrbNetInfoContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbNetInfoContent.Location = new System.Drawing.Point(0, 0);
            this.GrbNetInfoContent.Name = "GrbNetInfoContent";
            this.GrbNetInfoContent.Size = new System.Drawing.Size(510, 617);
            this.GrbNetInfoContent.TabIndex = 4;
            this.GrbNetInfoContent.TabStop = false;
            this.GrbNetInfoContent.Text = "设备其他信息参数";
            // 
            // GrbTxtLogger
            // 
            this.GrbTxtLogger.Controls.Add(this.TxtLogger);
            this.GrbTxtLogger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbTxtLogger.Location = new System.Drawing.Point(0, 0);
            this.GrbTxtLogger.Name = "GrbTxtLogger";
            this.GrbTxtLogger.Size = new System.Drawing.Size(562, 766);
            this.GrbTxtLogger.TabIndex = 1;
            this.GrbTxtLogger.TabStop = false;
            this.GrbTxtLogger.Text = "信息日志";
            // 
            // TxtLogger
            // 
            this.TxtLogger.ContextMenuStrip = this.CmsrLogger;
            this.TxtLogger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtLogger.Location = new System.Drawing.Point(3, 19);
            this.TxtLogger.Name = "TxtLogger";
            this.TxtLogger.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.TxtLogger.Size = new System.Drawing.Size(556, 744);
            this.TxtLogger.TabIndex = 0;
            this.TxtLogger.Text = "";
            // 
            // CmsrLogger
            // 
            this.CmsrLogger.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsrmLoggerClear});
            this.CmsrLogger.Name = "contextMenuStrip1";
            this.CmsrLogger.Size = new System.Drawing.Size(125, 26);
            // 
            // TsrmLoggerClear
            // 
            this.TsrmLoggerClear.Name = "TsrmLoggerClear";
            this.TsrmLoggerClear.Size = new System.Drawing.Size(124, 22);
            this.TsrmLoggerClear.Text = "清空日志";
            this.TsrmLoggerClear.Click += new System.EventHandler(this.TsrmLoggerClear_Click);
            // 
            // TestRecCodeR1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PnlContent);
            this.Name = "TestRecCodeR1";
            this.Size = new System.Drawing.Size(1080, 768);
            this.Load += new System.EventHandler(this.TestScanner_Load);
            this.PnlContent.ResumeLayout(false);
            this.SplContent.Panel1.ResumeLayout(false);
            this.SplContent.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplContent)).EndInit();
            this.SplContent.ResumeLayout(false);
            this.PnlNetControl.ResumeLayout(false);
            this.SplNetControl.Panel1.ResumeLayout(false);
            this.SplNetControl.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplNetControl)).EndInit();
            this.SplNetControl.ResumeLayout(false);
            this.GrbNetConfigArea.ResumeLayout(false);
            this.PngNetConfig.ResumeLayout(false);
            this.PngNetConfig.PerformLayout();
            this.PnlNetConfigs.ResumeLayout(false);
            this.PnlNetConfigs.PerformLayout();
            this.GrbTxtLogger.ResumeLayout(false);
            this.CmsrLogger.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel PnlContent;
        private System.Windows.Forms.SplitContainer SplContent;
        private System.Windows.Forms.RichTextBox TxtLogger;
        private System.Windows.Forms.Panel PnlNetControl;
        private System.Windows.Forms.SplitContainer SplNetControl;
        private System.Windows.Forms.GroupBox GrbNetConfigArea;
        private System.Windows.Forms.TextBox TxtNetConfigPort;
        private System.Windows.Forms.Label LblNetConfigIP;
        private System.Windows.Forms.TextBox TxtNetConfigIp;
        private System.Windows.Forms.Label LblNetConfigPort;
        private System.Windows.Forms.Panel PngNetConfig;
        private System.Windows.Forms.Button BtnNetConfigConnect;
        private System.Windows.Forms.Panel PnlNetConfigs;
        private System.Windows.Forms.ComboBox CbxNetConfigs;
        private System.Windows.Forms.GroupBox GrbNetInfoContent;
        private System.Windows.Forms.GroupBox GrbTxtLogger;
        private System.Windows.Forms.Button BtnNetConfigRemove;
        private System.Windows.Forms.ContextMenuStrip CmsrLogger;
        private System.Windows.Forms.ToolStripMenuItem TsrmLoggerClear;
        private System.Windows.Forms.CheckBox ChkNetReadBackground;
        private System.Windows.Forms.Label LblNetReadSeconds;
        private System.Windows.Forms.TextBox TxtNetSeconds;
    }
}
