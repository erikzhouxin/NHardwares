namespace VzClientSDKDemo
{
    partial class Form3
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
            this.strPalatID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.isenable = new System.Windows.Forms.CheckBox();
            this.isalarm = new System.Windows.Forms.CheckBox();
            this.save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.datalist = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // strPalatID
            // 
            this.strPalatID.Location = new System.Drawing.Point(96, 35);
            this.strPalatID.Name = "strPalatID";
            this.strPalatID.Size = new System.Drawing.Size(120, 21);
            this.strPalatID.TabIndex = 0;
            this.strPalatID.TextChanged += new System.EventHandler(this.strPalatID_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "车牌号：";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "是否报警：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "过期时间：";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "是否启用：";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // isenable
            // 
            this.isenable.AutoSize = true;
            this.isenable.Location = new System.Drawing.Point(96, 72);
            this.isenable.Name = "isenable";
            this.isenable.Size = new System.Drawing.Size(36, 16);
            this.isenable.TabIndex = 6;
            this.isenable.Text = "是";
            this.isenable.UseVisualStyleBackColor = true;
            this.isenable.CheckedChanged += new System.EventHandler(this.isenable_CheckedChanged);
            // 
            // isalarm
            // 
            this.isalarm.AutoSize = true;
            this.isalarm.Location = new System.Drawing.Point(96, 136);
            this.isalarm.Name = "isalarm";
            this.isalarm.Size = new System.Drawing.Size(36, 16);
            this.isalarm.TabIndex = 7;
            this.isalarm.Text = "是";
            this.isalarm.UseVisualStyleBackColor = true;
            this.isalarm.CheckedChanged += new System.EventHandler(this.isalarm_CheckedChanged);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(35, 172);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(51, 23);
            this.save.TabIndex = 8;
            this.save.Text = "保存";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(128, 171);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(54, 23);
            this.cancel.TabIndex = 9;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // datalist
            // 
            this.datalist.Location = new System.Drawing.Point(96, 99);
            this.datalist.Name = "datalist";
            this.datalist.Size = new System.Drawing.Size(117, 21);
            this.datalist.TabIndex = 10;
            this.datalist.ValueChanged += new System.EventHandler(this.datalist_ValueChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 215);
            this.Controls.Add(this.datalist);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.save);
            this.Controls.Add(this.isalarm);
            this.Controls.Add(this.isenable);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.strPalatID);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox strPalatID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox isenable;
        private System.Windows.Forms.CheckBox isalarm;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.DateTimePicker datalist;
    }
}