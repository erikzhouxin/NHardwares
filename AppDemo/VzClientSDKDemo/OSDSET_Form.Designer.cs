namespace VzClientSDKDemo
{
    partial class OSDSET_Form
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
            this.daystylecheck = new System.Windows.Forms.CheckBox();
            this.timestylecheck = new System.Windows.Forms.CheckBox();
            this.textcheck = new System.Windows.Forms.CheckBox();
            this.timesetcheck = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.daycombobox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.daypointx = new System.Windows.Forms.TextBox();
            this.daypointy = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.timepointy = new System.Windows.Forms.TextBox();
            this.timepointx = new System.Windows.Forms.TextBox();
            this.timecombobox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textpointx = new System.Windows.Forms.TextBox();
            this.textpointy = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.dayupdate = new System.Windows.Forms.DateTimePicker();
            this.timeupdate = new System.Windows.Forms.DateTimePicker();
            this.savebtn = new System.Windows.Forms.Button();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.textedit = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // daystylecheck
            // 
            this.daystylecheck.AutoSize = true;
            this.daystylecheck.Location = new System.Drawing.Point(33, 25);
            this.daystylecheck.Name = "daystylecheck";
            this.daystylecheck.Size = new System.Drawing.Size(48, 16);
            this.daystylecheck.TabIndex = 0;
            this.daystylecheck.Text = "日期";
            this.daystylecheck.UseVisualStyleBackColor = true;
            // 
            // timestylecheck
            // 
            this.timestylecheck.AutoSize = true;
            this.timestylecheck.Location = new System.Drawing.Point(33, 99);
            this.timestylecheck.Name = "timestylecheck";
            this.timestylecheck.Size = new System.Drawing.Size(48, 16);
            this.timestylecheck.TabIndex = 1;
            this.timestylecheck.Text = "时间";
            this.timestylecheck.UseVisualStyleBackColor = true;
            // 
            // textcheck
            // 
            this.textcheck.AutoSize = true;
            this.textcheck.Location = new System.Drawing.Point(33, 172);
            this.textcheck.Name = "textcheck";
            this.textcheck.Size = new System.Drawing.Size(48, 16);
            this.textcheck.TabIndex = 2;
            this.textcheck.Text = "文字";
            this.textcheck.UseVisualStyleBackColor = true;
            // 
            // timesetcheck
            // 
            this.timesetcheck.AutoSize = true;
            this.timesetcheck.Location = new System.Drawing.Point(33, 244);
            this.timesetcheck.Name = "timesetcheck";
            this.timesetcheck.Size = new System.Drawing.Size(96, 16);
            this.timesetcheck.TabIndex = 3;
            this.timesetcheck.Text = "是否更新时间";
            this.timesetcheck.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "日期格式：";
            // 
            // daycombobox
            // 
            this.daycombobox.FormattingEnabled = true;
            this.daycombobox.Items.AddRange(new object[] {
            "YYYY/MM/DD",
            "MM/DD/YYYY",
            "DD/MM//YYYY"});
            this.daycombobox.Location = new System.Drawing.Point(174, 23);
            this.daycombobox.Name = "daycombobox";
            this.daycombobox.Size = new System.Drawing.Size(146, 20);
            this.daycombobox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "坐标：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(174, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "X:";
            // 
            // daypointx
            // 
            this.daypointx.Location = new System.Drawing.Point(193, 52);
            this.daypointx.Name = "daypointx";
            this.daypointx.Size = new System.Drawing.Size(34, 21);
            this.daypointx.TabIndex = 8;
            // 
            // daypointy
            // 
            this.daypointy.Location = new System.Drawing.Point(275, 52);
            this.daypointy.Name = "daypointy";
            this.daypointy.Size = new System.Drawing.Size(34, 21);
            this.daypointy.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "Y:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(100, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "时间格式：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(100, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "坐标：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(174, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(17, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "X:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(251, 132);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(17, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "Y:";
            // 
            // timepointy
            // 
            this.timepointy.Location = new System.Drawing.Point(275, 128);
            this.timepointy.Name = "timepointy";
            this.timepointy.Size = new System.Drawing.Size(34, 21);
            this.timepointy.TabIndex = 15;
            // 
            // timepointx
            // 
            this.timepointx.Location = new System.Drawing.Point(193, 127);
            this.timepointx.Name = "timepointx";
            this.timepointx.Size = new System.Drawing.Size(34, 21);
            this.timepointx.TabIndex = 16;
            // 
            // timecombobox
            // 
            this.timecombobox.FormattingEnabled = true;
            this.timecombobox.Items.AddRange(new object[] {
            "12Hrs",
            "24Hrs"});
            this.timecombobox.Location = new System.Drawing.Point(176, 96);
            this.timecombobox.Name = "timecombobox";
            this.timecombobox.Size = new System.Drawing.Size(144, 20);
            this.timecombobox.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(102, 174);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "内容：";
            // 
            // textpointx
            // 
            this.textpointx.Location = new System.Drawing.Point(193, 203);
            this.textpointx.Name = "textpointx";
            this.textpointx.Size = new System.Drawing.Size(34, 21);
            this.textpointx.TabIndex = 24;
            // 
            // textpointy
            // 
            this.textpointy.Location = new System.Drawing.Point(275, 203);
            this.textpointy.Name = "textpointy";
            this.textpointy.Size = new System.Drawing.Size(34, 21);
            this.textpointy.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(248, 208);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "Y:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(173, 208);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(17, 12);
            this.label11.TabIndex = 21;
            this.label11.Text = "X:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(102, 207);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 20;
            this.label12.Text = "坐标：";
            // 
            // dayupdate
            // 
            this.dayupdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dayupdate.Location = new System.Drawing.Point(81, 275);
            this.dayupdate.Name = "dayupdate";
            this.dayupdate.Size = new System.Drawing.Size(109, 21);
            this.dayupdate.TabIndex = 25;
            // 
            // timeupdate
            // 
            this.timeupdate.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeupdate.Location = new System.Drawing.Point(197, 275);
            this.timeupdate.Name = "timeupdate";
            this.timeupdate.ShowUpDown = true;
            this.timeupdate.Size = new System.Drawing.Size(100, 21);
            this.timeupdate.TabIndex = 26;
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(95, 320);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(75, 23);
            this.savebtn.TabIndex = 27;
            this.savebtn.Text = "保存";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // cancelbtn
            // 
            this.cancelbtn.Location = new System.Drawing.Point(199, 320);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(75, 23);
            this.cancelbtn.TabIndex = 28;
            this.cancelbtn.Text = "取消";
            this.cancelbtn.UseVisualStyleBackColor = true;
            this.cancelbtn.Click += new System.EventHandler(this.cancelbtn_Click);
            // 
            // textedit
            // 
            this.textedit.Location = new System.Drawing.Point(174, 169);
            this.textedit.Name = "textedit";
            this.textedit.Size = new System.Drawing.Size(146, 21);
            this.textedit.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(233, 57);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 12);
            this.label13.TabIndex = 30;
            this.label13.Text = "%";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(312, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(11, 12);
            this.label14.TabIndex = 31;
            this.label14.Text = "%";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(233, 132);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 12);
            this.label15.TabIndex = 32;
            this.label15.Text = "%";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(312, 132);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(11, 12);
            this.label16.TabIndex = 33;
            this.label16.Text = "%";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(233, 207);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(11, 12);
            this.label17.TabIndex = 34;
            this.label17.Text = "%";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(312, 208);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(11, 12);
            this.label18.TabIndex = 35;
            this.label18.Text = "%";
            // 
            // OSDSET_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(347, 363);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textedit);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.timeupdate);
            this.Controls.Add(this.dayupdate);
            this.Controls.Add(this.textpointx);
            this.Controls.Add(this.textpointy);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.timecombobox);
            this.Controls.Add(this.timepointx);
            this.Controls.Add(this.timepointy);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.daypointy);
            this.Controls.Add(this.daypointx);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.daycombobox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timesetcheck);
            this.Controls.Add(this.textcheck);
            this.Controls.Add(this.timestylecheck);
            this.Controls.Add(this.daystylecheck);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "OSDSET_Form";
            this.Text = "OSD配置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox daystylecheck;
        private System.Windows.Forms.CheckBox timestylecheck;
        private System.Windows.Forms.CheckBox textcheck;
        private System.Windows.Forms.CheckBox timesetcheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox daycombobox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox daypointx;
        private System.Windows.Forms.TextBox daypointy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox timepointy;
        private System.Windows.Forms.TextBox timepointx;
        private System.Windows.Forms.ComboBox timecombobox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textpointx;
        private System.Windows.Forms.TextBox textpointy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dayupdate;
        private System.Windows.Forms.DateTimePicker timeupdate;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button cancelbtn;
        private System.Windows.Forms.TextBox textedit;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
    }
}