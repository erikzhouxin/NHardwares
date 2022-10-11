using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace System.Data.ShenBanReader.WinForm
{
    public partial class MainForm : Form
    {
        R2000UartDemo R2000UartDemo { get; set; }
        AutoReaderForm AutoReaderForm { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }

        private void 打开官方示例ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (R2000UartDemo ?? new R2000UartDemo()).ShowDialog();
        }

        private void 打开自动读取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (AutoReaderForm ?? new AutoReaderForm()).ShowDialog();
        }
    }
}
