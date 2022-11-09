namespace VzClientSDKDemo
{
    partial class SerialControl_Form
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPort = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtRecv = new System.Windows.Forms.TextBox();
            this.chkBoxHex = new System.Windows.Forms.CheckBox();
            this.btnClean = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.chkSendHex = new System.Windows.Forms.CheckBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口号";
            // 
            // cmbPort
            // 
            this.cmbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPort.FormattingEnabled = true;
            this.cmbPort.Items.AddRange(new object[] {
            "485-1",
            "485-2"});
            this.cmbPort.Location = new System.Drawing.Point(80, 31);
            this.cmbPort.Name = "cmbPort";
            this.cmbPort.Size = new System.Drawing.Size(100, 20);
            this.cmbPort.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(203, 29);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(60, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(280, 29);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(60, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtRecv
            // 
            this.txtRecv.Enabled = false;
            this.txtRecv.Location = new System.Drawing.Point(26, 70);
            this.txtRecv.Multiline = true;
            this.txtRecv.Name = "txtRecv";
            this.txtRecv.Size = new System.Drawing.Size(400, 120);
            this.txtRecv.TabIndex = 4;
            // 
            // chkBoxHex
            // 
            this.chkBoxHex.AutoSize = true;
            this.chkBoxHex.Location = new System.Drawing.Point(28, 205);
            this.chkBoxHex.Name = "chkBoxHex";
            this.chkBoxHex.Size = new System.Drawing.Size(96, 16);
            this.chkBoxHex.TabIndex = 5;
            this.chkBoxHex.Text = "十六进制显示";
            this.chkBoxHex.UseVisualStyleBackColor = true;
            this.chkBoxHex.Click += new System.EventHandler(this.chkBoxHex_Click);
            // 
            // btnClean
            // 
            this.btnClean.Location = new System.Drawing.Point(366, 201);
            this.btnClean.Name = "btnClean";
            this.btnClean.Size = new System.Drawing.Size(60, 23);
            this.btnClean.TabIndex = 6;
            this.btnClean.Text = "清除";
            this.btnClean.UseVisualStyleBackColor = true;
            this.btnClean.Click += new System.EventHandler(this.btnClean_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(28, 266);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(400, 120);
            this.txtSend.TabIndex = 7;
            // 
            // chkSendHex
            // 
            this.chkSendHex.AutoSize = true;
            this.chkSendHex.Location = new System.Drawing.Point(28, 402);
            this.chkSendHex.Name = "chkSendHex";
            this.chkSendHex.Size = new System.Drawing.Size(162, 16);
            this.chkSendHex.TabIndex = 8;
            this.chkSendHex.Text = "十六进制发送(01 FE ...)";
            this.chkSendHex.UseVisualStyleBackColor = true;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(366, 398);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(60, 23);
            this.btnSend.TabIndex = 9;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // SerialControl_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(460, 435);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.chkSendHex);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.btnClean);
            this.Controls.Add(this.chkBoxHex);
            this.Controls.Add(this.txtRecv);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cmbPort);
            this.Controls.Add(this.label1);
            this.Name = "SerialControl_Form";
            this.Text = "串口测试";
            this.Load += new System.EventHandler(this.SerialControl_Form_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SerialControl_Form_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPort;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtRecv;
        private System.Windows.Forms.CheckBox chkBoxHex;
        private System.Windows.Forms.Button btnClean;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.CheckBox chkSendHex;
        private System.Windows.Forms.Button btnSend;
    }
}