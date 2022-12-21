using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Cobber;
using System.Data.Extter;
using System.Data.HardwareInterfaces;
using System.Data.Logger;
using System.Data.YouRenIoTNetIO;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouRenIoTNetIO.WinForm.Views
{
    public partial class TestUSRIO808 : UserControl
    {
        /// <summary>
        /// 终端配置
        /// </summary>
        static HashSet<USRIO808Model> _devices = new HashSet<USRIO808Model>();
        static USRIO808Model _config = new USRIO808Model("192.168.1.110", 28899);
        static string _configPath = System.IO.Path.GetFullPath("testusrio808config.json");
        internal static TestUSRIO808 Instance { get; set; }
        Thread _guardianService;
        CancellationTokenSource _guardianCts;
        bool _isInitialize;
        public TestUSRIO808()
        {
            Instance = this;
            InitializeComponent();
        }
        private void TestScanner_Load(object sender, EventArgs e)
        {
            this.SplContent.SplitterDistance = 512;
            this.SplContent.Update();
            if (!_isInitialize)
            {
                _isInitialize = true;

                ReadDeviceAndSetFirstOne();

                _guardianCts = new CancellationTokenSource();
                _guardianService = new Thread(async () => await GuardianServiceAsync(_guardianCts.Token));
                _guardianService.IsBackground = true;
                _guardianService.Start();
            }
        }

        private void ReadDeviceAndSetFirstOne()
        {
            var configText = this.CbxNetConfigs.Text;
            this.CbxNetConfigs.Items.Clear();
            List<Tuble8String> list;
            if (System.IO.File.Exists(_configPath))
            {
                try
                {
                    list = System.IO.File.ReadAllText(_configPath).GetJsonObject<List<Tuble8String>>();
                }
                catch { list = new List<Tuble8String>(); }
            }
            else
            {
                System.IO.File.WriteAllText(_configPath, "[]");
                list = new List<Tuble8String>();
            }
            foreach (var item in list)
            {
                var key = $"{item.Item1}:{item.Item2}";
                if (!_devices.Any(s => s.Key == key))
                {
                    _devices.Add(new USRIO808Model(item.Item1, item.Item2.ToPInt32()));
                }
                this.CbxNetConfigs.Items.Add(key);
            }
            if (list.Count > 0)
            {
                if (string.IsNullOrWhiteSpace(configText) || !_devices.Any(s => s.Key == configText))
                {
                    this.CbxNetConfigs.SelectedIndex = 0;
                }
                else
                {
                    this.CbxNetConfigs.Text = configText;
                }
            }
        }
        #region // 服务内容
        async Task GuardianServiceAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                int seconds = 10;
                try
                {
                    if (!this.ChkNetReadBackground.Checked)
                    {
                        await Task.Delay(seconds * 1000, stoppingToken);
                        continue;
                    }
                    UpdateReadInfo();
                    if (this.TxtNetSeconds.Text.TryToInt32(out int sec))
                    {
                        if (sec > 5 && sec < 99)
                        {
                            seconds = sec;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Append(ex);
                }
                await Task.Delay(seconds * 1000, stoppingToken);
            }
        }

        private void UpdateReadInfo()
        {
            var item = _config;
            var taskres = item.Connect();
            if (taskres.IsSuccess)
            {
                for (int i = 0; i < 8; i++)
                {
                    item.UpdateDOStatus(i);
                    item.UpdateDIStatus(i);
                }
                item.UpdateDOStatusHolding();
            }
            else
            {
                AppendError(taskres.Message);
            }
            if (item.Key == _config.Key)
            {
                this.BeginInvoke(() => UpdateDOStatus(item.DOStatus));
                this.BeginInvoke(() => UpdateDIStatus(item.DIStatus));
                this.BeginInvoke(() => ChkNetDoHolding.CheckState = GetCheckState(item.DOStatusHolding));
            }
        }

        private void UpdateDIStatus(bool[] status)
        {
            this.PicNetDI1.Image = status[0] ? Properties.Resources.usr_io808_diopen : Properties.Resources.usr_io808_diclose;
            this.PicNetDI2.Image = status[1] ? Properties.Resources.usr_io808_diopen : Properties.Resources.usr_io808_diclose;
            this.PicNetDI3.Image = status[2] ? Properties.Resources.usr_io808_diopen : Properties.Resources.usr_io808_diclose;
            this.PicNetDI4.Image = status[3] ? Properties.Resources.usr_io808_diopen : Properties.Resources.usr_io808_diclose;
            this.PicNetDI5.Image = status[4] ? Properties.Resources.usr_io808_diopen : Properties.Resources.usr_io808_diclose;
            this.PicNetDI6.Image = status[5] ? Properties.Resources.usr_io808_diopen : Properties.Resources.usr_io808_diclose;
            this.PicNetDI7.Image = status[6] ? Properties.Resources.usr_io808_diopen : Properties.Resources.usr_io808_diclose;
            this.PicNetDI8.Image = status[7] ? Properties.Resources.usr_io808_diopen : Properties.Resources.usr_io808_diclose;
        }

        private void UpdateDOStatus(bool[] status)
        {
            this.PicNetDO1.Image = status[0] ? Properties.Resources.usr_io808_doopen : Properties.Resources.usr_io808_doclose;
            this.PicNetDO2.Image = status[1] ? Properties.Resources.usr_io808_doopen : Properties.Resources.usr_io808_doclose;
            this.PicNetDO3.Image = status[2] ? Properties.Resources.usr_io808_doopen : Properties.Resources.usr_io808_doclose;
            this.PicNetDO4.Image = status[3] ? Properties.Resources.usr_io808_doopen : Properties.Resources.usr_io808_doclose;
            this.PicNetDO5.Image = status[4] ? Properties.Resources.usr_io808_doopen : Properties.Resources.usr_io808_doclose;
            this.PicNetDO6.Image = status[5] ? Properties.Resources.usr_io808_doopen : Properties.Resources.usr_io808_doclose;
            this.PicNetDO7.Image = status[6] ? Properties.Resources.usr_io808_doopen : Properties.Resources.usr_io808_doclose;
            this.PicNetDO8.Image = status[7] ? Properties.Resources.usr_io808_doopen : Properties.Resources.usr_io808_doclose;
        }
        #endregion
        #region // 日志控件
        public void AppendTextEx(string strText, Color clAppend)
        {
            int nLen = this.TxtLogger.TextLength;

            if (nLen != 0)
            {
                TxtLogger.AppendText(Environment.NewLine + System.DateTime.Now.ToString() + " " + strText);
            }
            else
            {
                TxtLogger.AppendText(System.DateTime.Now.ToString() + " " + strText);
            }

            TxtLogger.Select(nLen, this.TxtLogger.TextLength - nLen);
            this.TxtLogger.SelectionColor = clAppend;
        }
        public TestUSRIO808 AppendError(string message)
        {
            this.Invoke((Action)(() =>
            {
                AppendTextEx(message, Color.Red);
            }));
            return this;
        }
        public TestUSRIO808 AppendSuccess(string message)
        {
            this.Invoke((Action)(() =>
            {
                AppendTextEx(message, Color.Green);
            }));
            return this;
        }
        public TestUSRIO808 AppendInfo(string message)
        {
            this.Invoke((Action)(() =>
            {
                AppendTextEx(message, Color.Blue);
            }));
            return this;
        }
        public TestUSRIO808 Append(IAlertMsg alert)
        {
            this.Invoke((Action)(() =>
            {
                AppendTextEx(alert.Message, alert.IsSuccess ? Color.Green : Color.Red);
            }));
            return this;
        }
        public TestUSRIO808 Append(Exception alert)
        {
            var sb = new StringBuilder().AppendLine(alert.Message).AppendLine(alert.StackTrace);
            this.Invoke((Action)(() =>
            {
                AppendTextEx(sb.ToString(), Color.Red);
            }));
            return this;
        }
        private void TxtLogger_TextChanged(object sender, EventArgs e)
        {
            TxtLogger.Select(TxtLogger.TextLength, 0);
            TxtLogger.ScrollToCaret();
        }
        #endregion

        private void TsbNetControl_Click(object sender, EventArgs e)
        {

        }

        private void BtnNetConfigConnect_Click(object sender, EventArgs e)
        {
            var iptext = (this.TxtNetConfigIp.Text ?? String.Empty).Trim();
            if (!IPAddress.TryParse(iptext, out var ipAddress))
            {
                AppendError($"小呆瓜注意：IP地址（{iptext}）长这样吗？能不能长点心好不好啊！");
                return;
            }
            var porttext = (this.TxtNetConfigPort.Text ?? "0").Trim();
            if (!Int32.TryParse(porttext, out var port) || port > ushort.MaxValue || port < ushort.MinValue)
            {
                AppendError($"小笨蛋注意：端口号是[0-65535]的数字哦！");
                return;
            }
            var key = $"{iptext}:{porttext}";
            var model = _devices.FirstOrDefault(s => s.Key == key);
            if (model == null)
            {
                model = new USRIO808Model(iptext, porttext.ToPInt32());
                _devices.Add(model);
                try
                {
                    System.IO.File.WriteAllText(_configPath, _devices.Select(s => new Tuble8String() { Item1 = s.IPAddress, Item2 = s.Port.ToString() }).GetJsonFormatString());
                }
                catch { }
            }
            this.CbxNetConfigs.Text = key;
            ReadDeviceAndSetFirstOne();
        }

        private void CbxNetConfigs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = this.CbxNetConfigs.Text;
            var model = _devices.FirstOrDefault(s => s.Key == text);
            if (model == null)
            {
                AppendError($"小呆瓜注意：此设备已删除");
                return;
            }
            _config = model;
            Task.Factory.StartNew(() => Append(model.Connect()));
            this.TxtNetConfigIp.Text = model.IPAddress;
            this.TxtNetConfigPort.Text = model.Port.ToString();
            if (!this.ChkNetReadBackground.Checked)
            {
                UpdateReadInfo();
            }
            else
            {
                UpdateDOStatus(model.DOStatus);
                UpdateDIStatus(model.DIStatus);
            }
        }


        private void PicNetDO_Click(object sender, MouseEventArgs e)
        {
            var pic = sender as PictureBox;
            switch (pic?.Name)
            {
                case nameof(PicNetDO1): _config.UpdateDOStatus(0, !_config.DOStatus[0]); break;
                case nameof(PicNetDO2): _config.UpdateDOStatus(1, !_config.DOStatus[1]); break;
                case nameof(PicNetDO3): _config.UpdateDOStatus(2, !_config.DOStatus[2]); break;
                case nameof(PicNetDO4): _config.UpdateDOStatus(3, !_config.DOStatus[3]); break;
                case nameof(PicNetDO5): _config.UpdateDOStatus(4, !_config.DOStatus[4]); break;
                case nameof(PicNetDO6): _config.UpdateDOStatus(5, !_config.DOStatus[5]); break;
                case nameof(PicNetDO7): _config.UpdateDOStatus(6, !_config.DOStatus[6]); break;
                case nameof(PicNetDO8): _config.UpdateDOStatus(7, !_config.DOStatus[7]); break;
                default: break;
            }
            UpdateDOStatus(_config.DOStatus);
        }

        private void PicNetDo_DoubleClick(object sender, EventArgs e)
        {
            var pic = sender as ToolStripMenuItem;
            switch (pic?.Name)
            {
                case nameof(TsrmPicNetDO1): _config.ResetDOStatus(0, !_config.DOStatus[0]); break;
                case nameof(TsrmPicNetDO2): _config.ResetDOStatus(1, !_config.DOStatus[1]); break;
                case nameof(TsrmPicNetDO3): _config.ResetDOStatus(2, !_config.DOStatus[2]); break;
                case nameof(TsrmPicNetDO4): _config.ResetDOStatus(3, !_config.DOStatus[3]); break;
                case nameof(TsrmPicNetDO5): _config.ResetDOStatus(4, !_config.DOStatus[4]); break;
                case nameof(TsrmPicNetDO6): _config.ResetDOStatus(5, !_config.DOStatus[5]); break;
                case nameof(TsrmPicNetDO7): _config.ResetDOStatus(6, !_config.DOStatus[6]); break;
                case nameof(TsrmPicNetDO8): _config.ResetDOStatus(7, !_config.DOStatus[7]); break;
                default: break;
            }
        }

        private void PicNetDI_Click(object sender, EventArgs e)
        {
            var pic = sender as PictureBox;
            switch (pic?.Name)
            {
                case nameof(PicNetDI1): _config.UpdateDIStatus(0); break;
                case nameof(PicNetDI2): _config.UpdateDIStatus(1); break;
                case nameof(PicNetDI3): _config.UpdateDIStatus(2); break;
                case nameof(PicNetDI4): _config.UpdateDIStatus(3); break;
                case nameof(PicNetDI5): _config.UpdateDIStatus(4); break;
                case nameof(PicNetDI6): _config.UpdateDIStatus(5); break;
                case nameof(PicNetDI7): _config.UpdateDIStatus(6); break;
                case nameof(PicNetDI8): _config.UpdateDIStatus(7); break;
                default: break;
            }
            UpdateDIStatus(_config.DIStatus);
        }

        private void LblNetDO_Click(object sender, EventArgs e)
        {
            var chk = sender as CheckBox;
            switch (chk?.Name)
            {
                case nameof(LblNetDO1): _config.UpdateDOStatus(0); break;
                case nameof(LblNetDO2): _config.UpdateDOStatus(1); break;
                case nameof(LblNetDO3): _config.UpdateDOStatus(2); break;
                case nameof(LblNetDO4): _config.UpdateDOStatus(3); break;
                case nameof(LblNetDO5): _config.UpdateDOStatus(4); break;
                case nameof(LblNetDO6): _config.UpdateDOStatus(5); break;
                case nameof(LblNetDO7): _config.UpdateDOStatus(6); break;
                case nameof(LblNetDO8): _config.UpdateDOStatus(7); break;
                default: break;
            }
            UpdateDOStatus(_config.DOStatus);
        }

        private void ChkNetDoHolding_Click(object sender, EventArgs e)
        {
            _config.UpdateDOStatusHolding(GetCheckValue(ChkNetDoHolding.CheckState));
            ChkNetDoHolding.CheckState = GetCheckState(_config.DOStatusHolding);
        }

        private bool? GetCheckValue(CheckState state)
        {
            switch (state)
            {
                case CheckState.Unchecked: return false;
                case CheckState.Checked: return true;
                case CheckState.Indeterminate:
                default: return null;
            }
        }
        private CheckState GetCheckState(bool? state)
        {
            if (state.HasValue)
            {
                return state.Value ? CheckState.Checked : CheckState.Unchecked;
            }
            return CheckState.Indeterminate;
        }
        private void BtnNetConfigRemove_Click(object sender, EventArgs e)
        {
            var key = $"{this.TxtNetConfigIp.Text?.Trim()}:{this.TxtNetConfigPort.Text?.Trim()}";
            var model = _devices.FirstOrDefault(s => s.Key == key);
            _devices.Remove(model);
            model.Control.Dispose();
            try
            {
                System.IO.File.WriteAllText(_configPath, _devices.Select(s => new Tuble8String() { Item1 = s.IPAddress, Item2 = s.Port.ToString() }).GetJsonFormatString());
            }
            catch { }
            ReadDeviceAndSetFirstOne();
        }
        #region // 内部类
        /// <summary>
        /// 类模型
        /// </summary>
        public class USRIO808Model
        {
            /// <summary>
            /// 键
            /// </summary>
            public virtual String Key { get; }
            /// <summary>
            /// IP地址
            /// </summary>
            public virtual String IPAddress { get; }
            /// <summary>
            /// 端口号
            /// </summary>
            public virtual Int32 Port { get; }
            /// <summary>
            /// 锁内容
            /// </summary>
            public virtual object Locker { get; set; }
            /// <summary>
            /// DO状态
            /// </summary>
            public virtual bool[] DOStatus { get; set; }
            /// <summary>
            /// DO状态保持
            /// </summary>
            public virtual bool? DOStatusHolding { get; set; }
            /// <summary>
            /// DI状态
            /// </summary>
            public virtual bool[] DIStatus { get; set; }
            /// <summary>
            /// 控制器
            /// </summary>
            public virtual IUsrIOControlProxy Control { get; }
            /// <summary>
            /// 构造
            /// </summary>
            public USRIO808Model(string ipAddresss, int port)
            {
                Key = $"{ipAddresss}:{port}";
                IPAddress = ipAddresss;
                Port = port;
                DOStatus = new bool[8];
                DIStatus = new bool[8];
                Control = NetIOControlSdk.CreateIOControl(IOControlType.USR_IO808_EWR);
                Locker = new object();
            }
            /// <summary>
            /// 连接
            /// </summary>
            /// <returns></returns>
            public IAlertMsg Connect()
            {
                System.Net.IPAddress.TryParse(IPAddress, out var ipAddress);
                if (Monitor.TryEnter(Locker, 1000))
                {
                    try
                    {
                        return Control.Connect(ipAddress, Port);
                    }
                    finally
                    {
                        Monitor.Exit(Locker);
                    }
                }
                return new AlertMsg(false, "当前连接正在使用中……");
            }
            public void UpdateDOStatus(int i)
            {
                if (Monitor.TryEnter(Locker, 1000))
                {
                    try
                    {
                        var res = Control.GetDOStatus(i);
                        Instance.Append(res);
                        if (res.IsSuccess)
                        {
                            DOStatus[i] = res.Data;
                        }
                    }
                    finally
                    {
                        Monitor.Exit(Locker);
                    }
                }
                else
                {
                    Instance.Append(new AlertMsg(false, "当前连接正在使用中……"));
                }
            }
            public void UpdateDOStatus(int i, bool value)
            {
                if (Monitor.TryEnter(Locker, 1000))
                {
                    try
                    {
                        var res = Control.SetDOStatus(i, value);
                        Instance.Append(res);
                        if (res.IsSuccess)
                        {
                            DOStatus[i] = res.Data;
                        }
                    }
                    finally
                    {
                        Monitor.Exit(Locker);
                    }
                }
                else
                {
                    Instance.Append(new AlertMsg(false, "当前连接正在使用中……"));
                }
            }

            public void ResetDOStatus(int i, bool value)
            {
                if (Monitor.TryEnter(Locker, 1000))
                {
                    try
                    {
                        Control.SetResetDOStatus(i, value);
                        var res = Control.GetDOStatus(i);
                        Instance.Append(res);
                        if (res.IsSuccess)
                        {
                            DOStatus[i] = res.Data;
                        }
                    }
                    finally
                    {
                        Monitor.Exit(Locker);
                    }
                }
                else
                {
                    Instance.Append(new AlertMsg(false, "当前连接正在使用中……"));
                }
            }

            public void UpdateDOStatusHolding()
            {
                if (Monitor.TryEnter(Locker, 1000))
                {
                    try
                    {
                        var res = Control.GetDOStatusHolding();
                        Instance.Append(res);
                        if (res.IsSuccess)
                        {
                            DOStatusHolding = res.Data == 1 ? true : (res.Data == 3 ? false : null);
                        }
                    }
                    finally
                    {
                        Monitor.Exit(Locker);
                    }
                }
                else
                {
                    Instance.Append(new AlertMsg(false, "当前连接正在使用中……"));
                }
            }

            public void UpdateDOStatusHolding(bool? value)
            {
                if (Monitor.TryEnter(Locker, 1000))
                {
                    try
                    {
                        var res = Control.SetDOStatusHolding(value);
                        Instance.Append(res);
                        if (res.IsSuccess)
                        {
                            DOStatusHolding = res.Data;
                        }
                    }
                    finally
                    {
                        Monitor.Exit(Locker);
                    }
                }
                else
                {
                    Instance.Append(new AlertMsg(false, "当前连接正在使用中……"));
                }
            }

            public void UpdateDIStatus(int i)
            {
                if (Monitor.TryEnter(Locker, 1000))
                {
                    try
                    {
                        var res = Control.GetDIStatus(i);
                        Instance.Append(res);
                        if (res.IsSuccess)
                        {
                            DIStatus[i] = res.Data;
                        }
                    }
                    finally
                    {
                        Monitor.Exit(Locker);
                    }
                }
                else
                {
                    Instance.Append(new AlertMsg(false, "当前连接正在使用中……"));
                }
            }
        }
        #endregion

        private void TsrmLoggerClear_Click(object sender, EventArgs e)
        {
            this.TxtLogger.Clear();
        }
    }
}
