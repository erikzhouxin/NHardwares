namespace TestHardwareDemo.WinForm.Views
{
    partial class ShenBanRFIDv2211
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
            this.Tlp = new System.Windows.Forms.TableLayoutPanel();
            this.PnlTabCnt1 = new System.Windows.Forms.Panel();
            this.GrbNetConfig = new System.Windows.Forms.GroupBox();
            this.GrbNetDetail = new System.Windows.Forms.GroupBox();
            this.PnlNetDetail = new System.Windows.Forms.Panel();
            this.ChkReadMode = new System.Windows.Forms.CheckBox();
            this.BtnRefreshPort = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LblSerialPort = new System.Windows.Forms.Label();
            this.BtnConnRemove = new System.Windows.Forms.Button();
            this.BtnConnAdd = new System.Windows.Forms.Button();
            this.CbxRfidAnt = new System.Windows.Forms.ComboBox();
            this.CbxPortRate = new System.Windows.Forms.ComboBox();
            this.CbxSerialPort = new System.Windows.Forms.ComboBox();
            this.PnlNetConfigs = new System.Windows.Forms.Panel();
            this.CbxNetConfigs = new System.Windows.Forms.ComboBox();
            this.PnlTabCnt2 = new System.Windows.Forms.Panel();
            this.GrbScanList = new System.Windows.Forms.GroupBox();
            this.DgvReadResult = new System.Windows.Forms.DataGridView();
            this.CmsrDgvTagResult = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TsmiClearTags = new System.Windows.Forms.ToolStripMenuItem();
            this.PnlTabCnt3 = new System.Windows.Forms.Panel();
            this.PnlTabCnt4 = new System.Windows.Forms.Panel();
            this.GrbTxtLogger = new System.Windows.Forms.GroupBox();
            this.TxtLogger = new System.Windows.Forms.RichTextBox();
            this.CmsrTxtLoggerCtx = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TsrmLoggerClear = new System.Windows.Forms.ToolStripMenuItem();
            this.PnlContent = new System.Windows.Forms.Panel();
            this.Tlp.SuspendLayout();
            this.PnlTabCnt1.SuspendLayout();
            this.GrbNetConfig.SuspendLayout();
            this.GrbNetDetail.SuspendLayout();
            this.PnlNetDetail.SuspendLayout();
            this.PnlNetConfigs.SuspendLayout();
            this.PnlTabCnt2.SuspendLayout();
            this.GrbScanList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvReadResult)).BeginInit();
            this.CmsrDgvTagResult.SuspendLayout();
            this.PnlTabCnt4.SuspendLayout();
            this.GrbTxtLogger.SuspendLayout();
            this.CmsrTxtLoggerCtx.SuspendLayout();
            this.PnlContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tlp
            // 
            this.Tlp.ColumnCount = 2;
            this.Tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tlp.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tlp.Controls.Add(this.PnlTabCnt1, 0, 0);
            this.Tlp.Controls.Add(this.PnlTabCnt2, 1, 0);
            this.Tlp.Controls.Add(this.PnlTabCnt3, 0, 1);
            this.Tlp.Controls.Add(this.PnlTabCnt4, 1, 1);
            this.Tlp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tlp.Location = new System.Drawing.Point(0, 0);
            this.Tlp.Name = "Tlp";
            this.Tlp.RowCount = 2;
            this.Tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tlp.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.Tlp.Size = new System.Drawing.Size(1045, 726);
            this.Tlp.TabIndex = 0;
            // 
            // PnlTabCnt1
            // 
            this.PnlTabCnt1.Controls.Add(this.GrbNetConfig);
            this.PnlTabCnt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTabCnt1.Location = new System.Drawing.Point(3, 3);
            this.PnlTabCnt1.Name = "PnlTabCnt1";
            this.PnlTabCnt1.Size = new System.Drawing.Size(516, 357);
            this.PnlTabCnt1.TabIndex = 0;
            // 
            // GrbNetConfig
            // 
            this.GrbNetConfig.Controls.Add(this.GrbNetDetail);
            this.GrbNetConfig.Controls.Add(this.PnlNetConfigs);
            this.GrbNetConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbNetConfig.Location = new System.Drawing.Point(0, 0);
            this.GrbNetConfig.Name = "GrbNetConfig";
            this.GrbNetConfig.Size = new System.Drawing.Size(516, 357);
            this.GrbNetConfig.TabIndex = 3;
            this.GrbNetConfig.TabStop = false;
            this.GrbNetConfig.Text = "连接配置";
            // 
            // GrbNetDetail
            // 
            this.GrbNetDetail.Controls.Add(this.PnlNetDetail);
            this.GrbNetDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbNetDetail.Location = new System.Drawing.Point(3, 87);
            this.GrbNetDetail.Name = "GrbNetDetail";
            this.GrbNetDetail.Size = new System.Drawing.Size(510, 267);
            this.GrbNetDetail.TabIndex = 2;
            this.GrbNetDetail.TabStop = false;
            this.GrbNetDetail.Text = "配置详情";
            // 
            // PnlNetDetail
            // 
            this.PnlNetDetail.AutoScroll = true;
            this.PnlNetDetail.Controls.Add(this.ChkReadMode);
            this.PnlNetDetail.Controls.Add(this.BtnRefreshPort);
            this.PnlNetDetail.Controls.Add(this.label2);
            this.PnlNetDetail.Controls.Add(this.label1);
            this.PnlNetDetail.Controls.Add(this.LblSerialPort);
            this.PnlNetDetail.Controls.Add(this.BtnConnRemove);
            this.PnlNetDetail.Controls.Add(this.BtnConnAdd);
            this.PnlNetDetail.Controls.Add(this.CbxRfidAnt);
            this.PnlNetDetail.Controls.Add(this.CbxPortRate);
            this.PnlNetDetail.Controls.Add(this.CbxSerialPort);
            this.PnlNetDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlNetDetail.Location = new System.Drawing.Point(3, 19);
            this.PnlNetDetail.Name = "PnlNetDetail";
            this.PnlNetDetail.Size = new System.Drawing.Size(504, 245);
            this.PnlNetDetail.TabIndex = 1;
            // 
            // ChkReadMode
            // 
            this.ChkReadMode.AutoSize = true;
            this.ChkReadMode.Location = new System.Drawing.Point(112, 110);
            this.ChkReadMode.Name = "ChkReadMode";
            this.ChkReadMode.Size = new System.Drawing.Size(75, 21);
            this.ChkReadMode.TabIndex = 14;
            this.ChkReadMode.Text = "自动读取";
            this.ChkReadMode.UseVisualStyleBackColor = true;
            // 
            // BtnRefreshPort
            // 
            this.BtnRefreshPort.Location = new System.Drawing.Point(261, 8);
            this.BtnRefreshPort.Margin = new System.Windows.Forms.Padding(4);
            this.BtnRefreshPort.Name = "BtnRefreshPort";
            this.BtnRefreshPort.Size = new System.Drawing.Size(60, 30);
            this.BtnRefreshPort.TabIndex = 13;
            this.BtnRefreshPort.Text = "刷新";
            this.BtnRefreshPort.UseVisualStyleBackColor = true;
            this.BtnRefreshPort.Click += new System.EventHandler(this.BtnRefreshPort_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "天线号或组合：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "波特率或端口：";
            // 
            // LblSerialPort
            // 
            this.LblSerialPort.AutoSize = true;
            this.LblSerialPort.Location = new System.Drawing.Point(12, 15);
            this.LblSerialPort.Name = "LblSerialPort";
            this.LblSerialPort.Size = new System.Drawing.Size(92, 17);
            this.LblSerialPort.TabIndex = 10;
            this.LblSerialPort.Text = "串口号或地址：";
            // 
            // BtnConnRemove
            // 
            this.BtnConnRemove.Location = new System.Drawing.Point(178, 140);
            this.BtnConnRemove.Margin = new System.Windows.Forms.Padding(4);
            this.BtnConnRemove.Name = "BtnConnRemove";
            this.BtnConnRemove.Size = new System.Drawing.Size(60, 30);
            this.BtnConnRemove.TabIndex = 7;
            this.BtnConnRemove.Text = "移除";
            this.BtnConnRemove.UseVisualStyleBackColor = true;
            this.BtnConnRemove.Click += new System.EventHandler(this.BtnConnRemove_Click);
            // 
            // BtnConnAdd
            // 
            this.BtnConnAdd.Location = new System.Drawing.Point(111, 140);
            this.BtnConnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.BtnConnAdd.Name = "BtnConnAdd";
            this.BtnConnAdd.Size = new System.Drawing.Size(60, 30);
            this.BtnConnAdd.TabIndex = 8;
            this.BtnConnAdd.Text = "添加";
            this.BtnConnAdd.UseVisualStyleBackColor = true;
            this.BtnConnAdd.Click += new System.EventHandler(this.BtnConnAdd_Click);
            // 
            // CbxRfidAnt
            // 
            this.CbxRfidAnt.FormattingEnabled = true;
            this.CbxRfidAnt.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.CbxRfidAnt.Location = new System.Drawing.Point(111, 78);
            this.CbxRfidAnt.Margin = new System.Windows.Forms.Padding(4);
            this.CbxRfidAnt.Name = "CbxRfidAnt";
            this.CbxRfidAnt.Size = new System.Drawing.Size(127, 25);
            this.CbxRfidAnt.TabIndex = 5;
            this.CbxRfidAnt.Text = "0";
            // 
            // CbxPortRate
            // 
            this.CbxPortRate.FormattingEnabled = true;
            this.CbxPortRate.Items.AddRange(new object[] {
            "115200",
            "4001"});
            this.CbxPortRate.Location = new System.Drawing.Point(111, 45);
            this.CbxPortRate.Margin = new System.Windows.Forms.Padding(4);
            this.CbxPortRate.Name = "CbxPortRate";
            this.CbxPortRate.Size = new System.Drawing.Size(127, 25);
            this.CbxPortRate.TabIndex = 6;
            this.CbxPortRate.Text = "4001";
            // 
            // CbxSerialPort
            // 
            this.CbxSerialPort.FormattingEnabled = true;
            this.CbxSerialPort.Items.AddRange(new object[] {
            "192.168.0.178",
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9"});
            this.CbxSerialPort.Location = new System.Drawing.Point(111, 12);
            this.CbxSerialPort.Margin = new System.Windows.Forms.Padding(4);
            this.CbxSerialPort.Name = "CbxSerialPort";
            this.CbxSerialPort.Size = new System.Drawing.Size(127, 25);
            this.CbxSerialPort.TabIndex = 4;
            this.CbxSerialPort.Text = "192.168.0.178";
            // 
            // PnlNetConfigs
            // 
            this.PnlNetConfigs.AutoScroll = true;
            this.PnlNetConfigs.Controls.Add(this.CbxNetConfigs);
            this.PnlNetConfigs.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlNetConfigs.Location = new System.Drawing.Point(3, 19);
            this.PnlNetConfigs.Name = "PnlNetConfigs";
            this.PnlNetConfigs.Size = new System.Drawing.Size(510, 68);
            this.PnlNetConfigs.TabIndex = 0;
            // 
            // CbxNetConfigs
            // 
            this.CbxNetConfigs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CbxNetConfigs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbxNetConfigs.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CbxNetConfigs.FormattingEnabled = true;
            this.CbxNetConfigs.Location = new System.Drawing.Point(15, 14);
            this.CbxNetConfigs.Name = "CbxNetConfigs";
            this.CbxNetConfigs.Size = new System.Drawing.Size(465, 29);
            this.CbxNetConfigs.TabIndex = 4;
            // 
            // PnlTabCnt2
            // 
            this.PnlTabCnt2.Controls.Add(this.GrbScanList);
            this.PnlTabCnt2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTabCnt2.Location = new System.Drawing.Point(525, 3);
            this.PnlTabCnt2.Name = "PnlTabCnt2";
            this.PnlTabCnt2.Size = new System.Drawing.Size(517, 357);
            this.PnlTabCnt2.TabIndex = 1;
            // 
            // GrbScanList
            // 
            this.GrbScanList.Controls.Add(this.DgvReadResult);
            this.GrbScanList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbScanList.Location = new System.Drawing.Point(0, 0);
            this.GrbScanList.Name = "GrbScanList";
            this.GrbScanList.Size = new System.Drawing.Size(517, 357);
            this.GrbScanList.TabIndex = 2;
            this.GrbScanList.TabStop = false;
            this.GrbScanList.Text = "扫描列表";
            // 
            // DgvReadResult
            // 
            this.DgvReadResult.AllowUserToAddRows = false;
            this.DgvReadResult.AllowUserToDeleteRows = false;
            this.DgvReadResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvReadResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvReadResult.ContextMenuStrip = this.CmsrDgvTagResult;
            this.DgvReadResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvReadResult.Location = new System.Drawing.Point(3, 19);
            this.DgvReadResult.Margin = new System.Windows.Forms.Padding(4);
            this.DgvReadResult.Name = "DgvReadResult";
            this.DgvReadResult.ReadOnly = true;
            this.DgvReadResult.RowTemplate.Height = 23;
            this.DgvReadResult.Size = new System.Drawing.Size(511, 335);
            this.DgvReadResult.TabIndex = 1;
            // 
            // CmsrDgvTagResult
            // 
            this.CmsrDgvTagResult.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiClearTags});
            this.CmsrDgvTagResult.Name = "CmsrDgvTagResult";
            this.CmsrDgvTagResult.Size = new System.Drawing.Size(125, 26);
            // 
            // TsmiClearTags
            // 
            this.TsmiClearTags.Name = "TsmiClearTags";
            this.TsmiClearTags.Size = new System.Drawing.Size(124, 22);
            this.TsmiClearTags.Text = "清除标签";
            this.TsmiClearTags.Click += new System.EventHandler(this.BtnClearTags_Click);
            // 
            // PnlTabCnt3
            // 
            this.PnlTabCnt3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTabCnt3.Location = new System.Drawing.Point(3, 366);
            this.PnlTabCnt3.Name = "PnlTabCnt3";
            this.PnlTabCnt3.Size = new System.Drawing.Size(516, 357);
            this.PnlTabCnt3.TabIndex = 2;
            // 
            // PnlTabCnt4
            // 
            this.PnlTabCnt4.Controls.Add(this.GrbTxtLogger);
            this.PnlTabCnt4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlTabCnt4.Location = new System.Drawing.Point(525, 366);
            this.PnlTabCnt4.Name = "PnlTabCnt4";
            this.PnlTabCnt4.Size = new System.Drawing.Size(517, 357);
            this.PnlTabCnt4.TabIndex = 3;
            // 
            // GrbTxtLogger
            // 
            this.GrbTxtLogger.Controls.Add(this.TxtLogger);
            this.GrbTxtLogger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbTxtLogger.Location = new System.Drawing.Point(0, 0);
            this.GrbTxtLogger.Name = "GrbTxtLogger";
            this.GrbTxtLogger.Size = new System.Drawing.Size(517, 357);
            this.GrbTxtLogger.TabIndex = 3;
            this.GrbTxtLogger.TabStop = false;
            this.GrbTxtLogger.Text = "日志信息";
            // 
            // TxtLogger
            // 
            this.TxtLogger.ContextMenuStrip = this.CmsrTxtLoggerCtx;
            this.TxtLogger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtLogger.Location = new System.Drawing.Point(3, 19);
            this.TxtLogger.Name = "TxtLogger";
            this.TxtLogger.Size = new System.Drawing.Size(511, 335);
            this.TxtLogger.TabIndex = 0;
            this.TxtLogger.Text = "";
            // 
            // CmsrTxtLoggerCtx
            // 
            this.CmsrTxtLoggerCtx.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsrmLoggerClear});
            this.CmsrTxtLoggerCtx.Name = "CmsrTxtLoggerCtx";
            this.CmsrTxtLoggerCtx.Size = new System.Drawing.Size(125, 26);
            // 
            // TsrmLoggerClear
            // 
            this.TsrmLoggerClear.Name = "TsrmLoggerClear";
            this.TsrmLoggerClear.Size = new System.Drawing.Size(124, 22);
            this.TsrmLoggerClear.Text = "清空日志";
            this.TsrmLoggerClear.Click += new System.EventHandler(this.TsrmLoggerClear_Click);
            // 
            // PnlContent
            // 
            this.PnlContent.Controls.Add(this.Tlp);
            this.PnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlContent.Location = new System.Drawing.Point(0, 0);
            this.PnlContent.Name = "PnlContent";
            this.PnlContent.Size = new System.Drawing.Size(1045, 726);
            this.PnlContent.TabIndex = 1;
            // 
            // ShenBanRFIDv2211
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PnlContent);
            this.Name = "ShenBanRFIDv2211";
            this.Size = new System.Drawing.Size(1045, 726);
            this.Load += new System.EventHandler(this.ShenBanRFIDv2211_Load);
            this.Tlp.ResumeLayout(false);
            this.PnlTabCnt1.ResumeLayout(false);
            this.GrbNetConfig.ResumeLayout(false);
            this.GrbNetDetail.ResumeLayout(false);
            this.PnlNetDetail.ResumeLayout(false);
            this.PnlNetDetail.PerformLayout();
            this.PnlNetConfigs.ResumeLayout(false);
            this.PnlTabCnt2.ResumeLayout(false);
            this.GrbScanList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvReadResult)).EndInit();
            this.CmsrDgvTagResult.ResumeLayout(false);
            this.PnlTabCnt4.ResumeLayout(false);
            this.GrbTxtLogger.ResumeLayout(false);
            this.CmsrTxtLoggerCtx.ResumeLayout(false);
            this.PnlContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel Tlp;
        private System.Windows.Forms.Panel PnlContent;
        private System.Windows.Forms.Panel PnlTabCnt1;
        private System.Windows.Forms.Panel PnlTabCnt2;
        private System.Windows.Forms.Panel PnlTabCnt3;
        private System.Windows.Forms.Panel PnlTabCnt4;
        private System.Windows.Forms.DataGridView DgvReadResult;
        private System.Windows.Forms.Panel PnlNetConfigs;
        private System.Windows.Forms.ComboBox CbxNetConfigs;
        private System.Windows.Forms.Panel PnlNetDetail;
        private System.Windows.Forms.GroupBox GrbNetDetail;
        private System.Windows.Forms.GroupBox GrbNetConfig;
        private System.Windows.Forms.Button BtnConnRemove;
        private System.Windows.Forms.Button BtnConnAdd;
        private System.Windows.Forms.ComboBox CbxRfidAnt;
        private System.Windows.Forms.ComboBox CbxPortRate;
        private System.Windows.Forms.ComboBox CbxSerialPort;
        private System.Windows.Forms.Label LblSerialPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GrbTxtLogger;
        private System.Windows.Forms.RichTextBox TxtLogger;
        private System.Windows.Forms.ContextMenuStrip CmsrTxtLoggerCtx;
        private System.Windows.Forms.ToolStripMenuItem TsrmLoggerClear;
        private System.Windows.Forms.GroupBox GrbScanList;
        private System.Windows.Forms.Button BtnRefreshPort;
        private System.Windows.Forms.CheckBox ChkReadMode;
        private System.Windows.Forms.ContextMenuStrip CmsrDgvTagResult;
        private System.Windows.Forms.ToolStripMenuItem TsmiClearTags;
    }
}
