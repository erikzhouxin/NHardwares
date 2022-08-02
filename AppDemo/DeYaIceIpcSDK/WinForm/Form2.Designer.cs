namespace TestDll
{
    partial class Form2
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
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.checkBoxOpenGate = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIntervalOpen = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBoxTrigger = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxIntervalTrigger = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxRecordTime = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxVideoOSD = new System.Windows.Forms.ComboBox();
            this.buttonVideoColor = new System.Windows.Forms.Button();
            this.checkBoxVideoDate = new System.Windows.Forms.CheckBox();
            this.checkBoxVideoLicense = new System.Windows.Forms.CheckBox();
            this.checkBoxVideoCustom = new System.Windows.Forms.CheckBox();
            this.textBoxVideoCustomInfo = new System.Windows.Forms.TextBox();
            this.textBoxJpegCustomInfo = new System.Windows.Forms.TextBox();
            this.checkBoxJpegCustom = new System.Windows.Forms.CheckBox();
            this.checkBoxJpegAlgo = new System.Windows.Forms.CheckBox();
            this.checkBoxJpegDate = new System.Windows.Forms.CheckBox();
            this.buttonJpegColor = new System.Windows.Forms.Button();
            this.comboBoxJpegOSD = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxIntervalRS232 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.checkBoxRS232 = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxIntervalRS485 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.checkBoxRS485 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxIntervalOpen2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBoxOpenGate2 = new System.Windows.Forms.CheckBox();
            this.button_Browse2 = new System.Windows.Forms.Button();
            this.textBox_logPath = new System.Windows.Forms.TextBox();
            this.checkBox_EnableLog = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "抓拍保存路径：";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(113, 18);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(355, 21);
            this.textBoxPath.TabIndex = 1;
            this.textBoxPath.Text = "D:\\";
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(485, 16);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "浏览...";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // checkBoxOpenGate
            // 
            this.checkBoxOpenGate.AutoSize = true;
            this.checkBoxOpenGate.Location = new System.Drawing.Point(26, 48);
            this.checkBoxOpenGate.Name = "checkBoxOpenGate";
            this.checkBoxOpenGate.Size = new System.Drawing.Size(72, 16);
            this.checkBoxOpenGate.TabIndex = 3;
            this.checkBoxOpenGate.Text = "打开道闸";
            this.checkBoxOpenGate.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(111, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "触发间隔:";
            // 
            // textBoxIntervalOpen
            // 
            this.textBoxIntervalOpen.Location = new System.Drawing.Point(176, 42);
            this.textBoxIntervalOpen.Name = "textBoxIntervalOpen";
            this.textBoxIntervalOpen.Size = new System.Drawing.Size(100, 21);
            this.textBoxIntervalOpen.TabIndex = 5;
            this.textBoxIntervalOpen.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIntervalOpen_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(292, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "毫秒";
            // 
            // checkBoxTrigger
            // 
            this.checkBoxTrigger.AutoSize = true;
            this.checkBoxTrigger.Location = new System.Drawing.Point(26, 72);
            this.checkBoxTrigger.Name = "checkBoxTrigger";
            this.checkBoxTrigger.Size = new System.Drawing.Size(60, 16);
            this.checkBoxTrigger.TabIndex = 7;
            this.checkBoxTrigger.Text = "软触发";
            this.checkBoxTrigger.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(111, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "触发间隔:";
            // 
            // textBoxIntervalTrigger
            // 
            this.textBoxIntervalTrigger.Location = new System.Drawing.Point(176, 67);
            this.textBoxIntervalTrigger.Name = "textBoxIntervalTrigger";
            this.textBoxIntervalTrigger.Size = new System.Drawing.Size(100, 21);
            this.textBoxIntervalTrigger.TabIndex = 9;
            this.textBoxIntervalTrigger.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxIntervalTrigger_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(292, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "毫秒";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "每段录像间隔时长:";
            // 
            // textBoxRecordTime
            // 
            this.textBoxRecordTime.Location = new System.Drawing.Point(176, 172);
            this.textBoxRecordTime.Name = "textBoxRecordTime";
            this.textBoxRecordTime.Size = new System.Drawing.Size(100, 21);
            this.textBoxRecordTime.TabIndex = 12;
            this.textBoxRecordTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxRecordTime_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(292, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "分钟";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(108, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "叠加位置:";
            // 
            // comboBoxVideoOSD
            // 
            this.comboBoxVideoOSD.FormattingEnabled = true;
            this.comboBoxVideoOSD.Location = new System.Drawing.Point(173, 28);
            this.comboBoxVideoOSD.Name = "comboBoxVideoOSD";
            this.comboBoxVideoOSD.Size = new System.Drawing.Size(100, 20);
            this.comboBoxVideoOSD.TabIndex = 15;
            // 
            // buttonVideoColor
            // 
            this.buttonVideoColor.Location = new System.Drawing.Point(291, 26);
            this.buttonVideoColor.Name = "buttonVideoColor";
            this.buttonVideoColor.Size = new System.Drawing.Size(75, 23);
            this.buttonVideoColor.TabIndex = 16;
            this.buttonVideoColor.Text = "颜色...";
            this.buttonVideoColor.UseVisualStyleBackColor = true;
            this.buttonVideoColor.Click += new System.EventHandler(this.buttonVideoColor_Click);
            // 
            // checkBoxVideoDate
            // 
            this.checkBoxVideoDate.AutoSize = true;
            this.checkBoxVideoDate.Location = new System.Drawing.Point(110, 59);
            this.checkBoxVideoDate.Name = "checkBoxVideoDate";
            this.checkBoxVideoDate.Size = new System.Drawing.Size(72, 16);
            this.checkBoxVideoDate.TabIndex = 17;
            this.checkBoxVideoDate.Text = "日期时间";
            this.checkBoxVideoDate.UseVisualStyleBackColor = true;
            // 
            // checkBoxVideoLicense
            // 
            this.checkBoxVideoLicense.AutoSize = true;
            this.checkBoxVideoLicense.Location = new System.Drawing.Point(266, 59);
            this.checkBoxVideoLicense.Name = "checkBoxVideoLicense";
            this.checkBoxVideoLicense.Size = new System.Drawing.Size(72, 16);
            this.checkBoxVideoLicense.TabIndex = 18;
            this.checkBoxVideoLicense.Text = "授权信息";
            this.checkBoxVideoLicense.UseVisualStyleBackColor = true;
            // 
            // checkBoxVideoCustom
            // 
            this.checkBoxVideoCustom.AutoSize = true;
            this.checkBoxVideoCustom.Location = new System.Drawing.Point(28, 85);
            this.checkBoxVideoCustom.Name = "checkBoxVideoCustom";
            this.checkBoxVideoCustom.Size = new System.Drawing.Size(84, 16);
            this.checkBoxVideoCustom.TabIndex = 19;
            this.checkBoxVideoCustom.Text = "自定义信息";
            this.checkBoxVideoCustom.UseVisualStyleBackColor = true;
            // 
            // textBoxVideoCustomInfo
            // 
            this.textBoxVideoCustomInfo.Location = new System.Drawing.Point(110, 85);
            this.textBoxVideoCustomInfo.Multiline = true;
            this.textBoxVideoCustomInfo.Name = "textBoxVideoCustomInfo";
            this.textBoxVideoCustomInfo.Size = new System.Drawing.Size(432, 94);
            this.textBoxVideoCustomInfo.TabIndex = 20;
            this.textBoxVideoCustomInfo.TextChanged += new System.EventHandler(this.textBoxVideoCustomInfo_TextChanged);
            this.textBoxVideoCustomInfo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxVideoCustomInfo_KeyPress);
            // 
            // textBoxJpegCustomInfo
            // 
            this.textBoxJpegCustomInfo.Location = new System.Drawing.Point(111, 77);
            this.textBoxJpegCustomInfo.Multiline = true;
            this.textBoxJpegCustomInfo.Name = "textBoxJpegCustomInfo";
            this.textBoxJpegCustomInfo.Size = new System.Drawing.Size(432, 97);
            this.textBoxJpegCustomInfo.TabIndex = 27;
            this.textBoxJpegCustomInfo.TextChanged += new System.EventHandler(this.textBoxJpegCustomInfo_TextChanged);
            this.textBoxJpegCustomInfo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxJpegCustomInfo_KeyPress);
            // 
            // checkBoxJpegCustom
            // 
            this.checkBoxJpegCustom.AutoSize = true;
            this.checkBoxJpegCustom.Location = new System.Drawing.Point(27, 77);
            this.checkBoxJpegCustom.Name = "checkBoxJpegCustom";
            this.checkBoxJpegCustom.Size = new System.Drawing.Size(84, 16);
            this.checkBoxJpegCustom.TabIndex = 26;
            this.checkBoxJpegCustom.Text = "自定义信息";
            this.checkBoxJpegCustom.UseVisualStyleBackColor = true;
            // 
            // checkBoxJpegAlgo
            // 
            this.checkBoxJpegAlgo.AutoSize = true;
            this.checkBoxJpegAlgo.Location = new System.Drawing.Point(267, 52);
            this.checkBoxJpegAlgo.Name = "checkBoxJpegAlgo";
            this.checkBoxJpegAlgo.Size = new System.Drawing.Size(72, 16);
            this.checkBoxJpegAlgo.TabIndex = 25;
            this.checkBoxJpegAlgo.Text = "算法信息";
            this.checkBoxJpegAlgo.UseVisualStyleBackColor = true;
            // 
            // checkBoxJpegDate
            // 
            this.checkBoxJpegDate.AutoSize = true;
            this.checkBoxJpegDate.Location = new System.Drawing.Point(111, 52);
            this.checkBoxJpegDate.Name = "checkBoxJpegDate";
            this.checkBoxJpegDate.Size = new System.Drawing.Size(72, 16);
            this.checkBoxJpegDate.TabIndex = 24;
            this.checkBoxJpegDate.Text = "日期时间";
            this.checkBoxJpegDate.UseVisualStyleBackColor = true;
            // 
            // buttonJpegColor
            // 
            this.buttonJpegColor.Location = new System.Drawing.Point(295, 20);
            this.buttonJpegColor.Name = "buttonJpegColor";
            this.buttonJpegColor.Size = new System.Drawing.Size(75, 23);
            this.buttonJpegColor.TabIndex = 23;
            this.buttonJpegColor.Text = "颜色...";
            this.buttonJpegColor.UseVisualStyleBackColor = true;
            this.buttonJpegColor.Click += new System.EventHandler(this.buttonJpegColor_Click);
            // 
            // comboBoxJpegOSD
            // 
            this.comboBoxJpegOSD.FormattingEnabled = true;
            this.comboBoxJpegOSD.Location = new System.Drawing.Point(174, 22);
            this.comboBoxJpegOSD.Name = "comboBoxJpegOSD";
            this.comboBoxJpegOSD.Size = new System.Drawing.Size(103, 20);
            this.comboBoxJpegOSD.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(109, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "叠加位置:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.textBoxIntervalRS232);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.checkBoxRS232);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.textBoxIntervalRS485);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.checkBoxRS485);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.textBoxIntervalOpen2);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.checkBoxOpenGate2);
            this.groupBox1.Controls.Add(this.button_Browse2);
            this.groupBox1.Controls.Add(this.textBox_logPath);
            this.groupBox1.Controls.Add(this.checkBox_EnableLog);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.textBoxRecordTime);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxIntervalTrigger);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.checkBoxTrigger);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxIntervalOpen);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.checkBoxOpenGate);
            this.groupBox1.Controls.Add(this.buttonBrowse);
            this.groupBox1.Controls.Add(this.textBoxPath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(35, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(620, 232);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本设置";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(292, 154);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 28;
            this.label14.Text = "毫秒";
            // 
            // textBoxIntervalRS232
            // 
            this.textBoxIntervalRS232.Location = new System.Drawing.Point(176, 145);
            this.textBoxIntervalRS232.Name = "textBoxIntervalRS232";
            this.textBoxIntervalRS232.Size = new System.Drawing.Size(100, 21);
            this.textBoxIntervalRS232.TabIndex = 27;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(111, 152);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 26;
            this.label15.Text = "发送间隔:";
            // 
            // checkBoxRS232
            // 
            this.checkBoxRS232.AutoSize = true;
            this.checkBoxRS232.Location = new System.Drawing.Point(26, 150);
            this.checkBoxRS232.Name = "checkBoxRS232";
            this.checkBoxRS232.Size = new System.Drawing.Size(54, 16);
            this.checkBoxRS232.TabIndex = 25;
            this.checkBoxRS232.Text = "RS232";
            this.checkBoxRS232.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(292, 130);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 24;
            this.label12.Text = "毫秒";
            // 
            // textBoxIntervalRS485
            // 
            this.textBoxIntervalRS485.Location = new System.Drawing.Point(176, 121);
            this.textBoxIntervalRS485.Name = "textBoxIntervalRS485";
            this.textBoxIntervalRS485.Size = new System.Drawing.Size(100, 21);
            this.textBoxIntervalRS485.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(111, 128);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 22;
            this.label13.Text = "发送间隔:";
            // 
            // checkBoxRS485
            // 
            this.checkBoxRS485.AutoSize = true;
            this.checkBoxRS485.Location = new System.Drawing.Point(26, 126);
            this.checkBoxRS485.Name = "checkBoxRS485";
            this.checkBoxRS485.Size = new System.Drawing.Size(54, 16);
            this.checkBoxRS485.TabIndex = 21;
            this.checkBoxRS485.Text = "RS485";
            this.checkBoxRS485.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(292, 103);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 20;
            this.label10.Text = "毫秒";
            // 
            // textBoxIntervalOpen2
            // 
            this.textBoxIntervalOpen2.Location = new System.Drawing.Point(176, 94);
            this.textBoxIntervalOpen2.Name = "textBoxIntervalOpen2";
            this.textBoxIntervalOpen2.Size = new System.Drawing.Size(100, 21);
            this.textBoxIntervalOpen2.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(111, 101);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "触发间隔:";
            // 
            // checkBoxOpenGate2
            // 
            this.checkBoxOpenGate2.AutoSize = true;
            this.checkBoxOpenGate2.Location = new System.Drawing.Point(26, 99);
            this.checkBoxOpenGate2.Name = "checkBoxOpenGate2";
            this.checkBoxOpenGate2.Size = new System.Drawing.Size(78, 16);
            this.checkBoxOpenGate2.TabIndex = 17;
            this.checkBoxOpenGate2.Text = "打开道闸2";
            this.checkBoxOpenGate2.UseVisualStyleBackColor = true;
            // 
            // button_Browse2
            // 
            this.button_Browse2.Location = new System.Drawing.Point(485, 196);
            this.button_Browse2.Name = "button_Browse2";
            this.button_Browse2.Size = new System.Drawing.Size(75, 23);
            this.button_Browse2.TabIndex = 16;
            this.button_Browse2.Text = "浏览...";
            this.button_Browse2.UseVisualStyleBackColor = true;
            this.button_Browse2.Click += new System.EventHandler(this.button_Browse2_Click);
            // 
            // textBox_logPath
            // 
            this.textBox_logPath.Location = new System.Drawing.Point(113, 200);
            this.textBox_logPath.Name = "textBox_logPath";
            this.textBox_logPath.Size = new System.Drawing.Size(355, 21);
            this.textBox_logPath.TabIndex = 15;
            this.textBox_logPath.Text = "D:\\";
            // 
            // checkBox_EnableLog
            // 
            this.checkBox_EnableLog.AutoSize = true;
            this.checkBox_EnableLog.Location = new System.Drawing.Point(27, 206);
            this.checkBox_EnableLog.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_EnableLog.Name = "checkBox_EnableLog";
            this.checkBox_EnableLog.Size = new System.Drawing.Size(72, 16);
            this.checkBox_EnableLog.TabIndex = 14;
            this.checkBox_EnableLog.Text = "开启日志";
            this.checkBox_EnableLog.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxVideoCustomInfo);
            this.groupBox2.Controls.Add(this.checkBoxVideoCustom);
            this.groupBox2.Controls.Add(this.checkBoxVideoLicense);
            this.groupBox2.Controls.Add(this.checkBoxVideoDate);
            this.groupBox2.Controls.Add(this.buttonVideoColor);
            this.groupBox2.Controls.Add(this.comboBoxVideoOSD);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(35, 250);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(619, 192);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "实时视频";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxJpegCustomInfo);
            this.groupBox3.Controls.Add(this.checkBoxJpegCustom);
            this.groupBox3.Controls.Add(this.checkBoxJpegAlgo);
            this.groupBox3.Controls.Add(this.checkBoxJpegDate);
            this.groupBox3.Controls.Add(this.buttonJpegColor);
            this.groupBox3.Controls.Add(this.comboBoxJpegOSD);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(34, 453);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(619, 185);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "抓拍图片";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(465, 645);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 31;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancle
            // 
            this.buttonCancle.Location = new System.Drawing.Point(578, 645);
            this.buttonCancle.Name = "buttonCancle";
            this.buttonCancle.Size = new System.Drawing.Size(75, 23);
            this.buttonCancle.TabIndex = 32;
            this.buttonCancle.Text = "取消";
            this.buttonCancle.UseVisualStyleBackColor = true;
            this.buttonCancle.Click += new System.EventHandler(this.buttonCancle_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 679);
            this.Controls.Add(this.buttonCancle);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.CheckBox checkBoxOpenGate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIntervalOpen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBoxTrigger;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxIntervalTrigger;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxRecordTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxVideoOSD;
        private System.Windows.Forms.Button buttonVideoColor;
        private System.Windows.Forms.CheckBox checkBoxVideoDate;
        private System.Windows.Forms.CheckBox checkBoxVideoLicense;
        private System.Windows.Forms.CheckBox checkBoxVideoCustom;
        private System.Windows.Forms.TextBox textBoxVideoCustomInfo;
        private System.Windows.Forms.TextBox textBoxJpegCustomInfo;
        private System.Windows.Forms.CheckBox checkBoxJpegCustom;
        private System.Windows.Forms.CheckBox checkBoxJpegAlgo;
        private System.Windows.Forms.CheckBox checkBoxJpegDate;
        private System.Windows.Forms.Button buttonJpegColor;
        private System.Windows.Forms.ComboBox comboBoxJpegOSD;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancle;
        private System.Windows.Forms.Button button_Browse2;
        private System.Windows.Forms.TextBox textBox_logPath;
        private System.Windows.Forms.CheckBox checkBox_EnableLog;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxIntervalRS232;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox checkBoxRS232;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBoxIntervalRS485;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkBoxRS485;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxIntervalOpen2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBoxOpenGate2;
    }
}