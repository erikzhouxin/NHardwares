namespace VzClientSDKDemo
{
    partial class WhiteListChange_Form
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
            this.datalist = new System.Windows.Forms.DateTimePicker();
            this.cancel = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.isalarm = new System.Windows.Forms.CheckBox();
            this.isenable = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.strPalatID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // datalist
            // 
            this.datalist.Location = new System.Drawing.Point(94, 102);
            this.datalist.Name = "datalist";
            this.datalist.Size = new System.Drawing.Size(117, 21);
            this.datalist.TabIndex = 20;
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(126, 174);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(54, 23);
            this.cancel.TabIndex = 19;
            this.cancel.Text = "取消";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click_1);
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(33, 175);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(51, 23);
            this.save.TabIndex = 18;
            this.save.Text = "保存";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // isalarm
            // 
            this.isalarm.AutoSize = true;
            this.isalarm.Location = new System.Drawing.Point(94, 139);
            this.isalarm.Name = "isalarm";
            this.isalarm.Size = new System.Drawing.Size(36, 16);
            this.isalarm.TabIndex = 17;
            this.isalarm.Text = "是";
            this.isalarm.UseVisualStyleBackColor = true;
            // 
            // isenable
            // 
            this.isenable.AutoSize = true;
            this.isenable.Location = new System.Drawing.Point(94, 75);
            this.isenable.Name = "isenable";
            this.isenable.Size = new System.Drawing.Size(36, 16);
            this.isenable.TabIndex = 16;
            this.isenable.Text = "是";
            this.isenable.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "是否启用：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 14;
            this.label3.Text = "过期时间：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "是否报警：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 12;
            this.label1.Text = "车牌号：";
            // 
            // strPalatID
            // 
            this.strPalatID.Location = new System.Drawing.Point(94, 38);
            this.strPalatID.Name = "strPalatID";
            this.strPalatID.Size = new System.Drawing.Size(120, 21);
            this.strPalatID.TabIndex = 11;
            // 
            // WhiteListChange_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 237);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "WhiteListChange_Form";
            this.Text = "修改";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datalist;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.CheckBox isalarm;
        private System.Windows.Forms.CheckBox isenable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox strPalatID;
    }
}