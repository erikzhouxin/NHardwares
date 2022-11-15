namespace ShenBanReader.WinForm
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
            this.TrmMainStart = new System.Windows.Forms.ToolStripMenuItem();
            this.TrmMainOrgDemo = new System.Windows.Forms.ToolStripMenuItem();
            this.TrmMainScanAnt = new System.Windows.Forms.ToolStripMenuItem();
            this.TrmMainAutoScan = new System.Windows.Forms.ToolStripMenuItem();
            this.TrmMainFastAntDemo = new System.Windows.Forms.ToolStripMenuItem();
            this.测试示例ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TrmMainScanLogic = new System.Windows.Forms.ToolStripMenuItem();
            this.MsrMainForm = new System.Windows.Forms.MenuStrip();
            this.CmtMainPages = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TsmiCloseThis = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiRefreshThis = new System.Windows.Forms.ToolStripMenuItem();
            this.TacMainContent.SuspendLayout();
            this.MsrMainForm.SuspendLayout();
            this.CmtMainPages.SuspendLayout();
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
            // TrmMainStart
            // 
            this.TrmMainStart.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TrmMainOrgDemo,
            this.TrmMainScanAnt,
            this.TrmMainAutoScan,
            this.TrmMainFastAntDemo});
            this.TrmMainStart.Name = "TrmMainStart";
            this.TrmMainStart.Size = new System.Drawing.Size(44, 21);
            this.TrmMainStart.Text = "开始";
            // 
            // TrmMainOrgDemo
            // 
            this.TrmMainOrgDemo.Name = "TrmMainOrgDemo";
            this.TrmMainOrgDemo.Size = new System.Drawing.Size(148, 22);
            this.TrmMainOrgDemo.Text = "打开官方示例";
            // 
            // TrmMainScanAnt
            // 
            this.TrmMainScanAnt.Name = "TrmMainScanAnt";
            this.TrmMainScanAnt.Size = new System.Drawing.Size(148, 22);
            this.TrmMainScanAnt.Text = "打开轮询天线";
            // 
            // TrmMainAutoScan
            // 
            this.TrmMainAutoScan.Name = "TrmMainAutoScan";
            this.TrmMainAutoScan.Size = new System.Drawing.Size(148, 22);
            this.TrmMainAutoScan.Text = "打开自动读取";
            this.TrmMainAutoScan.Click += new System.EventHandler(this.TrmMainAutoScan_Click);
            // 
            // TrmMainFastAntDemo
            // 
            this.TrmMainFastAntDemo.Name = "TrmMainFastAntDemo";
            this.TrmMainFastAntDemo.Size = new System.Drawing.Size(148, 22);
            this.TrmMainFastAntDemo.Text = "打开快速天线";
            // 
            // 测试示例ToolStripMenuItem
            // 
            this.测试示例ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TrmMainScanLogic});
            this.测试示例ToolStripMenuItem.Name = "测试示例ToolStripMenuItem";
            this.测试示例ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.测试示例ToolStripMenuItem.Text = "测试示例";
            // 
            // TrmMainScanLogic
            // 
            this.TrmMainScanLogic.Name = "TrmMainScanLogic";
            this.TrmMainScanLogic.Size = new System.Drawing.Size(148, 22);
            this.TrmMainScanLogic.Text = "测试扫描逻辑";
            this.TrmMainScanLogic.Click += new System.EventHandler(this.TrmMainScanLogic_Click);
            // 
            // MsrMainForm
            // 
            this.MsrMainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TrmMainStart,
            this.测试示例ToolStripMenuItem});
            this.MsrMainForm.Location = new System.Drawing.Point(0, 0);
            this.MsrMainForm.Name = "MsrMainForm";
            this.MsrMainForm.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.MsrMainForm.Size = new System.Drawing.Size(884, 27);
            this.MsrMainForm.TabIndex = 0;
            this.MsrMainForm.Text = "menuStrip1";
            // 
            // CmtMainPages
            // 
            this.CmtMainPages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiRefreshThis,
            this.TsmiCloseThis});
            this.CmtMainPages.Name = "CmtMainPages";
            this.CmtMainPages.Size = new System.Drawing.Size(181, 70);
            // 
            // TsmiCloseThis
            // 
            this.TsmiCloseThis.Name = "TsmiCloseThis";
            this.TsmiCloseThis.Size = new System.Drawing.Size(180, 22);
            this.TsmiCloseThis.Text = "关闭当前页";
            this.TsmiCloseThis.Click += new System.EventHandler(this.TsmiCloseThis_Click);
            // 
            // TsmiRefreshThis
            // 
            this.TsmiRefreshThis.Name = "TsmiRefreshThis";
            this.TsmiRefreshThis.Size = new System.Drawing.Size(180, 22);
            this.TsmiRefreshThis.Text = "刷新当前页";
            this.TsmiRefreshThis.Click += new System.EventHandler(this.TsmiRefreshThis_Click);
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
            this.MsrMainForm.ResumeLayout(false);
            this.MsrMainForm.PerformLayout();
            this.CmtMainPages.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabPage TabHome;
        private System.Windows.Forms.TabControl TacMainContent;
        private System.Windows.Forms.ToolStripMenuItem TrmMainStart;
        private System.Windows.Forms.ToolStripMenuItem TrmMainOrgDemo;
        private System.Windows.Forms.ToolStripMenuItem TrmMainScanAnt;
        private System.Windows.Forms.ToolStripMenuItem TrmMainAutoScan;
        private System.Windows.Forms.ToolStripMenuItem TrmMainFastAntDemo;
        private System.Windows.Forms.ToolStripMenuItem 测试示例ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TrmMainScanLogic;
        private System.Windows.Forms.MenuStrip MsrMainForm;
        private System.Windows.Forms.ContextMenuStrip CmtMainPages;
        private System.Windows.Forms.ToolStripMenuItem TsmiRefreshThis;
        private System.Windows.Forms.ToolStripMenuItem TsmiCloseThis;
    }
}