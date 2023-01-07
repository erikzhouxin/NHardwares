namespace HikHCNetSDK.WinForm
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
            this.components = new System.ComponentModel.Container();
            this.TabHome = new System.Windows.Forms.TabPage();
            this.TacMainContent = new System.Windows.Forms.TabControl();
            this.CmtMainPages = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TsmiRefreshThis = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiCloseThis = new System.Windows.Forms.ToolStripMenuItem();
            this.TrmMainStart = new System.Windows.Forms.ToolStripMenuItem();
            this.TrmMainTestDemo = new System.Windows.Forms.ToolStripMenuItem();
            this.TrmUSRIO808 = new System.Windows.Forms.ToolStripMenuItem();
            this.MsrMainForm = new System.Windows.Forms.MenuStrip();
            this.TacMainContent.SuspendLayout();
            this.CmtMainPages.SuspendLayout();
            this.MsrMainForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabHome
            // 
            this.TabHome.Location = new System.Drawing.Point(4, 26);
            this.TabHome.Name = "TabHome";
            this.TabHome.Padding = new System.Windows.Forms.Padding(3);
            this.TabHome.Size = new System.Drawing.Size(876, 504);
            this.TabHome.TabIndex = 0;
            this.TabHome.Text = "首页";
            this.TabHome.UseVisualStyleBackColor = true;
            // 
            // TacMainContent
            // 
            this.TacMainContent.ContextMenuStrip = this.CmtMainPages;
            this.TacMainContent.Controls.Add(this.TabHome);
            this.TacMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TacMainContent.Location = new System.Drawing.Point(0, 27);
            this.TacMainContent.Name = "TacMainContent";
            this.TacMainContent.SelectedIndex = 0;
            this.TacMainContent.Size = new System.Drawing.Size(884, 534);
            this.TacMainContent.TabIndex = 1;
            // 
            // CmtMainPages
            // 
            this.CmtMainPages.AllowDrop = true;
            this.CmtMainPages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiRefreshThis,
            this.TsmiCloseThis});
            this.CmtMainPages.Name = "CmtMainPages";
            this.CmtMainPages.Size = new System.Drawing.Size(137, 48);
            // 
            // TsmiRefreshThis
            // 
            this.TsmiRefreshThis.Name = "TsmiRefreshThis";
            this.TsmiRefreshThis.Size = new System.Drawing.Size(136, 22);
            this.TsmiRefreshThis.Text = "刷新当前页";
            this.TsmiRefreshThis.Click += new System.EventHandler(this.TsmiRefreshThis_Click);
            // 
            // TsmiCloseThis
            // 
            this.TsmiCloseThis.Name = "TsmiCloseThis";
            this.TsmiCloseThis.Size = new System.Drawing.Size(136, 22);
            this.TsmiCloseThis.Text = "关闭当前页";
            this.TsmiCloseThis.Click += new System.EventHandler(this.TsmiCloseThis_Click);
            // 
            // TrmMainStart
            // 
            this.TrmMainStart.Name = "TrmMainStart";
            this.TrmMainStart.Size = new System.Drawing.Size(44, 21);
            this.TrmMainStart.Text = "开始";
            // 
            // TrmMainTestDemo
            // 
            this.TrmMainTestDemo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TrmUSRIO808});
            this.TrmMainTestDemo.Name = "TrmMainTestDemo";
            this.TrmMainTestDemo.Size = new System.Drawing.Size(68, 21);
            this.TrmMainTestDemo.Text = "测试示例";
            // 
            // TrmUSRIO808
            // 
            this.TrmUSRIO808.Name = "TrmUSRIO808";
            this.TrmUSRIO808.Size = new System.Drawing.Size(180, 22);
            this.TrmUSRIO808.Text = "二维码识别1";
            this.TrmUSRIO808.Click += new System.EventHandler(this.TrmUSRIO808_Click);
            // 
            // MsrMainForm
            // 
            this.MsrMainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TrmMainStart,
            this.TrmMainTestDemo});
            this.MsrMainForm.Location = new System.Drawing.Point(0, 0);
            this.MsrMainForm.Name = "MsrMainForm";
            this.MsrMainForm.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.MsrMainForm.Size = new System.Drawing.Size(884, 27);
            this.MsrMainForm.TabIndex = 0;
            this.MsrMainForm.Text = "menuStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.TacMainContent);
            this.Controls.Add(this.MsrMainForm);
            this.MainMenuStrip = this.MsrMainForm;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.TacMainContent.ResumeLayout(false);
            this.CmtMainPages.ResumeLayout(false);
            this.MsrMainForm.ResumeLayout(false);
            this.MsrMainForm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabPage TabHome;
        private System.Windows.Forms.TabControl TacMainContent;
        private System.Windows.Forms.ToolStripMenuItem TrmMainStart;
        private System.Windows.Forms.ToolStripMenuItem TrmMainTestDemo;
        private System.Windows.Forms.ToolStripMenuItem TrmUSRIO808;
        private System.Windows.Forms.MenuStrip MsrMainForm;
        private System.Windows.Forms.ContextMenuStrip CmtMainPages;
        private System.Windows.Forms.ToolStripMenuItem TsmiRefreshThis;
        private System.Windows.Forms.ToolStripMenuItem TsmiCloseThis;
    }
}