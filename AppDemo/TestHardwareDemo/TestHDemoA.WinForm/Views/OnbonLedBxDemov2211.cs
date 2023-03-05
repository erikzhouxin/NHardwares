using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Cobber;
using System.Data.Extter;
using System.Data.OnbonLedBxSDK;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TestHardwareDemo.WinForm.Components;
using TestHardwareDemo.WinForm.Controls;

namespace TestHardwareDemo.WinForm.Views
{
    /// <summary>
    /// 仰邦科技LED显示测试
    /// </summary>
    [EDisplay("测试仰邦科技LED显示示例1")]
    public partial class OnbonLedBxDemov2211 : TextLoggerComponent
    {
        private bool _isInitialed;
        static ILedBxDualSdkProxy bxdualsdk = LedBxDualSdk.Create();
        private List<ContentModel> _devices = new();
        private string _configPath = System.IO.Path.GetFullPath($"{nameof(OnbonLedBxDemov2211)}.json");
        private ContentModel _config;
        /// <summary>
        /// 构造
        /// </summary>
        public OnbonLedBxDemov2211()
        {
            InitializeComponent();
        }

        private void VzLPRSDKDemov2211_Load(object sender, EventArgs e)
        {
            if (!_isInitialed)
            {
                _isInitialed = true;

                //初始化动态库
                int err = bxdualsdk.BxDual_InitSdk();

                base.Initialize();

                ReadDeviceAndSetFirstOne();
            }
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            try
            {
                //释放动态库
                //bxdualsdk.BxDual_ReleaseSdk();
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
            this.TxtNetPort.Text = model.Config.PortRate.ToString();
            this.TxtNetSerialNum.Text = model.Config.SerialNum;
            this.TxtNetAccount.Text = model.Config.Account;
            this.TxtNetPassword.Text = model.Config.Password;

            //Ping_data data = new Ping_data();
            //var err = bxdualsdk.BxDual_cmd_uart_searchController(ref data, config.Address.GetBytes());

            //AppendInfo("ControllerType:0x" + data.ControllerType.ToString("X2"));
            //AppendInfo("FirmwareVersion:V" + data.FirmwareVersion.GetString());
            //AppendInfo("ipAdder:" + data.ipAdder.GetString());
            //common_56.Net_Bright(2);
            //Ping_data data = new Ping_data();
            //err = bxdualsdk.BxDual_cmd_tcpPing(config.Address.GetBytes(), config.PortRate, ref data);

            //Console.WriteLine("ControllerType:0x" + data.ControllerType.ToString("X2"));
            //Console.WriteLine("FirmwareVersion:V" + System.Text.Encoding.Default.GetString(data.FirmwareVersion));
            //Console.WriteLine("ipAdder:" + System.Text.Encoding.Default.GetString(data.ipAdder));
            //Console.WriteLine("ScreenWidth:" + data.ScreenWidth.ToString());
            //Console.WriteLine("ScreenHeight:" + data.ScreenHeight.ToString());
            //Console.WriteLine("cmb_ping_Color:" + data.Color.ToString());
            //Console.WriteLine("\r\n");
            //common_56.sendConfigFile();
            //Console.Write("请输入串口：");
            //com = Encoding.GetEncoding("GBK").GetBytes(Console.ReadLine());
            //err = bxdualsdk.BxDual_cmd_check_time(ip, port);
            //if (err == 0) { Console.WriteLine("校时成功"); } else { Console.WriteLine("校时失败"); }
        }

        private void ChkNetPDNS_Click(object sender, EventArgs e)
        {
            this.TxtNetSerialNum.Enabled = this.ChkNetPDNS.Checked;
        }

        private void BtnNetExit_Click(object sender, EventArgs e)
        {
            var config = GetContentModel();

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
        #region // 内部类
        internal class ConfigModel
        {
            public string Key { get => $"{Address}:{PortRate}"; }
            public string Address { get; set; }
            public int PortRate { get; set; }
            public bool IsCom { get => Address.StartsWith("COM"); }
            public string SerialNum { get; set; }
            public string Account { get; set; }
            public string Password { get; set; }
            public ConfigModel() : this("192.168.1.100", 80) { }
            public ConfigModel(string address, int port)
            {
                Address = address;
                PortRate = port;
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

        private void BtnNetSearch_Click(object sender, EventArgs e)
        {
        }
        private void TsmiForceTrigger_Click(object sender, EventArgs e)
        {
        }
        private void TmsrRealCapture_Click(object sender, EventArgs e)
        {
        }
        private void TsmiGetSetIOValue_Click(object sender, EventArgs e)
        {
        }
    }
}
