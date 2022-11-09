namespace VzClientSDKDemo
{
    partial class ParamExt_Form
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
            this.getbtn = new System.Windows.Forms.Button();
            this.setbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.snedit = new System.Windows.Forms.TextBox();
            this.getedit = new System.Windows.Forms.TextBox();
            this.setedit = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.getbtn);
            this.groupBox1.Controls.Add(this.setbtn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.snedit);
            this.groupBox1.Controls.Add(this.getedit);
            this.groupBox1.Controls.Add(this.setedit);
            this.groupBox1.Location = new System.Drawing.Point(23, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 160);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户数据（二次加密）";
            // 
            // getbtn
            // 
            this.getbtn.Location = new System.Drawing.Point(184, 75);
            this.getbtn.Name = "getbtn";
            this.getbtn.Size = new System.Drawing.Size(41, 23);
            this.getbtn.TabIndex = 5;
            this.getbtn.Text = "获取";
            this.getbtn.UseVisualStyleBackColor = true;
            this.getbtn.Click += new System.EventHandler(this.getbtn_Click);
            // 
            // setbtn
            // 
            this.setbtn.Location = new System.Drawing.Point(184, 29);
            this.setbtn.Name = "setbtn";
            this.setbtn.Size = new System.Drawing.Size(41, 23);
            this.setbtn.TabIndex = 4;
            this.setbtn.Text = "设置";
            this.setbtn.UseVisualStyleBackColor = true;
            this.setbtn.Click += new System.EventHandler(this.setbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "SN：";
            // 
            // snedit
            // 
            this.snedit.Location = new System.Drawing.Point(45, 122);
            this.snedit.Name = "snedit";
            this.snedit.ReadOnly = true;
            this.snedit.Size = new System.Drawing.Size(180, 21);
            this.snedit.TabIndex = 2;
            // 
            // getedit
            // 
            this.getedit.Location = new System.Drawing.Point(18, 77);
            this.getedit.Name = "getedit";
            this.getedit.ReadOnly = true;
            this.getedit.Size = new System.Drawing.Size(159, 21);
            this.getedit.TabIndex = 1;
            // 
            // setedit
            // 
            this.setedit.Location = new System.Drawing.Point(18, 30);
            this.setedit.Name = "setedit";
            this.setedit.Size = new System.Drawing.Size(159, 21);
            this.setedit.TabIndex = 0;
            // 
            // ParamExt_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 184);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ParamExt_Form";
            this.Text = "扩展配置";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox getedit;
        private System.Windows.Forms.TextBox setedit;
        private System.Windows.Forms.Button getbtn;
        private System.Windows.Forms.Button setbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox snedit;
    }
}