namespace Txq_csharp_sdk
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLightOn = new System.Windows.Forms.Button();
            this.btnLightOff = new System.Windows.Forms.Button();
            this.btnOpenDevice = new System.Windows.Forms.Button();
            this.btnQuit = new System.Windows.Forms.Button();
            this.version_lable = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.timerBarScan = new System.Windows.Forms.Timer(this.components);
            this.richTextBoxResult = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "解码结果:";
            // 
            // btnLightOn
            // 
            this.btnLightOn.Location = new System.Drawing.Point(178, 207);
            this.btnLightOn.Name = "btnLightOn";
            this.btnLightOn.Size = new System.Drawing.Size(75, 41);
            this.btnLightOn.TabIndex = 5;
            this.btnLightOn.Text = "开灯";
            this.btnLightOn.UseVisualStyleBackColor = true;
            this.btnLightOn.Click += new System.EventHandler(this.btnLightOn_Click);
            // 
            // btnLightOff
            // 
            this.btnLightOff.Location = new System.Drawing.Point(178, 258);
            this.btnLightOff.Name = "btnLightOff";
            this.btnLightOff.Size = new System.Drawing.Size(75, 41);
            this.btnLightOff.TabIndex = 6;
            this.btnLightOff.Text = "关灯";
            this.btnLightOff.UseVisualStyleBackColor = true;
            this.btnLightOff.Click += new System.EventHandler(this.btnLightOff_Click);
            // 
            // btnOpenDevice
            // 
            this.btnOpenDevice.Location = new System.Drawing.Point(68, 258);
            this.btnOpenDevice.Name = "btnOpenDevice";
            this.btnOpenDevice.Size = new System.Drawing.Size(75, 41);
            this.btnOpenDevice.TabIndex = 10;
            this.btnOpenDevice.Text = "打开接收通道";
            this.btnOpenDevice.UseVisualStyleBackColor = true;
            this.btnOpenDevice.Click += new System.EventHandler(this.btnOpenDevice_Click);
            // 
            // btnQuit
            // 
            this.btnQuit.Location = new System.Drawing.Point(281, 258);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 41);
            this.btnQuit.TabIndex = 12;
            this.btnQuit.Text = "退出程序";
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // version_lable
            // 
            this.version_lable.AutoSize = true;
            this.version_lable.Location = new System.Drawing.Point(409, 224);
            this.version_lable.Name = "version_lable";
            this.version_lable.Size = new System.Drawing.Size(0, 12);
            this.version_lable.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(68, 207);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 38);
            this.button1.TabIndex = 16;
            this.button1.Text = "清除";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // richTextBoxResult
            // 
            this.richTextBoxResult.Location = new System.Drawing.Point(83, 5);
            this.richTextBoxResult.Name = "richTextBoxResult";
            this.richTextBoxResult.Size = new System.Drawing.Size(352, 184);
            this.richTextBoxResult.TabIndex = 18;
            this.richTextBoxResult.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(281, 207);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 38);
            this.button2.TabIndex = 19;
            this.button2.Text = "关闭接收通道";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(379, 207);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 38);
            this.button3.TabIndex = 20;
            this.button3.Text = "打开扫码";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(379, 258);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 41);
            this.button4.TabIndex = 21;
            this.button4.Text = "关闭扫码";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 309);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.richTextBoxResult);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.version_lable);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnOpenDevice);
            this.Controls.Add(this.btnLightOff);
            this.Controls.Add(this.btnLightOn);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "c#usb_微光通信协议demov2.0.1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLightOn;
        private System.Windows.Forms.Button btnLightOff;
        private System.Windows.Forms.Button btnOpenDevice;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.Label version_lable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timerBarScan;
        private System.Windows.Forms.RichTextBox richTextBoxResult;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}

