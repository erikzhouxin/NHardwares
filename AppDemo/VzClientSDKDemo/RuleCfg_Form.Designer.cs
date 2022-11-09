namespace VzClientSDKDemo
{
    partial class RuleCfg_Form
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
            this.picBoxVideo = new System.Windows.Forms.PictureBox();
            this.btnAddRule = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRuleName = new System.Windows.Forms.TextBox();
            this.txtMinWidth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.chkDraw = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMaxWidth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTimes = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbDir = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDeleRule = new System.Windows.Forms.Button();
            this.btnROI = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxVideo)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxVideo
            // 
            this.picBoxVideo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxVideo.Location = new System.Drawing.Point(12, 38);
            this.picBoxVideo.Name = "picBoxVideo";
            this.picBoxVideo.Size = new System.Drawing.Size(793, 515);
            this.picBoxVideo.TabIndex = 1;
            this.picBoxVideo.TabStop = false;
            this.picBoxVideo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picBoxVideo_MouseMove);
            this.picBoxVideo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picBoxVideo_MouseDown);
            this.picBoxVideo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picBoxVideo_MouseUp);
            // 
            // btnAddRule
            // 
            this.btnAddRule.Location = new System.Drawing.Point(12, 9);
            this.btnAddRule.Name = "btnAddRule";
            this.btnAddRule.Size = new System.Drawing.Size(75, 23);
            this.btnAddRule.TabIndex = 2;
            this.btnAddRule.Text = "添加线圈";
            this.btnAddRule.UseVisualStyleBackColor = true;
            this.btnAddRule.Click += new System.EventHandler(this.btnAddRule_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(817, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "规则名称";
            // 
            // txtRuleName
            // 
            this.txtRuleName.Enabled = false;
            this.txtRuleName.Location = new System.Drawing.Point(881, 45);
            this.txtRuleName.Name = "txtRuleName";
            this.txtRuleName.Size = new System.Drawing.Size(120, 21);
            this.txtRuleName.TabIndex = 4;
            // 
            // txtMinWidth
            // 
            this.txtMinWidth.Location = new System.Drawing.Point(900, 136);
            this.txtMinWidth.Name = "txtMinWidth";
            this.txtMinWidth.Size = new System.Drawing.Size(35, 21);
            this.txtMinWidth.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(817, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "车牌宽度限制";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(817, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "是否检测 ";
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Enabled = false;
            this.chkEnable.Location = new System.Drawing.Point(881, 82);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(36, 16);
            this.chkEnable.TabIndex = 8;
            this.chkEnable.Text = "是";
            this.chkEnable.UseVisualStyleBackColor = true;
            // 
            // chkDraw
            // 
            this.chkDraw.AutoSize = true;
            this.chkDraw.Enabled = false;
            this.chkDraw.Location = new System.Drawing.Point(881, 110);
            this.chkDraw.Name = "chkDraw";
            this.chkDraw.Size = new System.Drawing.Size(36, 16);
            this.chkDraw.TabIndex = 10;
            this.chkDraw.Text = "是";
            this.chkDraw.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(817, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "是否绘制";
            // 
            // txtMaxWidth
            // 
            this.txtMaxWidth.Location = new System.Drawing.Point(958, 136);
            this.txtMaxWidth.Name = "txtMaxWidth";
            this.txtMaxWidth.Size = new System.Drawing.Size(35, 21);
            this.txtMaxWidth.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(941, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "-";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1003, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "(45-600)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(817, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "相同车牌触发间隔时间";
            // 
            // txtTimes
            // 
            this.txtTimes.Location = new System.Drawing.Point(948, 168);
            this.txtTimes.Name = "txtTimes";
            this.txtTimes.Size = new System.Drawing.Size(35, 21);
            this.txtTimes.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(993, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 16;
            this.label8.Text = "秒 (0-255)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(817, 207);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "车辆通过方向";
            // 
            // cmbDir
            // 
            this.cmbDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDir.FormattingEnabled = true;
            this.cmbDir.Items.AddRange(new object[] {
            "双向",
            "由上至下",
            "从下至上"});
            this.cmbDir.Location = new System.Drawing.Point(900, 204);
            this.cmbDir.Name = "cmbDir";
            this.cmbDir.Size = new System.Drawing.Size(80, 20);
            this.cmbDir.TabIndex = 18;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(900, 238);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(52, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDeleRule
            // 
            this.btnDeleRule.Location = new System.Drawing.Point(101, 9);
            this.btnDeleRule.Name = "btnDeleRule";
            this.btnDeleRule.Size = new System.Drawing.Size(75, 23);
            this.btnDeleRule.TabIndex = 20;
            this.btnDeleRule.Text = "删除线圈";
            this.btnDeleRule.UseVisualStyleBackColor = true;
            this.btnDeleRule.Click += new System.EventHandler(this.btnDeleRule_Click);
            // 
            // btnROI
            // 
            this.btnROI.Location = new System.Drawing.Point(206, 9);
            this.btnROI.Name = "btnROI";
            this.btnROI.Size = new System.Drawing.Size(102, 23);
            this.btnROI.TabIndex = 21;
            this.btnROI.Text = "获取识别区域";
            this.btnROI.UseVisualStyleBackColor = true;
            this.btnROI.Click += new System.EventHandler(this.btnROI_Click);
            // 
            // RuleCfg_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 557);
            this.Controls.Add(this.btnROI);
            this.Controls.Add(this.btnDeleRule);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbDir);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtTimes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMaxWidth);
            this.Controls.Add(this.chkDraw);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkEnable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMinWidth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRuleName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddRule);
            this.Controls.Add(this.picBoxVideo);
            this.MaximizeBox = false;
            this.Name = "RuleCfg_Form";
            this.Text = "规则配置";
            this.Load += new System.EventHandler(this.RuleCfg_Form_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RuleCfg_Form_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxVideo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxVideo;
        private System.Windows.Forms.Button btnAddRule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRuleName;
        private System.Windows.Forms.TextBox txtMinWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkEnable;
        private System.Windows.Forms.CheckBox chkDraw;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMaxWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTimes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbDir;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDeleRule;
        private System.Windows.Forms.Button btnROI;
    }
}