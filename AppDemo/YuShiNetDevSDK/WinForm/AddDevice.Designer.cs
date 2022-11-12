namespace YuShiNetDevSDK.WinForm
{
    partial class AddDevice
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
            this.OKBtn = new System.Windows.Forms.Button();
            this.CannelBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ipDomainNameText = new System.Windows.Forms.TextBox();
            this.portText = new System.Windows.Forms.TextBox();
            this.userNameText = new System.Windows.Forms.TextBox();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.DeviceTypeLab = new System.Windows.Forms.Label();
            this.DeviceTypeCmb = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // OKBtn
            // 
            this.OKBtn.Location = new System.Drawing.Point(184, 234);
            this.OKBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.OKBtn.Name = "OKBtn";
            this.OKBtn.Size = new System.Drawing.Size(60, 30);
            this.OKBtn.TabIndex = 4;
            this.OKBtn.Text = "OK";
            this.OKBtn.UseVisualStyleBackColor = true;
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // CannelBtn
            // 
            this.CannelBtn.Location = new System.Drawing.Point(332, 234);
            this.CannelBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CannelBtn.Name = "CannelBtn";
            this.CannelBtn.Size = new System.Drawing.Size(60, 30);
            this.CannelBtn.TabIndex = 5;
            this.CannelBtn.Text = "Cannel";
            this.CannelBtn.UseVisualStyleBackColor = true;
            this.CannelBtn.Click += new System.EventHandler(this.CannelBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP/Domain Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "User Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Password";
            // 
            // ipDomainNameText
            // 
            this.ipDomainNameText.Location = new System.Drawing.Point(184, 83);
            this.ipDomainNameText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ipDomainNameText.Name = "ipDomainNameText";
            this.ipDomainNameText.Size = new System.Drawing.Size(208, 22);
            this.ipDomainNameText.TabIndex = 0;
            // 
            // portText
            // 
            this.portText.Location = new System.Drawing.Point(184, 122);
            this.portText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.portText.Name = "portText";
            this.portText.Size = new System.Drawing.Size(208, 22);
            this.portText.TabIndex = 1;
            this.portText.Text = "80";
            // 
            // userNameText
            // 
            this.userNameText.Location = new System.Drawing.Point(184, 160);
            this.userNameText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userNameText.Name = "userNameText";
            this.userNameText.Size = new System.Drawing.Size(208, 22);
            this.userNameText.TabIndex = 2;
            // 
            // passwordText
            // 
            this.passwordText.Location = new System.Drawing.Point(184, 198);
            this.passwordText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.passwordText.MaxLength = 64;
            this.passwordText.Name = "passwordText";
            this.passwordText.PasswordChar = '*';
            this.passwordText.Size = new System.Drawing.Size(208, 22);
            this.passwordText.TabIndex = 3;
            // 
            // DeviceTypeLab
            // 
            this.DeviceTypeLab.AutoSize = true;
            this.DeviceTypeLab.Location = new System.Drawing.Point(68, 47);
            this.DeviceTypeLab.Name = "DeviceTypeLab";
            this.DeviceTypeLab.Size = new System.Drawing.Size(33, 16);
            this.DeviceTypeLab.TabIndex = 6;
            this.DeviceTypeLab.Text = "Type";
            // 
            // DeviceTypeCmb
            // 
            this.DeviceTypeCmb.FormattingEnabled = true;
            this.DeviceTypeCmb.Items.AddRange(new object[] {
            "IPC/NVR",
            "VMS"});
            this.DeviceTypeCmb.Location = new System.Drawing.Point(184, 43);
            this.DeviceTypeCmb.Name = "DeviceTypeCmb";
            this.DeviceTypeCmb.Size = new System.Drawing.Size(208, 24);
            this.DeviceTypeCmb.TabIndex = 7;
            this.DeviceTypeCmb.Text = "IPC/NVR";
            // 
            // AddDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 288);
            this.Controls.Add(this.DeviceTypeCmb);
            this.Controls.Add(this.DeviceTypeLab);
            this.Controls.Add(this.passwordText);
            this.Controls.Add(this.userNameText);
            this.Controls.Add(this.portText);
            this.Controls.Add(this.ipDomainNameText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CannelBtn);
            this.Controls.Add(this.OKBtn);
            this.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "AddDevice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add Device";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKBtn;
        private System.Windows.Forms.Button CannelBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ipDomainNameText;
        private System.Windows.Forms.TextBox portText;
        private System.Windows.Forms.TextBox userNameText;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.Label DeviceTypeLab;
        private System.Windows.Forms.ComboBox DeviceTypeCmb;
    }
}