namespace YuShiNetDevSDK.WinForm
{
    partial class Discovery
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
            this.segmentSearchBtn = new System.Windows.Forms.Button();
            this.DeviceInfoListView = new System.Windows.Forms.ListView();
            this.Type = new System.Windows.Forms.ColumnHeader();
            this.IP = new System.Windows.Forms.ColumnHeader();
            this.Port = new System.Windows.Forms.ColumnHeader();
            this.MAC = new System.Windows.Forms.ColumnHeader();
            this.SerialNum = new System.Windows.Forms.ColumnHeader();
            this.Manufacturer = new System.Windows.Forms.ColumnHeader();
            this.Device_Number = new System.Windows.Forms.Label();
            this.deviceNumberLabel = new System.Windows.Forms.Label();
            this.Auto_Search = new System.Windows.Forms.Label();
            this.AutoSearchBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.endIPText = new System.Windows.Forms.TextBox();
            this.startIPext = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.passwordText = new System.Windows.Forms.TextBox();
            this.userNameText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.addDeviceBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // segmentSearchBtn
            // 
            this.segmentSearchBtn.Location = new System.Drawing.Point(200, 117);
            this.segmentSearchBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.segmentSearchBtn.Name = "segmentSearchBtn";
            this.segmentSearchBtn.Size = new System.Drawing.Size(80, 30);
            this.segmentSearchBtn.TabIndex = 0;
            this.segmentSearchBtn.Text = "Search";
            this.segmentSearchBtn.UseVisualStyleBackColor = true;
            this.segmentSearchBtn.Click += new System.EventHandler(this.segmentSearchBtn_Click);
            // 
            // DeviceInfoListView
            // 
            this.DeviceInfoListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Type,
            this.IP,
            this.Port,
            this.MAC,
            this.SerialNum,
            this.Manufacturer});
            this.DeviceInfoListView.FullRowSelect = true;
            this.DeviceInfoListView.GridLines = true;
            this.DeviceInfoListView.HideSelection = false;
            this.DeviceInfoListView.Location = new System.Drawing.Point(3, 16);
            this.DeviceInfoListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DeviceInfoListView.Name = "DeviceInfoListView";
            this.DeviceInfoListView.Size = new System.Drawing.Size(613, 485);
            this.DeviceInfoListView.TabIndex = 2;
            this.DeviceInfoListView.UseCompatibleStateImageBehavior = false;
            this.DeviceInfoListView.View = System.Windows.Forms.View.Details;
            this.DeviceInfoListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.DeviceInfoListView_ItemSelectionChanged);
            // 
            // Type
            // 
            this.Type.Text = "Type";
            this.Type.Width = 82;
            // 
            // IP
            // 
            this.IP.Text = "IP";
            this.IP.Width = 110;
            // 
            // Port
            // 
            this.Port.Text = "Port";
            this.Port.Width = 51;
            // 
            // MAC
            // 
            this.MAC.Text = "MAC";
            this.MAC.Width = 120;
            // 
            // SerialNum
            // 
            this.SerialNum.Text = "SerialNum";
            this.SerialNum.Width = 120;
            // 
            // Manufacturer
            // 
            this.Manufacturer.Text = "Manufacturer";
            this.Manufacturer.Width = 120;
            // 
            // Device_Number
            // 
            this.Device_Number.AutoSize = true;
            this.Device_Number.Location = new System.Drawing.Point(626, 36);
            this.Device_Number.Name = "Device_Number";
            this.Device_Number.Size = new System.Drawing.Size(89, 16);
            this.Device_Number.TabIndex = 3;
            this.Device_Number.Text = "Device Number";
            // 
            // deviceNumberLabel
            // 
            this.deviceNumberLabel.AutoSize = true;
            this.deviceNumberLabel.Location = new System.Drawing.Point(855, 36);
            this.deviceNumberLabel.Name = "deviceNumberLabel";
            this.deviceNumberLabel.Size = new System.Drawing.Size(14, 16);
            this.deviceNumberLabel.TabIndex = 4;
            this.deviceNumberLabel.Text = "0";
            // 
            // Auto_Search
            // 
            this.Auto_Search.AutoSize = true;
            this.Auto_Search.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Auto_Search.Location = new System.Drawing.Point(626, 70);
            this.Auto_Search.Name = "Auto_Search";
            this.Auto_Search.Size = new System.Drawing.Size(72, 16);
            this.Auto_Search.TabIndex = 5;
            this.Auto_Search.Text = "Auto Search";
            // 
            // AutoSearchBtn
            // 
            this.AutoSearchBtn.Location = new System.Drawing.Point(826, 64);
            this.AutoSearchBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AutoSearchBtn.Name = "AutoSearchBtn";
            this.AutoSearchBtn.Size = new System.Drawing.Size(80, 30);
            this.AutoSearchBtn.TabIndex = 6;
            this.AutoSearchBtn.Text = "Search";
            this.AutoSearchBtn.UseVisualStyleBackColor = true;
            this.AutoSearchBtn.Click += new System.EventHandler(this.AutoSearchBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.endIPText);
            this.groupBox1.Controls.Add(this.startIPext);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.segmentSearchBtn);
            this.groupBox1.Location = new System.Drawing.Point(628, 116);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(321, 172);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Segment";
            // 
            // endIPText
            // 
            this.endIPText.Location = new System.Drawing.Point(92, 81);
            this.endIPText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.endIPText.Name = "endIPText";
            this.endIPText.Size = new System.Drawing.Size(188, 22);
            this.endIPText.TabIndex = 3;
            // 
            // startIPext
            // 
            this.startIPext.Location = new System.Drawing.Point(92, 37);
            this.startIPext.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.startIPext.Name = "startIPext";
            this.startIPext.Size = new System.Drawing.Size(188, 22);
            this.startIPext.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "End IP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start IP";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(626, 481);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(337, 28);
            this.label3.TabIndex = 9;
            this.label3.Text = "Note : Please select device(s) and add to list.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.passwordText);
            this.groupBox2.Controls.Add(this.userNameText);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.addDeviceBtn);
            this.groupBox2.Location = new System.Drawing.Point(628, 302);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(321, 167);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add Device";
            // 
            // passwordText
            // 
            this.passwordText.Location = new System.Drawing.Point(90, 73);
            this.passwordText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.passwordText.MaxLength = 64;
            this.passwordText.Name = "passwordText";
            this.passwordText.PasswordChar = '*';
            this.passwordText.Size = new System.Drawing.Size(191, 22);
            this.passwordText.TabIndex = 2;
            // 
            // userNameText
            // 
            this.userNameText.Location = new System.Drawing.Point(90, 37);
            this.userNameText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userNameText.Name = "userNameText";
            this.userNameText.Size = new System.Drawing.Size(191, 22);
            this.userNameText.TabIndex = 2;
            this.userNameText.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "User Name";
            // 
            // addDeviceBtn
            // 
            this.addDeviceBtn.Location = new System.Drawing.Point(200, 128);
            this.addDeviceBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.addDeviceBtn.Name = "addDeviceBtn";
            this.addDeviceBtn.Size = new System.Drawing.Size(80, 30);
            this.addDeviceBtn.TabIndex = 0;
            this.addDeviceBtn.Text = "Add";
            this.addDeviceBtn.UseVisualStyleBackColor = true;
            this.addDeviceBtn.Click += new System.EventHandler(this.addDeviceBtn_Click);
            // 
            // Discovery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 505);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.AutoSearchBtn);
            this.Controls.Add(this.Auto_Search);
            this.Controls.Add(this.deviceNumberLabel);
            this.Controls.Add(this.Device_Number);
            this.Controls.Add(this.DeviceInfoListView);
            this.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Discovery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Discovery";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button segmentSearchBtn;
        private System.Windows.Forms.ListView DeviceInfoListView;
        private System.Windows.Forms.ColumnHeader Type;
        private System.Windows.Forms.ColumnHeader IP;
        private System.Windows.Forms.ColumnHeader Port;
        private System.Windows.Forms.ColumnHeader MAC;
        private System.Windows.Forms.ColumnHeader SerialNum;
        private System.Windows.Forms.ColumnHeader Manufacturer;
        private System.Windows.Forms.Label Device_Number;
        private System.Windows.Forms.Label deviceNumberLabel;
        private System.Windows.Forms.Label Auto_Search;
        private System.Windows.Forms.Button AutoSearchBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox endIPText;
        private System.Windows.Forms.TextBox startIPext;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox passwordText;
        private System.Windows.Forms.TextBox userNameText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button addDeviceBtn;
    }
}