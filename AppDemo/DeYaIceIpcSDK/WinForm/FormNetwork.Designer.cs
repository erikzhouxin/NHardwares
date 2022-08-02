namespace TestDll
{
    partial class FormNetwork
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_ip1 = new System.Windows.Forms.TextBox();
            this.textBox_ip2 = new System.Windows.Forms.TextBox();
            this.textBox_ip3 = new System.Windows.Forms.TextBox();
            this.textBox_ip4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_mask4 = new System.Windows.Forms.TextBox();
            this.textBox_mask3 = new System.Windows.Forms.TextBox();
            this.textBox_mask2 = new System.Windows.Forms.TextBox();
            this.textBox_mask1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox_gateway4 = new System.Windows.Forms.TextBox();
            this.textBox_gateway3 = new System.Windows.Forms.TextBox();
            this.textBox_gateway2 = new System.Windows.Forms.TextBox();
            this.textBox_gateway1 = new System.Windows.Forms.TextBox();
            this.button_apply = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBoxOutputTime = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.radioButtonClose = new System.Windows.Forms.RadioButton();
            this.radioButtonOpen = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox_EnableBrand = new System.Windows.Forms.CheckBox();
            this.checkBox_EnableNoPlate_Brand = new System.Windows.Forms.CheckBox();
            this.checkBox_EnableNoPlate = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.comboBox_settingPPI = new System.Windows.Forms.ComboBox();
            this.textBox_righty = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBox_rightx = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox_lefty = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textBox_leftx = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.comboBox_TriggerMode = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBox_uart = new System.Windows.Forms.ComboBox();
            this.comboBox_uartMode = new System.Windows.Forms.ComboBox();
            this.label27 = new System.Windows.Forms.Label();
            this.comboBox_flowctrl = new System.Windows.Forms.ComboBox();
            this.comboBox_stopbits = new System.Windows.Forms.ComboBox();
            this.comboBox_parity = new System.Windows.Forms.ComboBox();
            this.comboBox_databits = new System.Windows.Forms.ComboBox();
            this.comboBox_baudrate = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.checkBox_enableUart = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "掩码:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "网关:";
            // 
            // textBox_ip1
            // 
            this.textBox_ip1.Location = new System.Drawing.Point(77, 27);
            this.textBox_ip1.MaxLength = 3;
            this.textBox_ip1.Name = "textBox_ip1";
            this.textBox_ip1.Size = new System.Drawing.Size(35, 21);
            this.textBox_ip1.TabIndex = 3;
            this.textBox_ip1.TextChanged += new System.EventHandler(this.textBox_ip1_TextChanged);
            this.textBox_ip1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_ip1_KeyPress);
            // 
            // textBox_ip2
            // 
            this.textBox_ip2.Location = new System.Drawing.Point(128, 27);
            this.textBox_ip2.MaxLength = 3;
            this.textBox_ip2.Name = "textBox_ip2";
            this.textBox_ip2.Size = new System.Drawing.Size(35, 21);
            this.textBox_ip2.TabIndex = 4;
            this.textBox_ip2.TextChanged += new System.EventHandler(this.textBox_ip2_TextChanged);
            // 
            // textBox_ip3
            // 
            this.textBox_ip3.Location = new System.Drawing.Point(178, 27);
            this.textBox_ip3.MaxLength = 3;
            this.textBox_ip3.Name = "textBox_ip3";
            this.textBox_ip3.Size = new System.Drawing.Size(35, 21);
            this.textBox_ip3.TabIndex = 5;
            this.textBox_ip3.TextChanged += new System.EventHandler(this.textBox_ip3_TextChanged);
            // 
            // textBox_ip4
            // 
            this.textBox_ip4.Location = new System.Drawing.Point(231, 27);
            this.textBox_ip4.MaxLength = 3;
            this.textBox_ip4.Name = "textBox_ip4";
            this.textBox_ip4.Size = new System.Drawing.Size(35, 21);
            this.textBox_ip4.TabIndex = 6;
            this.textBox_ip4.TextChanged += new System.EventHandler(this.textBox_ip4_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(115, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = ".";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(164, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = ".";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(215, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 14);
            this.label6.TabIndex = 9;
            this.label6.Text = ".";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(215, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 14);
            this.label7.TabIndex = 16;
            this.label7.Text = ".";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(164, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 14);
            this.label8.TabIndex = 15;
            this.label8.Text = ".";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(115, 79);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 14);
            this.label9.TabIndex = 14;
            this.label9.Text = ".";
            // 
            // textBox_mask4
            // 
            this.textBox_mask4.Location = new System.Drawing.Point(231, 73);
            this.textBox_mask4.MaxLength = 3;
            this.textBox_mask4.Name = "textBox_mask4";
            this.textBox_mask4.Size = new System.Drawing.Size(35, 21);
            this.textBox_mask4.TabIndex = 13;
            this.textBox_mask4.TextChanged += new System.EventHandler(this.textBox_mask4_TextChanged);
            this.textBox_mask4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_mask4_KeyPress);
            // 
            // textBox_mask3
            // 
            this.textBox_mask3.Location = new System.Drawing.Point(178, 73);
            this.textBox_mask3.MaxLength = 3;
            this.textBox_mask3.Name = "textBox_mask3";
            this.textBox_mask3.Size = new System.Drawing.Size(35, 21);
            this.textBox_mask3.TabIndex = 12;
            this.textBox_mask3.TextChanged += new System.EventHandler(this.textBox_mask3_TextChanged);
            this.textBox_mask3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_mask3_KeyPress);
            // 
            // textBox_mask2
            // 
            this.textBox_mask2.Location = new System.Drawing.Point(128, 73);
            this.textBox_mask2.MaxLength = 3;
            this.textBox_mask2.Name = "textBox_mask2";
            this.textBox_mask2.Size = new System.Drawing.Size(35, 21);
            this.textBox_mask2.TabIndex = 11;
            this.textBox_mask2.TextChanged += new System.EventHandler(this.textBox_mask2_TextChanged);
            this.textBox_mask2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_mask2_KeyPress);
            // 
            // textBox_mask1
            // 
            this.textBox_mask1.Location = new System.Drawing.Point(77, 73);
            this.textBox_mask1.MaxLength = 3;
            this.textBox_mask1.Name = "textBox_mask1";
            this.textBox_mask1.Size = new System.Drawing.Size(35, 21);
            this.textBox_mask1.TabIndex = 10;
            this.textBox_mask1.TextChanged += new System.EventHandler(this.textBox_mask1_TextChanged);
            this.textBox_mask1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_mask1_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(215, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 14);
            this.label10.TabIndex = 23;
            this.label10.Text = ".";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(164, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 14);
            this.label11.TabIndex = 22;
            this.label11.Text = ".";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(115, 129);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 14);
            this.label12.TabIndex = 21;
            this.label12.Text = ".";
            // 
            // textBox_gateway4
            // 
            this.textBox_gateway4.Location = new System.Drawing.Point(231, 123);
            this.textBox_gateway4.MaxLength = 3;
            this.textBox_gateway4.Name = "textBox_gateway4";
            this.textBox_gateway4.Size = new System.Drawing.Size(35, 21);
            this.textBox_gateway4.TabIndex = 20;
            this.textBox_gateway4.TextChanged += new System.EventHandler(this.textBox_gateway4_TextChanged);
            this.textBox_gateway4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_gateway4_KeyPress);
            // 
            // textBox_gateway3
            // 
            this.textBox_gateway3.Location = new System.Drawing.Point(178, 123);
            this.textBox_gateway3.MaxLength = 3;
            this.textBox_gateway3.Name = "textBox_gateway3";
            this.textBox_gateway3.Size = new System.Drawing.Size(35, 21);
            this.textBox_gateway3.TabIndex = 19;
            this.textBox_gateway3.TextChanged += new System.EventHandler(this.textBox_gateway3_TextChanged);
            this.textBox_gateway3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_gateway3_KeyPress);
            // 
            // textBox_gateway2
            // 
            this.textBox_gateway2.Location = new System.Drawing.Point(128, 123);
            this.textBox_gateway2.MaxLength = 3;
            this.textBox_gateway2.Name = "textBox_gateway2";
            this.textBox_gateway2.Size = new System.Drawing.Size(35, 21);
            this.textBox_gateway2.TabIndex = 18;
            this.textBox_gateway2.TextChanged += new System.EventHandler(this.textBox_gateway2_TextChanged);
            this.textBox_gateway2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_gateway2_KeyPress);
            // 
            // textBox_gateway1
            // 
            this.textBox_gateway1.Location = new System.Drawing.Point(77, 123);
            this.textBox_gateway1.MaxLength = 3;
            this.textBox_gateway1.Name = "textBox_gateway1";
            this.textBox_gateway1.Size = new System.Drawing.Size(35, 21);
            this.textBox_gateway1.TabIndex = 17;
            this.textBox_gateway1.TextChanged += new System.EventHandler(this.textBox_gateway1_TextChanged);
            this.textBox_gateway1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_gateway1_KeyPress);
            // 
            // button_apply
            // 
            this.button_apply.Location = new System.Drawing.Point(773, 354);
            this.button_apply.Name = "button_apply";
            this.button_apply.Size = new System.Drawing.Size(75, 23);
            this.button_apply.TabIndex = 24;
            this.button_apply.Text = "应用";
            this.button_apply.UseVisualStyleBackColor = true;
            this.button_apply.Click += new System.EventHandler(this.button_apply_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(883, 354);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 25;
            this.button_cancel.Text = "取消";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.textBox_gateway4);
            this.groupBox1.Controls.Add(this.textBox_gateway3);
            this.groupBox1.Controls.Add(this.textBox_gateway2);
            this.groupBox1.Controls.Add(this.textBox_gateway1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox_mask4);
            this.groupBox1.Controls.Add(this.textBox_mask3);
            this.groupBox1.Controls.Add(this.textBox_mask2);
            this.groupBox1.Controls.Add(this.textBox_mask1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_ip4);
            this.groupBox1.Controls.Add(this.textBox_ip3);
            this.groupBox1.Controls.Add(this.textBox_ip2);
            this.groupBox1.Controls.Add(this.textBox_ip1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(17, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 165);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "网络参数";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.textBoxOutputTime);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.radioButtonClose);
            this.groupBox2.Controls.Add(this.radioButtonOpen);
            this.groupBox2.Location = new System.Drawing.Point(17, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(302, 115);
            this.groupBox2.TabIndex = 27;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "开关量输出2";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(213, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(17, 12);
            this.label14.TabIndex = 4;
            this.label14.Text = "秒";
            // 
            // textBoxOutputTime
            // 
            this.textBoxOutputTime.Location = new System.Drawing.Point(98, 70);
            this.textBoxOutputTime.Name = "textBoxOutputTime";
            this.textBoxOutputTime.Size = new System.Drawing.Size(100, 21);
            this.textBoxOutputTime.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(29, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 2;
            this.label13.Text = "输出延时:";
            // 
            // radioButtonClose
            // 
            this.radioButtonClose.AutoSize = true;
            this.radioButtonClose.Location = new System.Drawing.Point(128, 30);
            this.radioButtonClose.Name = "radioButtonClose";
            this.radioButtonClose.Size = new System.Drawing.Size(47, 16);
            this.radioButtonClose.TabIndex = 1;
            this.radioButtonClose.TabStop = true;
            this.radioButtonClose.Text = "常闭";
            this.radioButtonClose.UseVisualStyleBackColor = true;
            // 
            // radioButtonOpen
            // 
            this.radioButtonOpen.AutoSize = true;
            this.radioButtonOpen.Location = new System.Drawing.Point(31, 30);
            this.radioButtonOpen.Name = "radioButtonOpen";
            this.radioButtonOpen.Size = new System.Drawing.Size(47, 16);
            this.radioButtonOpen.TabIndex = 0;
            this.radioButtonOpen.TabStop = true;
            this.radioButtonOpen.Text = "常开";
            this.radioButtonOpen.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox_EnableBrand);
            this.groupBox3.Controls.Add(this.checkBox_EnableNoPlate_Brand);
            this.groupBox3.Controls.Add(this.checkBox_EnableNoPlate);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.comboBox_settingPPI);
            this.groupBox3.Controls.Add(this.textBox_righty);
            this.groupBox3.Controls.Add(this.label16);
            this.groupBox3.Controls.Add(this.textBox_rightx);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.textBox_lefty);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.textBox_leftx);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.comboBox_TriggerMode);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Location = new System.Drawing.Point(335, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(304, 309);
            this.groupBox3.TabIndex = 28;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "算法参数";
            // 
            // checkBox_EnableBrand
            // 
            this.checkBox_EnableBrand.AutoSize = true;
            this.checkBox_EnableBrand.Location = new System.Drawing.Point(27, 287);
            this.checkBox_EnableBrand.Name = "checkBox_EnableBrand";
            this.checkBox_EnableBrand.Size = new System.Drawing.Size(108, 16);
            this.checkBox_EnableBrand.TabIndex = 33;
            this.checkBox_EnableBrand.Text = "有牌车输出品牌";
            this.checkBox_EnableBrand.UseVisualStyleBackColor = true;
            // 
            // checkBox_EnableNoPlate_Brand
            // 
            this.checkBox_EnableNoPlate_Brand.AutoSize = true;
            this.checkBox_EnableNoPlate_Brand.Location = new System.Drawing.Point(168, 256);
            this.checkBox_EnableNoPlate_Brand.Name = "checkBox_EnableNoPlate_Brand";
            this.checkBox_EnableNoPlate_Brand.Size = new System.Drawing.Size(108, 16);
            this.checkBox_EnableNoPlate_Brand.TabIndex = 32;
            this.checkBox_EnableNoPlate_Brand.Text = "无牌车输出品牌";
            this.checkBox_EnableNoPlate_Brand.UseVisualStyleBackColor = true;
            // 
            // checkBox_EnableNoPlate
            // 
            this.checkBox_EnableNoPlate.AutoSize = true;
            this.checkBox_EnableNoPlate.Location = new System.Drawing.Point(27, 256);
            this.checkBox_EnableNoPlate.Name = "checkBox_EnableNoPlate";
            this.checkBox_EnableNoPlate.Size = new System.Drawing.Size(84, 16);
            this.checkBox_EnableNoPlate.TabIndex = 31;
            this.checkBox_EnableNoPlate.Text = "输出无牌车";
            this.checkBox_EnableNoPlate.UseVisualStyleBackColor = true;
            this.checkBox_EnableNoPlate.CheckedChanged += new System.EventHandler(this.checkBox_EnableNoPlate_CheckedChanged);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(28, 65);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(89, 12);
            this.label20.TabIndex = 30;
            this.label20.Text = "识别区域配置：";
            // 
            // comboBox_settingPPI
            // 
            this.comboBox_settingPPI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_settingPPI.FormattingEnabled = true;
            this.comboBox_settingPPI.Location = new System.Drawing.Point(111, 87);
            this.comboBox_settingPPI.Name = "comboBox_settingPPI";
            this.comboBox_settingPPI.Size = new System.Drawing.Size(147, 20);
            this.comboBox_settingPPI.TabIndex = 29;
            this.comboBox_settingPPI.SelectedIndexChanged += new System.EventHandler(this.comboBox_settingPPI_SelectedIndexChanged);
            // 
            // textBox_righty
            // 
            this.textBox_righty.Location = new System.Drawing.Point(111, 152);
            this.textBox_righty.MaxLength = 4;
            this.textBox_righty.Name = "textBox_righty";
            this.textBox_righty.Size = new System.Drawing.Size(147, 21);
            this.textBox_righty.TabIndex = 28;
            this.textBox_righty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_righty_KeyPress);
            this.textBox_righty.Leave += new System.EventHandler(this.textBox_righty_Leave);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(28, 155);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(59, 12);
            this.label16.TabIndex = 27;
            this.label16.Text = "上y坐标：";
            // 
            // textBox_rightx
            // 
            this.textBox_rightx.Location = new System.Drawing.Point(111, 184);
            this.textBox_rightx.MaxLength = 4;
            this.textBox_rightx.Name = "textBox_rightx";
            this.textBox_rightx.Size = new System.Drawing.Size(147, 21);
            this.textBox_rightx.TabIndex = 26;
            this.textBox_rightx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_rightx_KeyPress);
            this.textBox_rightx.Leave += new System.EventHandler(this.textBox_rightx_Leave);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(28, 187);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 12);
            this.label17.TabIndex = 25;
            this.label17.Text = "右x坐标：";
            // 
            // textBox_lefty
            // 
            this.textBox_lefty.Location = new System.Drawing.Point(111, 220);
            this.textBox_lefty.MaxLength = 4;
            this.textBox_lefty.Name = "textBox_lefty";
            this.textBox_lefty.Size = new System.Drawing.Size(147, 21);
            this.textBox_lefty.TabIndex = 24;
            this.textBox_lefty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_lefty_KeyPress);
            this.textBox_lefty.Leave += new System.EventHandler(this.textBox_lefty_Leave);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(28, 223);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 12);
            this.label18.TabIndex = 23;
            this.label18.Text = "下y坐标：";
            // 
            // textBox_leftx
            // 
            this.textBox_leftx.Location = new System.Drawing.Point(111, 120);
            this.textBox_leftx.MaxLength = 4;
            this.textBox_leftx.Name = "textBox_leftx";
            this.textBox_leftx.Size = new System.Drawing.Size(147, 21);
            this.textBox_leftx.TabIndex = 22;
            this.textBox_leftx.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_leftx_KeyPress);
            this.textBox_leftx.Leave += new System.EventHandler(this.textBox_leftx_Leave);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(28, 123);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(59, 12);
            this.label19.TabIndex = 21;
            this.label19.Text = "左x坐标：";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(28, 90);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 12);
            this.label21.TabIndex = 18;
            this.label21.Text = "设置分辨率：";
            // 
            // comboBox_TriggerMode
            // 
            this.comboBox_TriggerMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TriggerMode.FormattingEnabled = true;
            this.comboBox_TriggerMode.Location = new System.Drawing.Point(111, 31);
            this.comboBox_TriggerMode.Name = "comboBox_TriggerMode";
            this.comboBox_TriggerMode.Size = new System.Drawing.Size(121, 20);
            this.comboBox_TriggerMode.TabIndex = 1;
            this.comboBox_TriggerMode.SelectedIndexChanged += new System.EventHandler(this.comboBox_TriggerMode_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(28, 36);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(59, 12);
            this.label15.TabIndex = 0;
            this.label15.Text = "触发方式:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBox_uart);
            this.groupBox4.Controls.Add(this.comboBox_uartMode);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.comboBox_flowctrl);
            this.groupBox4.Controls.Add(this.comboBox_stopbits);
            this.groupBox4.Controls.Add(this.comboBox_parity);
            this.groupBox4.Controls.Add(this.comboBox_databits);
            this.groupBox4.Controls.Add(this.comboBox_baudrate);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.label26);
            this.groupBox4.Controls.Add(this.checkBox_enableUart);
            this.groupBox4.Location = new System.Drawing.Point(665, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(293, 309);
            this.groupBox4.TabIndex = 29;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "串口设置";
            // 
            // comboBox_uart
            // 
            this.comboBox_uart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_uart.FormattingEnabled = true;
            this.comboBox_uart.Location = new System.Drawing.Point(11, 28);
            this.comboBox_uart.Name = "comboBox_uart";
            this.comboBox_uart.Size = new System.Drawing.Size(63, 20);
            this.comboBox_uart.TabIndex = 25;
            this.comboBox_uart.SelectedIndexChanged += new System.EventHandler(this.comboBox_uart_SelectedIndexChanged);
            this.comboBox_uart.Click += new System.EventHandler(this.comboBox_uart_Click);
            // 
            // comboBox_uartMode
            // 
            this.comboBox_uartMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_uartMode.FormattingEnabled = true;
            this.comboBox_uartMode.Location = new System.Drawing.Point(121, 82);
            this.comboBox_uartMode.Name = "comboBox_uartMode";
            this.comboBox_uartMode.Size = new System.Drawing.Size(121, 20);
            this.comboBox_uartMode.TabIndex = 24;
            this.comboBox_uartMode.Click += new System.EventHandler(this.comboBox_uartMode_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(27, 85);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(89, 12);
            this.label27.TabIndex = 23;
            this.label27.Text = "串口工作模式：";
            // 
            // comboBox_flowctrl
            // 
            this.comboBox_flowctrl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_flowctrl.FormattingEnabled = true;
            this.comboBox_flowctrl.Location = new System.Drawing.Point(121, 252);
            this.comboBox_flowctrl.Name = "comboBox_flowctrl";
            this.comboBox_flowctrl.Size = new System.Drawing.Size(121, 20);
            this.comboBox_flowctrl.TabIndex = 22;
            this.comboBox_flowctrl.Click += new System.EventHandler(this.comboBox_flowctrl_Click);
            // 
            // comboBox_stopbits
            // 
            this.comboBox_stopbits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_stopbits.FormattingEnabled = true;
            this.comboBox_stopbits.Location = new System.Drawing.Point(121, 213);
            this.comboBox_stopbits.Name = "comboBox_stopbits";
            this.comboBox_stopbits.Size = new System.Drawing.Size(121, 20);
            this.comboBox_stopbits.TabIndex = 21;
            this.comboBox_stopbits.Click += new System.EventHandler(this.comboBox_stopbits_Click);
            // 
            // comboBox_parity
            // 
            this.comboBox_parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_parity.FormattingEnabled = true;
            this.comboBox_parity.Location = new System.Drawing.Point(121, 178);
            this.comboBox_parity.Name = "comboBox_parity";
            this.comboBox_parity.Size = new System.Drawing.Size(121, 20);
            this.comboBox_parity.TabIndex = 20;
            this.comboBox_parity.Click += new System.EventHandler(this.comboBox_parity_Click);
            // 
            // comboBox_databits
            // 
            this.comboBox_databits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_databits.FormattingEnabled = true;
            this.comboBox_databits.Location = new System.Drawing.Point(121, 143);
            this.comboBox_databits.Name = "comboBox_databits";
            this.comboBox_databits.Size = new System.Drawing.Size(121, 20);
            this.comboBox_databits.TabIndex = 19;
            this.comboBox_databits.Click += new System.EventHandler(this.comboBox_databits_Click);
            // 
            // comboBox_baudrate
            // 
            this.comboBox_baudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_baudrate.FormattingEnabled = true;
            this.comboBox_baudrate.Location = new System.Drawing.Point(121, 112);
            this.comboBox_baudrate.Name = "comboBox_baudrate";
            this.comboBox_baudrate.Size = new System.Drawing.Size(121, 20);
            this.comboBox_baudrate.TabIndex = 18;
            this.comboBox_baudrate.Click += new System.EventHandler(this.comboBox_baudrate_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(27, 255);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(59, 12);
            this.label22.TabIndex = 17;
            this.label22.Text = "流控模式:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(27, 216);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(47, 12);
            this.label23.TabIndex = 16;
            this.label23.Text = "停止位:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(27, 181);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(47, 12);
            this.label24.TabIndex = 15;
            this.label24.Text = "校验位:";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(27, 146);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(47, 12);
            this.label25.TabIndex = 14;
            this.label25.Text = "数据位:";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(27, 115);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(47, 12);
            this.label26.TabIndex = 13;
            this.label26.Text = "波特率:";
            // 
            // checkBox_enableUart
            // 
            this.checkBox_enableUart.AutoSize = true;
            this.checkBox_enableUart.Location = new System.Drawing.Point(11, 56);
            this.checkBox_enableUart.Name = "checkBox_enableUart";
            this.checkBox_enableUart.Size = new System.Drawing.Size(72, 16);
            this.checkBox_enableUart.TabIndex = 12;
            this.checkBox_enableUart.Text = "串口使能";
            this.checkBox_enableUart.UseVisualStyleBackColor = true;
            this.checkBox_enableUart.Click += new System.EventHandler(this.checkBox_enableUart_Click);
            // 
            // FormNetwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 410);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_apply);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNetwork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "配置";
            this.Load += new System.EventHandler(this.FormNetwork_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_ip1;
        private System.Windows.Forms.TextBox textBox_ip2;
        private System.Windows.Forms.TextBox textBox_ip3;
        private System.Windows.Forms.TextBox textBox_ip4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_mask4;
        private System.Windows.Forms.TextBox textBox_mask3;
        private System.Windows.Forms.TextBox textBox_mask2;
        private System.Windows.Forms.TextBox textBox_mask1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox_gateway4;
        private System.Windows.Forms.TextBox textBox_gateway3;
        private System.Windows.Forms.TextBox textBox_gateway2;
        private System.Windows.Forms.TextBox textBox_gateway1;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBoxOutputTime;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.RadioButton radioButtonClose;
        private System.Windows.Forms.RadioButton radioButtonOpen;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox comboBox_TriggerMode;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox comboBox_settingPPI;
        private System.Windows.Forms.TextBox textBox_righty;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textBox_rightx;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox_lefty;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textBox_leftx;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBox_uartMode;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.ComboBox comboBox_flowctrl;
        private System.Windows.Forms.ComboBox comboBox_stopbits;
        private System.Windows.Forms.ComboBox comboBox_parity;
        private System.Windows.Forms.ComboBox comboBox_databits;
        private System.Windows.Forms.ComboBox comboBox_baudrate;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.CheckBox checkBox_enableUart;
        private System.Windows.Forms.ComboBox comboBox_uart;
        private System.Windows.Forms.CheckBox checkBox_EnableBrand;
        private System.Windows.Forms.CheckBox checkBox_EnableNoPlate_Brand;
        private System.Windows.Forms.CheckBox checkBox_EnableNoPlate;

    }
}