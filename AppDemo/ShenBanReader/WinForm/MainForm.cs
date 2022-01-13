using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Cobber;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System.Data.ShenBanReader.WinForm
{
    public partial class MainForm : Form
    {
        private IR2000Reader _reader = ReaderBuilder.GetR2000Reader();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ReloadConnectConfig();
        }

        private void RBtnRs232_CheckedChanged(object sender, EventArgs e)
        {
            this.GbxConnectSPort.Enabled = this.RBtnRs232.Checked;
            this.GbxContentRate.Enabled = this.RBtnRs232.Checked;
        }

        private void RBtnNetport_CheckedChanged(object sender, EventArgs e)
        {
            this.GbxConnectIP.Enabled = this.RBtnNetport.Checked;
            this.GbxConnectNPort.Enabled = this.RBtnNetport.Checked;
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (this.RBtnRs232.Checked) // 串口连接
            {
                var portName = this.CbxConnectPort.Text;
                if (string.IsNullOrEmpty(portName))
                {
                    AlertError("串口号不能为空");
                    return;
                }
                var rate = this.CbxConnectRate.Text.ToPInt32();
                if (rate <= 0)
                {
                    AlertError("请正确填写波特率");
                    return;
                }
                if (_reader.Connect(portName, rate, out string exception))
                {
                    this.PnlContent.Enabled = true;
                    WriteLogger($"连接成功[{portName}:{rate}]");
                }
                else
                {
                    this.PnlContent.Enabled = false;
                    AlertError(exception);
                }
            }
            else
            {
                if (!IPAddress.TryParse(this.TxtConnectIP.Text, out IPAddress ipAddress))
                {
                    AlertError("IP地址不正确");
                    return;
                }
                var port = this.TxtConnectPort.Text.ToPInt32();
                if (port <= 0 || port >= 65535)
                {
                    AlertError("端口范围是1-65535的数字");
                    return;
                }
                if (_reader.Connect(ipAddress, port, out string exception))
                {
                    this.PnlContent.Enabled = true;
                    WriteLogger($"连接成功[{this.TxtConnectIP.Text}:{port}]");
                }
                else
                {
                    this.PnlContent.Enabled = false;
                    AlertError(exception);
                }
            }
        }

        private void WriteLogger(string msg)
        {

        }

        private void AlertError(string msg)
        {
            MessageBox.Show(msg, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ReloadConnectConfig()
        {
            this.CbxConnectPort.Items.Clear();
            var portNames = SerialPort.GetPortNames();
            this.CbxConnectPort.Items.AddRange(portNames);
            if (portNames.Length > 0)
            {
                this.CbxConnectPort.SelectedIndex = 0;
            }

            this.CbxConnectRate.Items.Clear();
            this.CbxConnectRate.Items.AddRange(new[] { "115200", "38400" });
            this.CbxConnectRate.SelectedIndex = 0;

            this.TxtConnectIP.Text = "192.168.0.178";
            this.TxtConnectPort.Text = "4001";
        }

        private void BtnConnect_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Clicks > 1) // 双击事件
                {

                }
                return;
            }
            if (e.Button == MouseButtons.Right) // 右击事件
            {
                if (e.Clicks > 1)
                {
                    ReloadConnectConfig();
                }
                return;
            }
        }
    }
}
