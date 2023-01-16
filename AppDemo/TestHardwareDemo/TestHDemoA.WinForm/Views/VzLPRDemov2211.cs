using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Cobber;
using System.Data.Extter;
using System.Data.VzClientSDK;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestHardwareDemo.WinForm.Components;
using TestHardwareDemo.WinForm.Controls;

namespace TestHardwareDemo.WinForm.Views
{
    /// <summary>
    /// 西沃车牌识别示例
    /// </summary>
    [EDisplay("测试西沃车牌识别示例")]
    public partial class VzLPRDemov2211 : TextLoggerComponent
    {
        private bool _isInitialed;
        private IVzClientSdkProxy VzClientSDK = VzClientSdk.Create();
        private List<ContentModel> _devices = new();
        private string _configPath = System.IO.Path.GetFullPath($"{nameof(VzLPRDemov2211)}.json");
        private ContentModel _config;
        /// <summary>
        /// 构造
        /// </summary>
        public VzLPRDemov2211()
        {
            InitializeComponent();
        }

        private void VzLPRSDKDemov2211_Load(object sender, EventArgs e)
        {
            if (!_isInitialed)
            {
                _isInitialed = true;

                VzClientSDK.VzLPRClient_Setup();

                base.Initialize();

                ReadDeviceAndSetFirstOne();
            }
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            try
            {
                foreach (var item in _devices) // 释放所有已连接设备
                {
                    if (item.Handler > 0)
                    {
                        VzClientSDK.VzLPRClient_StopRealPlay(item.Handler);
                        VzClientSDK.VzLPRClient_Close(item.Handler);
                    }
                }
                //停止搜索设备
                VzClientSDK.VZLPRClient_StopFindDevice();
                VzClientSDK.VzLPRClient_Cleanup();
            }
            catch { }
            base.OnHandleDestroyed(e);
        }
        private void BtnNetLogin_Click(object sender, EventArgs e)
        {
            // 检查格式
            if (!CompatWinFormComponent.TryCheckIPAddressPort(this.TxtNetIp.Text, this.TxtNetPort.Text, AppendErrorVoid, out Tuble<string, int> outVal))
            {
                return;
            }
            var key = $"{outVal.Item1}:{outVal.Item2}";
            var model = _devices.FirstOrDefault(s => s.Key == key);
            if (model == null)
            {
                model = new ContentModel(new ConfigModel(outVal.Item1, outVal.Item2));
                _devices.Add(model);
            }
            model.Config.IsPDNS = this.ChkNetPDNS.Checked;
            model.Config.SerialNum = this.TxtNetSerialNum.Text?.Trim() ?? string.Empty;
            model.Config.Account = this.TxtNetAccount.Text?.Trim() ?? string.Empty;
            model.Config.Password = this.TxtNetPassword.Text?.Trim() ?? string.Empty;
            try
            {
                System.IO.File.WriteAllText(_configPath, _devices.Select(s => s.Config).GetJsonFormatString());
            }
            catch { }
            this.CbxNetConfigs.Text = key;
            ReadDeviceAndSetFirstOne();
        }
        private void ReadDeviceAndSetFirstOne()
        {
            var configText = this.CbxNetConfigs.Text;
            this.CbxNetConfigs.Items.Clear();
            List<ContentModel> list;
            if (System.IO.File.Exists(_configPath))
            {
                try
                {
                    list = System.IO.File.ReadAllText(_configPath).GetJsonObject<List<ConfigModel>>()
                        .Select(s => new ContentModel(s)).ToList();
                }
                catch { list = new List<ContentModel>(); }
            }
            else
            {
                System.IO.File.WriteAllText(_configPath, "[]");
                list = new List<ContentModel>();
            }
            foreach (var item in list)
            {
                var key = item.Key;
                if (!_devices.Any(s => s.Key == key))
                {
                    _devices.Add(item);
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
            var config = model.Config;
            this.TxtNetIp.Text = model.Config.Address;
            this.TxtNetPort.Text = model.Config.Port.ToString();
            this.TxtNetSerialNum.Enabled = this.ChkNetPDNS.Checked = model.Config.IsPDNS;
            this.TxtNetSerialNum.Text = model.Config.SerialNum;
            this.TxtNetAccount.Text = model.Config.Account;
            this.TxtNetPassword.Text = model.Config.Password;
            if (model.Handle != IntPtr.Zero)
            {
                BtnNetExit_Click(sender, e);
            }
            int handle = 0;
            if (model.Config.IsPDNS)
            {
                handle = VzClientSDK.VzLPRClient_OpenV2(config.Address, (ushort)config.Port, config.Account, config.Password, 8557, 1, config.SerialNum);
            }
            else
            {
                handle = VzClientSDK.VzLPRClient_Open(config.Address, (ushort)config.Port, config.Account, config.Password);
            }
            if (handle == 0)
            {
                AppendError($"{text} => 打开设备失败！");
                return;
            }
            PicScreenView.Image = null;
            if (_config.Handle != IntPtr.Zero)
            {
                VzClientSDK.VzLPRClient_StopRealPlay(_config.Handler);
                VzClientSDK.VzLPRClient_SetPlateInfoCallBack((int)PicScreenView.Handle, null, IntPtr.Zero, 0);
            }
            _config.Handle = (IntPtr)handle;
            VzClientSDK.VzLPRClient_SetIsShowPlateRect(handle, 0);

            VzClientSDK.VzLPRClient_StartRealPlay(_config.Handler, PicScreenView.Handle);

            // 设置车牌识别结果回调
            VzClientSDK.VzLPRClient_SetPlateInfoCallBack(_config.Handler, OnPlateResult, IntPtr.Zero, 1);
            // VzClientSDK.VzLPRClient_SetGPIORecvCallBack(_config.Handler, OnGpioResult, IntPtr.Zero);
        }

        private int OnPlateResult(int handle, IntPtr pUserData, IntPtr pResult, uint uNumPlates, VZ_LPRC_RESULT_TYPE eResultType, IntPtr pImgFull, IntPtr pImgPlateClip)
        {
            throw new NotImplementedException();
        }

        private void ChkNetPDNS_Click(object sender, EventArgs e)
        {
            this.TxtNetSerialNum.Enabled = this.ChkNetPDNS.Checked;
        }

        private void BtnNetExit_Click(object sender, EventArgs e)
        {
            var config = GetContentModel();
            if (config.Handle == IntPtr.Zero)
            {
                AppendInfo($"{config.Key} => 已经断开连接了");
                return;
            }
            VzClientSDK.VzLPRClient_StopRealPlay((int)config.Handle);
            PicScreenView_Close();
            VzClientSDK.VzLPRClient_Close((int)config.Handle);
            config.Handle = IntPtr.Zero;
        }

        private ContentModel GetContentModel()
        {
            return _config ?? new ContentModel(new ConfigModel());
        }

        private void BtnNetRemove_Click(object sender, EventArgs e)
        {
            BtnNetExit_Click(sender, e);
            _devices.Remove(GetContentModel());
            try
            {
                System.IO.File.WriteAllText(_configPath, _devices.Select(s => s.Config).GetJsonFormatString());
            }
            catch { }
            ReadDeviceAndSetFirstOne();
        }
        private void PicScreenView_Close()
        {
            PicScreenView.Invoke(() =>
            {
                PicScreenView.Image = null;
                PicScreenView.Refresh();
                PicScreenView.Tag = 0;
            });
        }
        #region // 内部类
        internal class ConfigModel
        {
            public string Key { get => $"{Address}:{Port}"; }
            public string Address { get; set; }
            public int Port { get; set; }
            public bool IsPDNS { get; set; }
            public string SerialNum { get; set; }
            public string Account { get; set; }
            public string Password { get; set; }
            public ConfigModel() : this("192.168.1.100", 80) { }
            public ConfigModel(string address, int port)
            {
                Address = address;
                Port = port;
            }
        }
        internal class ContentModel
        {
            /// <summary>
            /// 键
            /// </summary>
            public string Key { get => Config.Key; }
            /// <summary>
            /// 配置
            /// </summary>
            public ConfigModel Config { get; set; }
            /// <summary>
            /// 句柄
            /// </summary>
            public IntPtr Handle { get; set; }
            public int Handler { get => (int)Handle; set => Handle = (IntPtr)value; }
            /// <summary>
            /// 构造
            /// </summary>
            /// <param name="config"></param>
            public ContentModel(ConfigModel config)
            {
                Config = config;
            }
        }
        #endregion
        #region // 基础内容
        public override RichTextBox ThisTxtLogger => TxtLogger;
        public override void GuardianTaskService()
        {

        }
        #endregion

        private VzLPRSDKDemoNetSearch _subNetSearch;
        private void BtnNetSearch_Click(object sender, EventArgs e)
        {
            var model = _subNetSearch;
            if (model == null)
            {
                model = _subNetSearch = new VzLPRSDKDemoNetSearch();
                model.StartCallback = () =>
                {
                    VzClientSDK.VZLPRClient_StopFindDevice();
                    var ret = VzClientSDK.VZLPRClient_StartFindDeviceEx(NetSearchCallback, IntPtr.Zero);
                    AppendInfo(ret == 0 ? "开始搜索成功" : "开始搜索失败");
                };
                model.StopCallback = () =>
                {
                    var ret = VzClientSDK.VZLPRClient_StopFindDevice();
                    AppendInfo(ret == 0 ? "停止搜索成功" : "停止搜索失败");
                };
                model.ChangeCallback = (o, n) =>
                {
                    int ret = VzClientSDK.VzLPRClient_UpdateNetworkParam(o.SerialLower, o.SerialHigher, n.Address, n.Gateway, n.Mask);
                    if (ret == 2)
                    {
                        AppendError("设备IP跟网关不在同一网段，请重新输入!");
                        return;
                    }
                    if (ret == -1)
                    {
                        AppendError("修改网络参数失败，请重新输入!");
                        return;
                    }
                    AppendInfo("修改网络参数成功");
                };
                model.LoggerCallback = (a) => Append(a);
            }
            TryAddConfigContent(this.PnlTabCnt3, model);
        }

        /// <summary>
        /// 通过该回调函数获得找到的设备基本信息
        /// </summary>
        /// <param name="pStrDevName">设备名称</param>
        /// <param name="pStrIPAddr">设备IP地址</param>
        /// <param name="usPort1">设备端口号</param>
        /// <param name="usPort2">预留</param>
        /// <param name="SL"></param>
        /// <param name="SH"></param>
        /// <param name="netmask"></param>
        /// <param name="gateway"></param>
        /// <param name="pUserData">回调函数上下文</param>
        public void NetSearchCallback(string pStrDevName, string pStrIPAddr, ushort usPort1, ushort usPort2, uint SL, uint SH, string netmask, string gateway, IntPtr pUserData)
        {
            AppendInfo($"{pStrIPAddr}-{netmask}-{gateway}-{usPort1}-{usPort2}-{SL}-{SH}-{pUserData}-{pStrDevName}");
            _subNetSearch.SearchCallback($"{pStrIPAddr}-{netmask}-{gateway}-{usPort1}-{usPort2}-{SL}-{SH}-{pUserData}-{pStrDevName}");
        }

        private void TsmiForceTrigger_Click(object sender, EventArgs e)
        {
            var config = GetContentModel();
            if (config.Handle == IntPtr.Zero)
            {
                AppendError("请连接设备进行操作");
                return;
            }
            VzClientSDK.VzLPRClient_ForceTrigger(config.Handler);
        }
    }
}
