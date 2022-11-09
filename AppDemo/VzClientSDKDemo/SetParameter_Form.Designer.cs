namespace VzClientSDKDemo
{
    partial class SetParameter_Form
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
            this.Label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.widthmin = new System.Windows.Forms.TextBox();
            this.widthmax = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.preprovince = new System.Windows.Forms.ComboBox();
            this.throughdirect = new System.Windows.Forms.ComboBox();
            this.esptimeedit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.savebtn = new System.Windows.Forms.Button();
            this.cancelbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(30, 32);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(83, 12);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "车牌宽度限制:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(170, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "-";
            // 
            // widthmin
            // 
            this.widthmin.Location = new System.Drawing.Point(120, 27);
            this.widthmin.Name = "widthmin";
            this.widthmin.Size = new System.Drawing.Size(43, 21);
            this.widthmin.TabIndex = 2;
            // 
            // widthmax
            // 
            this.widthmax.Location = new System.Drawing.Point(187, 27);
            this.widthmax.Name = "widthmax";
            this.widthmax.Size = new System.Drawing.Size(43, 21);
            this.widthmax.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "相同车牌触发间隔时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "预设省份:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "车辆通过方向：";
            // 
            // preprovince
            // 
            this.preprovince.FormattingEnabled = true;
            this.preprovince.Location = new System.Drawing.Point(169, 65);
            this.preprovince.Name = "preprovince";
            this.preprovince.Size = new System.Drawing.Size(61, 20);
            this.preprovince.TabIndex = 7;
            this.preprovince.SelectedIndexChanged += new System.EventHandler(this.preprovince_SelectedIndexChanged);
            // 
            // throughdirect
            // 
            this.throughdirect.FormattingEnabled = true;
            this.throughdirect.Items.AddRange(new object[] {
            "双向",
            "由上至下",
            "由下至上"});
            this.throughdirect.Location = new System.Drawing.Point(169, 109);
            this.throughdirect.Name = "throughdirect";
            this.throughdirect.Size = new System.Drawing.Size(61, 20);
            this.throughdirect.TabIndex = 8;
            // 
            // esptimeedit
            // 
            this.esptimeedit.Location = new System.Drawing.Point(171, 155);
            this.esptimeedit.Name = "esptimeedit";
            this.esptimeedit.Size = new System.Drawing.Size(39, 21);
            this.esptimeedit.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(216, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "秒";
            // 
            // savebtn
            // 
            this.savebtn.Location = new System.Drawing.Point(56, 210);
            this.savebtn.Name = "savebtn";
            this.savebtn.Size = new System.Drawing.Size(75, 23);
            this.savebtn.TabIndex = 11;
            this.savebtn.Text = "保存";
            this.savebtn.UseVisualStyleBackColor = true;
            this.savebtn.Click += new System.EventHandler(this.savebtn_Click);
            // 
            // cancelbtn
            // 
            this.cancelbtn.Location = new System.Drawing.Point(158, 210);
            this.cancelbtn.Name = "cancelbtn";
            this.cancelbtn.Size = new System.Drawing.Size(75, 23);
            this.cancelbtn.TabIndex = 12;
            this.cancelbtn.Text = "取消";
            this.cancelbtn.UseVisualStyleBackColor = true;
            // 
            // SetParameter_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 256);
            this.Controls.Add(this.cancelbtn);
            this.Controls.Add(this.savebtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.esptimeedit);
            this.Controls.Add(this.throughdirect);
            this.Controls.Add(this.preprovince);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.widthmax);
            this.Controls.Add(this.widthmin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "SetParameter_Form";
            this.Text = "设置参数";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox widthmin;
        private System.Windows.Forms.TextBox widthmax;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox preprovince;
        private System.Windows.Forms.ComboBox throughdirect;
        private System.Windows.Forms.TextBox esptimeedit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button savebtn;
        private System.Windows.Forms.Button cancelbtn;
    }
}