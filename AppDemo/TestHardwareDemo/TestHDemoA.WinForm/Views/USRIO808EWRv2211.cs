using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Cobber;
using System.Data.Extter;
using System.Data.NHInterfaces;
using System.Data.YouRenIoTNetIO;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestHardwareDemo.WinForm.Components;

namespace TestHardwareDemo.WinForm.Views
{
    /// <summary>
    /// 测试有人IO控制器
    /// </summary>
    [EDisplay("测试有人USR-IO808-EWR示例1")]
    public partial class USRIO808EWRv2211 : TextLoggerComponent
    {
        static string _configPath = System.IO.Path.GetFullPath($"{nameof(USRIO808EWRv2211)}.json");
        HashSet<USRIO808Model> _devices = new HashSet<USRIO808Model>();
        USRIO808Model _config;
        bool _isInitialize;
        /// <summary>
        /// 构造
        /// </summary>
        public USRIO808EWRv2211()
        {
            InitializeComponent();
        }
        private void USRIO808EWRv2211_Load(object sender, EventArgs e)
        {
            this.SplContent.SplitterDistance = 512;
            this.SplContent.Update();
            if (!_isInitialize)
            {
                _isInitialize = true;
                _config = new USRIO808Model(this);
                base.Initialize();
                ReadDeviceAndSetFirstOne();
            }
            GuardianServiceStart();
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
                    _devices.Add(new USRIO808Model(this, item.Item1, item.Item2.ToPInt32()));
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
        #region // 基础内容
        public override RichTextBox ThisTxtLogger => TxtLogger;
        public override void GuardianTaskService()
        {
            if (!this.ChkNetReadBackground.Checked)
            {
                GuardianInterval = 10 * 10;
                return;
            }
            UpdateReadInfo();
            if (this.TxtNetSeconds.Text.TryToInt32(out int sec))
            {
                if (sec > 5 && sec < 99)
                {
                    GuardianInterval = sec * 10;
                }
            }
        }
        #endregion 基础内容
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
                model = new USRIO808Model(this, iptext, porttext.ToPInt32());
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
            model.ReceiveTimeout = this.TxtNetReadTimeout.Text.ToPInt32();
            model.SendTimeout = this.TxtNetWriteTimeout.Text.ToPInt32();
            model.Retries = this.TxtNetRetries.Text.ToPInt32();
            model.RetryWaitout = this.TxtNetRetryWaitout.Text.ToPInt32();
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

        private void PicNetDO_Click(object sender, EventArgs e)
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
            var chk = sender as Label;
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
            /// 接收超时时间(毫秒)
            /// </summary>
            public virtual int ReceiveTimeout { get; set; }
            /// <summary>
            /// 发送超时时间(毫秒)
            /// </summary>
            public virtual int SendTimeout { get; set; }
            /// <summary>
            /// 重试次数
            /// </summary>
            public virtual int Retries { get; set; }
            /// <summary>
            /// 重试等待时间(毫秒)
            /// </summary>
            public virtual int RetryWaitout { get; set; }
            /// <summary>
            /// 控制器
            /// </summary>
            public virtual IUsrIOControlProxy Control { get; }
            /// <summary>
            /// 日志组件
            /// </summary>
            public virtual TextLoggerComponent Logger { get; }
            /// <summary>
            /// 构造
            /// </summary>
            /// <param name="logger"></param>
            public USRIO808Model(TextLoggerComponent logger) : this(logger, "192.168.1.110", 28899) { }
            /// <summary>
            /// 构造
            /// </summary>
            public USRIO808Model(TextLoggerComponent logger, string ipAddresss, int port)
            {
                Key = $"{ipAddresss}:{port}";
                IPAddress = ipAddresss;
                Port = port;
                DOStatus = new bool[8];
                DIStatus = new bool[8];
                Control = NetIOControlSdk.CreateIOControl(IOControlType.USR_IO808_EWR);
                Locker = new object();
                Logger = logger;
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
                        Control.ReceiveTimeout = ReceiveTimeout;
                        Control.SendTimeout = SendTimeout;
                        Control.Retries = Retries;
                        Control.RetryWaitout = RetryWaitout;
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
                        Logger.Append(res);
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
                    Logger.Append(new AlertMsg(false, "当前连接正在使用中……"));
                }
            }
            public void UpdateDOStatus(int i, bool value)
            {
                if (Monitor.TryEnter(Locker, 1000))
                {
                    try
                    {
                        var res = Control.SetDOStatus(i, value);
                        Logger.Append(res);
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
                    Logger.Append(new AlertMsg(false, "当前连接正在使用中……"));
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
                        Logger.Append(res);
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
                    Logger.Append(new AlertMsg(false, "当前连接正在使用中……"));
                }
            }

            public void UpdateDOStatusHolding()
            {
                if (Monitor.TryEnter(Locker, 1000))
                {
                    try
                    {
                        var res = Control.GetDOStatusHolding();
                        Logger.Append(res);
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
                    Logger.Append(new AlertMsg(false, "当前连接正在使用中……"));
                }
            }

            public void UpdateDOStatusHolding(bool? value)
            {
                if (Monitor.TryEnter(Locker, 1000))
                {
                    try
                    {
                        var res = Control.SetDOStatusHolding(value);
                        Logger.Append(res);
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
                    Logger.Append(new AlertMsg(false, "当前连接正在使用中……"));
                }
            }

            public void UpdateDIStatus(int i)
            {
                if (Monitor.TryEnter(Locker, 1000))
                {
                    try
                    {
                        var res = Control.GetDIStatus(i);
                        Logger.Append(res);
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
                    Logger.Append(new AlertMsg(false, "当前连接正在使用中……"));
                }
            }
        }
        #endregion
        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
        }
    }
}
