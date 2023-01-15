using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Cobber;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using TestHardwareDemo.WinForm.Components;
using TestHardwareDemo.WinForm.Views;

namespace TestHardwareDemo.WinForm
{
    public partial class MainForm : Form
    {
        bool _isInitialed = false;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!_isInitialed)
            {
                _isInitialed = true;
                var tagType = typeof(HomeControl);
                foreach (var item in tagType.Assembly.GetExportedTypes())
                {
                    if (tagType.Equals(item)) { continue; }
                    if (tagType.Namespace.Equals(item.Namespace))
                    {
                        if (item.IsSubclassOf(typeof(UserControl)))
                        {
                            var attr = item.GetCustomAttribute<EDisplayAttribute>() ?? new EDisplayAttribute(item.Name);
                            var menu = new ToolStripMenuItem()
                            {
                                Text = attr.Display,
                            };
                            menu.Click += (s, e) =>
                            {
                                var method = typeof(CompatWinFormComponent).GetMethod(nameof(CompatWinFormComponent.TrySelectTabPage), BindingFlags.Public | BindingFlags.Static | BindingFlags.IgnoreCase).MakeGenericMethod(item);
                                var args = new object[] { TacMainContent, null };
                                var res = method.Invoke(null, args);
                                var isFound = res is bool ? (bool)res : false;
                                if (!isFound)
                                {
                                    MessageBox.Show("未找到实现控件", "404NotFound", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            };
                            this.TrmMainHardwareMenu.DropDownItems.Add(menu);
                        }
                    }
                }
            }
        }

        private void TsmiRefreshThis_Click(object sender, EventArgs e)
        {

        }

        private void TsmiCloseThis_Click(object sender, EventArgs e)
        {
            var thisTab = this.TacMainContent.SelectedTab;
            if (thisTab.Text == "首页") { return; }
            var thisIndex = this.TacMainContent.SelectedIndex;
            if (thisIndex <= 0) { thisIndex = 0; }
            this.TacMainContent.TabPages.Remove(thisTab);
            if (thisIndex >= TacMainContent.TabPages.Count) { thisIndex = TacMainContent.TabPages.Count - 1; }
            this.TacMainContent.SelectedIndex = thisIndex;
        }

        private void TsmiCloseAll_Click(object sender, EventArgs e)
        {

        }

        private void TsmiCloseOther_Click(object sender, EventArgs e)
        {

        }
    }
}
