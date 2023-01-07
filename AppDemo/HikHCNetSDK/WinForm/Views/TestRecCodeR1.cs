﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Cobber;
using System.Data.Extter;
using System.Data.NHInterfaces;
using System.Data.Logger;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.NSerialPort;
using System.Text.RegularExpressions;

namespace HikHCNetSDK.WinForm.Views
{
    public partial class TestRecCodeR1 : UserControl
    {
        /// <summary>
        /// 终端配置
        /// </summary>
        static Dictionary<string, SerialPortConfigModel> _devices = new Dictionary<string, SerialPortConfigModel>();
        static object _config = new SerialPortConfigModel()
        {
            PortName = "COM1",
            PortRate = 9600,
            DataBits = DataBitsType.Len8,
            Parity = DataParityType.Unknown,
            StopBits = StopBitsType.One,
            ReadTimeout = 500,
            ThresholdLen = 30,
        };
        static string _configPath = System.IO.Path.GetFullPath("testreccoder1config.json");
        internal static TestRecCodeR1 Instance { get; set; }
        Thread _guardianService;
        CancellationTokenSource _guardianCts;
        bool _isInitialize;
        public TestRecCodeR1()
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
                    _devices.Add(key, new SerialPortConfigModel
                    {
                        PortName = item.Item1,
                        PortRate = item.Item2.ToPInt32(9600),
                        DataBits = DataBitsType.Len8,
                        Parity = DataParityType.Unknown,
                        StopBits = StopBitsType.One,
                    });
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
        public TestRecCodeR1 AppendError(string message)
        {
            this.Invoke((Action)(() =>
            {
                AppendTextEx(message, Color.Red);
            }));
            return this;
        }
        public TestRecCodeR1 AppendSuccess(string message)
        {
            this.Invoke((Action)(() =>
            {
                AppendTextEx(message, Color.Green);
            }));
            return this;
        }
        public TestRecCodeR1 AppendInfo(string message)
        {
            this.Invoke((Action)(() =>
            {
                AppendTextEx(message, Color.Blue);
            }));
            return this;
        }
        public TestRecCodeR1 Append(IAlertMsg alert)
        {
            this.Invoke((Action)(() =>
            {
                AppendTextEx(alert.Message, alert.IsSuccess ? Color.Green : Color.Red);
            }));
            return this;
        }
        public TestRecCodeR1 Append(Exception alert)
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

        private void BtnNetConfigConnect_Click(object sender, EventArgs e)
        {
            var iptext = (this.TxtNetConfigIp.Text ?? String.Empty).Trim();
            if (!Regex.IsMatch(iptext, "^COM\\d+$"))
            {
                AppendError($"小呆瓜注意：串口号（{iptext}）长这样吗？能不能长点心好不好啊！");
                return;
            }
            var porttext = (this.TxtNetConfigPort.Text ?? "0").Trim();
            var portVal = porttext.ToPInt32();
            if (!new int[] { 2400, 4800, 9600, 19200, 38400, 57600, 115200 }.Contains(portVal))
            {
                AppendError($"小笨蛋注意：波特率是[2400,4800,9600,19200,38400,57600,115200]的数字哦！");
                return;
            }
            var key = $"{iptext}:{porttext}";
            var model = _devices.FirstOrDefault(s => s.Key == key);
            if (model.Value == null)
            {
                _devices.Add(key, new SerialPortConfigModel
                {
                    PortName = iptext,
                    PortRate = porttext.ToPInt32(9600),
                    DataBits = DataBitsType.Len8,
                    Parity = DataParityType.Unknown,
                    StopBits = StopBitsType.One,
                });
                TrySaveConfig();
            }
            this.CbxNetConfigs.Text = key;
            ReadDeviceAndSetFirstOne();
        }

        private void CbxNetConfigs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = this.CbxNetConfigs.Text;
            var model = _devices.FirstOrDefault(s => s.Key == text);
            if (model.Value == null)
            {
                AppendError($"小呆瓜注意：此设备已删除");
                return;
            }

            AppendSuccess($"{text} => 连接成功");
        }

        private void RecBarCodeReceived(byte[] recBytes)
        {
            AppendInfo(recBytes.GetHexString());
        }

        private void RecBarCodeErrored(byte[] errBytes, Exception ex)
        {
            Append(ex);
        }

        private void BtnNetConfigRemove_Click(object sender, EventArgs e)
        {
            var key = $"{this.TxtNetConfigIp.Text?.Trim()}:{this.TxtNetConfigPort.Text?.Trim()}";
            _devices.Remove(key);
            TrySaveConfig();
            ReadDeviceAndSetFirstOne();
        }

        private static void TrySaveConfig()
        {
            try
            {
                System.IO.File.WriteAllText(_configPath, _devices.Select(s => new Tuble8String() { Item1 = s.Value.PortName, Item2 = s.Value.PortRate.ToString() }).GetJsonFormatString());
            }
            catch { }
        }

        private void TsrmLoggerClear_Click(object sender, EventArgs e)
        {
            this.TxtLogger.Clear();
        }
    }
}