namespace VzClientSDKDemo
{
    partial class PlayVoice
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
            this.btnPlayVoice = new System.Windows.Forms.Button();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnPlayVoice
            // 
            this.btnPlayVoice.Location = new System.Drawing.Point(200, 87);
            this.btnPlayVoice.Name = "btnPlayVoice";
            this.btnPlayVoice.Size = new System.Drawing.Size(81, 23);
            this.btnPlayVoice.TabIndex = 0;
            this.btnPlayVoice.Text = "播放语音";
            this.btnPlayVoice.UseVisualStyleBackColor = true;
            this.btnPlayVoice.Click += new System.EventHandler(this.btnPlayVoice_Click);
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(12, 51);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(269, 21);
            this.txtContent.TabIndex = 1;
            // 
            // PlayVoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 122);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.btnPlayVoice);
            this.Name = "PlayVoice";
            this.Text = "TTS语音功能";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPlayVoice;
        private System.Windows.Forms.TextBox txtContent;
    }
}