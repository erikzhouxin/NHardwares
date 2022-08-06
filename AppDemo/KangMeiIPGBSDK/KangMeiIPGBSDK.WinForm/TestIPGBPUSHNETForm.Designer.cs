namespace TestIPGBNETPush
{
    partial class TestIPGBPUSHNETForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtChannelId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEncType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBuf = new System.Windows.Forms.TextBox();
            this.buttonSound = new System.Windows.Forms.Button();
            this.buttonThrid = new System.Windows.Forms.Button();
            this.buttonFile = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "服务IP";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(77, 26);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(117, 21);
            this.txtIP.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(242, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "通道ID";
            // 
            // txtChannelId
            // 
            this.txtChannelId.Location = new System.Drawing.Point(302, 26);
            this.txtChannelId.Name = "txtChannelId";
            this.txtChannelId.Size = new System.Drawing.Size(117, 21);
            this.txtChannelId.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(465, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "编码类型";
            // 
            // txtEncType
            // 
            this.txtEncType.Location = new System.Drawing.Point(524, 26);
            this.txtEncType.Name = "txtEncType";
            this.txtEncType.Size = new System.Drawing.Size(117, 21);
            this.txtEncType.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "服务端口";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(77, 83);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(117, 21);
            this.txtPort.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(242, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "加密内容";
            // 
            // txtBuf
            // 
            this.txtBuf.Location = new System.Drawing.Point(302, 83);
            this.txtBuf.Name = "txtBuf";
            this.txtBuf.Size = new System.Drawing.Size(117, 21);
            this.txtBuf.TabIndex = 9;
            // 
            // buttonSound
            // 
            this.buttonSound.Location = new System.Drawing.Point(23, 146);
            this.buttonSound.Name = "buttonSound";
            this.buttonSound.Size = new System.Drawing.Size(100, 32);
            this.buttonSound.TabIndex = 10;
            this.buttonSound.Text = "声卡推流";
            this.buttonSound.UseVisualStyleBackColor = true;
            this.buttonSound.Click += new System.EventHandler(this.buttonSound_Click);
            // 
            // buttonThrid
            // 
            this.buttonThrid.Location = new System.Drawing.Point(174, 146);
            this.buttonThrid.Name = "buttonThrid";
            this.buttonThrid.Size = new System.Drawing.Size(121, 32);
            this.buttonThrid.TabIndex = 11;
            this.buttonThrid.Text = "第三方实时推流";
            this.buttonThrid.UseVisualStyleBackColor = true;
            this.buttonThrid.Click += new System.EventHandler(this.buttonThrid_Click);
            // 
            // buttonFile
            // 
            this.buttonFile.Location = new System.Drawing.Point(342, 146);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(92, 32);
            this.buttonFile.TabIndex = 12;
            this.buttonFile.Text = "文件实时推流";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Click += new System.EventHandler(this.buttonFile_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(477, 146);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(91, 32);
            this.buttonStop.TabIndex = 13;
            this.buttonStop.Text = "停止推流";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // txtArea
            // 
            this.txtArea.Location = new System.Drawing.Point(23, 216);
            this.txtArea.Multiline = true;
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(545, 172);
            this.txtArea.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 192);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "业务日志";
            // 
            // TestIPGBPUSHNETForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 436);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtArea);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonFile);
            this.Controls.Add(this.buttonThrid);
            this.Controls.Add(this.buttonSound);
            this.Controls.Add(this.txtBuf);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEncType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtChannelId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.Name = "TestIPGBPUSHNETForm";
            this.Text = "IP推流客户端测试程序";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TestIPGBPUSHNETForm_FormClosed);
            this.Load += new System.EventHandler(this.TestIPGBPUSHNETForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtChannelId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEncType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBuf;
        private System.Windows.Forms.Button buttonSound;
        private System.Windows.Forms.Button buttonThrid;
        private System.Windows.Forms.Button buttonFile;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Label label6;
    }
}

