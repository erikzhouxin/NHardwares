using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections;
using System.Data.YuShiITSSDK;
using stuUserInfo = System.Data.YuShiITSSDK.NETDEV_StuUserInfo;

namespace YuShiITSSDK.NWinFormUI
{
    public partial class MainForm : Form
    {
        #region // 全局定义字段
        public static IntPtr m_lpDevHandle = IntPtr.Zero;
        public static IntPtr m_oPlayHandleMap = IntPtr.Zero;
        public static IntPtr m_oPicHandleMap = IntPtr.Zero;
        public static IntPtr m_lpTmsPicHandle = IntPtr.Zero;
        public static IntPtr m_talkHandle = IntPtr.Zero;
        public static String m_strLogPath = null;
        public static String m_strRecordSavePath = null;
        public static String m_strsnapshotFilePath = null;
        public static String m_strVideoCBDataPath = null;
        public static String m_strVechicleListfile = null;
        public static String m_strDeviceUpPathfile = null;
        public static String m_strVehicleListPath = null;
        public static String m_strPicListPath = null;
        private static IItsNetDevSdkProxy NetDevSdk = ItsNetDevSdk.Create();
        #endregion

        public int m_volume = 0;
        public bool m_soundStatus = false;
        public int m_micVolume = 0;
        public bool m_micStatus = false;

        public SortedList m_VecDevInfo = new SortedList();

        /*callback function*/
        NETDEV_ParkStatusReportCallBack_PF ItsParkStatusReportCB = null;
        NETDEV_ParkStatusReportCallBack_PF ItsMultiParkStatusReportCB = null;

        NETDEV_PIC_UPLOAD_PF ItsPicCB = null;

        NETDEV_PIC_UPLOAD_PF ItsMultiPicCB = null;

        NETDEV_PIC_UPLOAD_PF ItsTmsPicCB = null;

        NETDEV_PARKING_STATUS_PF ItsTmsParkingStatusCB = null;

        NETDEV_PARSE_VIDEO_DATA_CALLBACK_PF ItsParseVideoCB = null;

        NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF ItsDecodeVideoCB = null;

        public string GetDefaultString(byte[] utf8String)
        {
            utf8String = Encoding.Convert(Encoding.GetEncoding("UTF-8"), Encoding.Unicode, utf8String);
            string strUnicode = Encoding.Unicode.GetString(utf8String);
            strUnicode = strUnicode.Substring(0, strUnicode.IndexOf('\0'));
            return strUnicode;
        }

        public void GetUTF8Buffer(string inputString, int bufferLen, out byte[] utf8Buffer)
        {
            utf8Buffer = new byte[bufferLen];
            byte[] tempBuffer = System.Text.Encoding.UTF8.GetBytes(inputString);
            for (int i = 0; i < tempBuffer.Length; ++i)
            {
                utf8Buffer[i] = tempBuffer[i];
            }
        }

        public object BytesToStruct(byte[] bytes, Type strcutType)
        {
            int size = Marshal.SizeOf(strcutType);
            IntPtr buffer = Marshal.AllocHGlobal(size);
            try
            {
                Marshal.Copy(bytes, 0, buffer, size);
                return Marshal.PtrToStructure(buffer, strcutType);
            }
            finally
            {
                Marshal.FreeHGlobal(buffer);
            }
        }

        /*Status report callback. used to get the status of connection between the SDK and the device */
        public void ParkStatusReportCallback(IntPtr lpUserID, UInt32 ulReportType, IntPtr pParam, IntPtr lpUserData)
        {

            switch (ulReportType)
            {
                case (uint)NETDEV_ITS_STATUS_REPORT_E.NETDEV_ITS_DEV_OFFLINE_E:
                    {
                        if (lpUserID == m_lpDevHandle)
                        {
                            DeviceStatuslabel.Text = "Offline";
                        }
                        break;
                    }
                case (uint)NETDEV_ITS_STATUS_REPORT_E.NETDEV_ITS_DEV_RONLINE_E:
                    {
                        if (lpUserID == m_lpDevHandle)
                        {
                            DeviceStatuslabel.Text = "Online";
                        }

                        break;
                    }
                case (uint)NETDEV_ITS_STATUS_REPORT_E.NETDEV_ITS_MEDIA_OFFLINE_E:
                    {
                        if (pParam == m_oPicHandleMap)
                        {
                            PicStreamlabel.Text = "Offline";
                        }
                        else if (pParam == m_oPlayHandleMap)
                        {
                            RealStreamlabel.Text = "Offline";
                        }

                        break;
                    }
                case (uint)NETDEV_ITS_STATUS_REPORT_E.NETDEV_ITS_MEDIA_RONLINE_E:
                    {
                        if (pParam == m_oPicHandleMap)
                        {
                            PicStreamlabel.Text = "Online";
                        }
                        else if (pParam == m_oPlayHandleMap)
                        {
                            RealStreamlabel.Text = "Online";
                        }

                        break;
                    }
                default:
                    break;
            }


        }

        /*Photo data callback function*/
        public void PicDataCallback(ref NETDEV_PIC_DATA_S pstPicData, IntPtr lpUserData)
        {
            string carPlate = GetDefaultString(pstPicData.szCarPlate);
            string time = GetDefaultString(pstPicData.szPassTime);
            string TollgateID = GetDefaultString(pstPicData.szTollgateID);

            string[] plateColour = new string[] { "white", "yellow", "blue", "black", "other", "green", "red", "y-g", "green" };

            ListViewItem oListViewItem = new ListViewItem(TollgateID);
            oListViewItem.SubItems.Add(time);
            oListViewItem.SubItems.Add(Convert.ToString(pstPicData.lLaneID));
            oListViewItem.SubItems.Add(plateColour[pstPicData.lPlateColor]);
            oListViewItem.SubItems.Add(carPlate);
            oListViewItem.SubItems.Add("No");

            oListViewItem.EnsureVisible();


            for (int i = 0; i < pstPicData.ulPicNumber; i++)
            {
                String strFileName = time + "_" + carPlate + "_" + i.ToString() + ".jpg";

                int size = (int)pstPicData.aulDataLen[i];
                byte[] buffer = new byte[size];
                Marshal.Copy(pstPicData.apcData[i], buffer, 0, size);

                FileStream fs = new FileStream(strFileName, FileMode.Create);

                fs.Write(buffer, 0, buffer.Length);

                fs.Close();
            }

            return;
        }

        /*TMS Photo data callback function*/
        public void TmsPicDataCallback(ref NETDEV_PIC_DATA_S pstPicData, IntPtr lpUserData)
        {
            string carPlate = GetDefaultString(pstPicData.szCarPlate);
            string time = GetDefaultString(pstPicData.szPassTime);
            string TollgateID = GetDefaultString(pstPicData.szTollgateID);

            string[] plateColour = new string[] { "white", "yellow", "blue", "black", "other", "green", "red", "y-g", "green" };

            ListViewItem oListViewItem = new ListViewItem(TollgateID);
            oListViewItem.SubItems.Add(time);
            oListViewItem.SubItems.Add(Convert.ToString(pstPicData.lLaneID));
            oListViewItem.SubItems.Add(carPlate);
            oListViewItem.SubItems.Add(plateColour[pstPicData.lPlateColor]);
            oListViewItem.EnsureVisible();

            //save pic
            for (int i = 0; i < pstPicData.ulPicNumber; i++)
            {
                String strFileName = time + "_" + carPlate + "_" + i.ToString() + ".jpg";

                int size = (int)pstPicData.aulDataLen[i];
                byte[] buffer = new byte[size];
                Marshal.Copy(pstPicData.apcData[i], buffer, 0, size);

                FileStream fs = new FileStream(strFileName, FileMode.Create);
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();
            }

            return;
        }


        /*Parking lot Status callback*/
        public void ParkingStatusCallback(IntPtr lpFindHandle, ref NETDEV_TMS_PARKINGSTATUS_S pstParkStatusData, IntPtr lpUserData)
        {
            string[] carStatus = new string[] { "out", "in", "other" };

            ListViewItem item = new ListViewItem(Convert.ToString(pstParkStatusData.szTollgateID));
            item.SubItems.Add(Convert.ToString(pstParkStatusData.szSampleTime));
            item.SubItems.Add(Convert.ToString(pstParkStatusData.lParkingLotID));
            item.SubItems.Add(Convert.ToString(pstParkStatusData.szCarPlate));
            item.SubItems.Add(carStatus[pstParkStatusData.lParkingLotStatus]);

            item.EnsureVisible();

            return;
        }



        public void DecodeVideoDataCallBack(IntPtr lpRealHandle, ref NETDEV_PICTURE_DATA_S pstPictureData, IntPtr lpUserParam)
        {
            return;
        }

        public void ParseVideoDataCallBack(IntPtr lpRealHandle, ref NETDEV_PARSE_VIDEO_DATA_S pstParseVideoData, IntPtr lpUserParam)
        {
            return;
        }


        public MainForm()
        {
            ItsParkStatusReportCB = new NETDEV_ParkStatusReportCallBack_PF(ParkStatusReportCallback);

            ItsMultiParkStatusReportCB = new NETDEV_ParkStatusReportCallBack_PF(ParkMultiStatusReportCallback);

            ItsPicCB = new NETDEV_PIC_UPLOAD_PF(ParkPicDataCallback);

            ItsTmsPicCB = new NETDEV_PIC_UPLOAD_PF(TmsPicDataCallback);

            ItsMultiPicCB = new NETDEV_PIC_UPLOAD_PF(ParkMultiPicDataCallback);

            ItsTmsParkingStatusCB = new NETDEV_PARKING_STATUS_PF(ParkingStatusCallback);

            ItsParseVideoCB = new NETDEV_PARSE_VIDEO_DATA_CALLBACK_PF(ParseVideoDataCallBack);

            ItsDecodeVideoCB = new NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF(DecodeVideoDataCallBack);

            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            InitNetDemo();
            InitNetTab();
            PathSetting();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

        public void initPlayPanel()
        {

        }

        public void PathSetting()
        {
            m_strLogPath = System.Environment.CurrentDirectory;
            m_strRecordSavePath = System.Environment.CurrentDirectory;
            m_strsnapshotFilePath = System.Environment.CurrentDirectory;
            m_strVideoCBDataPath = System.Environment.CurrentDirectory;
            m_strVehicleListPath = System.Environment.CurrentDirectory;

        }

        private void InitNetTab()
        {
            string[] RecordStyle = new string[] { "MP4(audio+video).mp4", "TS(audio+video).ts", "MP4(audio+video+time).mp4", "TS(audio+video+time).ts", "TS(audio).ts", "MP4(audio).mp4", "TS(audio+time).ts", "MP4(audio+time).mp4" };
            LiveRecordcomboBox.Items.AddRange(RecordStyle);
            LiveRecordcomboBox.SelectedIndex = 0;

            string[] LiveDataFormat = new string[] { "Parse video data", "Decode video data" };
            LiveDataFormatcomboBox.Items.AddRange(LiveDataFormat);
            LiveDataFormatcomboBox.SelectedIndex = 0;

            string[] getParameter = new string[] { "Device Info", "OSD configuration info", "Let Through Policy" };
            getParametercomboBox.Items.AddRange(getParameter);
            getParametercomboBox.SelectedIndex = 0;

            string[] setParameter = new string[] { "OSD configuration info", "Let Through Policy" };
            setParametercomboBox.Items.AddRange(setParameter);
            getParametercomboBox.SelectedIndex = 0;

            string[] getCapability = new string[] { "OSD parameter capability", "Video encoding capability(extended, recommended)" };
            CapabilitycomboBox.Items.AddRange(getCapability);
            CapabilitycomboBox.SelectedIndex = 0;

            string[] OsdFontStytle = new string[] { "Background", "Stroke", "Hollow", "Normal", "Inverse" };
            EffectcomboBox.Items.AddRange(OsdFontStytle);
            EffectcomboBox.SelectedIndex = 0;

            string[] OsdFontSize = new string[] { "X-large", "large", "Medium", "small" };
            FontSizecomboBox.Items.AddRange(OsdFontSize);
            FontSizecomboBox.SelectedIndex = 0;

            string[] OsdMin = new string[] { "None", "Single", "Double" };
            MinMargincomboBox.Items.AddRange(OsdMin);
            MinMargincomboBox.SelectedIndex = 0;

            string[] OsdColor = new string[] { "Black", "Red", "Blue", "Green" };
            FontColorcomboBox.Items.AddRange(OsdColor);
            FontColorcomboBox.SelectedIndex = 0;

            string[] PlateEnable = new string[] { "UTF-8", "GBK" };
            PlateencodingCombox.Items.AddRange(PlateEnable);
            PlateencodingCombox.SelectedIndex = 0;

            AllowListradioButton.Checked = true;
            BlockListradioButton.Checked = false;
        }

        //init demo app
        private void InitNetDemo()
        {
            int iRet = NetDevSdk.NETDEV_Init();
            if (ItsNetDevSdk.TRUE != iRet)
            {
                MessageBox.Show("it is not a admin oper");
            }

        }

        private void PhotoView_Enter(object sender, EventArgs e)
        {

        }

        private void UserLogin_Enter(object sender, EventArgs e)
        {

        }

        /*****Local Features*****/
        private void Loginbutton_Click(object sender, EventArgs e)
        {

            String strIP = DeviceIPtextBox.Text;
            int iPort = Convert.ToInt32(porttextBox.Text);
            String strUser = admintextBox.Text;
            String strPasswd = PasswordtextBox.Text;

            NETDEV_DEVICE_INFO_S pstDevInfo = new NETDEV_DEVICE_INFO_S();
            m_lpDevHandle = NetDevSdk.NETDEV_Login(strIP, (Int16)iPort, strUser, strPasswd, ref pstDevInfo);
            if (m_lpDevHandle == IntPtr.Zero)
            {
                MessageBox.Show("Login failed.", "warning");
            }
            else
            {
                DeviceStatuslabel.Text = "Online";

                NetDevSdk.NETDEV_SetParkStatusCallBack(m_lpDevHandle, ItsParkStatusReportCB, IntPtr.Zero);

                MessageBox.Show("Login succeed.");
            }

            return;
        }

        private void logoutbutton_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_lpDevHandle)
            {
                return;
            }

            Int32 bRet = NetDevSdk.NETDEV_Logout(m_lpDevHandle);
            if (ItsNetDevSdk.TRUE != bRet)
            {
                MessageBox.Show("Logout failed.", "warning");
            }
            else
            {
                DeviceStatuslabel.Text = "Offline";

                MessageBox.Show("Logout succeed.");
            }

        }


        /******Live Operation*****/

        private void LiveOpen_Click(object sender, EventArgs e)
        {

            int bRet;
            if (IntPtr.Zero == m_lpDevHandle)
            {
                return;
            }

            if (IntPtr.Zero != m_oPlayHandleMap)
            {
                bRet = NetDevSdk.NETDEV_StopRealPlay(m_oPlayHandleMap);
                if (ItsNetDevSdk.TRUE == bRet)
                {
                    m_oPlayHandleMap = IntPtr.Zero;
                }
            }

            NETDEV_PREVIEWINFO_S stNetInfo = new NETDEV_PREVIEWINFO_S();

            stNetInfo.dwChannelID = 1;
            stNetInfo.hPlayWnd = VID_STREAM.Handle;
            stNetInfo.dwStreamType = (Int32)NETDEV_LIVE_STREAM_INDEX_E.NETDEV_LIVE_STREAM_INDEX_MAIN;
            stNetInfo.dwLinkMode = (Int32)NETDEV_PROTOCAL_E.NETDEV_TRANSPROTOCAL_RTPTCP;//only support

            m_oPlayHandleMap = NetDevSdk.NETDEV_RealPlay(m_lpDevHandle, ref stNetInfo, IntPtr.Zero, IntPtr.Zero);
            if (IntPtr.Zero == m_oPlayHandleMap)
            {
                MessageBox.Show("start RealPlay failed.", "Warning");
            }
            else
            {
                RealStreamlabel.Text = "Online";
                MessageBox.Show("start RealPlay succeed.");
            }

        }

        private void LiveClose_Click(object sender, EventArgs e)
        {
            int bRet;
            if (IntPtr.Zero != m_oPlayHandleMap)
            {
                bRet = NetDevSdk.NETDEV_StopRealPlay(m_oPlayHandleMap);
                if (ItsNetDevSdk.TRUE == bRet)
                {
                    m_oPlayHandleMap = IntPtr.Zero;
                    MessageBox.Show("stop RealPlay succeed.");
                    RealStreamlabel.Text = "Offline";
                }
                else
                {
                    MessageBox.Show("stop RealPlay failed.");
                }
            }
        }

        private void Snapshot_Click(object sender, EventArgs e)
        {

            String strNowTime = DateTime.Now.ToString("HH-mm-ss-ms");

            String strFileName = m_strsnapshotFilePath + "\\snapFile\\" + strNowTime;
            byte[] picSavePath;
            GetUTF8Buffer(strFileName, ItsNetDevSdk.NETDEV_LEN_260, out picSavePath);

            if (IntPtr.Zero != m_oPlayHandleMap)
            {
                String strOut;
                int bRet = NetDevSdk.NETDEV_CapturePicture(m_oPlayHandleMap, picSavePath, (int)NETDEV_PICTURE_FORMAT_E.NETDEV_PICTURE_JPG);
                if (ItsNetDevSdk.TRUE != bRet)
                {
                    strOut = "snap shot failed.";
                }
                else
                {
                    strOut = "snap shot succeed";
                }
                MessageBox.Show(strOut);
            }
            else
            {
                String strOut = "snap shot failed.";
                MessageBox.Show(strOut);
            }
        }

        private void StartRecording_Click(object sender, EventArgs e)
        {

            string[] carStatus = new string[] { "MP4(audio+video).mp4", "TS(audio+video).ts", "MP4(audio+video+time).mp4", "TS(audio+video+time).ts", "TS(audio).ts", "MP4(audio).mp4", "TS(audio+time).ts", "MP4(audio+time).mp4" };
            string strRecordSavePath = "";
            //strRecordSavePath = m_strRecordSavePath + "\\RecordFile\\";

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Please select RcordSave path";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                strRecordSavePath = dialog.SelectedPath + "\\RecordFile\\";
                MessageBox.Show("Select Folder" + strRecordSavePath, "Select Folder Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);

                try
                {
                    if (!Directory.Exists(strRecordSavePath))
                    {
                        Directory.CreateDirectory(strRecordSavePath);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("create path fail", "warning");
                }
            }
            else
            {
                MessageBox.Show("No Select RealData SavePath", "warning");
                return;
            }

            byte[] localRecordPath;
            strRecordSavePath = strRecordSavePath + carStatus[LiveRecordcomboBox.SelectedIndex];
            GetUTF8Buffer(strRecordSavePath, ItsNetDevSdk.NETDEV_LEN_260, out localRecordPath);

            if (IntPtr.Zero != m_oPlayHandleMap)
            {
                int iRet = NetDevSdk.NETDEV_SaveRealData(m_oPlayHandleMap, localRecordPath, LiveRecordcomboBox.SelectedIndex);
                if (ItsNetDevSdk.FALSE == iRet)
                {
                    MessageBox.Show("Save RealData failed.");
                }
                else
                {
                    LiveRecordingSavePath.Text = strRecordSavePath; ;
                    MessageBox.Show("Save RealData succeed.");
                }
            }
            LiveRecordingSavePath.Text = strRecordSavePath;
        }

        private void StopRecording_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_oPlayHandleMap)
            {
                return;
            }

            int iRet = NetDevSdk.NETDEV_StopSaveRealData(m_oPlayHandleMap);
            if (ItsNetDevSdk.TRUE == iRet)
            {
                LiveRecordingSavePath.Text = "";
                MessageBox.Show("Stop SaveRealData succeed.");
                return;
            }
            else
            {
                MessageBox.Show("Stop SaveRealData failed.", "Warning");
            }
        }

        private void LiveDataSetCallback_Click(object sender, EventArgs e)
        {

            string strVideoSavePath = "";

            if (0 == LiveDataFormatcomboBox.SelectedIndex)
            {
                strVideoSavePath = m_strVideoCBDataPath + "\\ParseVideo";
            }
            else if (1 == LiveDataFormatcomboBox.SelectedIndex)
            {
                strVideoSavePath = m_strVideoCBDataPath + "\\DecodeVideo";
            }

            try
            {
                if (!Directory.Exists(strVideoSavePath))
                {
                    Directory.CreateDirectory(strVideoSavePath);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("create path fail", "warning");
            }

            if (IntPtr.Zero != m_oPlayHandleMap)
            {
                int iRet = 0;
                if (0 == LiveDataFormatcomboBox.SelectedIndex)
                {
                    iRet = NetDevSdk.NETDEV_SetPlayParseCB(m_oPlayHandleMap, ref ItsParseVideoCB, ItsNetDevSdk.TRUE, IntPtr.Zero);
                    if (ItsNetDevSdk.TRUE != iRet)
                    {
                        MessageBox.Show("set playParse fail", "warning");
                    }
                    else
                    {
                        MessageBox.Show("set playParse succeed");
                    }
                }
                else if (1 == LiveDataFormatcomboBox.SelectedIndex)
                {
                    iRet = NetDevSdk.NETDEV_SetPlayDecodeVideoCB(m_oPlayHandleMap, ref ItsDecodeVideoCB, ItsNetDevSdk.TRUE, IntPtr.Zero);
                    if (ItsNetDevSdk.TRUE != iRet)
                    {
                        MessageBox.Show("set playDecode fail", "warning");
                    }
                    else
                    {
                        MessageBox.Show("set playDecode succeed");
                    }
                }
            }

        }

        private void LiveDataReset_Click(object sender, EventArgs e)
        {

            NETDEV_PARSE_VIDEO_DATA_CALLBACK_PF oItsParseVideoCB = null;
            NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF oItsDecodeVideoCB = null;

            if (IntPtr.Zero != m_oPlayHandleMap)
            {
                int iRet = 0;
                if (0 == LiveDataFormatcomboBox.SelectedIndex)
                {
                    iRet = NetDevSdk.NETDEV_SetPlayParseCB(m_oPlayHandleMap, ref oItsParseVideoCB, ItsNetDevSdk.TRUE, IntPtr.Zero);
                    if (ItsNetDevSdk.TRUE != iRet)
                    {
                        MessageBox.Show("close playParse fail", "warning");
                    }
                    else
                    {
                        MessageBox.Show("close playParse succeed");
                    }
                }
                else if (1 == LiveDataFormatcomboBox.SelectedIndex)
                {
                    iRet = NetDevSdk.NETDEV_SetPlayDecodeVideoCB(m_oPlayHandleMap, ref oItsDecodeVideoCB, ItsNetDevSdk.TRUE, IntPtr.Zero);
                    if (ItsNetDevSdk.TRUE != iRet)
                    {
                        MessageBox.Show("close playDecode fail", "warning");
                    }
                    else
                    {
                        MessageBox.Show("close playDecode succeed");
                    }
                }
            }

            return;

        }


        /******Local Features*****/
        private void GetVersion_Click(object sender, EventArgs e)
        {
            byte[] szVersion = new byte[64];
            NetDevSdk.NETDEV_GetPARKVersion(szVersion);
            string strVersion = GetDefaultString(szVersion);
            VersiontextBox.Text = strVersion;
        }

        private void SetlogPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "Please select File path";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                m_strLogPath = dialog.SelectedPath + "\\log";
                MessageBox.Show("Select Folder" + m_strLogPath, "Select Folder Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);

                try
                {
                    if (!Directory.Exists(m_strLogPath))
                    {
                        Directory.CreateDirectory(m_strLogPath);
                        int bRet = NetDevSdk.NETDEV_SetLogPath(m_strLogPath);
                        if (ItsNetDevSdk.TRUE != bRet)
                        {
                            MessageBox.Show("Set log path fail: " + NetDevSdk.NETDEV_GetLastError(), "warning");
                        }
                        else
                        {
                            MessageBox.Show("Set log path Success", "warning");
                        }
                    }
                    LogPath.Text = m_strLogPath;
                }
                catch (Exception)
                {
                    MessageBox.Show("create path fail", "warning");
                }
            }
        }

        private void SetlogSizeNum_Click(object sender, EventArgs e)
        {
            int iLogFileSize = Convert.ToInt32(LogSize.Text);
            int iLogFileNum = Convert.ToInt32(LogNumber.Text);

            int iRet = NetDevSdk.NETDEV_ConfigLogFile(iLogFileSize * 1024 * 1024, iLogFileNum);
            if (ItsNetDevSdk.TRUE != iRet)
            {
                MessageBox.Show("NETDEV_ConfigLogFile fail: " + NetDevSdk.NETDEV_GetLastError(), "warning");
            }
            else
            {
                LogPath.Text = m_strLogPath;
                MessageBox.Show("ConfigLogFile Success", "warning");
            }
        }

        /******Photo Operation*****/

        public void ParkPicDataCallback(ref NETDEV_PIC_DATA_S pstPicData, IntPtr lpUserData)
        {

            string[] strColor = new string[] { "white", "yellow", "blue", "black", "other", "green", "red", "yellow-green", "gradual-green" };

            string carPlate = GetDefaultString(pstPicData.szCarPlate);
            string time = GetDefaultString(pstPicData.szPassTime);
            string TollgateID = GetDefaultString(pstPicData.szTollgateID);

            ListViewItem oListViewItem = new ListViewItem(TollgateID);
            oListViewItem.SubItems.Add(time);
            oListViewItem.SubItems.Add(Convert.ToString(pstPicData.lLaneID));
            if (pstPicData.lPlateColor > strColor.Length)
            {
                oListViewItem.SubItems.Add("other");
            }
            else
            {
                oListViewItem.SubItems.Add(strColor[pstPicData.lPlateColor]);
            }
            oListViewItem.SubItems.Add(carPlate);
            oListViewItem.SubItems.Add("No");

            this.PhotoListView.Items.Add(oListViewItem);
            oListViewItem.EnsureVisible();

            //获取当前文件夹路径
            string currPath = Application.StartupPath;
            //检查是否存在文件夹
            string subPath = currPath + "/pic/";
            if (false == System.IO.Directory.Exists(subPath))
            {
                //创建pic文件夹
                System.IO.Directory.CreateDirectory(subPath);
            }

            //save pic
            for (int i = 0; i < pstPicData.ulPicNumber; i++)
            {
                String strFileName = subPath + time + "_" + carPlate + "_" + i.ToString() + ".jpg";

                int size = (int)pstPicData.aulDataLen[i];
                byte[] buffer = new byte[size];
                Marshal.Copy(pstPicData.apcData[i], buffer, 0, size);

                FileStream fs = new FileStream(strFileName, FileMode.Create);
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();
            }

            return;
        }

        private void PhotoOpen_Click(object sender, EventArgs e)
        {

            if (IntPtr.Zero == m_lpDevHandle)
            {
                return;
            }

            if (IntPtr.Zero != m_oPicHandleMap)
            {
                int bRet = NetDevSdk.NETDEV_StopPicStream(m_oPicHandleMap);
                if (ItsNetDevSdk.TRUE == bRet)
                {
                    m_oPicHandleMap = IntPtr.Zero;
                }
            }

            m_oPicHandleMap = (IntPtr)NetDevSdk.NETDEV_StartPicStream(m_lpDevHandle, PIC_STREAM.Handle, false, "", ItsPicCB, IntPtr.Zero);
            if (IntPtr.Zero == m_oPicHandleMap)
            {
                MessageBox.Show("Start PicStream fail", "warning");
            }
            else
            {
                PicStreamlabel.Text = "Online";

                MessageBox.Show("Start PicStream succeed");
            }

            return;

        }

        private void PhotoClose_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_oPicHandleMap)
            {
                return;
            }
            if (IntPtr.Zero != m_oPicHandleMap)
            {
                int ulRet = NetDevSdk.NETDEV_StopPicStream(m_oPicHandleMap);
                if (ItsNetDevSdk.TRUE != ulRet)
                {
                    MessageBox.Show("Stop PicStream fail", "warning");
                    return;
                }
                else
                {
                    PicStreamlabel.Text = "Offline";
                    MessageBox.Show("Stop PicStream Succeed!");
                }
            }

            m_oPicHandleMap = IntPtr.Zero;

            return;
        }

        private void PhotoCapture_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_lpDevHandle || IntPtr.Zero == m_oPicHandleMap)
            {
                MessageBox.Show("No Start Picstream");
                return;
            }

            Int32 ulRet = NetDevSdk.NETDEV_Trigger(m_lpDevHandle);
            if (ItsNetDevSdk.TRUE != ulRet)
            {
                MessageBox.Show("NETDEV_Trigger fail");
                return;
            }
        }

        private void PhotoCaptureSys_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_lpDevHandle || IntPtr.Zero == m_oPicHandleMap)
            {
                MessageBox.Show("No Start Picstream");
                return;
            }

            IntPtr pPicDataInfo = IntPtr.Zero;

            Int32 ulRet = NetDevSdk.NETDEV_TriggerSync(m_lpDevHandle, ref pPicDataInfo);
            if (ItsNetDevSdk.TRUE != ulRet)
            {
                MessageBox.Show("NETDEV_TriggerSync fail, error code=" + ulRet);
                return;
            }

            NETDEV_PIC_DATA_S stDevInfo = new NETDEV_PIC_DATA_S();
            byte[] pByte = new byte[Marshal.SizeOf(stDevInfo)];
            Marshal.Copy(pPicDataInfo, pByte, 0, Marshal.SizeOf(stDevInfo));
            stDevInfo = (NETDEV_PIC_DATA_S)BytesToStruct(pByte, stDevInfo.GetType());

            string carPlate = GetDefaultString(stDevInfo.szCarPlate);
            string time = GetDefaultString(stDevInfo.szPassTime);
            string TollgateID = GetDefaultString(stDevInfo.szTollgateID);

            string[] plateColour = new string[] { "white", "yellow", "blue", "black", "other", "green", "red", "y-g", "gradualgreen" };

            ListViewItem oListViewItem = new ListViewItem(TollgateID);
            oListViewItem.SubItems.Add(time);
            oListViewItem.SubItems.Add(Convert.ToString(stDevInfo.lLaneID));
            oListViewItem.SubItems.Add(plateColour[stDevInfo.lPlateColor]);
            oListViewItem.SubItems.Add(carPlate);
            oListViewItem.SubItems.Add("Yes");
            this.PhotoListView.Items.Add(oListViewItem);
            oListViewItem.EnsureVisible();

            //获取当前文件夹路径
            string currPath = Application.StartupPath;
            //检查是否存在文件夹
            string subPath = currPath + "/pic/";
            if (false == System.IO.Directory.Exists(subPath))
            {
                //创建pic文件夹
                System.IO.Directory.CreateDirectory(subPath);
            }

            //save pic
            for (int i = 0; i < stDevInfo.ulPicNumber; i++)
            {
                String strFileName = subPath + time + "_" + carPlate + "_" + i.ToString() + ".jpg";

                int size = (int)stDevInfo.aulDataLen[i];
                byte[] buffer = new byte[size];
                Marshal.Copy(stDevInfo.apcData[i], buffer, 0, size);

                FileStream fs = new FileStream(strFileName, FileMode.Create);
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();
            }
            return;
        }


        /*****************************************VechicleList Operation***************************************/
        private void VechicleListBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "Please select file of csv";
            dialog.Filter = "csv files(*.csv)|*.csv||";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                VechicleListFilePath.Text = dialog.FileName;
                m_strVechicleListfile = dialog.FileName;
            }
        }

        private void VechicleListImport_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_lpDevHandle)
            {
                MessageBox.Show("Import BlackWhiteList File, device is NULL", "warning");
                return;
            }

            int iRet = NetDevSdk.NETDEV_ImportBlackWhiteListFile(m_lpDevHandle, m_strVechicleListfile);
            if (0 != iRet)
            {
                MessageBox.Show("Import BlackWhiteList File fail.");
            }
            else
            {
                MessageBox.Show("Import BlackWhiteList File succeed.");
            }

            return;
        }

        private void VehicleListAllowExport_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_lpDevHandle)
            {
                MessageBox.Show("Export Whitelist File, device is NULL", "warning");
                return;
            }

            string strCurPath = m_strVehicleListPath + "\\Whitelist\\GateWhitelist.csv";

            int iRet = NetDevSdk.NETDEV_ExportBlackWhiteListFile(m_lpDevHandle, strCurPath);
            if (0 == iRet)
            {
                MessageBox.Show("Export Whitelist succeed.");
            }
            else
            {
                MessageBox.Show("Export Whitelist fail.");
            }

            return;
        }

        private void VehicleListBlockExport_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_lpDevHandle)
            {
                MessageBox.Show("Export Blacklist, device is NULL", "warning");
                return;
            }


            string strCurPath = m_strVehicleListPath + "\\Blacklist\\GateBlacklist.csv";

            int iRet = NetDevSdk.NETDEV_ExportBlackWhiteListFile(m_lpDevHandle, strCurPath);
            if (0 == iRet)
            {
                MessageBox.Show("Export Blacklist succeed.");
            }
            else
            {
                MessageBox.Show("Export Blacklist fail.");
            }

            return;
        }

        private string getInputStartDataTime()
        {
            String beginDateTimeStr = this.EffectiveData.Value.Year.ToString();
            beginDateTimeStr += ("-" + this.EffectiveData.Value.Month.ToString());
            beginDateTimeStr += ("-" + this.EffectiveData.Value.Day.ToString());

            beginDateTimeStr += (" " + this.EffectiveTime.Value.Hour.ToString());
            beginDateTimeStr += (":" + this.EffectiveTime.Value.Minute.ToString());
            beginDateTimeStr += (":" + this.EffectiveTime.Value.Second.ToString());

            return beginDateTimeStr;
        }

        private string getInputEndDataTime()
        {
            String endDateTimeStr = this.ExpirationDate.Value.Year.ToString();
            endDateTimeStr += ("-" + this.ExpirationDate.Value.Month.ToString());
            endDateTimeStr += ("-" + this.ExpirationDate.Value.Day.ToString());

            endDateTimeStr += (" " + this.ExpirationTime.Value.Hour.ToString());
            endDateTimeStr += (":" + this.ExpirationTime.Value.Minute.ToString());
            endDateTimeStr += (":" + this.ExpirationTime.Value.Second.ToString());
            return endDateTimeStr;
        }

        private long getLongTime(String strTime)
        {
            DateTime dateTime = Convert.ToDateTime(strTime);
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 
            return (long)(dateTime - startTime).TotalSeconds; // 
        }

        private string getStrTime(long time)
        {
            DateTime startDateTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 
            return startDateTime.AddSeconds(time).ToString("yyyy/MM/dd HH:mm:ss");

        }

        private void AddRecord_Click(object sender, EventArgs e)
        {

            if (IntPtr.Zero == m_lpDevHandle)
            {
                MessageBox.Show("add Vehicle Record, device is NULL", "warning");
                return;
            }

            NETDEV_PARK_VEHICLE_RECORD_S pstVehicleRecord = new NETDEV_PARK_VEHICLE_RECORD_S();

            pstVehicleRecord.dwId = Convert.ToInt32(VechicleListIDtextBox.Text);
            pstVehicleRecord.dwEnableType = 0;
            pstVehicleRecord.szPlateNo = Encoding.UTF8.GetBytes(VechicleListNotextBox.Text.PadRight(32, '\0').ToCharArray());

            String beginDateTimeStr = getInputStartDataTime();
            String endDateTimeStr = getInputEndDataTime();

            pstVehicleRecord.dwEffectiveTime = this.getLongTime(beginDateTimeStr);
            pstVehicleRecord.dwExpirationTime = this.getLongTime(endDateTimeStr);


            NETDEV_PARK_VEHICLE_RECORD_EXTERN_S pstVehicleRecordExtern = new NETDEV_PARK_VEHICLE_RECORD_EXTERN_S();

            if (true == AllowListradioButton.Checked)
            {
                pstVehicleRecordExtern.dwListType = 0;
            }
            else if (true == BlockListradioButton.Checked)
            {
                pstVehicleRecordExtern.dwListType = 1;
            }

            pstVehicleRecordExtern.dwDBOperateType = (int)NETDEV_DB_OPERATE_E.NETDEV_DB_OPERATE_ADD;
            pstVehicleRecordExtern.stVehicleRecordList = new NETDEV_PARK_VEHICLE_RECORD_LIST_S();
            pstVehicleRecordExtern.stVehicleRecordList.dwNum = 1;

            int nSize = Marshal.SizeOf(pstVehicleRecord);
            pstVehicleRecordExtern.stVehicleRecordList.pastVehicleRecord = Marshal.AllocHGlobal(nSize);

            Marshal.StructureToPtr(pstVehicleRecord, pstVehicleRecordExtern.stVehicleRecordList.pastVehicleRecord, true);


            Int32 iRet = NetDevSdk.NETDEV_AddVehicleRecord(m_lpDevHandle, ref pstVehicleRecordExtern);
            if (0 != iRet)
            {

                MessageBox.Show("Add VehicleRecord fail.", "warning");
            }
            else
            {
                MessageBox.Show("Add VehicleRecord succeed.");
            }

            Marshal.FreeHGlobal(pstVehicleRecordExtern.stVehicleRecordList.pastVehicleRecord);

            return;
        }



        private void AllowListradioButton_CheckedChanged(object sender, EventArgs e)
        {
            BlockListradioButton.Checked = false;
        }

        private void BlockListradioButton_CheckedChanged(object sender, EventArgs e)
        {
            AllowListradioButton.Checked = false;
        }


        private void ModifyRecord_Click(object sender, EventArgs e)
        {

            if (IntPtr.Zero == m_lpDevHandle)
            {
                MessageBox.Show("Modify vehicle record, device is NULL", "warning");
                return;
            }

            NETDEV_PARK_VEHICLE_RECORD_S pstVehicleRecord = new NETDEV_PARK_VEHICLE_RECORD_S();

            pstVehicleRecord.dwId = Convert.ToInt32(VechicleListIDtextBox.Text);
            pstVehicleRecord.dwEnableType = 0;
            pstVehicleRecord.szPlateNo = Encoding.UTF8.GetBytes(VechicleListNotextBox.Text.PadRight(32, '\0').ToCharArray());

            String beginDateTimeStr = getInputStartDataTime();
            String endDateTimeStr = getInputEndDataTime();

            pstVehicleRecord.dwEffectiveTime = this.getLongTime(beginDateTimeStr);
            pstVehicleRecord.dwExpirationTime = this.getLongTime(endDateTimeStr);


            if (true == AllowListradioButton.Checked)
            {
                Int32 iRet = NetDevSdk.NETDEV_ModifyAllowVehicleRecord(m_lpDevHandle, ref pstVehicleRecord);
                if (0 != iRet)
                {
                    MessageBox.Show("Modify Allow vehicle record fail.", "warning");
                }
                else
                {
                    MessageBox.Show("Modify Allow vehicle record succeed.");
                }
            }
            else if (true == BlockListradioButton.Checked)
            {
                Int32 iRet = NetDevSdk.NETDEV_ModifyBlockVehicleRecord(m_lpDevHandle, ref pstVehicleRecord);
                if (0 != iRet)
                {
                    MessageBox.Show("Modify Block vehicle record fail.", "warning");
                }
                else
                {
                    MessageBox.Show("Modify Block vehicle record succeed.");
                }
            }

            return;
        }

        private void DeleteRecord_Click(object sender, EventArgs e)
        {

            if (IntPtr.Zero == m_lpDevHandle)
            {
                MessageBox.Show("Modify vehicle record, device is NULL", "warning");
                return;
            }

            if (true == AllowListradioButton.Checked)
            {
                Int32 iRet = NetDevSdk.NETDEV_DeleteAllowVehicleRecord(m_lpDevHandle, Convert.ToInt32(VechicleListIDtextBox.Text));
                if (0 != iRet)
                {
                    MessageBox.Show("Delete allow vehicle record fail.", "warning");
                }
                else
                {
                    MessageBox.Show("Delete allow vehicle record succeed.");
                }
            }
            else if (true == BlockListradioButton.Checked)
            {
                Int32 iRet = NetDevSdk.NETDEV_DeleteBlockVehicleRecord(m_lpDevHandle, Convert.ToInt32(VechicleListIDtextBox.Text));
                if (0 != iRet)
                {
                    MessageBox.Show("Delete block vehicle record fail.", "warning");
                }
                else
                {
                    MessageBox.Show("Delete block vehicle record succeed.");
                }
            }

            return;
        }


        /********************************************Parameter******************************************/

        private void Getparameter_Click(object sender, EventArgs e)
        {

            if (IntPtr.Zero == m_lpDevHandle)
            {
                MessageBox.Show("get parameter cfg, device is NULL", "warning");
                return;
            }


            int index = getParametercomboBox.SelectedIndex;

            switch (index)
            {
                case 0:
                    {
                        GetDeviceConfig();
                        break;
                    }
                case 1:
                    {
                        GetOSDInfo();
                        break;
                    }
                case 2:
                    {
                        GetReleaserInfo();
                        break;
                    }
                default:
                    break;

            }

            return;
        }

        private void GetDeviceConfig()
        {
            Int32 dwBytesReturned = 0;
            Int32 dwChannelID = 0;
            NETDEV_DEVICE_BASICINFO_S stDeviceBasicInfo = new NETDEV_DEVICE_BASICINFO_S();

            int iRet = NetDevSdk.NETDEV_GetDevConfig(m_lpDevHandle, dwChannelID, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_DEVICECFG, ref stDeviceBasicInfo, Marshal.SizeOf(stDeviceBasicInfo), ref dwBytesReturned);
            if (ItsNetDevSdk.TRUE != iRet)
            {
                MessageBox.Show("Get device name fail.");
            }
            else
            {
                String strText;
                strText = "Device model：" + Convert.ToString(stDeviceBasicInfo.szDevModel) + "Hardware serial number：" + Convert.ToString(stDeviceBasicInfo.szSerialNum) + "Software version number：" + Convert.ToString(stDeviceBasicInfo.szFirmwareVersion)
                    + "IPv4 MAC address" + Convert.ToString(stDeviceBasicInfo.szMacAddress) + "Device name：" + Convert.ToString(stDeviceBasicInfo.szDeviceName);

                MessageBox.Show(strText);
            }
            return;
        }

        public void GetOSDInfo()
        {
            /* Get OSD */
            Int32 dwBytesReturned = 0;
            Int32 dwChannelID = 1;

            NETDEV_VIDEO_OSD_CFG_S stOSDInfo = new NETDEV_VIDEO_OSD_CFG_S();
            stOSDInfo.astTextOverlay = new NETDEV_OSD_TEXT_OVERLAY_S[ItsNetDevSdk.NETDEV_OSD_TEXTOVERLAY_NUM];

            int iRet = NetDevSdk.NETDEV_GetDevConfig(m_lpDevHandle, dwChannelID, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_OSDCFG, ref stOSDInfo, Marshal.SizeOf(stOSDInfo), ref dwBytesReturned);
            if (ItsNetDevSdk.TRUE != iRet)
            {
                MessageBox.Show("Get OSD Cfg fail.", "warning");
            }
            else
            {
                MessageBox.Show("Get OSD Cfg succeed.");
            }

        }


        public void GetReleaserInfo()
        {
            /* Get OSD */
            Int32 dwBytesReturned = 0;
            Int32 dwChannelID = 0;

            NETDEV_INFORELEASE_CFG_S stReleaserInfo = new NETDEV_INFORELEASE_CFG_S();

            int iRet = NetDevSdk.NETDEV_GetDevConfig(m_lpDevHandle, dwChannelID, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_INFORELEASE, ref stReleaserInfo, Marshal.SizeOf(stReleaserInfo), ref dwBytesReturned);
            if (ItsNetDevSdk.TRUE != iRet)
            {
                MessageBox.Show("Get Releaser Info fail.", "warning");
                return;
            }
            else
            {
                MessageBox.Show("Get Releaser Info succeed.");
            }

        }

        private void Setparameter_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_lpDevHandle)
            {
                MessageBox.Show("set led cfg, device is NULL", "warning");
                return;
            }

            int index = setParametercomboBox.SelectedIndex;

            switch (index)
            {

                case 0:
                    {
                        SetOSDInfo();
                        break;
                    }
                case 1:
                    {
                        SetReleaserInfo();
                        break;
                    }
                default:
                    break;

            }

            return;
        }

        public void SetOSDInfo()
        {
            /* Get OSD */
            Int32 dwBytesReturned = 0;
            Int32 dwChannelID = 1;

            NETDEV_VIDEO_OSD_CFG_S stOSDInfo = new NETDEV_VIDEO_OSD_CFG_S();
            stOSDInfo.astTextOverlay = new NETDEV_OSD_TEXT_OVERLAY_S[ItsNetDevSdk.NETDEV_OSD_TEXTOVERLAY_NUM];

            int iRet = NetDevSdk.NETDEV_GetDevConfig(m_lpDevHandle, dwChannelID, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_OSDCFG, ref stOSDInfo, Marshal.SizeOf(stOSDInfo), ref dwBytesReturned);
            if (ItsNetDevSdk.TRUE != iRet)
            {
                MessageBox.Show("Set OSD Cfg fail.");
                return;
            }

            iRet = NetDevSdk.NETDEV_SetDevConfig(m_lpDevHandle, dwChannelID, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_SET_OSDCFG, ref stOSDInfo, Marshal.SizeOf(stOSDInfo));
            if (ItsNetDevSdk.TRUE != iRet)
            {
                MessageBox.Show("Set OSD Cfg fail.");
                return;
            }
            else
            {
                MessageBox.Show("Set OSD Cfg succeed.");
                return;
            }

        }


        public void SetReleaserInfo()
        {
            /* Get OSD */
            Int32 dwBytesReturned = 0;
            Int32 dwChannelID = 0;

            NETDEV_INFORELEASE_CFG_S stReleaserInfo = new NETDEV_INFORELEASE_CFG_S();

            int iRet = NetDevSdk.NETDEV_GetDevConfig(m_lpDevHandle, dwChannelID, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_INFORELEASE, ref stReleaserInfo, Marshal.SizeOf(stReleaserInfo), ref dwBytesReturned);
            if (ItsNetDevSdk.TRUE != iRet)
            {
                MessageBox.Show("Set Releaser Info fail.");
                return;
            }

            iRet = NetDevSdk.NETDEV_SetDevConfig(m_lpDevHandle, dwChannelID, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_SET_INFORELEASE, ref stReleaserInfo, Marshal.SizeOf(stReleaserInfo));
            if (ItsNetDevSdk.TRUE != iRet)
            {
                MessageBox.Show("Set Releaser Info fail.");
                return;
            }
            else
            {
                MessageBox.Show("Set Releaser Info succeed.");
                return;
            }

        }

        private void getcapability_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_lpDevHandle)
            {
                MessageBox.Show("get capability cfg, device is NULL", "warning");
                return;
            }

            int index = CapabilitycomboBox.SelectedIndex;

            switch (index)
            {

                case 0:
                    {
                        GetOsdCapability();
                        break;
                    }
                case 1:
                    {
                        GetVideoEncodeExCap();
                        break;
                    }
                default:
                    break;

            }

            return;
        }

        public void GetOsdCapability()
        {
            /* Get OsdCapability */
            Int32 dwBytesReturned = 0;
            Int32 dwChannelID = 0;

            NETDEV_OSD_CAP_S stOsdCapInfo = new NETDEV_OSD_CAP_S();


            int iRet = NetDevSdk.NETDEV_GetDeviceCapability(m_lpDevHandle, dwChannelID, (int)NETDEV_CAPABILITY_COMMOND_E.NETDEV_CAP_OSD, ref stOsdCapInfo, Marshal.SizeOf(stOsdCapInfo), ref dwBytesReturned);
            if (ItsNetDevSdk.TRUE != iRet)
            {
                MessageBox.Show("Get OsdCapability Info fail.");
            }
            else
            {
                MessageBox.Show("Get OsdCapability Info succeed.");
            }

            return;
        }

        public void GetVideoEncodeExCap()
        {
            /* Get VideoEncodeExCap */
            Int32 dwBytesReturned = 0;
            Int32 dwChannelID = 0;

            NETDEV_VIDEO_STREAM_CAP_EX_S stVideoStreamCapEx = new NETDEV_VIDEO_STREAM_CAP_EX_S();

            int iRet = NetDevSdk.NETDEV_GetDeviceCapability(m_lpDevHandle, dwChannelID, (int)NETDEV_CAPABILITY_COMMOND_E.NETDEV_CAP_VIDEO_ENCODE_EX, ref stVideoStreamCapEx, Marshal.SizeOf(stVideoStreamCapEx), ref dwBytesReturned);
            if (ItsNetDevSdk.TRUE != iRet)
            {
                MessageBox.Show("Get Video StreamCap Info fail.");
            }
            else
            {
                MessageBox.Show("Get Video StreamCap Info succeed.");
            }

            return;

        }

        private void SettingOSDContent_Click(object sender, EventArgs e)
        {

            if (IntPtr.Zero == m_lpDevHandle)
            {
                MessageBox.Show("set osdcontent cfg, device is NULL", "warning");
                return;
            }

            Int32 dwBytesReturned = 0;
            Int32 dwChannelID = 0;
            Int32 ulRet = 0;

            Int32[] sOsdcolor = new Int32[4];
            sOsdcolor[0] = 0x000000;            /*Black*/
            sOsdcolor[1] = 0xFF0000;            /*Red*/
            sOsdcolor[2] = 0x0000FF;            /*Blue*/
            sOsdcolor[3] = 0x00FF00;            /**Green*/


            string strOsdTest = OSDContenttextBox.Text;
            NETDEV_OSD_CONTENT_S stuInfoOsdCfgs = new NETDEV_OSD_CONTENT_S();
            NETDEV_OSD_CONTENT_STYLE_S stuStyleCfgs = new NETDEV_OSD_CONTENT_STYLE_S();
            IntPtr pInfoOsdCfgsA = IntPtr.Zero;
            IntPtr pInfoOsdCfgsB = IntPtr.Zero;
            IntPtr pstuStyleCfgsA = IntPtr.Zero;
            IntPtr pstuStyleCfgsB = IntPtr.Zero;

            //get osd text
            try
            {
                pInfoOsdCfgsA = Marshal.AllocHGlobal(Marshal.SizeOf(stuInfoOsdCfgs));
                Marshal.StructureToPtr(stuInfoOsdCfgs, pInfoOsdCfgsA, true);

                ulRet = NetDevSdk.NETDEV_GetDevConfig(m_lpDevHandle, dwChannelID, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_INFOOSDCFG, pInfoOsdCfgsA, Marshal.SizeOf(stuInfoOsdCfgs), ref dwBytesReturned);
                if (ItsNetDevSdk.TRUE != ulRet)
                {
                    string strError = string.Format("Get OSD info config fail, error code:{0:D}", ulRet);
                    MessageBox.Show(strError);
                    return;
                }
                stuInfoOsdCfgs = (NETDEV_OSD_CONTENT_S)Marshal.PtrToStructure(pInfoOsdCfgsA, stuInfoOsdCfgs.GetType());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                Marshal.FreeHGlobal(pInfoOsdCfgsA);
            }


            for (int i = 0; i < stuInfoOsdCfgs.udwNum; i++)
            {
                stuInfoOsdCfgs.astContentList[i].udwOSDID = (uint)i;
                if (i == 0)
                {
                    stuInfoOsdCfgs.astContentList[i].bEnabled = 1;
                }
                else
                {
                    stuInfoOsdCfgs.astContentList[i].bEnabled = 0;
                }

                stuInfoOsdCfgs.astContentList[i].udwAreaOSDNum = 8;

                stuInfoOsdCfgs.astContentList[i].udwTopLeftX = 2;
                stuInfoOsdCfgs.astContentList[i].udwTopLeftY = 3;

                stuInfoOsdCfgs.astContentList[i].udwBotRightX = 12;
                stuInfoOsdCfgs.astContentList[i].udwBotRightY = 13;

                for (int j = 0; j < stuInfoOsdCfgs.astContentList[i].udwAreaOSDNum; j++)
                {
                    stuInfoOsdCfgs.astContentList[i].astContentInfo[j].szOSDText = new byte[stuInfoOsdCfgs.astContentList[i].astContentInfo[j].szOSDText.Length];

                    if (i == 0 && j == 0)
                    {
                        stuInfoOsdCfgs.astContentList[i].astContentInfo[j].udwContentType = (uint)NETDEV_OSD_CONTENT_TYPE_E.NETDEV_OSD_CONTENT_TYPE_CUSTOM;
                        stuInfoOsdCfgs.astContentList[i].astContentInfo[j].szOSDText = Encoding.UTF8.GetBytes(strOsdTest.PadRight(68, '\0').ToCharArray());
                    }
                    else
                    {
                        stuInfoOsdCfgs.astContentList[i].astContentInfo[j].udwContentType = (uint)NETDEV_OSD_CONTENT_TYPE_E.NETDEV_OSD_CONTENT_TYPE_NOTUSE;
                    }
                }
            }
            //set OSD text
            try
            {

                pInfoOsdCfgsB = Marshal.AllocHGlobal(Marshal.SizeOf(stuInfoOsdCfgs));
                Marshal.StructureToPtr(stuInfoOsdCfgs, pInfoOsdCfgsB, true);

                ulRet = NetDevSdk.NETDEV_SetDevConfig(m_lpDevHandle, 1, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_SET_OSD_CONTENT_CFG, pInfoOsdCfgsB, ref dwBytesReturned);
                if (ItsNetDevSdk.TRUE != ulRet)
                {
                    string strError = string.Format("Set OSD info config fail");
                    MessageBox.Show(strError);
                    return;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                Marshal.FreeHGlobal(pInfoOsdCfgsB);
            }

            //get OSD cfg
            try
            {
                dwBytesReturned = 0;

                ulRet = NetDevSdk.NETDEV_GetDevConfig(m_lpDevHandle, 1, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_OSD_CONTENT_STYLE_CFG, ref stuStyleCfgs, Marshal.SizeOf(stuStyleCfgs), ref dwBytesReturned);
                if (ItsNetDevSdk.TRUE != ulRet)
                {
                    string strError = string.Format("Get OSD style config fail.");
                    MessageBox.Show(strError);
                    return;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            if (EffectcomboBox.SelectedIndex >= (int)NETDEV_OSD_FONT_STYLE_E.NETDEV_OSD_FONT_STYLE_BACKGROUND && EffectcomboBox.SelectedIndex <= (int)NETDEV_OSD_FONT_STYLE_E.NETDEV_OSD_FONT_STYLE_NORMAL)
            {
                stuStyleCfgs.udwFontStyle = (uint)EffectcomboBox.SelectedIndex;
            }

            if (FontSizecomboBox.SelectedIndex >= (int)NETDEV_OSD_FONT_SIZE_E.NETDEV_OSD_FONT_SIZE_LARGE && FontSizecomboBox.SelectedIndex <= (int)NETDEV_OSD_FONT_SIZE_E.NETDEV_OSD_FONT_SIZE_SMALL)
            {
                stuStyleCfgs.udwFontSize = (uint)FontSizecomboBox.SelectedIndex;
            }

            if (FontColorcomboBox.SelectedIndex >= (int)NETDEV_OSD_MIN_MARGIN_E.NETDEV_OSD_MIN_MARGIN_NONE && FontColorcomboBox.SelectedIndex <= (int)NETDEV_OSD_MIN_MARGIN_E.NETDEV_OSD_MIN_MARGIN_DOUBLE)
            {
                stuStyleCfgs.udwColor = (uint)sOsdcolor[FontColorcomboBox.SelectedIndex];
            }


            if (MinMargincomboBox.SelectedIndex >= (int)NETDEV_OSD_MIN_MARGIN_E.NETDEV_OSD_MIN_MARGIN_NONE && MinMargincomboBox.SelectedIndex <= (int)NETDEV_OSD_MIN_MARGIN_E.NETDEV_OSD_MIN_MARGIN_DOUBLE)
            {
                stuStyleCfgs.udwMargin = (uint)MinMargincomboBox.SelectedIndex;
            }

            //set OSD cfg
            try
            {
                int ulStyleCfgsSize = Marshal.SizeOf(stuStyleCfgs);

                ulRet = NetDevSdk.NETDEV_SetDevConfig(m_lpDevHandle, 1, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_SET_OSD_CONTENT_STYLE_CFG, ref stuStyleCfgs, ulStyleCfgsSize);
                if (ItsNetDevSdk.TRUE != ulRet)
                {
                    string strError = string.Format("Set OSD style config fail.");
                    MessageBox.Show(strError);
                    return;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            return;
        }

        private void ParkLedtextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        /***********************************System Maintenance*****************************/

        /*<Refresh version info>*/
        private void VedrsionInfoRefresh_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_lpDevHandle)
            {
                return;
            }

            NETDEV_DEVICE_BASICINFO_S stDeviceInfo = new NETDEV_DEVICE_BASICINFO_S();

            Int32 dwBytesReturned = 0;
            Int32 lChannelID = 1;
            int bRet = NetDevSdk.NETDEV_GetDevConfig(m_lpDevHandle, lChannelID, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_DEVICECFG, ref stDeviceInfo, Marshal.SizeOf(stDeviceInfo), ref dwBytesReturned);
            if (ItsNetDevSdk.TRUE != bRet)
            {
                MessageBox.Show("Get device info failed.", "waring");
            }
            else
            {
                string DevName = stDeviceInfo.szDeviceName;
                string SerialNum = stDeviceInfo.szSerialNum;
                string FirmwareVersion = stDeviceInfo.szFirmwareVersion;
                string DevModel = stDeviceInfo.szSerialNum;
                string MacAddress = stDeviceInfo.szMacAddress;


                HardwaretextBox.Text = DevModel;
                DeviceNametextBox.Text = DevName;
                SerialNotextBox.Text = SerialNum;
                FirmwaretextBox.Text = FirmwareVersion;
                MacAdresstextBox.Text = MacAddress;
            }
        }

        /*<get device net cfg info>*/
        private void GetNetInfo_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_lpDevHandle)
            {
                return;
            }

            NETDEV_NETWORKCFG_S stNetworkcfg = new NETDEV_NETWORKCFG_S();

            Int32 dwBytesReturned = 0;
            Int32 lChannelID = 0;
            int iRet = NetDevSdk.NETDEV_GetDevConfig(m_lpDevHandle, lChannelID, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_NETWORKCFG, ref stNetworkcfg, Marshal.SizeOf(stNetworkcfg), ref dwBytesReturned);
            if (ItsNetDevSdk.TRUE != iRet)
            {
                MessageBox.Show("Get network cfg fail");
                return;
            }
            else
            {
                string IPAddress = stNetworkcfg.Ipv4AddressStr;
                string SubnetMask = stNetworkcfg.szIPv4SubnetMask;
                string DHCP = Convert.ToString(stNetworkcfg.dwIPv4DHCP);
                string MTU = Convert.ToString(stNetworkcfg.dwMTU);

                IPAddressBox.Text = IPAddress;
                SubnetMasktextBox.Text = SubnetMask;
                DHCPtextBox.Text = DHCP;
                MTUtextBox.Text = MTU;
            }

            return;
        }

        /*<set device net cfg info>*/
        private void SetNetInfo_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_lpDevHandle)
            {
                return;
            }

            NETDEV_NETWORKCFG_S stNetworkcfg = new NETDEV_NETWORKCFG_S();

            Int32 dwBytesReturned = 0;
            Int32 lChannelID = 0;
            int iRet = NetDevSdk.NETDEV_GetDevConfig(m_lpDevHandle, lChannelID, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_NETWORKCFG, ref stNetworkcfg, Marshal.SizeOf(stNetworkcfg), ref dwBytesReturned);
            if (ItsNetDevSdk.TRUE != iRet)
            {
                MessageBox.Show("Set network cfg fail", "waring");
                return;
            }

            stNetworkcfg.Ipv4AddressStr = IPAddressBox.Text;
            stNetworkcfg.szIPv4SubnetMask = SubnetMasktextBox.Text;
            stNetworkcfg.dwIPv4DHCP = Convert.ToInt32(DHCPtextBox.Text);
            stNetworkcfg.dwMTU = Convert.ToInt32(MTUtextBox.Text);



            iRet = NetDevSdk.NETDEV_SetDevConfig(m_lpDevHandle, lChannelID, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_SET_NETWORKCFG, ref stNetworkcfg, Marshal.SizeOf(stNetworkcfg));
            if (ItsNetDevSdk.TRUE != iRet)
            {
                MessageBox.Show("Set network cfg fail", "waring");
                return;
            }
            else
            {
                MessageBox.Show("Set network cfg succeed");
            }
        }

        private void Browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "Please select file of version";
            dialog.Filter = "zip files(*.zip)|*.zip||";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return;
            }
        }

        private void Upgrade_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_lpDevHandle)
            {
                return;
            }


        }

        private void Reboot_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == m_lpDevHandle)
            {
                return;
            }

            int iRet = NetDevSdk.NETDEV_Reboot(m_lpDevHandle);
            if (ItsNetDevSdk.TRUE != iRet)
            {
                MessageBox.Show("reboot fail", "waring");
            }
            else
            {
                MessageBox.Show("reboot succeed");
            }

            return;
        }

        private void SetEncodingFormat_Click(object sender, EventArgs e)
        {
            Int32 iType = 0;
            if (0 == PlateencodingCombox.SelectedIndex)
            {
                iType = 1;
            }
            else if (1 == PlateencodingCombox.SelectedIndex)
            {
                iType = 0;
            }
            Int32 iRet = NetDevSdk.NETDEV_EnableCarplate(iType);
            if (ItsNetDevSdk.TRUE != iRet)
            {
                MessageBox.Show("Set Enable Carplate fail", "waring");
            }
            else
            {
                MessageBox.Show("Set Enable Carplate succeed");
            }

        }

        private void PicturePreview_Enter(object sender, EventArgs e)
        {

        }


        /*******************************Multiuser-login*******************************/

        /* Status report callback. used to get the status of connection between the SDK and the device */

        public void ParkMultiStatusReportCallback(IntPtr lpUserID, UInt32 ulReportType, IntPtr pParam, IntPtr lpUserData)
        {
            string strCameraIP = "";

            if (ulReportType == (uint)NETDEV_ITS_STATUS_REPORT_E.NETDEV_ITS_DEV_OFFLINE_E || ulReportType == (uint)NETDEV_ITS_STATUS_REPORT_E.NETDEV_ITS_DEV_RONLINE_E)
            {
                string strStatus = "";

                stuUserInfo oStuDevInfo;
                for (int i = 0; i < m_VecDevInfo.Count; i++)
                {
                    oStuDevInfo = (stuUserInfo)m_VecDevInfo.GetByIndex(i);

                    if (ulReportType == (uint)NETDEV_ITS_STATUS_REPORT_E.NETDEV_ITS_DEV_OFFLINE_E)
                    {
                        oStuDevInfo.bLogin = false;
                        strStatus = "Offline";
                    }
                    else
                    {
                        oStuDevInfo.bLogin = true;
                        strStatus = "Online";
                    }


                    if (oStuDevInfo.lpDevHandle == lpUserID)
                    {
                        strCameraIP = oStuDevInfo.strDevIP;
                        string strText = "";
                        for (int j = 0; j < UserInfolistView.Items.Count; j++)
                        {
                            strText = this.UserInfolistView.Items[j].SubItems[0].Text;
                            if (strCameraIP == strText)
                            {
                                this.UserInfolistView.Items[j].SubItems[2].Text = strStatus;
                                break;
                            }
                        }

                        m_VecDevInfo.SetByIndex(i, oStuDevInfo);
                        break;
                    }
                }
            }
            else if (ulReportType == (uint)NETDEV_ITS_STATUS_REPORT_E.NETDEV_ITS_MEDIA_OFFLINE_E || ulReportType == (uint)NETDEV_ITS_STATUS_REPORT_E.NETDEV_ITS_MEDIA_RONLINE_E)
            {

            }

            return;
        }

        /* Multiuser Photo data callback function */
        public void ParkMultiPicDataCallback(ref NETDEV_PIC_DATA_S pstPicData, IntPtr lpUserData)
        {
            string carPlate = GetDefaultString(pstPicData.szCarPlate);
            string time = GetDefaultString(pstPicData.szPassTime);
            string TollgateID = GetDefaultString(pstPicData.szTollgateID);
            string strCameraIP = "";
            string strText = "";
            int picCount = 0;
            stuUserInfo oStuDevInfo;

            for (int i = 0; i < m_VecDevInfo.Count; i++)
            {
                oStuDevInfo = (stuUserInfo)m_VecDevInfo.GetByIndex(i);
                if (oStuDevInfo.lpUserData == lpUserData)
                {
                    strCameraIP = oStuDevInfo.strDevIP;
                    picCount = oStuDevInfo.ulPicCount++;
                    picCount = picCount + 1;

                    for (int j = 0; j < UserInfolistView.Items.Count; j++)
                    {
                        strText = this.UserInfolistView.Items[j].SubItems[0].Text;
                        if (strCameraIP == strText)
                        {
                            this.UserInfolistView.Items[j].SubItems[3].Text = picCount.ToString();
                            break;
                        }
                    }

                    m_VecDevInfo.SetByIndex(i, oStuDevInfo);
                    break;
                }
            }

            //获取当前文件夹路径
            string currPath = Application.StartupPath;
            //检查是否存在文件夹
            string subPath = currPath + "/pic/";
            if (false == System.IO.Directory.Exists(subPath))
            {
                //创建pic文件夹
                System.IO.Directory.CreateDirectory(subPath);
            }

            /* save pic */
            for (int i = 0; i < pstPicData.ulPicNumber; i++)
            {
                String strFileName = subPath + time + "_" + carPlate + "_" + i.ToString() + ".jpg";

                int size = (int)pstPicData.aulDataLen[i];
                byte[] buffer = new byte[size];
                Marshal.Copy(pstPicData.apcData[i], buffer, 0, size);

                FileStream fs = new FileStream(strFileName, FileMode.Create);
                fs.Write(buffer, 0, buffer.Length);
                fs.Close();
            }

            return;
        }


        private void addUserInfolistItem(stuUserInfo pstUerInfo)
        {

            int gUserNo = UserInfolistView.Items.Count;
            ListViewItem item = new ListViewItem(pstUerInfo.strDevIP);
            item.SubItems.Add(pstUerInfo.strDevAdmin);
            item.SubItems.Add("Offline");
            item.SubItems.Add("0");

            UserInfolistView.Items.Insert(gUserNo, item);
            item.EnsureVisible();

            return;
        }

        private void DeleteUserInfolistItem(string strIP)
        {
            string strText = "";
            for (int j = 0; j < UserInfolistView.Items.Count; j++)
            {
                strText = this.UserInfolistView.Items[j].SubItems[0].Text;
                if (strIP == strText)
                {
                    this.UserInfolistView.Items.Remove(this.UserInfolistView.Items[j]);
                    break;
                }
            }

            return;
        }

        private void MultiLoginbutton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < m_VecDevInfo.Count; i++)
            {
                stuUserInfo pstUerInfo = new stuUserInfo();
                pstUerInfo = (stuUserInfo)m_VecDevInfo.GetByIndex(i);
                NETDEV_DEVICE_INFO_S pstDevInfo = new NETDEV_DEVICE_INFO_S();
                pstUerInfo.lpDevHandle = NetDevSdk.NETDEV_Login(pstUerInfo.strDevIP, (Int16)pstUerInfo.iPort, pstUerInfo.strDevAdmin, pstUerInfo.strDevPassWord, ref pstDevInfo);
                if (pstUerInfo.lpDevHandle == IntPtr.Zero)
                {
                    continue;
                }
                else
                {
                    pstUerInfo.bLogin = true;
                    for (int j = 0; j < UserInfolistView.Items.Count; j++)
                    {
                        string strText = this.UserInfolistView.Items[j].SubItems[0].Text;
                        if (pstUerInfo.strDevIP == strText)
                        {
                            this.UserInfolistView.Items[j].SubItems[2].Text = "Online";
                        }
                        else
                        {
                            continue;
                        }
                    }

                    /* Delete the value from the table, get the handle, 
                    and add the value to the table again at the end of the function */
                    m_VecDevInfo.Remove(pstUerInfo.strDevIP);

                    NetDevSdk.NETDEV_SetParkStatusCallBack(pstUerInfo.lpDevHandle, ItsMultiParkStatusReportCB, IntPtr.Zero);

                    /* start picstream */
                    pstUerInfo.lpPicHandle = (IntPtr)NetDevSdk.NETDEV_StartPicStream(pstUerInfo.lpDevHandle, IntPtr.Zero, false, "", ItsMultiPicCB, pstUerInfo.lpDevHandle);
                    if (IntPtr.Zero == pstUerInfo.lpPicHandle)
                    {
                        NetDevSdk.NETDEV_Logout(pstUerInfo.lpDevHandle);
                    }

                    pstUerInfo.bLogin = true;
                    pstUerInfo.bStartStream = true;
                    pstUerInfo.lpUserData = pstUerInfo.lpDevHandle;

                    /* sava user information */
                    m_VecDevInfo.Add(pstUerInfo.strDevIP, pstUerInfo);
                }
            }
        }

        private void MultiLogoutbutton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < m_VecDevInfo.Count; i++)
            {
                stuUserInfo pstUerInfo = new stuUserInfo();
                pstUerInfo = (stuUserInfo)m_VecDevInfo.GetByIndex(i);

                /* stop-picstream */
                if (IntPtr.Zero != pstUerInfo.lpPicHandle)
                {
                    int bRet = NetDevSdk.NETDEV_StopPicStream(pstUerInfo.lpPicHandle);

                    if (ItsNetDevSdk.TRUE == bRet)
                    {
                        pstUerInfo.lpPicHandle = IntPtr.Zero;
                        pstUerInfo.bStartStream = false;

                    }
                    else
                    {
                        MessageBox.Show("stop picStream fail.", "warning");
                    }
                }
                if (IntPtr.Zero == pstUerInfo.lpPicHandle && IntPtr.Zero != pstUerInfo.lpDevHandle)
                {
                    /* logout */
                    int bRet = NetDevSdk.NETDEV_Logout(pstUerInfo.lpDevHandle);
                    if (ItsNetDevSdk.TRUE != bRet)
                    {
                        MessageBox.Show("Logout failed.", "warning");
                    }
                    else
                    {
                        for (int j = 0; j < UserInfolistView.Items.Count; j++)
                        {
                            string strText = this.UserInfolistView.Items[j].SubItems[0].Text;
                            if (pstUerInfo.strDevIP == strText)
                            {
                                this.UserInfolistView.Items[j].SubItems[2].Text = "Offline";
                                continue;
                            }
                        }
                        pstUerInfo.lpDevHandle = IntPtr.Zero;
                        pstUerInfo.bLogin = false;
                    }
                }
            }
            return;
        }

        private void UserInfolistView_SelectedIndexChanged(object sender, EventArgs e)
        {

            ListView.SelectedIndexCollection indexes = this.UserInfolistView.SelectedIndices;
            if (indexes.Count > 0)
            {
                int index = indexes[0];
                string strIP = this.UserInfolistView.Items[index].SubItems[0].Text;

                stuUserInfo pstUerInfo = (stuUserInfo)m_VecDevInfo.GetByIndex(m_VecDevInfo.IndexOfKey(strIP));

                MultiIPtextBox.Text = strIP;
                MultiPorttextBox.Text = Convert.ToString(pstUerInfo.iPort);
                MultiUsernametextBox.Text = pstUerInfo.strDevAdmin;
                MultiPasswordtextBox.Text = pstUerInfo.strDevPassWord;

            }

            return;

        }

        private void addDevice_Click(object sender, EventArgs e)
        {
            /* login */
            String strIP = MultiIPtextBox.Text;
            int iPort = Convert.ToInt32(MultiPorttextBox.Text);
            String strUser = MultiUsernametextBox.Text;
            String strPasswd = MultiPasswordtextBox.Text;

            /* find-device */
            if (m_VecDevInfo.ContainsKey(strIP))
            {
                MessageBox.Show("Device already exist.", "warning");
                return;
            }

            stuUserInfo pstUerInfo = new stuUserInfo();
            pstUerInfo.strDevIP = strIP;
            pstUerInfo.strDevAdmin = strUser;
            pstUerInfo.strDevPassWord = strPasswd;
            pstUerInfo.iPort = iPort;
            pstUerInfo.ulPicCount = 0;

            addUserInfolistItem(pstUerInfo);

            m_VecDevInfo.Add(pstUerInfo.strDevIP, pstUerInfo);
        }

        private void deleteDevice_Click(object sender, EventArgs e)
        {
            String strIP = MultiIPtextBox.Text;
            int iPort = Convert.ToInt32(MultiPorttextBox.Text);
            String strUser = MultiUsernametextBox.Text;
            String strPasswd = MultiPasswordtextBox.Text;

            /* find-device */
            if (!m_VecDevInfo.ContainsKey(strIP))
            {
                MessageBox.Show("not find Device.", "warning");
                return;
            }

            int index = m_VecDevInfo.IndexOfKey(strIP);
            stuUserInfo pstUerInfo = (stuUserInfo)m_VecDevInfo.GetByIndex(index);

            /* stop-picstream */
            if (IntPtr.Zero != pstUerInfo.lpPicHandle)
            {
                int bRet = NetDevSdk.NETDEV_StopPicStream(pstUerInfo.lpPicHandle);

                if (ItsNetDevSdk.TRUE == bRet)
                {
                    pstUerInfo.lpPicHandle = IntPtr.Zero;
                    pstUerInfo.bStartStream = false;

                }
                else
                {
                    MessageBox.Show("picStream already stop.", "warning");
                }
            }

            if (IntPtr.Zero == pstUerInfo.lpPicHandle && IntPtr.Zero != pstUerInfo.lpDevHandle)
            {
                /* logout */
                int bRet = NetDevSdk.NETDEV_Logout(pstUerInfo.lpDevHandle);
                if (ItsNetDevSdk.TRUE != bRet)
                {
                    MessageBox.Show("Logout failed.", "warning");
                }
                else
                {
                    pstUerInfo.lpDevHandle = IntPtr.Zero;
                    pstUerInfo.bLogin = false;
                    DeleteUserInfolistItem(pstUerInfo.strDevIP);
                    m_VecDevInfo.Remove(pstUerInfo.strDevIP);
                    return;
                }
            }
            DeleteUserInfolistItem(pstUerInfo.strDevIP);
            m_VecDevInfo.Remove(pstUerInfo.strDevIP);
            return;
        }
    }
}
