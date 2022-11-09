namespace VzClientSDKDemo
{
    partial class RVideoCfg_Form
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.m_cmbStreamType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_img_quality = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txt_rateval = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_compress_mode = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_encode_type = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmb_frame_rate = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmb_frame_size = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnRecovery = new System.Windows.Forms.Button();
            this.cmb_img_pos = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmb_exposure_time = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbar_definition = new System.Windows.Forms.TrackBar();
            this.label13 = new System.Windows.Forms.Label();
            this.tbar_saturation = new System.Windows.Forms.TrackBar();
            this.label12 = new System.Windows.Forms.Label();
            this.tbar_contrast = new System.Windows.Forms.TrackBar();
            this.label10 = new System.Windows.Forms.Label();
            this.tbar_bright = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDefinition = new System.Windows.Forms.Label();
            this.lblSaturation = new System.Windows.Forms.Label();
            this.lblContrast = new System.Windows.Forms.Label();
            this.lblBright = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_definition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_saturation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_contrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_bright)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(376, 379);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_cmbStreamType);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.cmb_img_quality);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.btnSave);
            this.tabPage1.Controls.Add(this.txt_rateval);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.cmb_compress_mode);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.cmb_encode_type);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.cmb_frame_rate);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cmb_frame_size);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(368, 353);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "主码流";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // m_cmbStreamType
            // 
            this.m_cmbStreamType.FormattingEnabled = true;
            this.m_cmbStreamType.Items.AddRange(new object[] {
            "主码流",
            "子码流"});
            this.m_cmbStreamType.Location = new System.Drawing.Point(79, 31);
            this.m_cmbStreamType.Name = "m_cmbStreamType";
            this.m_cmbStreamType.Size = new System.Drawing.Size(121, 20);
            this.m_cmbStreamType.TabIndex = 14;
            this.m_cmbStreamType.SelectedIndexChanged += new System.EventHandler(this.m_cmbStreamType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "码流";
            // 
            // cmb_img_quality
            // 
            this.cmb_img_quality.FormattingEnabled = true;
            this.cmb_img_quality.Items.AddRange(new object[] {
            "最流畅",
            "较流畅",
            "流畅",
            "中等",
            "清晰",
            "较清晰",
            "最清晰"});
            this.cmb_img_quality.Location = new System.Drawing.Point(78, 188);
            this.cmb_img_quality.Name = "cmb_img_quality";
            this.cmb_img_quality.Size = new System.Drawing.Size(121, 20);
            this.cmb_img_quality.TabIndex = 12;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 191);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "图像质量";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(133, 251);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "确定";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txt_rateval
            // 
            this.txt_rateval.Location = new System.Drawing.Point(78, 217);
            this.txt_rateval.Name = "txt_rateval";
            this.txt_rateval.Size = new System.Drawing.Size(121, 21);
            this.txt_rateval.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 218);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 8;
            this.label9.Text = "码流上限";
            // 
            // cmb_compress_mode
            // 
            this.cmb_compress_mode.FormattingEnabled = true;
            this.cmb_compress_mode.Items.AddRange(new object[] {
            "定码流",
            "变码流"});
            this.cmb_compress_mode.Location = new System.Drawing.Point(78, 160);
            this.cmb_compress_mode.Name = "cmb_compress_mode";
            this.cmb_compress_mode.Size = new System.Drawing.Size(121, 20);
            this.cmb_compress_mode.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "码流控制";
            // 
            // cmb_encode_type
            // 
            this.cmb_encode_type.FormattingEnabled = true;
            this.cmb_encode_type.Items.AddRange(new object[] {
            "H264"});
            this.cmb_encode_type.Location = new System.Drawing.Point(79, 126);
            this.cmb_encode_type.Name = "cmb_encode_type";
            this.cmb_encode_type.Size = new System.Drawing.Size(121, 20);
            this.cmb_encode_type.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "编码方式";
            // 
            // cmb_frame_rate
            // 
            this.cmb_frame_rate.FormattingEnabled = true;
            this.cmb_frame_rate.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25"});
            this.cmb_frame_rate.Location = new System.Drawing.Point(79, 93);
            this.cmb_frame_rate.Name = "cmb_frame_rate";
            this.cmb_frame_rate.Size = new System.Drawing.Size(121, 20);
            this.cmb_frame_rate.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "帧  率";
            // 
            // cmb_frame_size
            // 
            this.cmb_frame_size.FormattingEnabled = true;
            this.cmb_frame_size.Items.AddRange(new object[] {
            "352x288",
            "704x576",
            "1280x720",
            "1920x1080"});
            this.cmb_frame_size.Location = new System.Drawing.Point(79, 62);
            this.cmb_frame_size.Name = "cmb_frame_size";
            this.cmb_frame_size.Size = new System.Drawing.Size(121, 20);
            this.cmb_frame_size.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "分辨率";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblDefinition);
            this.tabPage2.Controls.Add(this.lblSaturation);
            this.tabPage2.Controls.Add(this.lblContrast);
            this.tabPage2.Controls.Add(this.lblBright);
            this.tabPage2.Controls.Add(this.btnRecovery);
            this.tabPage2.Controls.Add(this.cmb_img_pos);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.cmb_exposure_time);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.tbar_definition);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.tbar_saturation);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.tbar_contrast);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.tbar_bright);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(368, 353);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "视频源";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnRecovery
            // 
            this.btnRecovery.Location = new System.Drawing.Point(216, 291);
            this.btnRecovery.Name = "btnRecovery";
            this.btnRecovery.Size = new System.Drawing.Size(75, 23);
            this.btnRecovery.TabIndex = 14;
            this.btnRecovery.Text = "恢复默认";
            this.btnRecovery.UseVisualStyleBackColor = true;
            this.btnRecovery.Click += new System.EventHandler(this.btnRecovery_Click);
            // 
            // cmb_img_pos
            // 
            this.cmb_img_pos.FormattingEnabled = true;
            this.cmb_img_pos.Items.AddRange(new object[] {
            "原始图像",
            "上下翻转",
            "左右翻转",
            "中心翻转"});
            this.cmb_img_pos.Location = new System.Drawing.Point(84, 237);
            this.cmb_img_pos.Name = "cmb_img_pos";
            this.cmb_img_pos.Size = new System.Drawing.Size(140, 20);
            this.cmb_img_pos.TabIndex = 13;
            this.cmb_img_pos.SelectedIndexChanged += new System.EventHandler(this.cmb_img_pos_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(17, 240);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 12;
            this.label16.Text = "图像翻转";
            // 
            // cmb_exposure_time
            // 
            this.cmb_exposure_time.FormattingEnabled = true;
            this.cmb_exposure_time.Items.AddRange(new object[] {
            "0~1ms",
            "0~2ms",
            "0~3ms",
            "0~4ms"});
            this.cmb_exposure_time.Location = new System.Drawing.Point(84, 204);
            this.cmb_exposure_time.Name = "cmb_exposure_time";
            this.cmb_exposure_time.Size = new System.Drawing.Size(140, 20);
            this.cmb_exposure_time.TabIndex = 11;
            this.cmb_exposure_time.SelectedIndexChanged += new System.EventHandler(this.cmb_exposure_time_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(17, 207);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 12);
            this.label15.TabIndex = 10;
            this.label15.Text = "曝光时间";
            // 
            // tbar_definition
            // 
            this.tbar_definition.AutoSize = false;
            this.tbar_definition.Location = new System.Drawing.Point(83, 115);
            this.tbar_definition.Maximum = 100;
            this.tbar_definition.Name = "tbar_definition";
            this.tbar_definition.Size = new System.Drawing.Size(220, 25);
            this.tbar_definition.TabIndex = 7;
            this.tbar_definition.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbar_definition.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbar_definition_MouseUp);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 119);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 12);
            this.label13.TabIndex = 6;
            this.label13.Text = "最大增益";
            // 
            // tbar_saturation
            // 
            this.tbar_saturation.AutoSize = false;
            this.tbar_saturation.Location = new System.Drawing.Point(83, 83);
            this.tbar_saturation.Maximum = 100;
            this.tbar_saturation.Name = "tbar_saturation";
            this.tbar_saturation.Size = new System.Drawing.Size(220, 25);
            this.tbar_saturation.TabIndex = 5;
            this.tbar_saturation.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbar_saturation.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbar_saturation_MouseUp);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 87);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 12);
            this.label12.TabIndex = 4;
            this.label12.Text = "饱和度";
            // 
            // tbar_contrast
            // 
            this.tbar_contrast.AutoSize = false;
            this.tbar_contrast.Location = new System.Drawing.Point(84, 50);
            this.tbar_contrast.Maximum = 100;
            this.tbar_contrast.Name = "tbar_contrast";
            this.tbar_contrast.Size = new System.Drawing.Size(219, 25);
            this.tbar_contrast.TabIndex = 3;
            this.tbar_contrast.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbar_contrast.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbar_contrast_MouseUp);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(24, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "对比度";
            // 
            // tbar_bright
            // 
            this.tbar_bright.AutoSize = false;
            this.tbar_bright.Location = new System.Drawing.Point(83, 17);
            this.tbar_bright.Maximum = 100;
            this.tbar_bright.Name = "tbar_bright";
            this.tbar_bright.Size = new System.Drawing.Size(220, 25);
            this.tbar_bright.TabIndex = 1;
            this.tbar_bright.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbar_bright.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbar_bright_MouseUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "亮度";
            // 
            // lblDefinition
            // 
            this.lblDefinition.AutoSize = true;
            this.lblDefinition.Location = new System.Drawing.Point(309, 119);
            this.lblDefinition.Name = "lblDefinition";
            this.lblDefinition.Size = new System.Drawing.Size(0, 12);
            this.lblDefinition.TabIndex = 26;
            // 
            // lblSaturation
            // 
            this.lblSaturation.AutoSize = true;
            this.lblSaturation.Location = new System.Drawing.Point(309, 87);
            this.lblSaturation.Name = "lblSaturation";
            this.lblSaturation.Size = new System.Drawing.Size(0, 12);
            this.lblSaturation.TabIndex = 25;
            // 
            // lblContrast
            // 
            this.lblContrast.AutoSize = true;
            this.lblContrast.Location = new System.Drawing.Point(309, 54);
            this.lblContrast.Name = "lblContrast";
            this.lblContrast.Size = new System.Drawing.Size(0, 12);
            this.lblContrast.TabIndex = 24;
            // 
            // lblBright
            // 
            this.lblBright.AutoSize = true;
            this.lblBright.Location = new System.Drawing.Point(309, 21);
            this.lblBright.Name = "lblBright";
            this.lblBright.Size = new System.Drawing.Size(0, 12);
            this.lblBright.TabIndex = 23;
            // 
            // RVideoCfg_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 416);
            this.Controls.Add(this.tabControl1);
            this.Name = "RVideoCfg_Form";
            this.Text = "RVideoCfg_Form";
            this.Load += new System.EventHandler(this.RVideoCfg_Form_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_definition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_saturation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_contrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbar_bright)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cmb_img_quality;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txt_rateval;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmb_compress_mode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_encode_type;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmb_frame_rate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmb_frame_size;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnRecovery;
        private System.Windows.Forms.ComboBox cmb_img_pos;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cmb_exposure_time;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TrackBar tbar_definition;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TrackBar tbar_saturation;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TrackBar tbar_contrast;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar tbar_bright;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox m_cmbStreamType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDefinition;
        private System.Windows.Forms.Label lblSaturation;
        private System.Windows.Forms.Label lblContrast;
        private System.Windows.Forms.Label lblBright;
    }
}