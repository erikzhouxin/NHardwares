namespace TestHardwareDemo.WinForm.Controls
{
    partial class VzLPRSDKDemoNetIOValue
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.GrbGetSetIOValue = new System.Windows.Forms.GroupBox();
            this.GrbIOContent = new System.Windows.Forms.GroupBox();
            this.LblIONum = new System.Windows.Forms.Label();
            this.LblInputNum = new System.Windows.Forms.Label();
            this.BtnSetIONum2 = new System.Windows.Forms.Button();
            this.BtnGetIONum2 = new System.Windows.Forms.Button();
            this.BtnSetIONum1 = new System.Windows.Forms.Button();
            this.BtnGetIONum1 = new System.Windows.Forms.Button();
            this.ChkInputNum2 = new System.Windows.Forms.CheckBox();
            this.ChkIONum2 = new System.Windows.Forms.CheckBox();
            this.ChkInputNum1 = new System.Windows.Forms.CheckBox();
            this.ChkIONum1 = new System.Windows.Forms.CheckBox();
            this.LblIONum2 = new System.Windows.Forms.Label();
            this.LblIONum1 = new System.Windows.Forms.Label();
            this.GrbGetSetIOValue.SuspendLayout();
            this.GrbIOContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrbGetSetIOValue
            // 
            this.GrbGetSetIOValue.Controls.Add(this.GrbIOContent);
            this.GrbGetSetIOValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrbGetSetIOValue.Location = new System.Drawing.Point(0, 0);
            this.GrbGetSetIOValue.Name = "GrbGetSetIOValue";
            this.GrbGetSetIOValue.Size = new System.Drawing.Size(488, 396);
            this.GrbGetSetIOValue.TabIndex = 0;
            this.GrbGetSetIOValue.TabStop = false;
            this.GrbGetSetIOValue.Text = "设置输入输出";
            // 
            // GrbIOContent
            // 
            this.GrbIOContent.Controls.Add(this.LblIONum);
            this.GrbIOContent.Controls.Add(this.LblInputNum);
            this.GrbIOContent.Controls.Add(this.BtnSetIONum2);
            this.GrbIOContent.Controls.Add(this.BtnGetIONum2);
            this.GrbIOContent.Controls.Add(this.BtnSetIONum1);
            this.GrbIOContent.Controls.Add(this.BtnGetIONum1);
            this.GrbIOContent.Controls.Add(this.ChkInputNum2);
            this.GrbIOContent.Controls.Add(this.ChkIONum2);
            this.GrbIOContent.Controls.Add(this.ChkInputNum1);
            this.GrbIOContent.Controls.Add(this.ChkIONum1);
            this.GrbIOContent.Controls.Add(this.LblIONum2);
            this.GrbIOContent.Controls.Add(this.LblIONum1);
            this.GrbIOContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrbIOContent.Location = new System.Drawing.Point(3, 19);
            this.GrbIOContent.MinimumSize = new System.Drawing.Size(480, 100);
            this.GrbIOContent.Name = "GrbIOContent";
            this.GrbIOContent.Size = new System.Drawing.Size(482, 135);
            this.GrbIOContent.TabIndex = 0;
            this.GrbIOContent.TabStop = false;
            this.GrbIOContent.Text = "开关量电平";
            // 
            // LblIONum
            // 
            this.LblIONum.AutoSize = true;
            this.LblIONum.Location = new System.Drawing.Point(199, 29);
            this.LblIONum.Name = "LblIONum";
            this.LblIONum.Size = new System.Drawing.Size(56, 17);
            this.LblIONum.TabIndex = 8;
            this.LblIONum.Text = "输入输出";
            // 
            // LblInputNum
            // 
            this.LblInputNum.AutoSize = true;
            this.LblInputNum.Location = new System.Drawing.Point(128, 29);
            this.LblInputNum.Name = "LblInputNum";
            this.LblInputNum.Size = new System.Drawing.Size(56, 17);
            this.LblInputNum.TabIndex = 8;
            this.LblInputNum.Text = "电平输入";
            // 
            // BtnSetIONum2
            // 
            this.BtnSetIONum2.Location = new System.Drawing.Point(380, 93);
            this.BtnSetIONum2.Name = "BtnSetIONum2";
            this.BtnSetIONum2.Size = new System.Drawing.Size(75, 23);
            this.BtnSetIONum2.TabIndex = 7;
            this.BtnSetIONum2.Text = "设置";
            this.BtnSetIONum2.UseVisualStyleBackColor = true;
            this.BtnSetIONum2.Click += new System.EventHandler(this.BtnSetIONum2_Click);
            // 
            // BtnGetIONum2
            // 
            this.BtnGetIONum2.Location = new System.Drawing.Point(280, 93);
            this.BtnGetIONum2.Name = "BtnGetIONum2";
            this.BtnGetIONum2.Size = new System.Drawing.Size(75, 23);
            this.BtnGetIONum2.TabIndex = 6;
            this.BtnGetIONum2.Text = "获取";
            this.BtnGetIONum2.UseVisualStyleBackColor = true;
            this.BtnGetIONum2.Click += new System.EventHandler(this.BtnGetIONum2_Click);
            // 
            // BtnSetIONum1
            // 
            this.BtnSetIONum1.Location = new System.Drawing.Point(380, 58);
            this.BtnSetIONum1.Name = "BtnSetIONum1";
            this.BtnSetIONum1.Size = new System.Drawing.Size(75, 23);
            this.BtnSetIONum1.TabIndex = 5;
            this.BtnSetIONum1.Text = "设置";
            this.BtnSetIONum1.UseVisualStyleBackColor = true;
            this.BtnSetIONum1.Click += new System.EventHandler(this.BtnSetIONum1_Click);
            // 
            // BtnGetIONum1
            // 
            this.BtnGetIONum1.Location = new System.Drawing.Point(280, 58);
            this.BtnGetIONum1.Name = "BtnGetIONum1";
            this.BtnGetIONum1.Size = new System.Drawing.Size(75, 23);
            this.BtnGetIONum1.TabIndex = 4;
            this.BtnGetIONum1.Text = "获取";
            this.BtnGetIONum1.UseVisualStyleBackColor = true;
            this.BtnGetIONum1.Click += new System.EventHandler(this.BtnGetIONum1_Click);
            // 
            // ChkInputNum2
            // 
            this.ChkInputNum2.AutoSize = true;
            this.ChkInputNum2.Enabled = false;
            this.ChkInputNum2.Location = new System.Drawing.Point(128, 93);
            this.ChkInputNum2.Name = "ChkInputNum2";
            this.ChkInputNum2.Size = new System.Drawing.Size(51, 21);
            this.ChkInputNum2.TabIndex = 3;
            this.ChkInputNum2.Text = "开路";
            this.ChkInputNum2.UseVisualStyleBackColor = true;
            this.ChkInputNum2.CheckedChanged += new System.EventHandler(this.ChkInputNum2_CheckedChanged);
            // 
            // ChkIONum2
            // 
            this.ChkIONum2.AutoSize = true;
            this.ChkIONum2.Location = new System.Drawing.Point(204, 94);
            this.ChkIONum2.Name = "ChkIONum2";
            this.ChkIONum2.Size = new System.Drawing.Size(51, 21);
            this.ChkIONum2.TabIndex = 3;
            this.ChkIONum2.Text = "开路";
            this.ChkIONum2.UseVisualStyleBackColor = true;
            this.ChkIONum2.CheckedChanged += new System.EventHandler(this.ChkIONum2_CheckedChanged);
            // 
            // ChkInputNum1
            // 
            this.ChkInputNum1.AutoSize = true;
            this.ChkInputNum1.Enabled = false;
            this.ChkInputNum1.Location = new System.Drawing.Point(128, 59);
            this.ChkInputNum1.Name = "ChkInputNum1";
            this.ChkInputNum1.Size = new System.Drawing.Size(51, 21);
            this.ChkInputNum1.TabIndex = 2;
            this.ChkInputNum1.Text = "开路";
            this.ChkInputNum1.UseVisualStyleBackColor = true;
            this.ChkInputNum1.CheckedChanged += new System.EventHandler(this.ChkInputNum1_CheckedChanged);
            // 
            // ChkIONum1
            // 
            this.ChkIONum1.AutoSize = true;
            this.ChkIONum1.Location = new System.Drawing.Point(204, 59);
            this.ChkIONum1.Name = "ChkIONum1";
            this.ChkIONum1.Size = new System.Drawing.Size(51, 21);
            this.ChkIONum1.TabIndex = 2;
            this.ChkIONum1.Text = "开路";
            this.ChkIONum1.UseVisualStyleBackColor = true;
            this.ChkIONum1.CheckedChanged += new System.EventHandler(this.ChkIONum1_CheckedChanged);
            // 
            // LblIONum2
            // 
            this.LblIONum2.AutoSize = true;
            this.LblIONum2.Location = new System.Drawing.Point(11, 96);
            this.LblIONum2.Name = "LblIONum2";
            this.LblIONum2.Size = new System.Drawing.Size(92, 17);
            this.LblIONum2.TabIndex = 1;
            this.LblIONum2.Text = "开关量/电平2：";
            // 
            // LblIONum1
            // 
            this.LblIONum1.AutoSize = true;
            this.LblIONum1.Location = new System.Drawing.Point(11, 61);
            this.LblIONum1.Name = "LblIONum1";
            this.LblIONum1.Size = new System.Drawing.Size(92, 17);
            this.LblIONum1.TabIndex = 0;
            this.LblIONum1.Text = "开关量/电平1：";
            // 
            // VzLPRSDKDemoNetIOValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.GrbGetSetIOValue);
            this.Name = "VzLPRSDKDemoNetIOValue";
            this.Size = new System.Drawing.Size(488, 396);
            this.Load += new System.EventHandler(this.VzLPRSDKDemoNetIOValue_Load);
            this.GrbGetSetIOValue.ResumeLayout(false);
            this.GrbIOContent.ResumeLayout(false);
            this.GrbIOContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrbGetSetIOValue;
        private System.Windows.Forms.GroupBox GrbIOContent;
        private System.Windows.Forms.Label LblIONum1;
        private System.Windows.Forms.Label LblIONum2;
        private System.Windows.Forms.CheckBox ChkIONum2;
        private System.Windows.Forms.CheckBox ChkIONum1;
        private System.Windows.Forms.Button BtnSetIONum2;
        private System.Windows.Forms.Button BtnGetIONum2;
        private System.Windows.Forms.Button BtnSetIONum1;
        private System.Windows.Forms.Button BtnGetIONum1;
        private System.Windows.Forms.Label LblIONum;
        private System.Windows.Forms.Label LblInputNum;
        private System.Windows.Forms.CheckBox ChkInputNum2;
        private System.Windows.Forms.CheckBox ChkInputNum1;
    }
}
