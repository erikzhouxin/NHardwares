namespace VzClientSDKDemo
{
    partial class AlgResultParamCfg
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
            this.radled6 = new System.Windows.Forms.RadioButton();
            this.radled4 = new System.Windows.Forms.RadioButton();
            this.radled2 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // radled6
            // 
            this.radled6.AutoSize = true;
            this.radled6.Location = new System.Drawing.Point(180, 62);
            this.radled6.Name = "radled6";
            this.radled6.Size = new System.Drawing.Size(53, 16);
            this.radled6.TabIndex = 5;
            this.radled6.TabStop = true;
            this.radled6.Text = "6-8米";
            this.radled6.UseVisualStyleBackColor = true;
            this.radled6.CheckedChanged += new System.EventHandler(this.radled6_CheckedChanged);
            // 
            // radled4
            // 
            this.radled4.AutoSize = true;
            this.radled4.Location = new System.Drawing.Point(113, 63);
            this.radled4.Name = "radled4";
            this.radled4.Size = new System.Drawing.Size(53, 16);
            this.radled4.TabIndex = 4;
            this.radled4.TabStop = true;
            this.radled4.Text = "4-6米";
            this.radled4.UseVisualStyleBackColor = true;
            this.radled4.CheckedChanged += new System.EventHandler(this.radled4_CheckedChanged);
            // 
            // radled2
            // 
            this.radled2.AutoSize = true;
            this.radled2.Location = new System.Drawing.Point(51, 63);
            this.radled2.Name = "radled2";
            this.radled2.Size = new System.Drawing.Size(53, 16);
            this.radled2.TabIndex = 3;
            this.radled2.TabStop = true;
            this.radled2.Text = "2-4米";
            this.radled2.UseVisualStyleBackColor = true;
            this.radled2.CheckedChanged += new System.EventHandler(this.radled2_CheckedChanged);
            // 
            // AlgResultParamCfg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 140);
            this.Controls.Add(this.radled6);
            this.Controls.Add(this.radled4);
            this.Controls.Add(this.radled2);
            this.Name = "AlgResultParamCfg";
            this.Text = "定焦配置";
            this.Load += new System.EventHandler(this.AlgResultParamCfg_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radled6;
        private System.Windows.Forms.RadioButton radled4;
        private System.Windows.Forms.RadioButton radled2;
    }
}