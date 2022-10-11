namespace System.Data.ShenBanReader.WinForm
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开官方示例ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开轮询天线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开自动读取ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打开快速天线ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(961, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开官方示例ToolStripMenuItem,
            this.打开轮询天线ToolStripMenuItem,
            this.打开自动读取ToolStripMenuItem,
            this.打开快速天线ToolStripMenuItem});
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.开始ToolStripMenuItem.Text = "开始";
            // 
            // 打开官方示例ToolStripMenuItem
            // 
            this.打开官方示例ToolStripMenuItem.Name = "打开官方示例ToolStripMenuItem";
            this.打开官方示例ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.打开官方示例ToolStripMenuItem.Text = "打开官方示例";
            this.打开官方示例ToolStripMenuItem.Click += new System.EventHandler(this.打开官方示例ToolStripMenuItem_Click);
            // 
            // 打开轮询天线ToolStripMenuItem
            // 
            this.打开轮询天线ToolStripMenuItem.Name = "打开轮询天线ToolStripMenuItem";
            this.打开轮询天线ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.打开轮询天线ToolStripMenuItem.Text = "打开轮询天线";
            // 
            // 打开自动读取ToolStripMenuItem
            // 
            this.打开自动读取ToolStripMenuItem.Name = "打开自动读取ToolStripMenuItem";
            this.打开自动读取ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.打开自动读取ToolStripMenuItem.Text = "打开自动读取";
            this.打开自动读取ToolStripMenuItem.Click += new System.EventHandler(this.打开自动读取ToolStripMenuItem_Click);
            // 
            // 打开快速天线ToolStripMenuItem
            // 
            this.打开快速天线ToolStripMenuItem.Name = "打开快速天线ToolStripMenuItem";
            this.打开快速天线ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.打开快速天线ToolStripMenuItem.Text = "打开快速天线";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 598);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Windows.Forms.MenuStrip menuStrip1;
        private Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private Windows.Forms.ToolStripMenuItem 打开官方示例ToolStripMenuItem;
        private Windows.Forms.ToolStripMenuItem 打开轮询天线ToolStripMenuItem;
        private Windows.Forms.ToolStripMenuItem 打开自动读取ToolStripMenuItem;
        private Windows.Forms.ToolStripMenuItem 打开快速天线ToolStripMenuItem;
    }
}