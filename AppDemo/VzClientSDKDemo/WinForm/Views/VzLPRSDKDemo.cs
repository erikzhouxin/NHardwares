﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Cobber;
using System.Data.Extter;
using System.Data.VzClientSDK;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VzClientSDK.WinForm.Views
{
    public partial class VzLPRSDKDemo : UserControl
    {
        /// <summary>
        /// 终端配置
        /// </summary>
        static Dictionary<string, SdkConfigModel> _devices = new();
        static SdkConfigModel _config = new SdkConfigModel();
        static string _configPath = System.IO.Path.GetFullPath("testvzlprsdkconfig.json");
        internal static VzLPRSDKDemo Instance { get; set; }
        Thread _guardianService;
        CancellationTokenSource _guardianCts;
        bool _isInitialize;
        private IVzClientSdkProxy VzClientSDK;

        public VzLPRSDKDemo()
        {
            Instance = this;
            InitializeComponent();
        }

        private void VzLPRSDKDemo_Load(object sender, EventArgs e)
        {
            if (!_isInitialize)
            {
                _isInitialize = true;

                ReadDeviceAndSetFirstOne();

                _guardianCts = new CancellationTokenSource();
                _guardianService = new Thread(async () => await GuardianServiceAsync(_guardianCts.Token));
                _guardianService.IsBackground = true;
                _guardianService.Start();
                VzClientSDK = VzClientSdk.Create();
                VzClientSDK.VzLPRClient_Setup();

                hwndMain = this.Handle;

                m_sAppPath = System.IO.Directory.GetCurrentDirectory();
                m_bFirst = true;
                m_bFindDev = false;

                outputbox.SelectedIndex = 0;

                m_gpio_recvCB = new VZLPRC_GPIO_RECV_CALLBACK(OnGPIORecv);
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
                    _devices.Add(key, new SdkConfigModel());
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
            if (nLen != 0) { TxtLogger.AppendText(Environment.NewLine); }
            TxtLogger.AppendText(DateTime.Now.ToString() + " " + strText);
            TxtLogger.Select(nLen, this.TxtLogger.TextLength - nLen);
            this.TxtLogger.SelectionColor = clAppend;
        }
        public VzLPRSDKDemo AppendError(string message)
        {
            this.Invoke((Action)(() => AppendTextEx(message, Color.Red)));
            return this;
        }
        public VzLPRSDKDemo AppendSuccess(string message)
        {
            this.Invoke((Action)(() => AppendTextEx(message, Color.Green)));
            return this;
        }
        public VzLPRSDKDemo AppendInfo(string message)
        {
            this.Invoke((Action)(() => AppendTextEx(message, Color.Blue)));
            return this;
        }
        public VzLPRSDKDemo Append(IAlertMsg alert)
        {
            this.Invoke((Action)(() => AppendTextEx(alert.Message, alert.IsSuccess ? Color.Green : Color.Red)));
            return this;
        }
        public VzLPRSDKDemo Append(Exception alert)
        {
            var sb = new StringBuilder().AppendLine(alert.Message).AppendLine(alert.StackTrace);
            this.Invoke((Action)(() => AppendTextEx(sb.ToString(), Color.Red)));
            return this;
        }
        private void TxtLogger_TextChanged(object sender, EventArgs e)
        {
            TxtLogger.Select(TxtLogger.TextLength, 0);
            TxtLogger.ScrollToCaret();
        }
        private void TsrmLoggerClear_Click(object sender, EventArgs e)
        {
            this.TxtLogger.Clear();
        }
        #endregion
        #region // 内部类
        public class SdkConfigModel
        {
            /// <summary>
            /// 名称
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// 句柄
            /// </summary>
            public IntPtr Handle { get; set; }
            /// <summary>
            /// 地址
            /// </summary>
            public string Address { get; set; }
            /// <summary>
            /// 端口
            /// </summary>
            public int Port { get; set; }
            /// <summary>
            /// 序列号
            /// </summary>
            public string SerialNo { get; set; }
            /// <summary>
            /// 开关量
            /// </summary>
            public int IOVolume { get; set; }
            /// <summary>
            /// 账号
            /// </summary>
            public String Account { get; set; }
            /// <summary>
            /// 密码
            /// </summary>
            public String Password { get; set; }
        }
        #endregion
        #region // VzLPRSDKDemo_Form
        private const int MSG_PLATE_INFO = 0x901;
        private const int MSG_DEVICE_INFO = 0x902;

        private int m_nPlayHandle = 0;
        private int m_nPlayHandle2 = 0;

        private string m_sAppPath;

        System.Timers.Timer resetrecordtime;

        public IntPtr hwndMain;

        int m_nLastLEDLevel;


        private Color m_originalColor;
        private bool m_bFirst;
        private bool m_bFindDev;

        private VZLPRC_PLATE_INFO_CALLBACK m_PlateResultCB = null;
        private VZLPRC_FIND_DEVICE_CALLBACK_EX find_DeviceCB = null;
        private VZLPRC_PLATE_INFO_CALLBACK m_PlateResultCB2 = null;
        private VZLPRC_GPIO_RECV_CALLBACK m_gpio_recvCB = null;


        private void Form1_Load(object sender, EventArgs e)
        {
            VzClientSDK.VzLPRClient_Setup();

            hwndMain = this.Handle;

            m_sAppPath = System.IO.Directory.GetCurrentDirectory();
            m_originalColor = pictureBox1.BackColor;
            m_bFirst = true;
            m_bFindDev = false;

            txtSerialNum.Enabled = false;

            outputbox.SelectedIndex = 0;

            m_gpio_recvCB = new VzClientSDK.VZLPRC_GPIO_RECV_CALLBACK(OnGPIORecv);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            short nPort = Int16.Parse(txtPort.Text);

            int handle = 0;

            if (chkPDNS.Checked)
            {
                handle = VzClientSDK.VzLPRClient_OpenV2(txtIP.Text, (ushort)nPort, txtUserName.Text, txtPwd.Text, 8557, 1, txtSerialNum.Text);
            }
            else
            {
                handle = VzClientSDK.VzLPRClient_Open(txtIP.Text, (ushort)nPort, txtUserName.Text, txtPwd.Text);
            }

            if (handle == 0)
            {
                MessageBox.Show("打开设备失败！");
                return;
            }

            VzClientSDK.VzLPRClient_SetIsShowPlateRect(handle, 0);

            TreeNode node = new TreeNode(txtIP.Text);
            node.Tag = handle;
            treeDevice.Nodes.Add(node);

            treeDevice.SelectedNode = node;
        }

        public void RecordReset(object source, System.Timers.ElapsedEventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }

            VzClientSDK.VzLPRClient_StopSaveRealData(lprHandle);
            string strFilePath = m_sAppPath + "Video";
            string szPath = strFilePath + "\\" + DateTime.Now.Year.ToString() +
                DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() +
                DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() +
                DateTime.Now.Second.ToString() + ".avi";
            VzClientSDK.VzLPRClient_SaveRealData(lprHandle, szPath);

        }

        private int OnPlateResult(int handle, IntPtr pUserData,
                                                  IntPtr pResult, uint uNumPlates,
                                                  VZ_LPRC_RESULT_TYPE eResultType,
                                                  IntPtr pImgFull,
                                                  IntPtr pImgPlateClip)
        {
            if (eResultType != VZ_LPRC_RESULT_TYPE.VZ_LPRC_RESULT_REALTIME)
            {
                TH_PlateResult result = (TH_PlateResult)Marshal.PtrToStructure(pResult, typeof(TH_PlateResult));
                string strLicense = new string(result.license);

                VZ_LPR_MSG_PLATE_INFO plateInfo = new VZ_LPR_MSG_PLATE_INFO();
                plateInfo.plate = strLicense;

                DateTime now = DateTime.Now;
                string sTime = string.Format("{0:yyyyMMddHHmmssffff}", now);

                string strFilePath = m_sAppPath + "\\cap\\";
                if (!Directory.Exists(strFilePath))
                {
                    Directory.CreateDirectory(strFilePath);
                }

                string path = strFilePath + sTime + ".jpg";

                VzClientSDK.VzLPRClient_ImageSaveToJpeg(pImgFull, path, 100);
                plateInfo.img_path = path;

                int size = Marshal.SizeOf(plateInfo);
                IntPtr intptr = Marshal.AllocHGlobal(size);
                Marshal.StructureToPtr(plateInfo, intptr, true);

                Win32API.PostMessage(hwndMain, MSG_PLATE_INFO, (int)intptr, handle);
            }

            return 0;
        }

        private void OnGPIORecv(int handle, int nGPIOId, int nVal, IntPtr pUserData)
        {
            int value = nVal;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //关闭视频播放句柄以及关闭设备
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                return;
            }

            if (lprHandle == GetPicBox1Handle())
            {
                if (m_nPlayHandle > 0)
                {
                    int ret = VzClientSDK.VzLPRClient_StopRealPlay(m_nPlayHandle);
                    m_nPlayHandle = 0;
                }

                Pic1Close();
                Pic2Close();
            }
            else
            {
                if (m_nPlayHandle2 > 0)
                {
                    int ret = VzClientSDK.VzLPRClient_StopRealPlay(m_nPlayHandle2);
                    m_nPlayHandle2 = 0;
                }

                Pic3Close();
                Pic4Close();
            }

            VzClientSDK.VzLPRClient_Close(lprHandle);
            treeDevice.Nodes.Remove(treeDevice.SelectedNode);

            //停止搜索设备
            if (m_bFindDev)
            {
                VzClientSDK.VZLPRClient_StopFindDevice();
                m_bFindDev = false;
            }
            VzClientSDK.VZLPRClient_StopFindDevice();

            VzClientSDK.VzLPRClient_Cleanup();
        }

        //关闭第一个窗口
        private delegate void Pic1CloseThread();
        public void Pic1Close()
        {
            Pic1CloseThread Pic1CloseDelegate = delegate ()
            {
                pictureBox1.Image = null;
                pictureBox1.Refresh();
                pictureBox1.Tag = 0;
            };
            pictureBox1.Invoke(Pic1CloseDelegate);
        }

        //关闭第二个窗口
        private delegate void Pic2CloseThread();
        public void Pic2Close()
        {
            Pic2CloseThread Pic2CloseDelegate = delegate ()
            {
                pictureBox2.Image = null;
                pictureBox2.Refresh();
            };
            pictureBox2.Invoke(Pic2CloseDelegate);
        }

        //关闭第三个窗口
        private delegate void Pic3CloseThread();
        public void Pic3Close()
        {
            Pic2CloseThread Pic3CloseDelegate = delegate ()
            {
                pictureBox3.Image = null;
                pictureBox3.Refresh();
                pictureBox3.Tag = 0;
            };
            pictureBox3.Invoke(Pic3CloseDelegate);
        }

        //关闭第四个窗口
        private delegate void Pic4CloseThread();
        public void Pic4Close()
        {
            Pic1CloseThread Pic4CloseDelegate = delegate ()
            {
                pictureBox4.Image = null;
                pictureBox4.Refresh();
            };

            pictureBox4.Invoke(Pic4CloseDelegate);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }

            if (lprHandle == GetPicBox1Handle())
            {
                if (m_nPlayHandle > 0)
                {
                    int ret = VzClientSDK.VzLPRClient_StopRealPlay(m_nPlayHandle);
                    m_nPlayHandle = 0;
                }

                Pic1Close();
                Pic2Close();
            }
            else
            {
                if (m_nPlayHandle2 > 0)
                {
                    int ret = VzClientSDK.VzLPRClient_StopRealPlay(m_nPlayHandle2);
                    m_nPlayHandle2 = 0;
                }

                Pic3Close();
                Pic4Close();
            }

            VzClientSDK.VzLPRClient_Close(lprHandle);
            treeDevice.Nodes.Remove(treeDevice.SelectedNode);
        }

        // 手动触发识别
        private void btnManual_Click(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }

            if (lprHandle > 0)
            {
                VzClientSDK.VzLPRClient_ForceTrigger(lprHandle);
            }
        }

        // 抓图功能
        private void btnCap_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            string sTime = string.Format("{0:yyyyMMddHHmmssffff}", now);

            string strFilePath = m_sAppPath + "\\Snap\\";
            if (!Directory.Exists(strFilePath))
            {
                Directory.CreateDirectory(strFilePath);
            }

            string path = strFilePath + sTime + ".jpg";

            int ret = -1;

            if (m_bFirst)
            {
                if (m_nPlayHandle > 0)
                {
                    ret = VzClientSDK.VzLPRClient_GetSnapShootToJpeg2(m_nPlayHandle, path, 90);
                }
            }
            else
            {
                if (m_nPlayHandle2 > 0)
                {
                    ret = VzClientSDK.VzLPRClient_GetSnapShootToJpeg2(m_nPlayHandle, path, 90); ;
                    m_nPlayHandle2 = 0;
                }
            }

            if (ret == 0)
            {
                MessageBox.Show("截图成功！ ");
            }
            else
            {
                MessageBox.Show("截图失败， 请检查是否当前视频是否播放！ ");
            }
        }

        private void btngpio_Click(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }

            int[] test = new int[1];
            GCHandle hObject = GCHandle.Alloc(test, GCHandleType.Pinned);
            IntPtr pObject = hObject.AddrOfPinnedObject();

            int ret = VzClientSDK.VzLPRClient_GetGPIOValue(lprHandle, 0, pObject);
            if (test[0] == 0)
            {
                MessageBox.Show("IOInput is [短路]");
            }
            else if (test[0] == 1)
            {
                MessageBox.Show("IOInput is [开路]");
            }

            if (hObject.IsAllocated)
                hObject.Free();
        }

        private void listbt_Click(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }

            WhiteList_Form listform = new WhiteList_Form();
            listform.StartPosition = FormStartPosition.CenterScreen;
            listform.Show();
            listform.SetLPRHandle(lprHandle);
        }

        //触发结果显示
        public void ShowDevice(string pStrDev, string serialNO)
        {
            TreeNode node = new TreeNode(pStrDev);
            node.Tag = serialNO;
            dev_treeview.Nodes.Add(node);
            dev_treeview.Sort();
        }

        private void FIND_DEVICE_CALLBACK_EX(string pStrDevName, string pStrIPAddr, ushort usPort1, ushort usPort2, uint SL, uint SH, string netmask, string gateway, IntPtr pUserData)
        {
            string pStrDev = pStrIPAddr.ToString() + ":" + usPort1.ToString();
            string serialNO = SL.ToString() + ":" + SH.ToString() + ":" + netmask + ":" + gateway;

            VzClientSDK.VZ_LPR_DEVICE_INFO device_info = new VzClientSDK.VZ_LPR_DEVICE_INFO();
            device_info.device_ip = pStrDev;
            device_info.serial_no = serialNO;

            int size = Marshal.SizeOf(device_info);
            IntPtr intptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(device_info, intptr, true);

            Win32API.PostMessage(hwndMain, MSG_DEVICE_INFO, (int)intptr, 0);
        }

        private void startsearchdev_Click(object sender, EventArgs e)
        {
            VzClientSDK.VZLPRClient_StopFindDevice();

            dev_treeview.Nodes.Clear();
            find_DeviceCB = new VzClientSDK.VZLPRC_FIND_DEVICE_CALLBACK_EX(FIND_DEVICE_CALLBACK_EX);
            int ret = VzClientSDK.VZLPRClient_StartFindDeviceEx(find_DeviceCB, IntPtr.Zero);
            if (ret == 0)
            {
                m_bFindDev = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }

            VzClientSDK.VzLPRClient_SetLEDLightControlMode(lprHandle, VzClientSDK.VZ_LED_CTRL.VZ_LED_AUTO);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }

            VzClientSDK.VzLPRClient_SetLEDLightControlMode(lprHandle, VzClientSDK.VZ_LED_CTRL.VZ_LED_MANUAL_ON);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }

            VzClientSDK.VzLPRClient_SetLEDLightControlMode(lprHandle, VzClientSDK.VZ_LED_CTRL.VZ_LED_MANUAL_OFF);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }

            int nValue = ledbar.Value - 1;

            int nLevelNow = 0;
            int nLevelMax = 0;

            VzClientSDK.VzLPRClient_GetLEDLightStatus(lprHandle, ref nLevelNow, ref nLevelMax);
            m_nLastLEDLevel = nLevelNow;
            if (nValue != nLevelNow)
            {
                VzClientSDK.VzLPRClient_SetLEDLightLevel(lprHandle, nValue);
                m_nLastLEDLevel = nValue;
            }
        }

        private void recordbtn_Click(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }

            resetrecordtime = new System.Timers.Timer(1000 * 60 * 5);
            resetrecordtime.Elapsed += new System.Timers.ElapsedEventHandler(RecordReset);
            resetrecordtime.AutoReset = true;
            resetrecordtime.Enabled = true;

            string strFilePath = m_sAppPath + "\\Video";
            if (!Directory.Exists(strFilePath))
            {
                Directory.CreateDirectory(strFilePath);
            }
            string szPath = strFilePath + "\\" + DateTime.Now.Year.ToString() +
                DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() +
                DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() +
                ".avi";
            VzClientSDK.VzLPRClient_SaveRealData(lprHandle, szPath);
            recordbtn.Enabled = false;
            stoprecordbtn.Enabled = true;
        }

        private void stoprecordbtn_Click(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }

            VzClientSDK.VzLPRClient_StopSaveRealData(lprHandle);
            resetrecordtime.Close();
            stoprecordbtn.Enabled = false;
            recordbtn.Enabled = true;
        }

        private void stoprealplaybtn_Click(object sender, EventArgs e)
        {
            if (m_bFirst)
            {
                if (m_nPlayHandle > 0)
                {
                    int ret = VzClientSDK.VzLPRClient_StopRealPlay(m_nPlayHandle);
                    m_nPlayHandle = 0;
                }

                int lprHandle = GetPicBox1Handle();
                if (lprHandle > 0)
                {
                    VzClientSDK.VzLPRClient_SetPlateInfoCallBack(lprHandle, null, IntPtr.Zero, 0);
                }

                Pic1Close();
                Pic2Close();
            }
            else
            {
                if (m_nPlayHandle2 > 0)
                {
                    int ret = VzClientSDK.VzLPRClient_StopRealPlay(m_nPlayHandle2);
                    m_nPlayHandle2 = 0;
                }

                int lprHandle2 = GetPicBox3Handle();
                if (lprHandle2 > 0)
                {
                    VzClientSDK.VzLPRClient_SetPlateInfoCallBack(lprHandle2, null, IntPtr.Zero, 0);
                }

                Pic3Close();
                Pic4Close();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }

            if (check_set_offline.Checked)
            {
                VzClientSDK.VzLPRClient_SetOfflineCheck(lprHandle);
            }
            else
            {
                VzClientSDK.VzLPRClient_CancelOfflineCheck(lprHandle);
            }
        }

        private void stopsearchdev_Click(object sender, EventArgs e)
        {
            VzClientSDK.VZLPRClient_StopFindDevice();
            if (m_bFindDev)
            {
                m_bFindDev = false;
            }
        }

        private void querybtn_Click(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }

            PlateQuery_Form listform = new PlateQuery_Form();
            listform.StartPosition = FormStartPosition.CenterScreen;
            listform.Show();
            listform.SetLPRHandle(lprHandle, m_sAppPath);
        }

        private void snapshootbtn_Click(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }

            if (lprHandle == GetPicBox1Handle() || lprHandle == GetPicBox3Handle())
            {
                MessageBox.Show("该设备已经输出在视频窗口中，请先停止。");
                return;
            }

            if (m_bFirst)
            {
                pictureBox1.Image = null;
                if (m_nPlayHandle > 0)
                {
                    VzClientSDK.VzLPRClient_StopRealPlay(m_nPlayHandle);
                    m_nPlayHandle = 0;
                }

                int lprHandle1 = GetPicBox1Handle();
                if (lprHandle1 > 0)
                {
                    VzClientSDK.VzLPRClient_SetPlateInfoCallBack(lprHandle1, null, IntPtr.Zero, 0);
                }

                m_nPlayHandle = VzClientSDK.VzLPRClient_StartRealPlay(lprHandle, pictureBox1.Handle);
                pictureBox1.Tag = lprHandle;

                // 设置车牌识别结果回调
                m_PlateResultCB = new VzClientSDK.VZLPRC_PLATE_INFO_CALLBACK(OnPlateResult);
                VzClientSDK.VzLPRClient_SetPlateInfoCallBack(lprHandle, m_PlateResultCB, IntPtr.Zero, 1);

                VzClientSDK.VzLPRClient_SetGPIORecvCallBack(lprHandle, m_gpio_recvCB, IntPtr.Zero);
            }
            else
            {
                pictureBox3.Image = null;
                if (m_nPlayHandle2 > 0)
                {
                    VzClientSDK.VzLPRClient_StopRealPlay(m_nPlayHandle2);
                    m_nPlayHandle2 = 0;
                }

                int lprHandle2 = GetPicBox3Handle();
                if (lprHandle2 > 0)
                {
                    VzClientSDK.VzLPRClient_SetPlateInfoCallBack(lprHandle2, null, IntPtr.Zero, 0);
                }

                m_nPlayHandle2 = VzClientSDK.VzLPRClient_StartRealPlay(lprHandle, pictureBox3.Handle);
                pictureBox3.Tag = lprHandle;

                // 设置车牌识别结果回调
                m_PlateResultCB2 = new VzClientSDK.VZLPRC_PLATE_INFO_CALLBACK(OnPlateResult);
                VzClientSDK.VzLPRClient_SetPlateInfoCallBack(lprHandle, m_PlateResultCB2, IntPtr.Zero, 1);
            }


        }

        private void osdbtn_Click(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }


            OSDSET_Form listform = new OSDSET_Form();
            listform.StartPosition = FormStartPosition.CenterScreen;
            listform.Show();
            listform.SetLPRHandle(lprHandle);
        }

        private void setvloopbtn_Click(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }

            SetParameter_Form listform = new SetParameter_Form();
            listform.StartPosition = FormStartPosition.CenterScreen;
            listform.Show();
            listform.SetLPRHandle(lprHandle);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }

            VzClientSDK.VzLPRClient_SetIOOutput(lprHandle, outputbox.SelectedIndex, outputcheck.Checked ? 1 : 0);
        }

        private void outputbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                return;
            }

            int nOutRT = -1;

            int rt = VzClientSDK.VzLPRClient_GetIOOutput(lprHandle, outputbox.SelectedIndex, ref nOutRT);
            outputcheck.Checked = (nOutRT == 1) ? true : false;
        }

        private void dev_treeview_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string ipstr = dev_treeview.SelectedNode.Text;
            int temp = ipstr.IndexOf(":");
            txtIP.Text = ipstr.Substring(0, temp);
            txtPort.Text = ipstr.Substring(temp + 1);
        }

        protected override void DefWndProc(ref Message m)
        {
            IntPtr intptr;
            VzClientSDK.VZ_LPR_MSG_PLATE_INFO plateInfo;
            VzClientSDK.VZ_LPR_DEVICE_INFO deviceInfo;

            int handle = 0;

            switch (m.Msg)
            {
                case MSG_PLATE_INFO:
                    intptr = (IntPtr)m.WParam.ToInt32();
                    handle = m.LParam.ToInt32();
                    if (intptr != null)
                    {
                        // VzClientSDK.VzLPRClient_SetIOOutputAuto(m_hLPRClient, 0, 500);
                        //根据句柄获取设备IP
                        byte[] strDecIP = new byte[32];
                        int max_count = 32;
                        int ret = VzClientSDK.VzLPRClient_GetDeviceIP(handle, ref strDecIP[0], max_count);
                        string strIP = System.Text.Encoding.Default.GetString(strDecIP);
                        strIP = strIP.TrimEnd('\0');

                        plateInfo = (VzClientSDK.VZ_LPR_MSG_PLATE_INFO)Marshal.PtrToStructure(intptr, typeof(VzClientSDK.VZ_LPR_MSG_PLATE_INFO));

                        if (handle == GetPicBox1Handle())
                        {
                            // 显示车牌号
                            if (plateInfo.plate != "")
                            {
                                lblPlate.Text = plateInfo.plate;
                            }

                            // 显示图片
                            if (plateInfo.img_path != "")
                            {
                                pictureBox2.Image = Image.FromFile(plateInfo.img_path);
                            }
                        }
                        else
                        {
                            // 显示车牌号
                            if (plateInfo.plate != "")
                            {
                                lblPlate2.Text = plateInfo.plate;
                            }

                            // 显示图片
                            if (plateInfo.img_path != "")
                            {
                                pictureBox4.Image = Image.FromFile(plateInfo.img_path);
                            }
                        }


                        Marshal.FreeHGlobal(intptr);
                    }

                    break;

                case MSG_DEVICE_INFO:
                    intptr = (IntPtr)m.WParam.ToInt32();
                    if (intptr != null)
                    {
                        deviceInfo = (VzClientSDK.VZ_LPR_DEVICE_INFO)Marshal.PtrToStructure(intptr, typeof(VzClientSDK.VZ_LPR_DEVICE_INFO));
                        ShowDevice(deviceInfo.device_ip, deviceInfo.serial_no);

                        Marshal.FreeHGlobal(intptr);

                    }
                    break;

                default:
                    base.DefWndProc(ref m);
                    break;
            }
        }

        private void btnConnStat_Click(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }

            byte stat = 0;
            VzClientSDK.VzLPRClient_IsConnected(lprHandle, ref stat);

            if (stat == 1)
            {
                MessageBox.Show("连接正常");
            }
            else
            {
                MessageBox.Show("连接断开");
            }

            /*
            VzClientSDK.VZ_CAR_INFO carInfo = new VzClientSDK.VZ_CAR_INFO();
            int size = Marshal.SizeOf(carInfo);

            carInfo.logo_id = 1;
            carInfo.series_id = 2;
            carInfo.style_id = 3;

            IntPtr intptr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(carInfo, intptr, true);

            int ret = VzClientSDK.VzLPRClient_GetCameraConfig(lprHandle, 1201, 0, intptr, size);

            carInfo = (VzClientSDK.VZ_CAR_INFO)Marshal.PtrToStructure(intptr, typeof(VzClientSDK.VZ_CAR_INFO));

            Marshal.FreeHGlobal(intptr);
           */
        }

        public void Write(string path, string content)
        {
            StreamWriter sw = new StreamWriter(path, true);
            //开始写入
            sw.Write(content);
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
        }

        private int GetSeleHandle()
        {
            int handle = 0;

            if (treeDevice.SelectedNode != null)
            {
                string sHandle = treeDevice.SelectedNode.Tag.ToString();
                handle = Int32.Parse(sHandle);
            }

            return handle;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Color c = Color.FromArgb(255, 220, 220, 220);
            pictureBox1.BackColor = c;

            pictureBox3.BackColor = m_originalColor;
            m_bFirst = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox1.BackColor = m_originalColor;

            Color c = Color.FromArgb(255, 220, 220, 220);
            pictureBox3.BackColor = c;
            m_bFirst = false;
        }

        private int GetPicBox1Handle()
        {
            int handle = 0;

            if (pictureBox1.Tag != null)
            {
                string sHandle = pictureBox1.Tag.ToString();
                handle = Int32.Parse(sHandle);
            }

            return handle;
        }

        private int GetPicBox3Handle()
        {
            int handle = 0;

            if (pictureBox3.Tag != null)
            {
                string sHandle = pictureBox3.Tag.ToString();
                handle = Int32.Parse(sHandle);
            }

            return handle;
        }

        // 485控制的功能
        private void btnSerial_Click(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }

            SerialControl_Form serialForm = new SerialControl_Form();
            serialForm.StartPosition = FormStartPosition.CenterScreen;
            serialForm.SetLPRHandle(lprHandle);
            serialForm.ShowDialog();
        }

        private void m_btnBaseConfig_Click(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }

            BaseConfig_From configform = new BaseConfig_From();
            configform.StartPosition = FormStartPosition.CenterScreen;
            configform.SetLPRHandle(lprHandle);
            configform.ShowDialog();
        }

        private void InOutBtn_Click(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }

            InAndOut_Form inandoutform = new InAndOut_Form();
            inandoutform.StartPosition = FormStartPosition.CenterScreen;
            inandoutform.SetLPRHandle(lprHandle);
            inandoutform.ShowDialog();
        }


        private void btnIOOut_Click(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }
            int ioVolume = _config.IOVolume;
            VzClientSDK.VzLPRClient_SetIOOutputAuto(lprHandle, ioVolume, 500);
        }

        private void btnVideoCfg_Click(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }

            int board_type = 0;
            VzClientSDK.VzLPRClient_GetHwBoardType(lprHandle, ref board_type);
            if (board_type == 3)
            {
                RVideoCfg_Form from = new RVideoCfg_Form();
                from.StartPosition = FormStartPosition.CenterScreen;
                from.SetLPRHandle(lprHandle);
                from.Show();
            }
            else
            {
                VideoCfg_Form from = new VideoCfg_Form();
                from.StartPosition = FormStartPosition.CenterScreen;
                from.SetLPRHandle(lprHandle);
                from.Show();
            }
        }

        // 修改设备IP的功能
        private void btnNetCfg_Click(object sender, EventArgs e)
        {
            if (_config.Handle != IntPtr.Zero)
            {
                string ip = _config.Address;
                string serialNO = _config.SerialNo;

                string[] arrIP = ip.Split(new char[] { ':' });
                string[] arrSerial = serialNO.Split(new char[] { ':' });

                uint SL = uint.Parse(arrSerial[0]);
                uint SH = uint.Parse(arrSerial[1]);

                NetCfg_Form from = new NetCfg_Form();
                from.StartPosition = FormStartPosition.CenterScreen;
                from.SetNetParam(arrIP[0], SL, SH, arrSerial[2], arrSerial[3]);
                from.Show();
            }
            else
            {

                MessageBox.Show("请选择搜索设备列表中的设备");
            }
        }

        // 线圈配置的功能
        private void btnRuleCfg_Click(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }

            RuleCfg_Form from = new RuleCfg_Form();
            from.StartPosition = FormStartPosition.CenterScreen;
            from.SetLPRHandle(lprHandle);
            from.Show();
        }

        private void btnEncryptCfg_Click(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }
            EncryptCfg_Form form = new EncryptCfg_Form();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.SetLPRHandle(lprHandle);
            form.Show();
        }

        private void btnPlayVoice_Click(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }

            PlayVoice form = new PlayVoice();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.SetLPRHandle(lprHandle);
            form.Show();
        }

        /// <summary>
        /// 定焦配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnFixedCfg_Click(object sender, EventArgs e)
        {
            int lprHandle = GetSeleHandle();
            if (lprHandle == 0)
            {
                MessageBox.Show("请选择一台列表中的设备");
                return;
            }

            int board_version = 0;
            Int64 exdataSize = 0;
            int ret = VzClientSDK.VzLPRClient_GetHwBoardVersion(lprHandle, ref board_version, ref exdataSize);
            if (board_version == 0x3045 || board_version == 0x3085 || board_version == 0x30C5 || board_version == 0x3105 || board_version == 0x3185)
            {
                AlgResultParamCfg form = new AlgResultParamCfg();
                form.StartPosition = FormStartPosition.CenterScreen;
                form.SetLPRHandle(lprHandle);
                form.Show();
            }
            else
            {
                MessageBox.Show("当前相机不是定焦版本，不能进行定焦配置!");
            }

        }

        private void ChkNetPDNS_Click(object sender, EventArgs e)
        {
            if (ChkNetPDNS.Checked)
            {
                TxtNetSerialNum.Enabled = true;
            }
            else
            {
                TxtNetSerialNum.Enabled = false;
            }
        }

        private Dictionary<String, IntPtr> GetAllDevice()
        {
            Dictionary<String, IntPtr> deviceInfo = new Dictionary<String, IntPtr>();
            foreach (var item in _devices)
            {
                deviceInfo.Add(item.Value.Address, item.Value.Handle);
            }
            return deviceInfo;
        }

        private void BtnTalk_Click(object sender, EventArgs e)
        {
            var deviceInfo = GetAllDevice();
            if (deviceInfo.Count == 0) { MessageBox.Show("请先打开设备"); return; }
            Talk_Form from = new Talk_Form();
            from.StartPosition = FormStartPosition.CenterScreen;
            from.SetDeviceInfo(deviceInfo.ToDictionary(s => s.Key, s => (int)s.Value));
            from.Show();
        }
        #endregion VzLPRSDKDemo_Form
    }
}
