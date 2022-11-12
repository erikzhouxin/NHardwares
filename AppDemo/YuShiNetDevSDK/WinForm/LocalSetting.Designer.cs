namespace YuShiNetDevSDK.WinForm
{
    partial class LocalSetting
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.logFilePathText = new System.Windows.Forms.TextBox();
            this.snapshotFilePathText = new System.Windows.Forms.TextBox();
            this.LocalRecordPathText = new System.Windows.Forms.TextBox();
            this.SavePathSettingBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.saveKeepLiveSttingBtn = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.waitTimeText = new System.Windows.Forms.TextBox();
            this.tryTimesText = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.saveTimeOutSettingBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.fileTimeOutText = new System.Windows.Forms.TextBox();
            this.receiveTimeOutText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.SuccessLogCkBox = new System.Windows.Forms.CheckBox();
            this.failureLogCkBox = new System.Windows.Forms.CheckBox();
            this.AutoSaveCkBox = new System.Windows.Forms.CheckBox();
            this.saveOperLogSettingBtn = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.logFilePathText);
            this.groupBox1.Controls.Add(this.snapshotFilePathText);
            this.groupBox1.Controls.Add(this.LocalRecordPathText);
            this.groupBox1.Controls.Add(this.SavePathSettingBtn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(14, 16);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(572, 165);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Path Setting";
            // 
            // logFilePathText
            // 
            this.logFilePathText.Location = new System.Drawing.Point(197, 25);
            this.logFilePathText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.logFilePathText.Name = "logFilePathText";
            this.logFilePathText.Size = new System.Drawing.Size(360, 22);
            this.logFilePathText.TabIndex = 2;
            // 
            // snapshotFilePathText
            // 
            this.snapshotFilePathText.Location = new System.Drawing.Point(197, 59);
            this.snapshotFilePathText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.snapshotFilePathText.Name = "snapshotFilePathText";
            this.snapshotFilePathText.Size = new System.Drawing.Size(360, 22);
            this.snapshotFilePathText.TabIndex = 2;
            // 
            // LocalRecordPathText
            // 
            this.LocalRecordPathText.Location = new System.Drawing.Point(200, 94);
            this.LocalRecordPathText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LocalRecordPathText.Name = "LocalRecordPathText";
            this.LocalRecordPathText.Size = new System.Drawing.Size(357, 22);
            this.LocalRecordPathText.TabIndex = 2;
            // 
            // SavePathSettingBtn
            // 
            this.SavePathSettingBtn.Location = new System.Drawing.Point(497, 124);
            this.SavePathSettingBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SavePathSettingBtn.Name = "SavePathSettingBtn";
            this.SavePathSettingBtn.Size = new System.Drawing.Size(60, 30);
            this.SavePathSettingBtn.TabIndex = 1;
            this.SavePathSettingBtn.Text = "Save";
            this.SavePathSettingBtn.UseVisualStyleBackColor = true;
            this.SavePathSettingBtn.Click += new System.EventHandler(this.SavePathSettingBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Local Record Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Snapshot File Path";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Log File Path";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.saveKeepLiveSttingBtn);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.waitTimeText);
            this.groupBox2.Controls.Add(this.tryTimesText);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(14, 188);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(572, 97);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Keep Live";
            // 
            // saveKeepLiveSttingBtn
            // 
            this.saveKeepLiveSttingBtn.Location = new System.Drawing.Point(497, 56);
            this.saveKeepLiveSttingBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveKeepLiveSttingBtn.Name = "saveKeepLiveSttingBtn";
            this.saveKeepLiveSttingBtn.Size = new System.Drawing.Size(60, 30);
            this.saveKeepLiveSttingBtn.TabIndex = 1;
            this.saveKeepLiveSttingBtn.Text = "Save";
            this.saveKeepLiveSttingBtn.UseVisualStyleBackColor = true;
            this.saveKeepLiveSttingBtn.Click += new System.EventHandler(this.saveKeepLiveSttingBtn_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Try Times";
            // 
            // waitTimeText
            // 
            this.waitTimeText.Location = new System.Drawing.Point(197, 28);
            this.waitTimeText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.waitTimeText.Name = "waitTimeText";
            this.waitTimeText.Size = new System.Drawing.Size(156, 22);
            this.waitTimeText.TabIndex = 2;
            this.waitTimeText.Text = "15";
            // 
            // tryTimesText
            // 
            this.tryTimesText.Location = new System.Drawing.Point(197, 65);
            this.tryTimesText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tryTimesText.Name = "tryTimesText";
            this.tryTimesText.Size = new System.Drawing.Size(156, 22);
            this.tryTimesText.TabIndex = 2;
            this.tryTimesText.Text = "3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Wait Time(s)";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.saveTimeOutSettingBtn);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.fileTimeOutText);
            this.groupBox3.Controls.Add(this.receiveTimeOutText);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(14, 292);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Size = new System.Drawing.Size(572, 93);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "TimeOut";
            // 
            // saveTimeOutSettingBtn
            // 
            this.saveTimeOutSettingBtn.Location = new System.Drawing.Point(497, 51);
            this.saveTimeOutSettingBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveTimeOutSettingBtn.Name = "saveTimeOutSettingBtn";
            this.saveTimeOutSettingBtn.Size = new System.Drawing.Size(60, 30);
            this.saveTimeOutSettingBtn.TabIndex = 1;
            this.saveTimeOutSettingBtn.Text = "Save";
            this.saveTimeOutSettingBtn.UseVisualStyleBackColor = true;
            this.saveTimeOutSettingBtn.Click += new System.EventHandler(this.saveTimeOutSettingBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "File TimeOut(s)";
            // 
            // fileTimeOutText
            // 
            this.fileTimeOutText.Location = new System.Drawing.Point(197, 60);
            this.fileTimeOutText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.fileTimeOutText.Name = "fileTimeOutText";
            this.fileTimeOutText.Size = new System.Drawing.Size(156, 22);
            this.fileTimeOutText.TabIndex = 2;
            this.fileTimeOutText.Text = "60";
            // 
            // receiveTimeOutText
            // 
            this.receiveTimeOutText.Location = new System.Drawing.Point(197, 25);
            this.receiveTimeOutText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.receiveTimeOutText.Name = "receiveTimeOutText";
            this.receiveTimeOutText.Size = new System.Drawing.Size(156, 22);
            this.receiveTimeOutText.TabIndex = 2;
            this.receiveTimeOutText.Text = "5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Receive TimeOut(s)";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.SuccessLogCkBox);
            this.groupBox4.Controls.Add(this.failureLogCkBox);
            this.groupBox4.Controls.Add(this.AutoSaveCkBox);
            this.groupBox4.Controls.Add(this.saveOperLogSettingBtn);
            this.groupBox4.Location = new System.Drawing.Point(14, 394);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Size = new System.Drawing.Size(572, 103);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Operation Log Setting";
            // 
            // SuccessLogCkBox
            // 
            this.SuccessLogCkBox.AutoSize = true;
            this.SuccessLogCkBox.Checked = true;
            this.SuccessLogCkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SuccessLogCkBox.Location = new System.Drawing.Point(267, 41);
            this.SuccessLogCkBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SuccessLogCkBox.Name = "SuccessLogCkBox";
            this.SuccessLogCkBox.Size = new System.Drawing.Size(105, 20);
            this.SuccessLogCkBox.TabIndex = 0;
            this.SuccessLogCkBox.Text = "Successful Log";
            this.SuccessLogCkBox.UseVisualStyleBackColor = true;
            // 
            // failureLogCkBox
            // 
            this.failureLogCkBox.AutoSize = true;
            this.failureLogCkBox.Checked = true;
            this.failureLogCkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.failureLogCkBox.Location = new System.Drawing.Point(138, 41);
            this.failureLogCkBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.failureLogCkBox.Name = "failureLogCkBox";
            this.failureLogCkBox.Size = new System.Drawing.Size(85, 20);
            this.failureLogCkBox.TabIndex = 0;
            this.failureLogCkBox.Text = "Failure Log";
            this.failureLogCkBox.UseVisualStyleBackColor = true;
            // 
            // AutoSaveCkBox
            // 
            this.AutoSaveCkBox.AutoSize = true;
            this.AutoSaveCkBox.Checked = true;
            this.AutoSaveCkBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoSaveCkBox.Location = new System.Drawing.Point(20, 41);
            this.AutoSaveCkBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.AutoSaveCkBox.Name = "AutoSaveCkBox";
            this.AutoSaveCkBox.Size = new System.Drawing.Size(80, 20);
            this.AutoSaveCkBox.TabIndex = 0;
            this.AutoSaveCkBox.Text = "Auto Save";
            this.AutoSaveCkBox.UseVisualStyleBackColor = true;
            // 
            // saveOperLogSettingBtn
            // 
            this.saveOperLogSettingBtn.Location = new System.Drawing.Point(497, 63);
            this.saveOperLogSettingBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveOperLogSettingBtn.Name = "saveOperLogSettingBtn";
            this.saveOperLogSettingBtn.Size = new System.Drawing.Size(60, 30);
            this.saveOperLogSettingBtn.TabIndex = 1;
            this.saveOperLogSettingBtn.Text = "Save";
            this.saveOperLogSettingBtn.UseVisualStyleBackColor = true;
            this.saveOperLogSettingBtn.Click += new System.EventHandler(this.saveOperLogSettingBtn_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Controls.Add(this.radioButton3);
            this.groupBox5.Controls.Add(this.radioButton2);
            this.groupBox5.Controls.Add(this.radioButton1);
            this.groupBox5.Location = new System.Drawing.Point(14, 504);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(572, 77);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Stream Type";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(20, 34);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(53, 20);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Main";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(138, 34);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(46, 20);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Sub";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(267, 34);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(53, 20);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Third";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(497, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LocalSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 586);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocalSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Local Setting";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox logFilePathText;
        private System.Windows.Forms.TextBox snapshotFilePathText;
        private System.Windows.Forms.TextBox LocalRecordPathText;
        private System.Windows.Forms.Button SavePathSettingBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button saveKeepLiveSttingBtn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox waitTimeText;
        private System.Windows.Forms.TextBox tryTimesText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button saveTimeOutSettingBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox fileTimeOutText;
        private System.Windows.Forms.TextBox receiveTimeOutText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox SuccessLogCkBox;
        private System.Windows.Forms.CheckBox failureLogCkBox;
        private System.Windows.Forms.CheckBox AutoSaveCkBox;
        private System.Windows.Forms.Button saveOperLogSettingBtn;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}