namespace TestHardwareDemo.WinForm
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
            this.TsmiCloseOther = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmiCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.TrmMainStart = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmrRefreshThis = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmrCloseThis = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmrCloseOther = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmrCloseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.TsmrMainStartSplit = new System.Windows.Forms.ToolStripSeparator();
            this.TsmrExitSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.MsrMainForm = new System.Windows.Forms.MenuStrip();
            this.TrmMainHardwareMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.homeControl1 = new TestHardwareDemo.WinForm.Views.HomeControl();
            this.TabHome.SuspendLayout();
            this.TacMainContent.SuspendLayout();
            this.CmtMainPages.SuspendLayout();
            this.MsrMainForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabHome
            // 
            this.TabHome.Controls.Add(this.homeControl1);
            this.TabHome.Location = new System.Drawing.Point(4, 26);
            this.TabHome.Name = "TabHome";
            this.TabHome.Padding = new System.Windows.Forms.Padding(3);
            this.TabHome.Size = new System.Drawing.Size(792, 393);
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
            this.TacMainContent.Size = new System.Drawing.Size(800, 423);
            this.TacMainContent.TabIndex = 3;
            // 
            // CmtMainPages
            // 
            this.CmtMainPages.AllowDrop = true;
            this.CmtMainPages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmiRefreshThis,
            this.TsmiCloseThis,
            this.TsmiCloseOther,
            this.TsmiCloseAll});
            this.CmtMainPages.Name = "CmtMainPages";
            this.CmtMainPages.Size = new System.Drawing.Size(137, 92);
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
            // TsmiCloseOther
            // 
            this.TsmiCloseOther.Name = "TsmiCloseOther";
            this.TsmiCloseOther.Size = new System.Drawing.Size(136, 22);
            this.TsmiCloseOther.Text = "关闭其他页";
            this.TsmiCloseOther.Click += new System.EventHandler(this.TsmiCloseOther_Click);
            // 
            // TsmiCloseAll
            // 
            this.TsmiCloseAll.Name = "TsmiCloseAll";
            this.TsmiCloseAll.Size = new System.Drawing.Size(136, 22);
            this.TsmiCloseAll.Text = "全部关闭页";
            this.TsmiCloseAll.Click += new System.EventHandler(this.TsmiCloseAll_Click);
            // 
            // TrmMainStart
            // 
            this.TrmMainStart.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsmrRefreshThis,
            this.TsmrCloseThis,
            this.TsmrCloseOther,
            this.TsmrCloseAll,
            this.TsmrMainStartSplit,
            this.TsmrExitSystem});
            this.TrmMainStart.Name = "TrmMainStart";
            this.TrmMainStart.Size = new System.Drawing.Size(44, 21);
            this.TrmMainStart.Text = "开始";
            // 
            // TsmrRefreshThis
            // 
            this.TsmrRefreshThis.Name = "TsmrRefreshThis";
            this.TsmrRefreshThis.Size = new System.Drawing.Size(124, 22);
            this.TsmrRefreshThis.Text = "刷新当前";
            this.TsmrRefreshThis.Click += new System.EventHandler(this.TsmiRefreshThis_Click);
            // 
            // TsmrCloseThis
            // 
            this.TsmrCloseThis.Name = "TsmrCloseThis";
            this.TsmrCloseThis.Size = new System.Drawing.Size(124, 22);
            this.TsmrCloseThis.Text = "关闭当前";
            this.TsmrCloseThis.Click += new System.EventHandler(this.TsmiCloseThis_Click);
            // 
            // TsmrCloseOther
            // 
            this.TsmrCloseOther.Name = "TsmrCloseOther";
            this.TsmrCloseOther.Size = new System.Drawing.Size(124, 22);
            this.TsmrCloseOther.Text = "关闭其他";
            this.TsmrCloseOther.Click += new System.EventHandler(this.TsmiCloseOther_Click);
            // 
            // TsmrCloseAll
            // 
            this.TsmrCloseAll.Name = "TsmrCloseAll";
            this.TsmrCloseAll.Size = new System.Drawing.Size(124, 22);
            this.TsmrCloseAll.Text = "关闭全部";
            this.TsmrCloseAll.Click += new System.EventHandler(this.TsmiCloseAll_Click);
            // 
            // TsmrMainStartSplit
            // 
            this.TsmrMainStartSplit.Name = "TsmrMainStartSplit";
            this.TsmrMainStartSplit.Size = new System.Drawing.Size(121, 6);
            // 
            // TsmrExitSystem
            // 
            this.TsmrExitSystem.Name = "TsmrExitSystem";
            this.TsmrExitSystem.Size = new System.Drawing.Size(124, 22);
            this.TsmrExitSystem.Text = "退出系统";
            // 
            // MsrMainForm
            // 
            this.MsrMainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TrmMainStart,
            this.TrmMainHardwareMenu});
            this.MsrMainForm.Location = new System.Drawing.Point(0, 0);
            this.MsrMainForm.Name = "MsrMainForm";
            this.MsrMainForm.Padding = new System.Windows.Forms.Padding(7, 3, 0, 3);
            this.MsrMainForm.Size = new System.Drawing.Size(800, 27);
            this.MsrMainForm.TabIndex = 2;
            this.MsrMainForm.Text = "工具栏菜单";
            // 
            // TrmMainHardwareMenu
            // 
            this.TrmMainHardwareMenu.Name = "TrmMainHardwareMenu";
            this.TrmMainHardwareMenu.Size = new System.Drawing.Size(79, 21);
            this.TrmMainHardwareMenu.Text = "测试Demo";
            // 
            // homeControl1
            // 
            this.homeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.homeControl1.Location = new System.Drawing.Point(3, 3);
            this.homeControl1.Name = "homeControl1";
            this.homeControl1.Size = new System.Drawing.Size(786, 387);
            this.homeControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TacMainContent);
            this.Controls.Add(this.MsrMainForm);
            this.Name = "MainForm";
            this.Text = "最新硬件组件测试Demo";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TabHome.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip CmtMainPages;
        private System.Windows.Forms.ToolStripMenuItem TsmiRefreshThis;
        private System.Windows.Forms.ToolStripMenuItem TsmiCloseThis;
        private System.Windows.Forms.ToolStripMenuItem TrmMainStart;
        private System.Windows.Forms.MenuStrip MsrMainForm;
        private System.Windows.Forms.ToolStripMenuItem TrmMainHardwareMenu;
        private System.Windows.Forms.ToolStripMenuItem TsmiCloseOther;
        private System.Windows.Forms.ToolStripMenuItem TsmiCloseAll;
        private System.Windows.Forms.ToolStripMenuItem TsmrCloseThis;
        private System.Windows.Forms.ToolStripMenuItem TsmrCloseOther;
        private System.Windows.Forms.ToolStripMenuItem TsmrCloseAll;
        private System.Windows.Forms.ToolStripSeparator TsmrMainStartSplit;
        private System.Windows.Forms.ToolStripMenuItem TsmrExitSystem;
        private System.Windows.Forms.ToolStripMenuItem TsmrRefreshThis;
        private Views.HomeControl homeControl1;
    }
}