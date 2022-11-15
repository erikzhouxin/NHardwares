namespace ShenBanReader.WinForm.Views
{
    partial class AutoReaderFlew
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnRefreshPort = new System.Windows.Forms.Button();
            this.BtnConnection = new System.Windows.Forms.Button();
            this.CbxPortRate = new System.Windows.Forms.ComboBox();
            this.CbxSerialPort = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.DgvReadResult = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TxtLogger = new System.Windows.Forms.RichTextBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvReadResult)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnRefreshPort);
            this.panel2.Controls.Add(this.BtnConnection);
            this.panel2.Controls.Add(this.CbxPortRate);
            this.panel2.Controls.Add(this.CbxSerialPort);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1005, 194);
            this.panel2.TabIndex = 0;
            // 
            // BtnRefreshPort
            // 
            this.BtnRefreshPort.Location = new System.Drawing.Point(643, 62);
            this.BtnRefreshPort.Margin = new System.Windows.Forms.Padding(4);
            this.BtnRefreshPort.Name = "BtnRefreshPort";
            this.BtnRefreshPort.Size = new System.Drawing.Size(88, 33);
            this.BtnRefreshPort.TabIndex = 3;
            this.BtnRefreshPort.Text = "刷新串口";
            this.BtnRefreshPort.UseVisualStyleBackColor = true;
            this.BtnRefreshPort.Click += new System.EventHandler(this.BtnRefreshPort_Click);
            // 
            // BtnConnection
            // 
            this.BtnConnection.Location = new System.Drawing.Point(532, 62);
            this.BtnConnection.Margin = new System.Windows.Forms.Padding(4);
            this.BtnConnection.Name = "BtnConnection";
            this.BtnConnection.Size = new System.Drawing.Size(88, 33);
            this.BtnConnection.TabIndex = 2;
            this.BtnConnection.Text = "开始";
            this.BtnConnection.UseVisualStyleBackColor = true;
            this.BtnConnection.Click += new System.EventHandler(this.BtnConnection_Click);
            // 
            // CbxPortRate
            // 
            this.CbxPortRate.FormattingEnabled = true;
            this.CbxPortRate.Items.AddRange(new object[] {
            "115200",
            "9600"});
            this.CbxPortRate.Location = new System.Drawing.Point(250, 62);
            this.CbxPortRate.Margin = new System.Windows.Forms.Padding(4);
            this.CbxPortRate.Name = "CbxPortRate";
            this.CbxPortRate.Size = new System.Drawing.Size(140, 25);
            this.CbxPortRate.TabIndex = 1;
            this.CbxPortRate.Text = "115200";
            // 
            // CbxSerialPort
            // 
            this.CbxSerialPort.FormattingEnabled = true;
            this.CbxSerialPort.Location = new System.Drawing.Point(42, 62);
            this.CbxSerialPort.Margin = new System.Windows.Forms.Padding(4);
            this.CbxSerialPort.Name = "CbxSerialPort";
            this.CbxSerialPort.Size = new System.Drawing.Size(140, 25);
            this.CbxSerialPort.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1005, 680);
            this.panel1.TabIndex = 1;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.DgvReadResult);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(167, 194);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(668, 344);
            this.panel6.TabIndex = 4;
            // 
            // DgvReadResult
            // 
            this.DgvReadResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DgvReadResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvReadResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvReadResult.Location = new System.Drawing.Point(0, 0);
            this.DgvReadResult.Margin = new System.Windows.Forms.Padding(4);
            this.DgvReadResult.Name = "DgvReadResult";
            this.DgvReadResult.RowTemplate.Height = 23;
            this.DgvReadResult.Size = new System.Drawing.Size(668, 344);
            this.DgvReadResult.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(835, 194);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(170, 344);
            this.panel5.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 194);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(167, 344);
            this.panel4.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.TxtLogger);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 538);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1005, 142);
            this.panel3.TabIndex = 1;
            // 
            // TxtLogger
            // 
            this.TxtLogger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtLogger.Location = new System.Drawing.Point(0, 0);
            this.TxtLogger.Name = "TxtLogger";
            this.TxtLogger.Size = new System.Drawing.Size(1005, 142);
            this.TxtLogger.TabIndex = 0;
            this.TxtLogger.Text = "";
            this.TxtLogger.TextChanged += new System.EventHandler(this.TxtLogger_TextChanged);
            // 
            // AutoReaderFlew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "AutoReaderFlew";
            this.Size = new System.Drawing.Size(1005, 680);
            this.Load += new System.EventHandler(this.AutoReaderForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvReadResult)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnConnection;
        private System.Windows.Forms.ComboBox CbxPortRate;
        private System.Windows.Forms.ComboBox CbxSerialPort;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DataGridView DgvReadResult;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RichTextBox TxtLogger;
        private System.Windows.Forms.Button BtnRefreshPort;
    }
}
