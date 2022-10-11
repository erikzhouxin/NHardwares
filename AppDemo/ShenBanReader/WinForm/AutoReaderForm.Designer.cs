namespace System.Data.ShenBanReader.WinForm
{
    partial class AutoReaderForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.DgvReadResult = new System.Windows.Forms.DataGridView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TxtLogArea = new System.Data.ShenBanReader.WinForm.LogRichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnConnection = new System.Windows.Forms.Button();
            this.CbxPortRate = new System.Windows.Forms.ComboBox();
            this.CbxSerialPort = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvReadResult)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(915, 795);
            this.panel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.DgvReadResult);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(167, 194);
            this.panel6.Margin = new System.Windows.Forms.Padding(4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(578, 459);
            this.panel6.TabIndex = 4;
            // 
            // DgvReadResult
            // 
            this.DgvReadResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvReadResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvReadResult.Location = new System.Drawing.Point(0, 0);
            this.DgvReadResult.Margin = new System.Windows.Forms.Padding(4);
            this.DgvReadResult.Name = "DgvReadResult";
            this.DgvReadResult.RowTemplate.Height = 23;
            this.DgvReadResult.Size = new System.Drawing.Size(578, 459);
            this.DgvReadResult.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel5.Location = new System.Drawing.Point(745, 194);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(170, 459);
            this.panel5.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 194);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(167, 459);
            this.panel4.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.TxtLogArea);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 653);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(915, 142);
            this.panel3.TabIndex = 1;
            // 
            // TxtLogArea
            // 
            this.TxtLogArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TxtLogArea.Location = new System.Drawing.Point(0, 0);
            this.TxtLogArea.Margin = new System.Windows.Forms.Padding(4);
            this.TxtLogArea.Name = "TxtLogArea";
            this.TxtLogArea.Size = new System.Drawing.Size(915, 142);
            this.TxtLogArea.TabIndex = 0;
            this.TxtLogArea.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnConnection);
            this.panel2.Controls.Add(this.CbxPortRate);
            this.panel2.Controls.Add(this.CbxSerialPort);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(915, 194);
            this.panel2.TabIndex = 0;
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
            this.CbxSerialPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9"});
            this.CbxSerialPort.Location = new System.Drawing.Point(42, 62);
            this.CbxSerialPort.Margin = new System.Windows.Forms.Padding(4);
            this.CbxSerialPort.Name = "CbxSerialPort";
            this.CbxSerialPort.Size = new System.Drawing.Size(140, 25);
            this.CbxSerialPort.TabIndex = 0;
            this.CbxSerialPort.Text = "COM1";
            // 
            // AutoReaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 795);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(931, 726);
            this.Name = "AutoReaderForm";
            this.Text = "AutoReader";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AutoReaderForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvReadResult)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Windows.Forms.Panel panel1;
        private Windows.Forms.Panel panel6;
        private Windows.Forms.Panel panel5;
        private Windows.Forms.Panel panel4;
        private Windows.Forms.Panel panel3;
        private Windows.Forms.Panel panel2;
        private Windows.Forms.DataGridView DgvReadResult;
        private Windows.Forms.ComboBox CbxSerialPort;
        private Windows.Forms.ComboBox CbxPortRate;
        private Windows.Forms.Button BtnConnection;
        private LogRichTextBox TxtLogArea;
    }
}