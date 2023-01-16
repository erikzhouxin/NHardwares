using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Cobber;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace TestHardwareDemo.WinForm.Controls
{
    /// <summary>
    /// 车牌识别网络查询
    /// </summary>
    public partial class VzLPRSDKDemoNetSearch : UserControl
    {
        /// <summary>
        /// 构造
        /// </summary>
        public VzLPRSDKDemoNetSearch()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 开始搜索回调
        /// </summary>
        public Action StartCallback { get; set; }
        /// <summary>
        /// 停止搜索回调
        /// </summary>
        public Action StopCallback { get; set; }
        /// <summary>
        /// 修改地址回调
        /// </summary>
        internal Action<NetConfigModel, NetConfigModel> ChangeCallback { get; set; }
        /// <summary>
        /// 日志回调
        /// </summary>
        public Action<IAlertMsg> LoggerCallback { get; set; }
        /// <summary>
        /// 日志回调
        /// </summary>
        public Action<string> WriteCallback { get; set; }
        /// <summary>
        /// 搜索回调
        /// </summary>
        public void SearchCallback(string info)
        {
            this.Invoke(() => TvwSearchRes.Nodes.Add(info));
        }
        #region // 内部类
        internal class NetConfigModel
        {
            public string Address { get; set; }
            public string Mask { get; set; }
            public String Gateway { get; set; }
            public uint SerialLower { get; set; }
            public uint SerialHigher { get; set; }
        }
        #endregion

        private void BtnStart_Click(object sender, EventArgs e)
        {
            this.TvwSearchRes.Nodes.Clear();
            StartCallback?.Invoke();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            StopCallback?.Invoke();
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            if (this.TvwSearchRes.SelectedNode == null)
            {
                LoggerCallback?.Invoke(new AlertMsg(false, $"请选择需要修改的IP地址......"));
                return;
            }
            var selectNode = this.TvwSearchRes.SelectedNode;
            if (!IPAddress.TryParse(this.TxtNetAddress.Text, out IPAddress address))
            {
                LoggerCallback?.Invoke(new AlertMsg(false, $"【{this.TxtNetAddress.Text}】无法转换成IP地址"));
                return;
            }
            if (!IPAddress.TryParse(this.TxtNetMask.Text, out IPAddress mask))
            {
                LoggerCallback?.Invoke(new AlertMsg(false, $"【{this.TxtNetMask.Text}】无法转换成子网掩码"));
                return;
            }
            if (!IPAddress.TryParse(this.TxtNetGateway.Text, out IPAddress gateway))
            {
                LoggerCallback?.Invoke(new AlertMsg(false, $"【{this.TxtNetGateway.Text}】无法转换成默认网关"));
                return;
            }
            var node = selectNode.Text.Split("-");
            ChangeCallback?.Invoke(new NetConfigModel
            {
                Address = node[0],
                Mask = node[1],
                Gateway = node[2],
                SerialLower = (uint)node[5].ToPInt64(),
                SerialHigher = (uint)node[6].ToPInt64(),
            }, new NetConfigModel
            {
                Address = address.ToString(),
                Mask = mask.ToString(),
                Gateway = gateway.ToString(),
            });
        }

        private void TvwSearchRes_DoubleClick(object sender, EventArgs e)
        {
            var selectNode = this.TvwSearchRes.SelectedNode;
            if (selectNode == null)
            {
                LoggerCallback?.Invoke(new AlertMsg(false, $"请选择需要连接的IP地址......"));
                return;
            }
            var spliter = selectNode.Text.Split("-");
            this.TxtNetAddress.Text = spliter[0];
            this.TxtNetGateway.Text = spliter[1];
            this.TxtNetMask.Text = spliter[2];
            WriteCallback?.Invoke(selectNode.Text);
        }
    }
}
