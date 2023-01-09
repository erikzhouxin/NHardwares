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

namespace HikHCNetSDK.WinForm.Views
{
    public partial class PreviewDemo1 : UserControl
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
        internal static PreviewDemo1 Instance { get; set; }
        Thread _guardianService;
        CancellationTokenSource _guardianCts;
        bool _isInitialize;

        public PreviewDemo1()
        {
            Instance = this;
            InitializeComponent();
        }
        private void TestScanner_Load(object sender, EventArgs e)
        {
            if (!_isInitialize)
            {
                _isInitialize = true;

                ReadDeviceAndSetFirstOne();

                _guardianCts = new CancellationTokenSource();
                _guardianService = new Thread(async () => await GuardianServiceAsync(_guardianCts.Token));
                _guardianService.IsBackground = true;
                _guardianService.Start();

                CHCNetSDK = HikHCNetSdk.Create();
                m_bInitSDK = CHCNetSDK.NET_DVR_Init();
                if (m_bInitSDK == false)
                {
                    MessageBox.Show("NET_DVR_Init error!");
                    return;
                }
                else
                {
                    //保存SDK日志 To save the SDK log
                    CHCNetSDK.NET_DVR_SetLogToFile(3, System.IO.Path.GetFullPath("."), true);
                }
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
        public NET_DVR_USER_LOGIN_INFO struLogInfo;
        public NET_DVR_DEVICEINFO_V40 DeviceInfo;

        public delegate void UpdateTextStatusCallback(string strLogStatus, IntPtr lpDeviceInfo);
        IHikHCNetSdkProxy CHCNetSDK;
        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (m_lRealHandle >= 0)
            {
                CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle);
            }
            if (m_lUserID >= 0)
            {
                CHCNetSDK.NET_DVR_Logout(m_lUserID);
            }
            if (m_bInitSDK == true)
            {
                CHCNetSDK.NET_DVR_Cleanup();
            }
            base.OnHandleDestroyed(e);
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {

        }

        public void UpdateClientList(string strLogStatus, IntPtr lpDeviceInfo)
        {
            //列表新增报警信息
            labelLogin.Text = "登录状态（异步）：" + strLogStatus;
        }

        public void cbLoginCallBack(int lUserID, int dwResult, IntPtr lpDeviceInfo, IntPtr pUser)
        {
            string strLoginCallBack = "登录设备，lUserID：" + lUserID + "，dwResult：" + dwResult;

            if (dwResult == 0)
            {
                uint iErrCode = CHCNetSDK.NET_DVR_GetLastError();
                strLoginCallBack = strLoginCallBack + "，错误号:" + iErrCode;
            }

            //下面代码注释掉也会崩溃
            if (InvokeRequired)
            {
                object[] paras = new object[2];
                paras[0] = strLoginCallBack;
                paras[1] = lpDeviceInfo;
                labelLogin.BeginInvoke(new UpdateTextStatusCallback(UpdateClientList), paras);
            }
            else
            {
                //创建该控件的主线程直接更新信息列表 
                UpdateClientList(strLoginCallBack, lpDeviceInfo);
            }

        }

        private void btnLogin_Click(object sender, System.EventArgs e)
        {
            if (textBoxIP.Text == "" || textBoxPort.Text == "" ||
                textBoxUserName.Text == "" || textBoxPassword.Text == "")
            {
                MessageBox.Show("Please input IP, Port, User name and Password!");
                return;
            }
            if (m_lUserID < 0)
            {

                struLogInfo = new NET_DVR_USER_LOGIN_INFO();

                //设备IP地址或者域名
                byte[] byIP = System.Text.Encoding.Default.GetBytes(textBoxIP.Text);
                struLogInfo.sDeviceAddress = new byte[129];
                byIP.CopyTo(struLogInfo.sDeviceAddress, 0);

                //设备用户名
                byte[] byUserName = System.Text.Encoding.Default.GetBytes(textBoxUserName.Text);
                struLogInfo.sUserName = new byte[64];
                byUserName.CopyTo(struLogInfo.sUserName, 0);

                //设备密码
                byte[] byPassword = System.Text.Encoding.Default.GetBytes(textBoxPassword.Text);
                struLogInfo.sPassword = new byte[64];
                byPassword.CopyTo(struLogInfo.sPassword, 0);

                struLogInfo.wPort = ushort.Parse(textBoxPort.Text);//设备服务端口号

                if (LoginCallBack == null)
                {
                    LoginCallBack = new LOGINRESULTCALLBACK(cbLoginCallBack);//注册回调函数                    
                }
                struLogInfo.cbLoginResult = LoginCallBack;
                struLogInfo.bUseAsynLogin = false; //是否异步登录：0- 否，1- 是 

                DeviceInfo = new NET_DVR_DEVICEINFO_V40();

                //登录设备 Login the device
                m_lUserID = CHCNetSDK.NET_DVR_Login_V40(ref struLogInfo, ref DeviceInfo);
                if (m_lUserID < 0)
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_Login_V40 failed, error code= " + iLastErr; //登录失败，输出错误号
                    MessageBox.Show(str);
                    return;
                }
                else
                {
                    //登录成功
                    MessageBox.Show("Login Success!");
                    btnLogin.Text = "Logout";
                }

            }
            else
            {
                //注销登录 Logout the device
                if (m_lRealHandle >= 0)
                {
                    MessageBox.Show("Please stop live view firstly");
                    return;
                }

                if (!CHCNetSDK.NET_DVR_Logout(m_lUserID))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_Logout failed, error code= " + iLastErr;
                    MessageBox.Show(str);
                    return;
                }
                m_lUserID = -1;
                btnLogin.Text = "Login";
            }
            return;
        }

        private void btnPreview_Click(object sender, System.EventArgs e)
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
                lpPreviewInfo.lChannel = Int16.Parse(textBoxChannel.Text);//预te览的设备通道
                lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
                lpPreviewInfo.dwDisplayBufNum = 1; //播放库播放缓冲区最大缓冲帧数
                lpPreviewInfo.byProtoType = 0;
                lpPreviewInfo.byPreviewMode = 0;

                if (textBoxID.Text != "")
                {
                    lpPreviewInfo.lChannel = -1;
                    byte[] byStreamID = System.Text.Encoding.Default.GetBytes(textBoxID.Text);
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
                    btnPreview.Text = "Stop Live View";
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
                btnPreview.Text = "Live View";

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

        private void btnBMP_Click(object sender, EventArgs e)
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

        private void btnJPEG_Click(object sender, EventArgs e)
        {
            string sJpegPicFileName;
            //图片保存路径和文件名 the path and file name to save
            sJpegPicFileName = "JPEG_test.jpg";

            int lChannel = Int16.Parse(textBoxChannel.Text); //通道号 Channel number

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

        private void btnRecord_Click(object sender, EventArgs e)
        {
            //录像保存路径和文件名 the path and file name to save
            string sVideoFileName;
            sVideoFileName = "Record_test.mp4";

            if (m_bRecord == false)
            {
                //强制I帧 Make a I frame
                int lChannel = Int16.Parse(textBoxChannel.Text); //通道号 Channel number
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
                    btnRecord.Text = "Stop Record";
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
                    btnRecord.Text = "Start Record";
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

        private void btnPTZ_Click(object sender, EventArgs e)
        {

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

        private void btnVioceTalk_Click(object sender, EventArgs e)
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
                    btnVioceTalk.Text = "Stop Talk";
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
                    btnVioceTalk.Text = "Start Talk";
                    m_bTalk = false;
                }
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void Preview_Load(object sender, EventArgs e)
        {

        }

        private void Ptz_Set_Click(object sender, EventArgs e)
        {

        }

        private void PreSet_Click(object sender, EventArgs e)
        {
            m_lChannel = 1;


            comboBoxSpeed.SelectedIndex = 3;
            if (m_lRealHandle > -1)
            {
                checkBoxPreview.Checked = true;
            }
            else
            {
                checkBoxPreview.Checked = false;
            }

            PtzRange_Click(sender, e);
        }
        #endregion Preview
        #region // PreSet
        public int m_lChannel = 1;
        private bool bAuto = false;
        public int PreSetNo = 0;
        public NET_DVR_PTZSCOPE m_struPtzCfg1;
        public NET_DVR_PRESET_NAME[] m_struPreSetCfg = new NET_DVR_PRESET_NAME[300];

        private void PreSetSet_Click(object sender, EventArgs e)
        {
            while (comboBox1.Text != "")
            {
                if (textBoxPanPos1.Text == "" || textBoxTiltPos1.Text == "" || textBoxZoomPos1.Text == "" || PreSetName.Text == "")
                {
                    MessageBox.Show("please input the Parameters");
                    return;
                }
                else
                {
                    PreSetNo = comboBox1.Items.IndexOf(comboBox1.Text);
                    m_struPreSetCfg[PreSetNo].byRes = new byte[58];
                    m_struPreSetCfg[PreSetNo].byRes1 = new byte[2];
                    Int32 nSize = Marshal.SizeOf(m_struPreSetCfg[PreSetNo]);
                    IntPtr ptrPreSetCfg = Marshal.AllocHGlobal(nSize);


                    m_struPreSetCfg[PreSetNo].dwSize = (uint)nSize;
                    /*str1 = "dddd";
                    m_struPreSetCfg[PreSetNo].byName = System.Text.Encoding.Default.GetBytes(str1);*/
                    /* m_struPreSetCfg[PreSetNo].byName = new byte[32];
                     m_struPreSetCfg[PreSetNo].byName[0] = 100;
                     m_struPreSetCfg[PreSetNo].byName[1] = 100;
                     m_struPreSetCfg[PreSetNo].byName[2] = 100;
                     m_struPreSetCfg[PreSetNo].byName[3] = 100;*/
                    byte[] byName = System.Text.Encoding.Default.GetBytes(PreSetName.Text);
                    m_struPreSetCfg[PreSetNo].byName = new byte[32];
                    byName.CopyTo(m_struPreSetCfg[PreSetNo].byName, 0);
                    /* m_struPreSetCfg[PreSetNo].wPanPos = new UInt16();
                    m_struPreSetCfg[PreSetNo].wPanPos = ushort.Parse(textBoxPanPos.Text);
                    /*  m_struPreSetCfg[PreSetNo].wTiltPos = ushort.Parse(textBoxTiltPos.Text);
                     m_struPreSetCfg[PreSetNo].wZoomPos = ushort.Parse(textBoxZoomPos.Text);*/

                    /*for (i = 0; i < 32; i++)
                    {
                        m_struPreSetCfg[PreSetNo].byName[i] = byte.Parse(str);
                    }*/
                    Marshal.StructureToPtr(m_struPreSetCfg[PreSetNo], ptrPreSetCfg, false);

                    //设置参数失败
                    if (!CHCNetSDK.NET_DVR_SetDVRConfig(m_lUserID, HikHCNetSdk.NET_DVR_SET_PRESET_NAME, 1, ptrPreSetCfg, (UInt32)nSize))
                    {
                        iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                        str = "NET_DVR_SetDVRConfig failed, error code= " + iLastErr;
                        MessageBox.Show(str);
                        return;
                    }
                    else
                    {
                        m_struPreSetCfg[PreSetNo] = (NET_DVR_PRESET_NAME)Marshal.PtrToStructure(ptrPreSetCfg, typeof(NET_DVR_PRESET_NAME));
                        MessageBox.Show("设置成功");
                    }
                    Marshal.FreeHGlobal(ptrPreSetCfg);
                    return;
                }
            }
            MessageBox.Show("please input the PtrPreSetNo");
        }

        private void PreSetGet_Click(object sender, EventArgs e)
        {
            while (comboBox1.Text != "")
            {
                PreSetNo = comboBox1.Items.IndexOf(comboBox1.Text);
                UInt32 dwReturn = 0;
                Int32 nSize = Marshal.SizeOf(m_struPreSetCfg[PreSetNo]);
                Int32 nOutBufSize = nSize * 300;
                IntPtr ptrPreSetCfg = Marshal.AllocHGlobal(nOutBufSize);
                int i;
                for (i = 0; i < 300; i++)
                {
                    //m_struPreSetCfg[i] = new CHCNetSDK.NET_DVR_PRESET_NAME();
                    /* if (i == PreSetNo)
                     {
                         textBoxPanPos1.Text = Convert.ToString(0.1 * m_struPreSetCfg[PreSetNo].wPanPos);
                         textBoxTiltPos1.Text = Convert.ToString(0.1 * m_struPreSetCfg[PreSetNo].wTiltPos);
                         textBoxZoomPos1.Text = Convert.ToString(0.1 * m_struPreSetCfg[PreSetNo].wZoomPos);
                     }*/
                    Marshal.StructureToPtr(m_struPreSetCfg[i], (IntPtr)((Int32)(ptrPreSetCfg) + i * nSize), false);

                }
                //获取参数失败
                if (!CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID, HikHCNetSdk.NET_DVR_GET_PRESET_NAME, 1, ptrPreSetCfg, (UInt32)nOutBufSize, ref dwReturn))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_GetDVRConfig failed, error code= " + iLastErr;
                    MessageBox.Show(str);
                    return;
                }
                else
                {
                    for (i = 0; i < 300; i++)
                    {
                        m_struPreSetCfg[i] = (NET_DVR_PRESET_NAME)Marshal.PtrToStructure((IntPtr)((Int32)(ptrPreSetCfg) + i * nSize), typeof(NET_DVR_PRESET_NAME));
                    }
                    textBoxPanPos1.Text = Convert.ToString(0.1 * m_struPreSetCfg[PreSetNo].wPanPos);
                    textBoxTiltPos1.Text = Convert.ToString(0.1 * m_struPreSetCfg[PreSetNo].wTiltPos);
                    textBoxZoomPos1.Text = Convert.ToString(0.1 * m_struPreSetCfg[PreSetNo].wZoomPos);
                    if (m_struPreSetCfg[PreSetNo].byName != null)
                    {
                        str = System.Text.Encoding.Default.GetString(m_struPreSetCfg[PreSetNo].byName);
                    }

                    PreSetName.Text = str;
                    MessageBox.Show("获取成功");
                }
                Marshal.FreeHGlobal(ptrPreSetCfg);
                return;

            }
            MessageBox.Show("please input the PtrPreSetNo");

        }

        private void PreSetGo_Click(object sender, EventArgs e)
        {
            while (comboBox1.Text != "")
            {
                PreSetNo = comboBox1.Items.IndexOf(comboBox1.Text);
                if (!CHCNetSDK.NET_DVR_PTZPreset_Other(m_lUserID, 1, HikHCNetSdk.GOTO_PRESET, (UInt32)(PreSetNo + 1)))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_PTZPreset_Other failed, error code= " + iLastErr;
                    MessageBox.Show(str);
                    return;
                }
                else
                {
                    /*if (m_struPreSetCfg[PreSetNo].wPanPos == 0)
                    {
                        MessageBox.Show("该预置点还没有设置");
                        return;
                    }*/
                    textBoxPanPos1.Text = Convert.ToString(0.1 * m_struPreSetCfg[PreSetNo].wPanPos);
                    textBoxTiltPos1.Text = Convert.ToString(0.1 * m_struPreSetCfg[PreSetNo].wTiltPos);
                    textBoxZoomPos1.Text = Convert.ToString(0.1 * m_struPreSetCfg[PreSetNo].wZoomPos);
                    if (m_struPreSetCfg[PreSetNo].byName != null)
                    {
                        PreSetName.Text = System.Text.Encoding.Default.GetString(m_struPreSetCfg[PreSetNo].byName);
                    }
                    MessageBox.Show("调用成功");
                }
                return;
            }
            MessageBox.Show("please input the PtrPreSetNo");
        }


        private void btnLeft_MouseDown(object sender, MouseEventArgs e)
        {
            if (checkBoxPreview.Checked)
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed(m_lRealHandle, (uint)HikHCNetSdk.PAN_LEFT, 0, (uint)(comboBoxSpeed.SelectedIndex + 1));
            }
            else
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(m_lUserID, m_lChannel, HikHCNetSdk.PAN_LEFT, 0, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
        }

        private void btnLeft_MouseUp(object sender, MouseEventArgs e)
        {
            if (checkBoxPreview.Checked)
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed(m_lRealHandle, HikHCNetSdk.PAN_LEFT, 1, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
            else
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(m_lUserID, m_lChannel, HikHCNetSdk.PAN_LEFT, 1, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
        }

        private void btnUp_MouseDown(object sender, MouseEventArgs e)
        {
            if (checkBoxPreview.Checked)
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed(m_lRealHandle, HikHCNetSdk.TILT_UP, 0, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
            else
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(m_lUserID, m_lChannel, HikHCNetSdk.TILT_UP, 0, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
        }

        private void btnUp_MouseUp(object sender, MouseEventArgs e)
        {
            if (checkBoxPreview.Checked)
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed(m_lRealHandle, HikHCNetSdk.TILT_UP, 1, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
            else
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(m_lUserID, m_lChannel, HikHCNetSdk.TILT_UP, 1, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
        }

        private void btnRight_MouseDown(object sender, MouseEventArgs e)
        {
            if (checkBoxPreview.Checked)
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed(m_lRealHandle, HikHCNetSdk.PAN_RIGHT, 0, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
            else
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(m_lUserID, m_lChannel, HikHCNetSdk.PAN_RIGHT, 0, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
        }

        private void btnRight_MouseUp(object sender, MouseEventArgs e)
        {
            if (checkBoxPreview.Checked)
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed(m_lRealHandle, HikHCNetSdk.PAN_RIGHT, 1, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
            else
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(m_lUserID, m_lChannel, HikHCNetSdk.PAN_RIGHT, 1, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
        }

        private void btnDown_MouseDown(object sender, MouseEventArgs e)
        {
            if (checkBoxPreview.Checked)
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed(m_lRealHandle, HikHCNetSdk.TILT_DOWN, 0, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
            else
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(m_lUserID, m_lChannel, HikHCNetSdk.TILT_DOWN, 0, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
        }

        private void btnDown_MouseUp(object sender, MouseEventArgs e)
        {
            if (checkBoxPreview.Checked)
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed(m_lRealHandle, HikHCNetSdk.TILT_DOWN, 1, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
            else
            {
                CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(m_lUserID, m_lChannel, HikHCNetSdk.TILT_DOWN, 1, (uint)comboBoxSpeed.SelectedIndex + 1);
            }
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            if (checkBoxPreview.Checked)
            {
                if (!bAuto)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(m_lRealHandle, HikHCNetSdk.PAN_AUTO, 0, (uint)comboBoxSpeed.SelectedIndex + 1);
                    btnAuto.Text = "Stop";
                    bAuto = true;
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed(m_lRealHandle, HikHCNetSdk.PAN_AUTO, 1, (uint)comboBoxSpeed.SelectedIndex + 1);
                    btnAuto.Text = "Auto";
                    bAuto = false;
                }
            }
            else
            {
                if (!bAuto)
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(m_lUserID, m_lChannel, HikHCNetSdk.PAN_AUTO, 0, (uint)comboBoxSpeed.SelectedIndex + 1);
                    btnAuto.Text = "Stop";
                    bAuto = true;
                }
                else
                {
                    CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other(m_lUserID, m_lChannel, HikHCNetSdk.PAN_AUTO, 1, (uint)comboBoxSpeed.SelectedIndex + 1);
                    btnAuto.Text = "Auto";
                    bAuto = false;
                }
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {

        }

        private void PreSet_Load_1(object sender, EventArgs e)
        {

        }

        private void PreSet_Set_Click(object sender, EventArgs e)
        {
            while (comboBox1.Text != "")
            {
                DialogResult dr;
                dr = MessageBox.Show("确认将当前点设置为预置点" + comboBox1.Text, "设置", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                {
                    PreSetNo = comboBox1.Items.IndexOf(comboBox1.Text);
                    if (!CHCNetSDK.NET_DVR_PTZPreset_Other(m_lUserID, 1, HikHCNetSdk.SET_PRESET, (UInt32)(PreSetNo + 1)))
                    {
                        iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                        str = "NET_DVR_PTZPreset_Other failed, error code= " + iLastErr;
                        MessageBox.Show(str);
                        return;
                    }
                    else
                    {
                        textBoxPanPos1.Text = Convert.ToString(0.1 * m_struPreSetCfg[PreSetNo].wPanPos);
                        textBoxTiltPos1.Text = Convert.ToString(0.1 * m_struPreSetCfg[PreSetNo].wTiltPos);
                        textBoxZoomPos1.Text = Convert.ToString(0.1 * m_struPreSetCfg[PreSetNo].wZoomPos);
                        MessageBox.Show("设置成功");
                    }
                    return;
                }
                else return;
            }
            MessageBox.Show("please input the PtrPreSetNo");
        }

        private void PreSet_Delete_Click(object sender, EventArgs e)
        {
            while (comboBox1.Text != "")
            {
                DialogResult dr;
                dr = MessageBox.Show("确认删除预置点" + comboBox1.Text, "删除", MessageBoxButtons.YesNo,
                         MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                {
                    PreSetNo = comboBox1.Items.IndexOf(comboBox1.Text);
                    if (!CHCNetSDK.NET_DVR_PTZPreset_Other(m_lUserID, 1, HikHCNetSdk.CLE_PRESET, (UInt32)(PreSetNo + 1)))
                    {
                        iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                        str = "NET_DVR_PTZPreset_Other failed, error code= " + iLastErr;
                        MessageBox.Show(str);
                        return;
                    }
                    else
                    {
                        textBoxPanPos1.Text = Convert.ToString(0);
                        textBoxTiltPos1.Text = Convert.ToString(0);
                        textBoxZoomPos1.Text = Convert.ToString(1);
                        MessageBox.Show("删除成功");
                    }
                    return;
                }
                else return;
            }
            MessageBox.Show("please input the PtrPreSetNo");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PtzGet_Click(object sender, EventArgs e)
        {
            UInt32 dwReturn = 0;
            Int32 nSize = Marshal.SizeOf(m_struPtzCfg);
            IntPtr ptrPtzCfg = Marshal.AllocHGlobal(nSize);
            Marshal.StructureToPtr(m_struPtzCfg, ptrPtzCfg, false);
            //获取参数失败
            if (!CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID, HikHCNetSdk.NET_DVR_GET_PTZPOS, -1, ptrPtzCfg, (UInt32)nSize, ref dwReturn))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_GetDVRConfig failed, error code= " + iLastErr;
                MessageBox.Show(str);
                return;
            }
            else
            {
                m_struPtzCfg = (NET_DVR_PTZPOS)Marshal.PtrToStructure(ptrPtzCfg, typeof(NET_DVR_PTZPOS));
                //成功获取显示ptz参数
                ushort wPanPos = Convert.ToUInt16(Convert.ToString(m_struPtzCfg.wPanPos, 16));
                float WPanPos = wPanPos * 0.1f;
                textBoxPanPos.Text = Convert.ToString(WPanPos);
                ushort wTiltPos = Convert.ToUInt16(Convert.ToString(m_struPtzCfg.wTiltPos, 16));
                float WTiltPos = wTiltPos * 0.1f;
                textBoxTiltPos.Text = Convert.ToString(WTiltPos);
                ushort wZoomPos = Convert.ToUInt16(Convert.ToString(m_struPtzCfg.wZoomPos, 16));
                float WZoomPos = wZoomPos * 0.1f;
                textBoxZoomPos.Text = Convert.ToString(WZoomPos);
                /*textBoxPanPos.Text= Convert.ToString(Convert.ToUInt32(Convert.ToString(m_struPtzCfg.wPanPos,16))*0.1f,10);
                textBoxTiltPos.Text = Convert.ToString(Convert.ToUInt32(Convert.ToUInt32(Convert.ToString(m_struPtzCfg.wTiltPos, 16)) * 0.1f), 10);
                textBoxZoomPos.Text = Convert.ToString(Convert.ToUInt32(Convert.ToString(m_struPtzCfg.wZoomPos, 16)) * 0.1), 10);*/
                //textBoxPanPos.Text=Convert.ToString(m_struPtzCfg.wPanPos,16);
            }
            return;
        }

        private void PtzSet_Click(object sender, EventArgs e)
        {
            int flag = 1;
            float wPanPos, wTiltPos, wZoomPos;
            String str1, str2, str3;
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Please input the operation type  ");
            }
            /* wPanPos = ushort.Parse(textBoxPanPos.Text);
             wTiltPos = ushort.Parse(textBoxTiltPos.Text);
             wZoomPos = ushort.Parse(textBoxZoomPos.Text);*/
            switch (comboBox2.Items.IndexOf(comboBox2.Text))//下拉框中的数据
            {
                case 0:

                    if (textBoxPanPos.Text == "" || textBoxTiltPos.Text == "" ||
                        textBoxZoomPos.Text == "")
                    {

                        MessageBox.Show("Please input prarameters of P,T,Z: ");
                        return;
                    }
                    else
                    {
                        flag = 0;
                        m_struPtzCfg.wAction = 1;
                        //m_struPtzCfg.wPanPos = ushort.Parse(textBoxPanPos.Text);
                        /* m_struPtzCfg.wPanPos = Convert.ToUInt16(wPanPos);
                          m_struPtzCfg.wTiltPos = wTiltPos;
                          m_struPtzCfg.wZoomPos = wZoomPos;*/
                        /* m_struPtzCfg.wPanPos = Convert.ToUInt16(Convert.ToString(Convert.ToUInt32(Convert.ToString(wPanPos * 10, 16)), 10));
                        m_struPtzCfg.wTiltPos = Convert.ToUInt16(Convert.ToString(Convert.ToUInt32(Convert.ToString(wTiltPos*10, 16)), 10));
                         m_struPtzCfg.wZoomPos = Convert.ToUInt16(Convert.ToString(Convert.ToUInt32(Convert.ToString(wZoomPos*10, 16)), 10));*/
                        str1 = Convert.ToString(float.Parse(textBoxPanPos.Text) * 10);
                        m_struPtzCfg.wPanPos = (ushort)(Convert.ToUInt16(str1, 16));
                        str2 = Convert.ToString(float.Parse(textBoxTiltPos.Text) * 10);
                        m_struPtzCfg.wTiltPos = (ushort)(Convert.ToUInt16(str2, 16));
                        str3 = Convert.ToString(float.Parse(textBoxZoomPos.Text) * 10);
                        m_struPtzCfg.wZoomPos = (ushort)(Convert.ToUInt16(str3, 16));
                        /* m_struPtzCfg.wTiltPos = ushort.Parse(textBoxTiltPos.Text);
                         m_struPtzCfg.wZoomPos = ushort.Parse(textBoxZoomPos.Text);*/
                    }
                    break;
                case 1:
                    if (textBoxPanPos.Text == "")
                    {
                        MessageBox.Show("Please input prarameters of P: ");
                        return;
                    }
                    else
                    {
                        flag = 0;
                        m_struPtzCfg.wAction = 2;

                        //wPanPos = float.Parse(textBoxPanPos.Text);
                        str1 = Convert.ToString(float.Parse(textBoxPanPos.Text) * 10);
                        m_struPtzCfg.wPanPos = (ushort)(Convert.ToUInt16(str1, 16));

                        //m_struPtzCfg.wPanPos = ushort.Parse(textBoxPanPos.Text);

                    }
                    break;
                case 2:
                    if (textBoxTiltPos.Text == "")
                    {
                        MessageBox.Show("Please input prarameters of T: ");
                        return;
                    }
                    else
                    {
                        flag = 0;
                        m_struPtzCfg.wAction = 3;
                        m_struPtzCfg.wTiltPos = ushort.Parse(textBoxTiltPos.Text);

                        str2 = Convert.ToString(float.Parse(textBoxTiltPos.Text) * 10);
                        m_struPtzCfg.wTiltPos = (ushort)(Convert.ToUInt16(str2, 16));

                    }
                    break;
                case 3:
                    if (textBoxZoomPos.Text == "")
                    {
                        MessageBox.Show("Please input prarameters of Z: ");
                        return;
                    }
                    else
                    {
                        flag = 0;
                        m_struPtzCfg.wAction = 4;
                        m_struPtzCfg.wZoomPos = ushort.Parse(textBoxZoomPos.Text);

                        str3 = Convert.ToString(float.Parse(textBoxZoomPos.Text) * 10);
                        m_struPtzCfg.wZoomPos = (ushort)(Convert.ToUInt16(str3, 16));
                    }
                    break;
                case 4:
                    if (textBoxTiltPos.Text == "" || textBoxPanPos.Text == "")
                    {
                        MessageBox.Show("Please input prarameters of P,T: ");
                        return;
                    }
                    else
                    {
                        flag = 0;
                        m_struPtzCfg.wAction = 5;
                        m_struPtzCfg.wPanPos = ushort.Parse(textBoxPanPos.Text);
                        m_struPtzCfg.wTiltPos = ushort.Parse(textBoxTiltPos.Text);

                        str1 = Convert.ToString(float.Parse(textBoxPanPos.Text) * 10);
                        m_struPtzCfg.wPanPos = (ushort)(Convert.ToUInt16(str1, 16));
                        str2 = Convert.ToString(float.Parse(textBoxTiltPos.Text) * 10);
                        m_struPtzCfg.wTiltPos = (ushort)(Convert.ToUInt16(str2, 16));

                    }
                    break;


            }


            while (flag == 0)
            {

                Int32 nSize = Marshal.SizeOf(m_struPtzCfg);
                IntPtr ptrPtzCfg = Marshal.AllocHGlobal(nSize);
                Marshal.StructureToPtr(m_struPtzCfg, ptrPtzCfg, false);

                if (!CHCNetSDK.NET_DVR_SetDVRConfig(m_lUserID, HikHCNetSdk.NET_DVR_SET_PTZPOS, 1, ptrPtzCfg, (UInt32)nSize))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    str = "NET_DVR_SetDVRConfig failed, error code= " + iLastErr;
                    //设置POS参数失败
                    MessageBox.Show(str);
                    return;
                }
                else
                {
                    MessageBox.Show("设置成功!");
                    break;
                }

                Marshal.FreeHGlobal(ptrPtzCfg);

            }
            return;
        }

        private void PtzRange_Click(object sender, EventArgs e)
        {
            UInt32 dwReturn = 0;
            Int32 nSize = Marshal.SizeOf(m_struPtzCfg1);
            IntPtr ptrPtzCfg = Marshal.AllocHGlobal(nSize);
            Marshal.StructureToPtr(m_struPtzCfg1, ptrPtzCfg, false);

            //获取参数失败
            if (!CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID, HikHCNetSdk.NET_DVR_GET_PTZSCOPE, -1, ptrPtzCfg, (UInt32)nSize, ref dwReturn))
            {
                iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                str = "NET_DVR_GetDVRConfig failed, error code= " + iLastErr;
                MessageBox.Show(str);
                return;
            }
            else
            {
                m_struPtzCfg1 = (NET_DVR_PTZSCOPE)Marshal.PtrToStructure(ptrPtzCfg, typeof(NET_DVR_PTZSCOPE));
                //成功获取显示ptz参数范围
                ushort wPanPosMax = Convert.ToUInt16(Convert.ToString(m_struPtzCfg1.wPanPosMax, 16));
                float WPanPosMax = wPanPosMax * 0.1f;
                ushort wTiltPosMax = Convert.ToUInt16(Convert.ToString(m_struPtzCfg1.wTiltPosMax, 16));
                float WTiltPosMax = wTiltPosMax * 0.1f;
                ushort wZoomPosMax = Convert.ToUInt16(Convert.ToString(m_struPtzCfg1.wZoomPosMax, 16));
                float WZoomPosMax = wZoomPosMax * 0.1f;
                ushort wPanPosMin = Convert.ToUInt16(Convert.ToString(m_struPtzCfg1.wPanPosMin, 16));
                float WPanPosMin = wPanPosMin * 0.1f;
                ushort wTiltPosMin = Convert.ToUInt16(Convert.ToString(m_struPtzCfg1.wTiltPosMin, 16));
                float WTiltPosMin = wTiltPosMin * 0.1f;
                ushort wZoomPosMin = Convert.ToUInt16(Convert.ToString(m_struPtzCfg1.wZoomPosMin, 16));
                float WZoomPosMin = wZoomPosMin * 0.1f;

                str = "PMax=" + WPanPosMax + "    TMax=" + WTiltPosMax + "  ZMax=" + WZoomPosMax + "   PMin=" + WPanPosMin + "    TMin=" + WTiltPosMin + "  ZMin=" + WZoomPosMin;
                label13.Text = str;

            }
            return;
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxPreview_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        #endregion PreSet
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
                    //if (!this.ChkNetReadBackground.Checked)
                    //{
                    //    await Task.Delay(seconds * 1000, stoppingToken);
                    //    continue;
                    //}
                    //if (this.TxtNetSeconds.Text.TryToInt32(out int sec))
                    //{
                    //    if (sec > 5 && sec < 99)
                    //    {
                    //        seconds = sec;
                    //    }
                    //}
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
        public PreviewDemo1 AppendError(string message)
        {
            this.Invoke((Action)(() =>
            {
                AppendTextEx(message, Color.Red);
            }));
            return this;
        }
        public PreviewDemo1 AppendSuccess(string message)
        {
            this.Invoke((Action)(() =>
            {
                AppendTextEx(message, Color.Green);
            }));
            return this;
        }
        public PreviewDemo1 AppendInfo(string message)
        {
            this.Invoke((Action)(() =>
            {
                AppendTextEx(message, Color.Blue);
            }));
            return this;
        }
        public PreviewDemo1 Append(IAlertMsg alert)
        {
            this.Invoke((Action)(() =>
            {
                AppendTextEx(alert.Message, alert.IsSuccess ? Color.Green : Color.Red);
            }));
            return this;
        }
        public PreviewDemo1 Append(Exception alert)
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
