using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Cobber;
using HikHCNetSDK.WinForm.Views;

namespace HikHCNetSDK.WinForm
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 测试扫描窗体
        /// </summary>
        PreviewDemo1 PreDemo1 { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }

        private static bool TryGetTabPageSelect<T>(IEnumerable<TabPage> pages, T scanPanel, out TabPage page)
        {
            foreach (TabPage item in pages)
            {
                foreach (var ctl in item.Controls)
                {
                    if (ctl is T scan)
                    {
                        if (scan.Equals(scanPanel))
                        {
                            page = item;
                            return true;
                        }
                    }
                }
            }
            page = null;
            return false;
        }

        private void TrmUSRIO808_Click(object sender, EventArgs e)
        {
            var scanPanel = PreDemo1 ??= new PreviewDemo1();
            if (!TryGetTabPageSelect(TacMainContent.TabPages.ToEnumerable<TabPage>(), scanPanel, out TabPage page))
            {
                page = new TabPage();
                page.Text = "测试识别1";
                page.Controls.Add(scanPanel);
                scanPanel.Dock = DockStyle.Fill;
                TacMainContent.TabPages.Add(page);
            }
            this.TacMainContent.SelectedTab = page;
        }

        private void TsmiRefreshThis_Click(object sender, EventArgs e)
        {

        }

        private void TsmiCloseThis_Click(object sender, EventArgs e)
        {
            var thisTab = this.TacMainContent.SelectedTab;
            if (thisTab.Text == "首页")
            {
                return;
            }
            var thisIndex = this.TacMainContent.SelectedIndex;
            if (thisIndex <= 0) { thisIndex = 0; }
            this.TacMainContent.TabPages.Remove(thisTab);
            if (thisIndex >= TacMainContent.TabPages.Count) { thisIndex = TacMainContent.TabPages.Count - 1; }
            this.TacMainContent.SelectedIndex = thisIndex;
        }
    }
}
