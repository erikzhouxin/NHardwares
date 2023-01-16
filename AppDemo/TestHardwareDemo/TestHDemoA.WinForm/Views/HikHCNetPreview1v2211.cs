using System;
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
using System.Data.HikHCNetSDK;
using System.Runtime.InteropServices;
using TestHardwareDemo.WinForm.Components;
using TestHardwareDemo.WinForm.Controls;

namespace TestHardwareDemo.WinForm.Views
{
    /// <summary>
    /// 测试海康威视摄像头预览1
    /// </summary>
    [EDisplay("测试海康威视摄像头预览1")]
    public partial class HikHCNetPreview1v2211 : TextLoggerComponent
    {
        /// <summary>
        /// 终端配置
        /// </summary>
        List<ContentModel> _devices = new List<ContentModel>();
        ContentModel _config;
        static string _configPath = System.IO.Path.GetFullPath("testreccoder1config.json");
        bool _isInitialize;
        IHikHCNetSdkProxy CHCNetSDK = HikHCNetSdk.Create();

        public HikHCNetPreview1v2211()
        {
            InitializeComponent();
        }
        private void HikHCNetPreview1v2211_Load(object sender, EventArgs e)
        {
            if (!_isInitialize)
            {
                _isInitialize = true;

                CHCNetSDK.NET_DVR_Init();
                //保存SDK日志 To save the SDK log
                CHCNetSDK.NET_DVR_SetLogToFile(3, System.IO.Path.GetFullPath("."), true);

                _config = new ContentModel(new ConfigModel());

                base.Initialize();

                ReadDeviceAndSetFirstOne();
            }
        }

        #region// Preview

        private uint iLastErr = 0;
        private Int32 m_lUserID = -1;
        private bool m_bInitSDK = false;
        private bool m_bRecord = false;
        private bool m_bTalk = false;
        private Int32 m_lRealHandle = -1;
        private int lVoiceComHandle = -1;
        private string str;

        REALDATACALLBACK RealData = null;
        LOGINRESULTCALLBACK LoginCallBack = null;
        public NET_DVR_PTZPOS m_struPtzCfg;

        public void cbLoginCallBack(int lUserID, int dwResult, IntPtr lpDeviceInfo, IntPtr pUser)
        {
            string strLoginCallBack = $"登录设备，lUserID：{lUserID}，登录结果：{dwResult}";
            if (dwResult == 0)
            {
                uint iErrCode = CHCNetSDK.NET_DVR_GetLastError();
                strLoginCallBack += $"，错误码:{iErrCode}";
                AppendError(strLoginCallBack);
                return;
            }
            AppendInfo(strLoginCallBack);
        }

        private void BtnNetLogin_Click(object sender, System.EventArgs e)
        {
            // 检查格式
            if (!CompatWinFormComponent.TryCheckIPAddressPort(this.TxtNetAddress.Text, this.TxtNetPort.Text, AppendErrorVoid, out Tuble<string, int> outVal))
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

        private void BtnNetPreview_Click(object sender, System.EventArgs e)
        {
            if (m_lUserID < 0)
            {
                MessageBox.Show("Please login the device firstly");
                return;
            }

            if (m_lRealHandle < 0)
            {
                NET_DVR_PREVIEWINFO lpPreviewInfo = new NET_DVR_PREVIEWINFO();
                lpPreviewInfo.hPlayWnd = RealPlayWnd.Handle;//预览窗口
                lpPreviewInfo.lChannel = Int16.Parse(TxtNetChannel.Text);//预te览的设备通道
                lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
                lpPreviewInfo.dwDisplayBufNum = 1; //播放库播放缓冲区最大缓冲帧数
                lpPreviewInfo.byProtoType = 0;
                lpPreviewInfo.byPreviewMode = 0;

                if (TxtNetTarget.Text != "")
                {
                    lpPreviewInfo.lChannel = -1;
                    byte[] byStreamID = System.Text.Encoding.Default.GetBytes(TxtNetTarget.Text);
                    lpPreviewInfo.byStreamID = new byte[32];
                    byStreamID.CopyTo(lpPreviewInfo.byStreamID, 0);
                }


                if (RealData == null)
                {
                    RealData = new REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数
                }

                IntPtr pUser = new IntPtr();//用户数据

                //打开预览 Start live view 
                m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);
                if (m_lRealHandle < 0)
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_RealPlay_V40 failed, error code= " + iLastErr; //预览失败，输出错误号
                    MessageBox.Show(str);
                    return;
                }
                else
                {
                    //预览成功
                    //btnPreview.Text = "Stop Live View";
                }
            }
            else
            {
                //停止预览 Stop live view 
                if (!CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_StopRealPlay failed, error code= " + iLastErr;
                    MessageBox.Show(str);
                    return;
                }
                m_lRealHandle = -1;
                //btnPreview.Text = "Live View";

            }
            return;
        }

        public void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, IntPtr pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
            if (dwBufSize > 0)
            {
                byte[] sData = new byte[dwBufSize];
                Marshal.Copy(pBuffer, sData, 0, (Int32)dwBufSize);

                string str = "实时流数据.ps";
                var fs = new System.IO.FileStream(str, System.IO.FileMode.Create);
                int iLen = (int)dwBufSize;
                fs.Write(sData, 0, iLen);
                fs.Close();
            }
        }

        private void BtnNetBmp_Click(object sender, EventArgs e)
        {
            string sBmpPicFileName;
            //图片保存路径和文件名 the path and file name to save
            sBmpPicFileName = "BMP_test.bmp";

            //BMP抓图 Capture a BMP picture
            if (!CHCNetSDK.NET_DVR_CapturePicture(m_lRealHandle, sBmpPicFileName))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_CapturePicture failed, error code= " + iLastErr;
                MessageBox.Show(str);
                return;
            }
            else
            {
                str = "Successful to capture the BMP file and the saved file is " + sBmpPicFileName;
                MessageBox.Show(str);
            }
            return;
        }

        private void BtnNetJpeg_Click(object sender, EventArgs e)
        {
            string sJpegPicFileName;
            //图片保存路径和文件名 the path and file name to save
            sJpegPicFileName = "JPEG_test.jpg";

            int lChannel = Int16.Parse(TxtNetChannel.Text); //通道号 Channel number

            var lpJpegPara = new NET_DVR_JPEGPARA();
            lpJpegPara.wPicQuality = 0; //图像质量 Image quality
            lpJpegPara.wPicSize = 0xff; //抓图分辨率 Picture size: 2- 4CIF，0xff- Auto(使用当前码流分辨率)，抓图分辨率需要设备支持，更多取值请参考SDK文档

            //JPEG抓图 Capture a JPEG picture
            if (!CHCNetSDK.NET_DVR_CaptureJPEGPicture(m_lUserID, lChannel, ref lpJpegPara, sJpegPicFileName))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_CaptureJPEGPicture failed, error code= " + iLastErr;
                MessageBox.Show(str);
                return;
            }
            else
            {
                str = "Successful to capture the JPEG file and the saved file is " + sJpegPicFileName;
                MessageBox.Show(str);
            }
            return;
        }

        private void BtnNetRecord_Click(object sender, EventArgs e)
        {
            //录像保存路径和文件名 the path and file name to save
            string sVideoFileName;
            sVideoFileName = "Record_test.mp4";

            if (m_bRecord == false)
            {
                //强制I帧 Make a I frame
                int lChannel = Int16.Parse(TxtNetChannel.Text); //通道号 Channel number
                CHCNetSDK.NET_DVR_MakeKeyFrame(m_lUserID, lChannel);

                //开始录像 Start recording
                if (!CHCNetSDK.NET_DVR_SaveRealData(m_lRealHandle, sVideoFileName))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_SaveRealData failed, error code= " + iLastErr;
                    MessageBox.Show(str);
                    return;
                }
                else
                {
                    //btnRecord.Text = "Stop Record";
                    m_bRecord = true;
                }
            }
            else
            {
                //停止录像 Stop recording
                if (!CHCNetSDK.NET_DVR_StopSaveRealData(m_lRealHandle))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_StopSaveRealData failed, error code= " + iLastErr;
                    MessageBox.Show(str);
                    return;
                }
                else
                {
                    str = "Successful to stop recording and the saved file is " + sVideoFileName;
                    MessageBox.Show(str);
                    //btnRecord.Text = "Start Record";
                    m_bRecord = false;
                }
            }

            return;
        }

        private void btn_Exit_Click(object sender, EventArgs e)
        {
            //停止预览 Stop live view 
            if (m_lRealHandle >= 0)
            {
                CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle);
                m_lRealHandle = -1;
            }

            //注销登录 Logout the device
            if (m_lUserID >= 0)
            {
                CHCNetSDK.NET_DVR_Logout(m_lUserID);
                m_lUserID = -1;
            }

            CHCNetSDK.NET_DVR_Cleanup();

            Application.Exit();
        }

        public void VoiceDataCallBack(int lVoiceComHandle, IntPtr pRecvDataBuffer, uint dwBufSize, byte byAudioFlag, System.IntPtr pUser)
        {
            byte[] sString = new byte[dwBufSize];
            Marshal.Copy(pRecvDataBuffer, sString, 0, (Int32)dwBufSize);

            if (byAudioFlag == 0)
            {
                //将缓冲区里的音频数据写入文件 save the data into a file
                string str = "PC采集音频文件.pcm";
                var fs = new System.IO.FileStream(str, System.IO.FileMode.Create);
                int iLen = (int)dwBufSize;
                fs.Write(sString, 0, iLen);
                fs.Close();
            }
            if (byAudioFlag == 1)
            {
                //将缓冲区里的音频数据写入文件 save the data into a file
                string str = "设备音频文件.pcm";
                var fs = new System.IO.FileStream(str, System.IO.FileMode.Create);
                int iLen = (int)dwBufSize;
                fs.Write(sString, 0, iLen);
                fs.Close();
            }

        }

        private void BtnNetVioceTalk_Click(object sender, EventArgs e)
        {
            if (m_bTalk == false)
            {
                //开始语音对讲 Start two-way talk
                var VoiceData = new VOICEDATACALLBACKV30(VoiceDataCallBack);//预览实时流回调函数

                lVoiceComHandle = CHCNetSDK.NET_DVR_StartVoiceCom_V30(m_lUserID, 1, true, VoiceData, IntPtr.Zero);
                //bNeedCBNoEncData [in]需要回调的语音数据类型：0- 编码后的语音数据，1- 编码前的PCM原始数据

                if (lVoiceComHandle < 0)
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_StartVoiceCom_V30 failed, error code= " + iLastErr;
                    MessageBox.Show(str);
                    return;
                }
                else
                {
                    //btnVioceTalk.Text = "Stop Talk";
                    m_bTalk = true;
                }
            }
            else
            {
                //停止语音对讲 Stop two-way talk
                if (!CHCNetSDK.NET_DVR_StopVoiceCom(lVoiceComHandle))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_StopVoiceCom failed, error code= " + iLastErr;
                    MessageBox.Show(str);
                    return;
                }
                else
                {
                    //btnVioceTalk.Text = "Start Talk";
                    m_bTalk = false;
                }
            }
        }

        private void BtnNetPtz_Click(object sender, EventArgs e)
        {
            var model = new HikHCNetPreview1Ptz();
            TryAddConfigContent(this.PnlTabCnt3, model);
        }
        #endregion Preview
        private void ReadDeviceAndSetFirstOne()
        {
            var configText = this.CbxNetConfigs.Text;
            this.CbxNetConfigs.Items.Clear();
            List<ConfigModel> list;
            if (System.IO.File.Exists(_configPath))
            {
                try
                {
                    list = System.IO.File.ReadAllText(_configPath).GetJsonObject<List<ConfigModel>>();
                }
                catch { list = new List<ConfigModel>(); }
            }
            else
            {
                System.IO.File.WriteAllText(_configPath, "[]");
                list = new List<ConfigModel>();
            }
            foreach (var item in list)
            {
                var key = item.Key;
                if (!_devices.Any(s => s.Key == key))
                {
                    _devices.Add(new ContentModel(item));
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
            this.TxtNetAddress.Text = model.Config.Address;
            this.TxtNetPort.Text = model.Config.Port.ToString();
            this.TxtNetAccount.Text = model.Config.Account;
            this.TxtNetPassword.Text = model.Config.Password;
            if (model.UserID > 0)
            {
                NetUserLogout(model);
            }
            model.LoginCallBack ??= new LOGINRESULTCALLBACK(cbLoginCallBack);//注册回调函数
            var loginInfo = new NET_DVR_USER_LOGIN_INFO()
            {
                sDeviceAddress = new byte[129],
                sUserName = new byte[64],
                sPassword = new byte[64]
            };
            var deviceInfo = new NET_DVR_DEVICEINFO_V40();
            //设备IP地址或者域名
            Encoding.Default.GetBytes(model.Config.Address).CopyTo(loginInfo.sDeviceAddress, 0);
            //设备用户名
            Encoding.Default.GetBytes(model.Config.Account).CopyTo(loginInfo.sUserName, 0);
            //设备密码
            Encoding.Default.GetBytes(model.Config.Password).CopyTo(loginInfo.sPassword, 0);
            //设备服务端口号
            loginInfo.wPort = (ushort)model.Config.Port;

            loginInfo.cbLoginResult = LoginCallBack;
            loginInfo.bUseAsynLogin = false; //是否异步登录：0- 否，1- 是 

            //登录设备 Login the device
            model.UserID = CHCNetSDK.NET_DVR_Login_V40(ref loginInfo, ref deviceInfo);
            if (model.UserID < 0)
            {
                var iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                AppendError($"{model.Config.Address}:{model.Config.Port}?Account={model.Config.Account}&Password=****** 登录失败,错误代码为{iLastErr}");
                return;
            }
            model.LoginInfo = loginInfo;
            model.DeviceInfo = deviceInfo;
            //登录成功
            AppendSuccess($"{model.Config.Address}:{model.Config.Port}?Account={model.Config.Account}&Password=****** 登录成功");
            AppendInfo(model.DeviceInfo.GetJsonFormatString());
        }

        private void BtnNetLogout_Click(object sender, EventArgs e)
        {
            NetUserLogout(_config);
        }

        private void NetUserLogout(ContentModel model)
        {
            //注销登录 Logout the device
            if (model.RealHandler > 0)
            {
                if (CHCNetSDK.NET_DVR_StopRealPlay(model.RealHandler))
                {
                    AppendInfo($"{model.Config.Address}:{model.Config.Port}已停止视频预览");
                }
                else
                {
                    AppendError($"{model.Config.Address}:{model.Config.Port}停止视频预览失败,错误代码为{CHCNetSDK.NET_DVR_GetLastError()}");
                }
            }
            if (!CHCNetSDK.NET_DVR_Logout(_config.UserID))
            {
                AppendError($"{model.Config.Address}:{model.Config.Port}退出登录失败,错误代码为{CHCNetSDK.NET_DVR_GetLastError()}");
                return;
            }
            AppendInfo($"{model.Config.Address}:{model.Config.Port}已成功退出");
        }
        #region // 基础内容
        public override RichTextBox ThisTxtLogger => TxtLogger;
        public override void GuardianTaskService()
        {
        }
        #endregion 基础内容
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
            public int UserID { get; set; }
            public int RealHandler { get; set; }
            public LOGINRESULTCALLBACK LoginCallBack { get; set; }
            public NET_DVR_USER_LOGIN_INFO LoginInfo { get; set; }
            public NET_DVR_DEVICEINFO_V40 DeviceInfo { get; set; }
            /// <summary>
            /// 构造
            /// </summary>
            /// <param name="config"></param>
            public ContentModel(ConfigModel config)
            {
                Config = config;
            }
        }
        internal interface IVzLPRSDKDemoSubCtrl
        {
            /// <summary>
            /// 清理返回False则不能被清理
            /// </summary>
            IAlertMsg Clear();
        }
        #endregion
        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void OnHandleDestroyed(EventArgs e)
        {
            try
            {
                foreach (var item in _devices)
                {
                    try
                    {
                        if (item.RealHandler > 0) // 释放实时预览
                        { CHCNetSDK.NET_DVR_StopRealPlay(item.RealHandler); }
                        if (item.UserID > 0) // 释放用户登录
                        { CHCNetSDK.NET_DVR_Logout(item.UserID); }
                    }
                    catch { }
                }
                CHCNetSDK.NET_DVR_Cleanup();
            }
            catch { }
            base.OnHandleDestroyed(e);
        }
    }
}
