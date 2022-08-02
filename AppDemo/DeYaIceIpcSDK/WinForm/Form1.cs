using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Net;
using System.Text.RegularExpressions;
using System.Data.DeYaIceIpcSDK;

namespace TestDll
{
    public partial class Form1 : Form
    {
        static IIceIpcSdkProxy ipcsdk = IceIpcSdk.Create();
        public Form1()
        {
            InitializeComponent();
        }

        public delegate void UpdatePlateInfo(string strIP, string strNum, string strColor, uint nVehicleColor,
            uint nAlarmType, short nVehiclType, uint nCapTime, int index, string strLogName, ICE_RECT_S stVlprInfo);
        public UpdatePlateInfo updatePlateInfo;
        public delegate void UpdateStatus(int index, int type);
        public UpdateStatus updateStatus;
        public delegate void UpdateTriggerStatus(int index, uint nStatus);
        public UpdateTriggerStatus triggerStatus;
        public delegate void UpdatePortInfo(string strIp, uint len, int index, string data, int type);
        public UpdatePortInfo updatePortInfo;
        public delegate void UpdateDeviceEvent(string strIP, uint nType, uint ndata1, uint ndata2, uint ndata3, uint ndata4, int nFlag, int road);
        public UpdateDeviceEvent updateDeviceEvent;

        //private static uint[] UID = new uint[4] { 0, 0, 0, 0 };
        private int[] count = new int[4] { 0, 0, 0, 0 };
        private bool[] bTalk = new bool[4] { false, false, false, false };
        private UInt32[] nCurrentStatus = new UInt32[4] { 0, 0, 0, 0 };
        private UInt32[] nStatus = new UInt32[4] { 0, 0, 0, 0 };
        private StringBuilder[] strMac = new StringBuilder[4];
        private UInt32[] nGateNum = new UInt32[4] { 0, 0, 0, 0 };
        private UInt32[] nTriggerNum = new UInt32[4] { 0, 0, 0, 0 };
        private UInt32[] nGate2Num = new UInt32[4] { 0, 0, 0, 0 };
        private uint[] nRS232Num = new uint[4] { 0, 0, 0, 0 };
        private uint[] nRS485Num = new uint[4] { 0, 0, 0, 0 };
        private bool[] bRecord = new bool[4] { false, false, false, false };
        private bool[] bPreview = new bool[4] { true, true, true, true };
        private bool[] bClose = new bool[4] { false, false, false, false };
        private IntPtr[] pUid = new IntPtr[4] {IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero};
        private string[] strIp = new string[4];
        private uint[] nRecvPortCount_RS232 = new uint[4] { 0, 0, 0, 0 };
        private uint[] nRecvPortCount_RS485 = new uint[4] { 0, 0, 0, 0 };
        private uint nDeviceEventCount = 0;

        private TextBox[] textBoxIP = new TextBox[4];
        private Label[] labelStatus = new Label[4];
        private Label[] labelPlate = new Label[4];
        private TextBox[] textBoxGateNum = new TextBox[4];
        private TextBox[] textBoxTriggerNum = new TextBox[4];

        private long totalCount = 0;
        private long pastCount = 0;

        private int MAX_OSD_TEXT = 64;
        public ICE_OSDAttr_S osdInfo = new ICE_OSDAttr_S();
        public ICE_VBR_RESULT_S vbrResult = new ICE_VBR_RESULT_S();
        public ICE_VDC_PICTRUE_INFO_S vdcInfo = new ICE_VDC_PICTRUE_INFO_S();
        public ICE_VLPR_OUTPUT_S vlprInfo = new ICE_VLPR_OUTPUT_S();

        Mutex mutex = new Mutex();
        Mutex mutexThread = new Mutex();
        public static Thread[] mythread = new Thread[4]{null, null, null, null};
        public static Thread threadTrigger = null;
        public static Thread threadOpenGate = null;
        public static Thread threadStatus = null;
        public static Thread threadOpenGate2 = null;
        public static Thread threadRS485 = null;
        public static Thread threadRS232 = null;
        public static Thread[] threadBroadcast = new Thread[4] { null, null, null, null };

        private string[] strVehicleColor_old = new string[] { "未知", "红色", "绿色", "蓝色", "黄色", "白色", "灰色", "黑色", "紫色", "棕色", "粉色" };
        private string[] strVehicleColor = new string[] { 
            "未知", 
	        "黑色",
	        "蓝色",
	        "灰色",	
	        "棕色",
	        "绿色",
	        "夜间深色",
	        "紫色",
	        "红色",
	        "白色",
	        "黄色" };
        private string[] strAlarmType = new string[]{
            "实时_硬触发+临时车辆",
	        "实时_视频触发+临时车辆",
	        "实时_软触发+临时车辆",
	        "实时_硬触发+白名单",
	        "实时_视频触发+白名单",
	        "实时_软触发+白名单",
	        "实时_硬触发+黑名单",
	        "实时_视频触发+黑名单",
	        "实时_软触发+黑名单",
	        "脱机_硬触发+临时车辆",
	        "脱机_视频触发+临时车辆",
	        "脱机_软触发+临时车辆",
	        "脱机_硬触发+白名单",
	        "脱机_视频触发+白名单",
	        "脱机_软触发+白名单",
	        "脱机_硬触发+黑名单",
	        "脱机_视频触发+黑名单",
	        "脱机_软触发+黑名单",
            "实时_硬触发+过期白名单",
	        "实时_视频触发+过期白名单",
	        "实时_软触发+过期白名单",
	        "脱机_硬触发+过期白名单",
	        "脱机_视频触发+过期白名单",
	        "脱机_软触发+过期白名单"
        };
        private string[] strVehicleType = new string[]
        {
	        "未知",
            "轿车",
            "面包车",
            "大型客车",
            "中型客车",
            "皮卡",
            "非机动车",
            "SUV",
            "MPV",
            "微型货车",
            "轻型货车",
            "中型货车",
            "重型货车"
        };
        //设置变量
        private string m_strStorePath = "D:\\";
        private int m_bOpenGate = 0;
        private int m_bTrigger = 0;
        private int m_bOpenGate2 = 0;
        private int m_bRS485 = 0;
        private int m_bRS232 = 0;

        private int m_nOpenInterval = 0;
        private int m_nTriggerInterval = 0;
        private int m_nOpenInterval2 = 0;
        private int m_nRS485Interval = 0;
        private int m_nRS232Interval = 0;
        private int m_nRecordInterval = 10;

        private string m_nVideoColor = "000000";
        private string m_nJpegColor = "000000";
        private string m_strLogPath = "D:\\";
        private int m_bEnableLog = 0;

        //将收到的实时识别数据和断网识别数据显示在界面上
        public void showCount(string strIP, string strNum, string strColor, uint nVehicleColor,
            uint nAlarmType, short nVehiclType, uint nCapTime, int index, string strLogName, ICE_RECT_S stRect)
        {
            if (listBoxInfo.Items.Count > 1024)
            {
                listBoxInfo.Items.Clear();
            }
            if (pUid[index] != IntPtr.Zero)
            {
                if (nCapTime == 0)//实时数据
                {
                    count[index]++;
                    string strText = count[index].ToString() + ". " + strNum + " " + strColor;
                    labelPlate[index].Text = strText;

                    totalCount++;
                    string textInfo = totalCount.ToString() + ". " + strIP + " " + strNum + " " + strColor + " " ;
                    if (strLogName.Length == 0)
                        textInfo += strVehicleColor_old[nVehicleColor];
                    else
                        textInfo += strVehicleColor[nVehicleColor + 1];

                    string textInfo2 = "    " + strAlarmType[nAlarmType] + " " + strVehicleType[nVehiclType] + " "+ strLogName;

    
                    string textInfo3 = "    " + "车牌坐标：( leftX)" + stRect.s16Left.ToString() + ",（topY）" + stRect.s16Top.ToString()
                        + ",(rightX)" + stRect.s16Right.ToString() + ",(bottomY)" + stRect.s16Bottom.ToString();
                    if (textInfo == null || textInfo2 == null || textInfo3 == null)
                        return;
                    listBoxInfo.Items.Insert(0, textInfo3);//将车牌坐标在界面上（右边的显示框）
                    listBoxInfo.Items.Insert(0, textInfo2);//将实时数据显示在界面上（右边的显示框）
                    listBoxInfo.Items.Insert(0, textInfo);//将实时数据显示在界面上（右边的显示框）
                }
                else//断网数据
                {
                    pastCount++;
                    string pastText = pastCount.ToString() + ". 断网续传" + strIP + strNum + " " + strColor + " " + strVehicleColor[nVehicleColor + 1];
                    string pastText2 = "    " + strAlarmType[nAlarmType];
                    if (pastText == null || pastText2 == null)
                        return;
                    listBoxInfo.Items.Insert(0, pastText2);//将断网数据显示在界面上（右边的显示框）
                    listBoxInfo.Items.Insert(0, pastText);//将断网数据显示在界面上（右边的显示框）
                }
            }
        }

        //存图
        public void storePic(byte[] picData, string strIP, string strNumber, bool bIsPlate, UInt32 nCapTime, float[] fResFuture, string strLogName)
        {
            DateTime dt = new DateTime();
            if (nCapTime == 0)
            {
                dt = DateTime.Now;
            }
            else
            {
                dt = DateTime.Parse("1970-01-01 08:00:00").AddSeconds(nCapTime);
            }

            string strDir = m_strStorePath + @"抓拍_C#\" + strIP + @"\" + dt.ToString("yyyyMMdd");
            if (!Directory.Exists(strDir))
            {
                Directory.CreateDirectory(strDir);
            }

            string strPicName;
            if (strLogName.Length != 0)
                strPicName = strDir + @"\" + dt.ToString("yyyyMMddHHmmss") +"_" + strLogName + "_" + strNumber;
            else
                strPicName = strDir + @"\" + dt.ToString("yyyyMMddHHmmss") + "_" + strNumber;
            if (bIsPlate)//车牌图，图片名后缀加_plate
                strPicName += "_plate";
            //string tmp = strPicName;
            strPicName += ".jpg";
            if (File.Exists(strPicName))//如果图片名存在，则在文件名末尾加数字以分辨，如XXX_1.jpg;XXX_2.jpg
            {
                int count = 1;
                while (count <= 10)
                {
                    strPicName = strDir + @"\" + dt.ToString("yyyyMMddHHmmss") + "_" + strNumber;
                    if (bIsPlate)
                    {
                        strPicName += "_plate";
                    }
                    strPicName += "_" + count.ToString() + ".jpg";

                    if (!File.Exists(strPicName))
                    {
                        break;
                    }
                    count++;
                }
            }
            //存图
            try
            {
                FileStream fs = new FileStream(strPicName, FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(picData);
                bw.Close();
                fs.Close();
            }
            catch (System.Exception ex)
            {

            }

            //保存特征码
            if (bIsPlate || null == fResFuture)
                return;

            string strFileName = strDir + @"\" + "vbr_record.txt";

            string strContent = "";
            //将车辆特征码存到字符串中
            for (int i = 0; i < 20; i++)
            {
                if (i != 0)
                    strContent += " ";
                strContent += fResFuture[i].ToString("0.000000");
            }
            //将车辆特征码数据追加到文件中
            try
            {
                StreamWriter sw = new StreamWriter(strFileName, true, Encoding.Unicode);
                if (null != sw)
                {
                    strContent = dt.ToString("yyyyMMddHHmmss") + "_" + strLogName +"_" + strNumber + ".jpg" + " " + strNumber + " " + strContent + "\r\n";
                    sw.Write(strContent);
                    sw.Close();
                }
            }
            catch (System.Exception ex)
            {
            	
            }
            
        }

        private bool m_bExit = false;

        public void on_plate(string bstrIP, string bstrNumber, string bstrColor, IntPtr vPicData, UInt32 nPicLen,
          IntPtr vCloseUpPicData, UInt32 nCloseUpPicLen, short nSpeed, short nVehicleType, short nReserved1, short nReserved2, Single fPlateConfidence,
          UInt32 nVehicleColor, UInt32 nPlateType, UInt32 nVehicleDir, UInt32 nAlarmType, UInt32 nCapTime, Int32 index, uint u32ResultHigh, uint u32ResultLow)
        {
            if (m_bExit)
                return;
#if VERSION32
            IntPtr vdcPtr = (IntPtr)u32ResultLow;
#else
            ulong tmp = ((ulong)u32ResultHigh << 32) + (ulong)u32ResultLow;
            IntPtr vdcPtr = (IntPtr)tmp;
#endif
            if (vdcPtr != IntPtr.Zero)
            {
                //将数据拷贝到ICE_VDC_PICTRUE_INFO_S结构体
                vdcInfo = (ICE_VDC_PICTRUE_INFO_S)Marshal.PtrToStructure(vdcPtr, typeof(ICE_VDC_PICTRUE_INFO_S));

                //获得车款结构体指针，并拷贝
                if (vdcInfo.pstVbrResult != IntPtr.Zero)
                {
                    vbrResult = (ICE_VBR_RESULT_S)Marshal.PtrToStructure(vdcInfo.pstVbrResult, typeof(ICE_VBR_RESULT_S));
                    if (vbrResult.szLogName.Length == 0)
                        vbrResult.szLogName = "未知";
                    //委托，用于显示识别数据(showCount),vdcInfo.stPlateInfo表示车牌信息
                    this.BeginInvoke(updatePlateInfo, bstrIP, bstrNumber, bstrColor,
                        nVehicleColor, nAlarmType, nVehicleType, nCapTime, index, vbrResult.szLogName, vdcInfo.stPlateInfo.stPlateRect);
                }
                else
                    this.BeginInvoke(updatePlateInfo, bstrIP, bstrNumber, bstrColor,
                        nVehicleColor, nAlarmType, nVehicleType, nCapTime, index, "", vdcInfo.stPlateInfo.stPlateRect);//委托，用于显示识别数据(showCount),vdcInfo.stPlateInfo表示车牌信息
            }
            else
                this.BeginInvoke(updatePlateInfo, bstrIP, bstrNumber, bstrColor,
                    nVehicleColor, nAlarmType, nVehicleType, nCapTime, index, "", null);//委托，用于显示识别数据(showCount)

            if (nPicLen > 0)//全景图数据长度不为0
            {
                IntPtr ptr2 = (IntPtr)vPicData;
                byte[] datajpg2 = new byte[nPicLen];
                Marshal.Copy(ptr2, datajpg2, 0, datajpg2.Length);//拷贝图片数据
                //存图
                if (vdcInfo.pstVbrResult != IntPtr.Zero)
                    storePic(datajpg2, bstrIP, bstrNumber, false, nCapTime, vbrResult.fResFeature, vbrResult.szLogName);
                else
                    storePic(datajpg2, bstrIP, bstrNumber, false, nCapTime, null, "");
            }


            if (nCloseUpPicLen > 0)//车牌图数据长度不为0
            {
                IntPtr ptr = (IntPtr)vCloseUpPicData;
                byte[] datajpg = new byte[nCloseUpPicLen];
                Marshal.Copy(ptr, datajpg, 0, datajpg.Length);//拷贝图片数据
                //存图
                if (vdcInfo.pstVbrResult != IntPtr.Zero)
                    storePic(datajpg, bstrIP, bstrNumber, true, nCapTime, null, vbrResult.szLogName);
                else
                    storePic(datajpg, bstrIP, bstrNumber, true, nCapTime, null, "");
            }         
        }

        //实时抓拍
        public void SDK_OnPlate(System.IntPtr pvParam,
                    [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcIP,
                    [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcNumber,
                    [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcColor,
                    System.IntPtr pcPicData,uint u32PicLen,System.IntPtr pcCloseUpPicData,uint u32CloseUpPicLen,
                    short nSpeed, short nVehicleType, short nReserved1, short nReserved2,
                    float fPlateConfidence,uint u32VehicleColor,uint u32PlateType,uint u32VehicleDir,uint u32AlarmType,
                    uint u32SerialNum, uint uCapTime, uint u32ResultHigh, uint u32ResultLow)
        {
            int index = (int)pvParam;
            if (m_bExit || bClose[index])
                return;
            on_plate(pcIP, pcNumber, pcColor, pcPicData, u32PicLen, pcCloseUpPicData, u32CloseUpPicLen,
                nSpeed, nVehicleType, nReserved1, nReserved2, fPlateConfidence,
                u32VehicleColor, u32PlateType, u32VehicleDir, u32AlarmType, 0, index, u32ResultHigh, u32ResultLow);
        }

        //断网续传
        public void SDK_OnPastPlate(System.IntPtr pvParam,
            [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcIP,
            uint u32CapTime,
            [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcNumber,
            [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcColor,
            System.IntPtr pcPicData,uint u32PicLen,System.IntPtr pcCloseUpPicData,uint u32CloseUpPicLen,short s16PlatePosLeft,
            short s16PlatePosTop,short s16PlatePosRight,short s16PlatePosBottom,float fPlateConfidence,uint u32VehicleColor,
            uint u32PlateType,uint u32VehicleDir,uint u32AlarmType,uint u32Reserved1,uint u32Reserved2,uint u32Reserved3,
            uint u32Reserved4)
        {
            int index = (int)pvParam;
            if (m_bExit || bClose[index])
                return;
            on_plate(pcIP, pcNumber, pcColor, pcPicData, u32PicLen, pcCloseUpPicData, u32CloseUpPicLen,
                s16PlatePosLeft, s16PlatePosTop, s16PlatePosRight, s16PlatePosBottom, fPlateConfidence,
                u32VehicleColor, u32PlateType, u32VehicleDir, u32AlarmType, u32CapTime, index, u32Reserved2, u32Reserved3);
        }

        private int[] frame_count = new int[4] { 0, 0, 0, 0 };
        
        public void on_frame(UInt32 u32Timestamp, 
            IntPtr pu8DataY, IntPtr pu8DataU, IntPtr pu8DataV,
            Int32 s32LinesizeY, Int32 s32LinesizeU, Int32 s32LinesizeV,
            Int32 s32Width, Int32 s32Height, Int32 i)
        {
            if (m_bExit)
                return;

            mutex.WaitOne();
            string strDir = m_strStorePath + @"抓拍_C#Frame\" + strIp[i] + @"\" + DateTime.Now.ToString("yyyyMMdd");
            if (!Directory.Exists(strDir))
            {
                Directory.CreateDirectory(strDir);
            }

            string strPicName = strDir + @"\" + "test.bmp";

            if (0 == (frame_count[i] % 30))
            {
                
                try
                {
                    //拷贝数据
                    byte[] datay = new byte[s32Width * s32Height];
                    for (int j = 0; j < s32Height; j++)
                        Marshal.Copy((IntPtr)pu8DataY + j * s32LinesizeY, datay, j * s32Width, s32Width);

                    byte[] datau = new byte[s32Width * s32Height / 4];
                    for (int j = 0; j < s32Height / 2; j++)
                        Marshal.Copy((IntPtr)pu8DataU + j * s32LinesizeU, datau, j * s32Width / 2, s32Width / 2);

                    byte[] datav = new byte[s32Width * s32Height / 4];
                    for (int j = 0; j < s32Height / 2; j++)
                        Marshal.Copy((IntPtr)pu8DataV + j * s32LinesizeV, datav, j * s32Width / 2, s32Width / 2);

                    byte[] rgb24 = new byte[s32Width * s32Height * 3];

                    util.Convert(s32Width, s32Height, datay, datau, datav, ref rgb24);
                    //存图
                    FileStream fs = new FileStream(strPicName, FileMode.Create, FileAccess.Write);
                    BinaryWriter bw = new BinaryWriter(fs);

                    bw.Write('B');
                    bw.Write('M');
                    bw.Write(rgb24.Length + 54);
                    bw.Write(0);
                    bw.Write(54);
                    bw.Write(40);
                    bw.Write(s32Width);
                    bw.Write(s32Height);
                    bw.Write((ushort)1);
                    bw.Write((ushort)24);
                    bw.Write(0);
                    bw.Write(rgb24.Length);
                    bw.Write(0);
                    bw.Write(0);
                    bw.Write(0);
                    bw.Write(0);

                    bw.Write(rgb24, 0, rgb24.Length);
                    bw.Close();
                    fs.Close();
                    
                }
                catch (System.Exception ex)
                {
                    //MessageBox.Show("frame" + ex.Message);
                }

                frame_count[i] = 0;
            }
            frame_count[i]++;
            mutex.ReleaseMutex();
        }

        public void SDK_OnFrame(System.IntPtr pvParam, uint u32Timestamp, System.IntPtr pu8DataY,
            System.IntPtr pu8DataU, System.IntPtr pu8DataV, int s32LinesizeY, int s32LinesizeU, 
            int s32LinesizeV, int s32Width, int s32Height)
        {
            int index = (int)pvParam;
            if (m_bExit || bClose[index])
                return;
            on_frame(u32Timestamp, pu8DataY, pu8DataU, pu8DataV, s32LinesizeY,
                s32LinesizeU, s32LinesizeV, s32Width, s32Height, index);
        }

        public void SDK_OnSerialPort(System.IntPtr pvParam,
            [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcIP,
            System.IntPtr pcData, uint u32Len)
        {
            if (m_bExit)
                return;

            int index = (int)pvParam;
            IntPtr tmp = pcData;
            byte[] dataPort2 = new byte[u32Len];
            Marshal.Copy(tmp, dataPort2, 0, dataPort2.Length);//拷贝串口数据
            string strPort = BitConverter.ToString(dataPort2);
            strPort = strPort.Replace("-", " ");
            //委托，用于在界面上显示收到的串口数据
            IAsyncResult syncResult = this.BeginInvoke(updatePortInfo, pcIP, u32Len, index, strPort, 0);
        }

        public void SDK_OnSerialPortRS232(System.IntPtr pvParam, 
            [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcIP,
            System.IntPtr pcData, uint u32Len)
        {
            if (m_bExit)
                return;
            int index = (int)pvParam;
            IntPtr tmp = pcData;
            byte[] dataPort2 = new byte[u32Len];
            Marshal.Copy(tmp, dataPort2, 0, dataPort2.Length);//拷贝串口数据
            string strPort = BitConverter.ToString(dataPort2);
            strPort = strPort.Replace("-", " ");
            //委托，用于在界面上显示收到的串口数据
            IAsyncResult syncResult = this.BeginInvoke(updatePortInfo, pcIP, u32Len, index, strPort, 1);       
        }

        public void showDeviceEvent(string strIP, uint nType, uint ndata1, uint ndata2, uint ndata3, uint ndata4, int nFlag, int road)
        {
            if (listBoxInfo.Items.Count > 1024)
            {
                listBoxInfo.Items.Clear();
            }
            string strText = "";
            if (0 == nFlag)
            {
                if (0 == nType)
                {
                    strText = "第" + (road+1).ToString() + "路 " + strIP + " IO状态改变： " +
                        ndata1.ToString() + ndata2.ToString() + ndata3.ToString() + ndata4.ToString();
                }
                listBoxInfo.Items.Insert(0, strText);
                return;
            }
            else 
            {
                if (0 == nType)
                    strText = strIP + ":当前状态离线";
                else if (1 == nType)
                    strText = strIP + ":当前状态在线";
                else if (2 == nType)
                {
                    nDeviceEventCount++;
                    strText = nDeviceEventCount.ToString() + " " + strIP + " IO状态改变： " +
                        ndata1.ToString() + ndata2.ToString() + ndata3.ToString() + ndata4.ToString();
                }
            }
            
            listBoxInfo.Items.Insert(0, strText);
        }

        public void SDK_OnDeviceEvent(System.IntPtr pvParam,
           [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcIP,
           uint u32EventType, uint u32EventData1, uint u32EventData2, uint u32EventData3, uint u32EventData4)
        {
            IAsyncResult syncResult = this.BeginInvoke(updateDeviceEvent, pcIP, u32EventType, u32EventData1,
                u32EventData2, u32EventData3, u32EventData4, 1, 0);
        }

        public void SDK_OnIOEvent(System.IntPtr pvParam,
            [System.Runtime.InteropServices.InAttribute()] [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.LPStr)] string pcIP,
            uint u32EventType, uint u32IOData1, uint u32IOData2, uint u32IOData3, uint u32IOData4)
        {
            IAsyncResult syncResult = this.BeginInvoke(updateDeviceEvent, pcIP, u32EventType, u32IOData1,
                u32IOData2, u32IOData3, u32IOData4, 0, (int)pvParam);
        }

        private ICE_IPCSDK_OnPlate onPlate;
        private ICE_IPCSDK_OnFrame_Planar onFrame;
        private ICE_IPCSDK_OnPastPlate onPastPlate;
        private ICE_IPCSDK_OnSerialPort onSerialPort;
        private ICE_IPCSDK_OnSerialPort_RS232 onSerialPortRS232;
        private ICE_IPCSDK_OnDeviceEvent onDeviceEvent;
        private ICE_IPCSDK_OnIOEvent onIOEvent;
        //第一路，连接相机，提供了三个连接相机接口的调用方法
        /*
         * 连接接口使用说明：
         * 连接接口共6个：不带密码的：ICE_IPCSDK_OpenPreview， ICE_IPCSDK_Open， ICE_IPCSDK_OpenDevice
         *              带密码的：ICE_IPCSDK_OpenPreview_Passwd， ICE_IPCSDK_Open_Passwd， ICE_IPCSDK_OpenDevice_Passwd
         * 1.当需要视频时，推荐使用：ICE_IPCSDK_OpenPreview；如果是加密相机，则使用ICE_IPCSDK_OpenPreview_Passwd
         * 2.不需要视频时，推荐使用：ICE_IPCSDK_OpenDevice；如果是加密相机，则使用ICE_IPCSDK_OpenDevice_Passwd
         * 3.需要自己做视频显示时，使用：ICE_IPCSDK_Open；如果是加密相机，则使用ICE_IPCSDK_Open_Passwd
         */
        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (radioButton_Preview.Checked) //选择连接方式为：视频预览
            {
                IntPtr videoHwnd = pictureBox1.Handle;
                if (videoHwnd != IntPtr.Zero)
                {
                    if (checkBoxPassword.Checked == true) //使用密码连接
                    {
                        pUid[0] = ipcsdk.ICE_IPCSDK_OpenPreview_Passwd(textBoxIP1.Text, textBoxPassword.Text, 1, 1,
                            (uint)videoHwnd, onPlate, new IntPtr(0)); //使用带密码的接口连接相机，并且设置车牌识别数据回调onPlate
                        if (pUid[0] == IntPtr.Zero)
                        {
                            MessageBox.Show("相机1连接失败,密码错误或者网络不好！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        //使用不带密码的接口连接相机
                        pUid[0] = ipcsdk.ICE_IPCSDK_OpenPreview(textBoxIP1.Text, 1, 1, (uint)videoHwnd, onPlate, new IntPtr(0));
                        if (pUid[0] == IntPtr.Zero)
                        {
                            MessageBox.Show("相机1连接失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("未获得视频播放窗口");
                    return;
                }
                buttonStartVideo1.Text = "结束视频";
                buttonStartVideo1.Enabled = true;
            }
            else if (radioButton_Frame.Checked == true) //选择连接方法为：图像解码
            {
                if (checkBoxPassword.Checked == true) //使用密码连接
                {
                    //调用带密码的接口连接相机
                    pUid[0] = ipcsdk.ICE_IPCSDK_Open_Passwd(textBoxIP1.Text, textBoxPassword.Text, 1, 554, 8117, 8080, 1, 0, IntPtr.Zero, 0, IntPtr.Zero);
                    if (pUid[0] == IntPtr.Zero)
                    {
                        MessageBox.Show("相机1连接失败,密码错误或者网络不好！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    //调用不带密码的接口连接相机
                    pUid[0] = ipcsdk.ICE_IPCSDK_Open(textBoxIP1.Text, 1, 554, 8117, 8080, 1, 0, IntPtr.Zero, 0, IntPtr.Zero);
                    if (pUid[0] == IntPtr.Zero)
                    {
                        MessageBox.Show("相机1连接失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                ipcsdk.ICE_IPCSDK_SetFrameCallback(pUid[0], onFrame, new IntPtr(0));//设置获得解码出的一帧图像的相关回调函数
                ipcsdk.ICE_IPCSDK_SetPlateCallback(pUid[0], onPlate, new IntPtr(0));//设置获取车牌识别数据的回调函数
            }

            else if (radioButtonOnlyConn.Checked == true) //选择连接方式为：连接与码流分开
            {
                if (checkBoxPassword.Checked == true)//使用密码连接
                {
                    //调用带密码的连接接口
                    pUid[0] = ipcsdk.ICE_IPCSDK_OpenDevice_Passwd(textBoxIP1.Text, textBoxPassword.Text);
                    if (pUid[0] == IntPtr.Zero)
                    {
                        MessageBox.Show("相机1连接失败,密码错误或者网络不好！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    //调用不带密码的连接接口
                    pUid[0] = ipcsdk.ICE_IPCSDK_OpenDevice(textBoxIP1.Text);
                    if (pUid[0] == IntPtr.Zero)
                    {
                        MessageBox.Show("相机1连接失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                

                IntPtr videoHwnd = pictureBox1.Handle;
                if (videoHwnd != IntPtr.Zero)
                {
                    //连接视频，因为ICE_IPCSDK_OpenDevice不带视频流；如果不需要视频，可不调用该接口
                    UInt32 ret = ipcsdk.ICE_IPCSDK_StartStream(pUid[0], 1, (UInt32)videoHwnd);
                    if (ret == 0)
                    {
                        ipcsdk.ICE_IPCSDK_StopStream(pUid[0]);//连接视频失败，调用断开视频接口释放资源
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("未获得视频播放窗口");
                    return;
                }
                ipcsdk.ICE_IPCSDK_SetPlateCallback(pUid[0], onPlate, new IntPtr(0));//设置车牌识别数据回调
                buttonStartVideo1.Enabled = true;
                buttonStartVideo1.Text = "结束视频";
            }

            //设置断网续传回调
            ipcsdk.ICE_IPCSDK_SetPastPlateCallBack(pUid[0], onPastPlate, new IntPtr(0));

            //设置RS485透明串口回调
            ipcsdk.ICE_IPCSDK_SetSerialPortCallBack(pUid[0], onSerialPort, new IntPtr(0));//485
            //设置RS232透明串口回调
            ipcsdk.ICE_IPCSDK_SetSerialPortCallBack_RS232(pUid[0], onSerialPortRS232, new IntPtr(0));//232

            //IO变化事件
            ipcsdk.ICE_IPCSDK_SetIOEventCallBack(pUid[0], onIOEvent, new IntPtr(0));

            strIp[0] = textBoxIP1.Text;
            buttonConnect.Enabled = false;
            buttonDisconnect.Enabled = true;
            button_talk.Enabled = true;
            button_trigger.Enabled = true;
            button_openGate.Enabled = true;
            button_reboot.Enabled = true;
            buttonSyncTime1.Enabled = true;
            buttonSPortSend1.Enabled = true;
            buttonCapture1.Enabled = true;
            buttonRecord1.Enabled = true;
            button_WR1.Enabled = true;
            button_network1.Enabled = true;
            button_openGate2_1.Enabled = true;
            button_broadcast1.Enabled = true;
            button_broadcastGroup1.Enabled = true;
            button_WBinary1.Enabled = true;
            button_RBinary1.Enabled = true;
            button_RS232_1.Enabled = true;
            button_cameraInfo1.Enabled = true;
            button_getIOState1.Enabled = true;
            button_getVehicleInfo1.Enabled = true;
            button_getPayInfo1.Enabled = true;
            button_settingMore.Enabled = true;
            button_updateList.Enabled = true;

            bPreview[0] = true;
            bClose[0] = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ipcsdk.ICE_IPCSDK_Init(); //调用全局初始化

            onFrame = new ICE_IPCSDK_OnFrame_Planar(SDK_OnFrame);
            onPlate= new ICE_IPCSDK_OnPlate(SDK_OnPlate);
            onPastPlate = new ICE_IPCSDK_OnPastPlate(SDK_OnPastPlate);
            onSerialPort = new ICE_IPCSDK_OnSerialPort(SDK_OnSerialPort);
            onSerialPortRS232 = new ICE_IPCSDK_OnSerialPort_RS232(SDK_OnSerialPortRS232);
            onDeviceEvent = new ICE_IPCSDK_OnDeviceEvent(SDK_OnDeviceEvent);
            onIOEvent = new ICE_IPCSDK_OnIOEvent(SDK_OnIOEvent);

            textBoxIP[0] = this.textBoxIP1;
            textBoxIP[1] = this.textBoxIP2;
            textBoxIP[2] = this.textBoxIP3;
            textBoxIP[3] = this.textBoxIP4;

            labelStatus[0] = this.labelStatus1;
            labelStatus[1] = this.labelStatus2;
            labelStatus[2] = this.labelStatus3;
            labelStatus[3] = this.labelStatus4;

            labelPlate[0] = this.labelPlate1;
            labelPlate[1] = this.labelPlate2;
            labelPlate[2] = this.labelPlate3;
            labelPlate[3] = this.labelPlate4;

            textBoxGateNum[0] = this.textBoxGateNum1;
            textBoxGateNum[1] = this.textBoxGateNum2;
            textBoxGateNum[2] = this.textBoxGateNum3;
            textBoxGateNum[3] = this.textBoxGateNum4;

            textBoxTriggerNum[0] = this.textBoxTriggerNum1;
            textBoxTriggerNum[1] = this.textBoxTriggerNum2;
            textBoxTriggerNum[2] = this.textBoxTriggerNum3;
            textBoxTriggerNum[3] = this.textBoxTriggerNum4;

            textBox_offset.Text = "0";

            for (int i = 0; i < 4; i++)
            {
                strMac[i] = new StringBuilder(64);
            }

            updatePlateInfo = new UpdatePlateInfo(showCount);
            updateStatus = new UpdateStatus(showStatus);
            triggerStatus = new UpdateTriggerStatus(showTriggerStatus);
            updatePortInfo = new UpdatePortInfo(showPortData);
            updateDeviceEvent = new UpdateDeviceEvent(showDeviceEvent);

            //为语音播放序号下拉框赋值0-145
            for (int pos = 0; pos < 146; pos++)
            {
                comboBox_BIndex1.Items.Add(pos.ToString());
                comboBox_BIndex2.Items.Add(pos.ToString());
                comboBox_BIndex3.Items.Add(pos.ToString());
                comboBox_BIndex4.Items.Add(pos.ToString());
            }
            comboBox_BIndex1.SelectedIndex = 0;
            comboBox_BIndex2.SelectedIndex = 0;
            comboBox_BIndex3.SelectedIndex = 0;
            comboBox_BIndex4.SelectedIndex = 0;

            //osdInfo.szCamreaLocation = new byte[MAX_OSD_TEXT];
            //osdInfo.szCustomJpeg = new byte[MAX_OSD_TEXT];
            //osdInfo.szCustomVideo = new byte[MAX_OSD_TEXT];
            //osdInfo.szDeviceID = new byte[MAX_OSD_TEXT];
            //osdInfo.szDeviceName = new byte[MAX_OSD_TEXT];
            //osdInfo.szSubLocation = new byte[MAX_OSD_TEXT];
            ////osdInfo.szCustomJpeg6 = new char[6 * MAX_OSD_TEXT];
            ////osdInfo.szCustomVideo6 = new char[6*MAX_OSD_TEXT];
            //获得设置
            if (File.Exists(@"./param.dat"))
            {
                FileStream fs = new FileStream("param.dat", FileMode.Open, FileAccess.Read);
                if (fs != null)
                {
                    try
                    {
                        BinaryReader br = new BinaryReader(fs);
                        if (br != null)
                        {
                            m_strStorePath = br.ReadString();
                            m_strLogPath = br.ReadString();
                            m_bEnableLog = br.ReadInt32();
                            m_bOpenGate = br.ReadInt32();
                            m_bTrigger = br.ReadInt32();
                            m_nOpenInterval = br.ReadInt32();
                            m_nTriggerInterval = br.ReadInt32();
                            m_nRecordInterval = br.ReadInt32();

                            osdInfo.u32OSDLocationVideo = (UInt32)br.ReadInt32();
                            m_nVideoColor = br.ReadString();
                            osdInfo.u32DateVideo = (UInt32)br.ReadInt32();
                            osdInfo.u32License = (UInt32)br.ReadInt32();
                            osdInfo.u32CustomVideo = (UInt32)br.ReadInt32();
                            osdInfo.szCustomVideo6 = br.ReadString();

                            osdInfo.u32OSDLocationJpeg = (UInt32)br.ReadInt32();
                            m_nJpegColor = br.ReadString();
                            osdInfo.u32DateJpeg = (UInt32)br.ReadInt32();
                            osdInfo.u32Algo = (UInt32)br.ReadInt32();
                            osdInfo.u32CustomJpeg = (UInt32)br.ReadInt32();
                            osdInfo.szCustomJpeg6 = br.ReadString();

                            m_bOpenGate2 = br.ReadInt32();
                            m_bRS485 = br.ReadInt32();
                            m_bRS232 = br.ReadInt32();
                            m_nOpenInterval2 = br.ReadInt32();
                            m_nRS485Interval = br.ReadInt32();
                            m_nRS232Interval = br.ReadInt32();


                            br.Close();
                        }
                        fs.Close();
                    }
                    catch (System.Exception ex)
                    {

                    }
                }
            }

            if (m_strStorePath == "")
            {
                m_strStorePath = "D:\\";
            }
            if (m_strLogPath == "")
            {
                m_strStorePath = "D:\\";
            }

            string tmp = getColor16(m_nVideoColor);
            osdInfo.u32ColorVideo = Convert.ToUInt32(tmp, 16);
            tmp = "";
            tmp = getColor16(m_nJpegColor);
            osdInfo.u32CustomJpeg = Convert.ToUInt32(tmp, 16);
            loadConfig(m_strStorePath, m_bOpenGate, m_bTrigger, m_nOpenInterval,
                m_nTriggerInterval, m_nRecordInterval, m_bOpenGate2, m_bRS485, m_bRS232,
                m_nOpenInterval2, m_nRS485Interval, m_nRS232Interval);//设置图片保存路径，是否定时调用触发，定时打开道闸等，见函数实现中的说明
            ipcsdk.ICE_IPCSDK_LogConfig(m_bEnableLog, m_strLogPath);//日志配置

            ipcsdk.ICE_IPCSDK_SetDeviceEventCallBack(IntPtr.Zero, onDeviceEvent, new IntPtr(0));

            if (threadStatus != null)
            {
                threadStatus.Abort();
                threadStatus = null;
            }
            threadStatus = new Thread(new ThreadStart(getStatus));//开启获取相机状态线程
            threadStatus.Start();
        }

        //得到的RGB颜色值格式为0xrrggbb，要转成0xbbggrr格式
        private string getColor16(string color)
        {
            string realColor = "";
            realColor = color[4].ToString() + color[5].ToString() + color[2].ToString() + color[3].ToString() + color[0].ToString() + color[1].ToString();
            return realColor;
        }

        //设置OSD参数
        private void loadOsdConfig(uint nPosVideo, string nColorVideo, uint nDateTimeVideo, uint nLicense, uint nCustomVideo, string bstrCustomVideo,
            uint nPosJpeg, string nColorJpeg, uint nDateTimeJpeg, uint nAlgo, uint nCustomJpeg, string bstrCustomJpeg)
        {
            osdInfo.u32OSDLocationVideo= nPosVideo;
            m_nVideoColor = nColorVideo;
            osdInfo.u32DateVideo = nDateTimeVideo;
            osdInfo.u32License = nLicense;
            osdInfo.u32CustomVideo= nCustomVideo;
            osdInfo.szCustomVideo6 = bstrCustomVideo;/*System.Text.Encoding.Default.GetBytes(bstrCustomVideo.PadRight(6 * 64, '\0'));*/
            osdInfo.u32OSDLocationJpeg = nPosJpeg;
            m_nJpegColor = nColorJpeg;
            osdInfo.u32DateJpeg = nDateTimeJpeg;
            osdInfo.u32Algo = nAlgo;
            osdInfo.u32CustomJpeg = nCustomJpeg;
            osdInfo.szCustomJpeg6 = bstrCustomJpeg;/*System.Text.Encoding.Default.GetBytes(bstrCustomJpeg.PadRight(6 * 64, '\0'));*/

            string tmp = getColor16(m_nVideoColor);
            osdInfo.u32ColorVideo = Convert.ToUInt32(tmp, 16);
            tmp = "";
            tmp = getColor16(m_nJpegColor);
            osdInfo.u32ColorJpeg = Convert.ToUInt32(tmp, 16);

            for (int i = 0; i < 4; i++)
            {
                if (pUid[i] != IntPtr.Zero)
                {
                    //IntPtr pUid = new IntPtr(UID[i]);
                    ipcsdk.ICE_IPCSDK_SetOSDCfg(pUid[i], ref osdInfo);//调用设置OSD参数接口
                }
            }
        }

        //通过从配置文件中读取出来的参数，进行相关操作
        private void loadConfig(string strPath, int nOpenGate, int nTrigger, int nOpenGateInterval, int nTriggerInterval, int nRecordInterval, 
            int nOpenGate2, int nRS485, int nRS232, int nOpenGate2Interval, int nRS485Interval, int nRS232Interval)
        {
            //mutexMsg.WaitOne();
            m_strStorePath = strPath;//图片保存路径
            m_bOpenGate = nOpenGate;
            m_bTrigger = nTrigger;
            m_nOpenInterval = nOpenGateInterval;
            m_nTriggerInterval = nTriggerInterval;
            m_nRecordInterval = nRecordInterval;

            m_bOpenGate2 = nOpenGate2;
            m_bRS485 = nRS485;
            m_bRS232 = nRS232;
            m_nOpenInterval2 = nOpenGate2Interval;
            m_nRS485Interval = nRS485Interval;
            m_nRS232Interval = nRS232Interval;

            if (m_strStorePath == "")
            {
                m_strStorePath = "D:\\";
            }

            //以下线程都是为了测试相机和sdk稳定性而设计的
            if (nOpenGate == 1)//如果定时打开道闸为1，则启动定时开闸线程
            {   
                if (threadOpenGate == null)
                {
                    threadOpenGate = new Thread(new ThreadStart(openGate));
                    threadOpenGate.Start();
                }
            }
            else//如果定时打开道闸为0，则关闭定时开闸线程
            {   
                if (threadOpenGate != null)
                {
                    threadOpenGate.Abort();
                    threadOpenGate = null;
                }
            }


            if (nTrigger == 1)//如果定时软触发为1，则启动定时软触发线程
            {
                if (threadTrigger == null)
                {
                    threadTrigger = new Thread(new ThreadStart(trigger));
                    threadTrigger.Start();
                }
            }
            else//如果定时软触发为0，则关闭定时软触发线程
            {
                if (threadTrigger != null)
                {
                    threadTrigger.Abort();
                    threadTrigger = null;
                }
            }

            if (nOpenGate2 == 1)//如果定时打开道闸2为1，则启动定时打开道闸2线程
            {
                if (threadOpenGate2 == null)
                {
                    threadOpenGate2 = new Thread(new ThreadStart(openGate2));
                    threadOpenGate2.Start();
                }
            }
            else//如果定时打开道闸2为0，则关闭定时打开道闸2线程
            {
                if (threadOpenGate2 != null)
                {
                    threadOpenGate2.Abort();
                    threadOpenGate2 = null;
                }
            }

            if (nRS485 == 1)//如果定时发送RS485数据为1，则启动定时发送RS485数据线程
            {
                if (threadRS485 == null)
                {
                    threadRS485 = new Thread(new ThreadStart(sendRS485));
                    threadRS485.Start();
                }
            }
            else//如果定时发送RS485数据为1，则关闭定时发送RS485数据线程
            {
                if (threadRS485 != null)
                {
                    threadRS485.Abort();
                    threadRS485 = null;
                }
            }

            if (nRS232 == 1)//如果定时发送RS232数据为1，则启动定时发送RS232数据线程
            {
                if (threadRS232 == null)
                {
                    threadRS232 = new Thread(new ThreadStart(sendRS232));
                    threadRS232.Start();
                }
            }
            else//如果定时发送RS232数据为1，则关闭定时发送RS232数据线程
            {
                if (threadRS232 != null)
                {
                    threadRS232.Abort();
                    threadRS232 = null;
                }
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_bExit = true;
            //timerStatus.Enabled = false;
            //timerOpenGate.Enabled = false;
            //timerTrigger.Enabled = false;

            //mutexThread.WaitOne();
            //关闭线程
            if (threadTrigger != null)
            {
                threadTrigger.Abort();
                threadTrigger = null;
            }
            if (threadOpenGate != null)
            {
                threadOpenGate.Abort();
                threadOpenGate = null;
            }
            if (threadStatus != null)
            {
                threadStatus.Abort();
                threadStatus = null;
            }
            if (threadOpenGate2 != null)
            {
                threadOpenGate2.Abort();
                threadOpenGate2 = null;
            }
            if (threadRS485 != null)
            {
                threadRS485.Abort();
                threadRS485 = null;
            }
            if (threadRS232 != null)
            {
                threadRS232.Abort();
                threadRS232 = null;
            }

            for (int i = 0; i < 4; i++ )
            {
                if (pUid[i] != IntPtr.Zero)
                {
                    if (bRecord[i])//在进行录像，则关闭录像
                    {
                        if (null != mythread[i])
                        {
                            mythread[i].Abort();
                            mythread[i] = null;
                        }
                        bRecord[i] = false;
                        ipcsdk.ICE_IPCSDK_StopRecord(pUid[i]);//调用关闭录像接口
                    }
                    ipcsdk.ICE_IPCSDK_Close(pUid[i]);
                    pUid[i] = IntPtr.Zero;
                }
            }
            //mutexThread.ReleaseMutex();
            mutex.Close();
            mutex = null;
            mutexThread.Close();
            mutexThread = null;
            ipcsdk.ICE_IPCSDK_Fini(); //调用全局释放   
        }
        //第一路 断开连接
        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            if (pUid[0] == IntPtr.Zero)
                return;

            bClose[0] = true;
            try
            {
                if (bTalk[0]) //在进行对讲
                {
                    ipcsdk.ICE_IPCSDK_EndTalk(pUid[0]);//结束对讲
                    button_talk.Text = "对讲";
                    bTalk[0] = false;
                }

                if (bRecord[0]) //在进行录像
                {
                    buttonRecord1.Text = "开始录像";
                    bRecord[0] = false;
                    if (null != mythread[0])
                    {
                        mythread[0].Abort();
                        mythread[0] = null;
                    }
                    ipcsdk.ICE_IPCSDK_StopRecord(pUid[0]); //结束录像
                }

                mutexThread.WaitOne();
                ipcsdk.ICE_IPCSDK_Close(pUid[0]);//断开连接
                pUid[0] = IntPtr.Zero;
                mutexThread.ReleaseMutex();
            }
            catch (System.Exception ex)
            {
            	
            }

            if (bPreview[0])
            {
                buttonStartVideo1.Text = "开始视频";
                bPreview[0] = false;
            }

            labelStatus1.Text = "离线";
            frame_count[0] = 0;
            nCurrentStatus[0] = 0;
            nStatus[0] = 0;

            buttonConnect.Enabled = true;
            buttonDisconnect.Enabled = false;
            button_talk.Enabled = false;
            button_trigger.Enabled = false;
            button_openGate.Enabled = false;
            button_reboot.Enabled = false;
            buttonSyncTime1.Enabled = false;
            buttonSPortSend1.Enabled = false;
            buttonCapture1.Enabled = false;
            buttonRecord1.Enabled = false;
            buttonStartVideo1.Enabled = false;
            button_WR1.Enabled = false;
            button_network1.Enabled = false;
            button_openGate2_1.Enabled = false;
            button_broadcast1.Enabled = false;
            button_broadcastGroup1.Enabled = false;
            button_WBinary1.Enabled = false;
            button_RBinary1.Enabled = false;
            button_RS232_1.Enabled = false;
            button_cameraInfo1.Enabled = false;
            button_getIOState1.Enabled = false;
            button_getVehicleInfo1.Enabled = false;
            button_getPayInfo1.Enabled = false;
            button_settingMore.Enabled = false;
            button_updateList.Enabled = false;
        }

        //第二路，连接相机，提供了三个连接相机接口的调用方法
        /*
         * 连接接口使用说明：
         * 连接接口共6个：不带密码的：ICE_IPCSDK_OpenPreview， ICE_IPCSDK_Open， ICE_IPCSDK_OpenDevice
         *              带密码的：ICE_IPCSDK_OpenPreview_Passwd， ICE_IPCSDK_Open_Passwd， ICE_IPCSDK_OpenDevice_Passwd
         * 1.当需要视频时，推荐使用：ICE_IPCSDK_OpenPreview；如果是加密相机，则使用ICE_IPCSDK_OpenPreview_Passwd
         * 2.不需要视频时，推荐使用：ICE_IPCSDK_OpenDevice；如果是加密相机，则使用ICE_IPCSDK_OpenDevice_Passwd
         * 3.需要自己做视频显示时，使用：ICE_IPCSDK_Open；如果是加密相机，则使用ICE_IPCSDK_Open_Passwd
         */
        private void buttonConnect2_Click(object sender, EventArgs e)
        {
            if (radioButton_Preview.Checked == true)//选择连接方式为：视频预览
            {
                IntPtr videoHwnd = pictureBox2.Handle;
                if (videoHwnd != IntPtr.Zero)
                {
                    if (checkBoxPassword.Checked == true)//使用密码连接
                    {
                        pUid[1] = ipcsdk.ICE_IPCSDK_OpenPreview_Passwd(textBoxIP2.Text, textBoxPassword.Text, 1, 1,
                            (uint)videoHwnd, onPlate, new IntPtr(1));//使用带密码的接口连接相机，并且设置车牌识别数据回调onPlate
                        if (pUid[1] == IntPtr.Zero)
                        {
                            MessageBox.Show("相机2连接失败，密码错误或者网络不好！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        //使用不带密码的接口连接相机
                        pUid[1] = ipcsdk.ICE_IPCSDK_OpenPreview(textBoxIP2.Text, 1, 1, (uint)videoHwnd, onPlate, new IntPtr(1));
                        if (pUid[1] == IntPtr.Zero)
                        {
                            MessageBox.Show("相机2连接失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("未获得视频播放窗口");
                    return;
                }
                
                buttonStartVideo2.Enabled = true;
                buttonStartVideo2.Text = "结束视频";
            }
            else if (radioButton_Frame.Checked == true)//选择连接方法为：图像解码
            {
                if (checkBoxPassword.Checked == true)//使用密码连接
                {
                    //调用带密码的接口连接相机
                    pUid[1] = ipcsdk.ICE_IPCSDK_Open_Passwd(textBoxIP2.Text, textBoxPassword.Text, 1, 554, 8117, 8080, 1, 0, IntPtr.Zero, 0, IntPtr.Zero);
                    if (pUid[1] == IntPtr.Zero)
                    {
                        MessageBox.Show("相机2连接失败，密码错误或者网络不好！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    //调用不带密码的接口连接相机
                    pUid[1] = ipcsdk.ICE_IPCSDK_Open(textBoxIP2.Text, 1, 554, 8117, 8080, 1, 0, IntPtr.Zero, 0, IntPtr.Zero);
                    if (pUid[1] == IntPtr.Zero)
                    {
                        MessageBox.Show("相机2连接失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                //设置获得解码出的一帧图像的相关回调函数
                ipcsdk.ICE_IPCSDK_SetFrameCallback(pUid[1], onFrame, new IntPtr(1));
                //设置获取车牌识别数据的回调函数
                ipcsdk.ICE_IPCSDK_SetPlateCallback(pUid[1], onPlate, new IntPtr(1));
            }
            else if (radioButtonOnlyConn.Checked == true)//选择连接方式为：连接与码流分开
            {
                if (checkBoxPassword.Checked == true)//使用密码连接
                {
                    //调用带密码的连接接口
                    pUid[1] = ipcsdk.ICE_IPCSDK_OpenDevice_Passwd(textBoxIP2.Text, textBoxPassword.Text);
                    if (pUid[1] == IntPtr.Zero)
                    {
                        MessageBox.Show("相机2连接失败，密码错误或者网络不好！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    //调用不带密码的连接接口
                    pUid[1] = ipcsdk.ICE_IPCSDK_OpenDevice(textBoxIP2.Text);
                    if (pUid[1] == IntPtr.Zero)
                    {
                        MessageBox.Show("相机2连接失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                

                IntPtr videoHwnd = pictureBox2.Handle;
                if (videoHwnd != IntPtr.Zero)
                {
                    //连接视频，因为ICE_IPCSDK_OpenDevice不带视频流；如果不需要视频，可不调用该接口
                    UInt32 ret = ipcsdk.ICE_IPCSDK_StartStream(pUid[1], 1, (UInt32)videoHwnd);
                    if (ret == 0)
                    {
                        ipcsdk.ICE_IPCSDK_StopStream(pUid[1]);//连接视频失败，调用断开视频接口释放资源
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("未获得视频播放窗口");
                    return;
                }
                //设置车牌识别数据回调
                ipcsdk.ICE_IPCSDK_SetPlateCallback(pUid[1], onPlate, new IntPtr(1));
                buttonStartVideo2.Enabled = true;
                buttonStartVideo2.Text = "结束视频";
            }

            //设置断网续传回调
            ipcsdk.ICE_IPCSDK_SetPastPlateCallBack(pUid[1], onPastPlate, new IntPtr(1));

            //设置RS485透明串口回调
            ipcsdk.ICE_IPCSDK_SetSerialPortCallBack(pUid[1], onSerialPort, new IntPtr(1));//485
            //设置RS232透明串口回调
            ipcsdk.ICE_IPCSDK_SetSerialPortCallBack_RS232(pUid[1], onSerialPortRS232, new IntPtr(1));//232

            //IO状态变化事件
            ipcsdk.ICE_IPCSDK_SetIOEventCallBack(pUid[1], onIOEvent, new IntPtr(1));

            strIp[1] = textBoxIP2.Text;
            buttonConnect2.Enabled = false;
            buttonDisconnect2.Enabled = true;
            button_talk2.Enabled = true;
            button_trigger2.Enabled = true;
            button_openGate2.Enabled = true;
            button_reboot2.Enabled = true;
            buttonSyncTime2.Enabled = true;
            buttonSPortSend2.Enabled = true;
            buttonCapture2.Enabled = true;
            buttonRecord2.Enabled = true;
            button_WR2.Enabled = true;
            button_network2.Enabled = true;
            button_openGate2_2.Enabled = true;
            button_broadcast2.Enabled = true;
            button_broadcastGroup2.Enabled = true;
            button_WBinary2.Enabled = true;
            button_RBinary2.Enabled = true;
            button_RS232_2.Enabled = true;
            button_cameraInfo2.Enabled = true;
            button_getIOState2.Enabled = true;
            button_getVehicleInfo2.Enabled = true;
            button_getPayInfo2.Enabled = true;
            button_settingMore2.Enabled = true;

            bPreview[1] = true;
            bClose[1] = false;
        }

        //第二路 断开连接
        private void buttonDisconnect2_Click(object sender, EventArgs e)
        {
            if (pUid[1] == IntPtr.Zero)
                return;

            bClose[1] = true;

            if (bTalk[1])//在进行对讲
            {
                ipcsdk.ICE_IPCSDK_EndTalk(pUid[1]);//结束对讲
                button_talk2.Text = "对讲";
                bTalk[1] = false;
            }

            if (bRecord[1])//在进行录像
            {
                buttonRecord2.Text = "开始录像";
                bRecord[1] = false;
                if (null != mythread[1])
                {
                    mythread[1].Abort();
                    mythread[1] = null;
                }
                ipcsdk.ICE_IPCSDK_StopRecord(pUid[1]);//结束录像
            }

            mutexThread.WaitOne();
            ipcsdk.ICE_IPCSDK_Close(pUid[1]);//断开连接
            pUid[1] = IntPtr.Zero;
            mutexThread.ReleaseMutex();

            if (bPreview[1])
            {
                buttonStartVideo2.Text = "开始视频";
                bPreview[1] = false;
            }
            labelStatus2.Text = "离线";
            frame_count[1] = 0;
            nCurrentStatus[1] = 0;
            nStatus[1] = 0;

            buttonConnect2.Enabled = true;
            buttonDisconnect2.Enabled = false;
            button_talk2.Enabled = false;
            button_trigger2.Enabled = false;
            button_openGate2.Enabled = false;
            button_reboot2.Enabled = false;
            buttonSyncTime2.Enabled = false;
            buttonSPortSend2.Enabled = false;
            buttonCapture2.Enabled = false;
            buttonRecord2.Enabled = false;
            buttonStartVideo2.Enabled = false;
            button_WR2.Enabled = false;
            button_network2.Enabled = false;
            button_openGate2_2.Enabled = false;
            button_broadcast2.Enabled = false;
            button_broadcastGroup2.Enabled = false;
            button_WBinary2.Enabled = false;
            button_RBinary2.Enabled = false;
            button_RS232_2.Enabled = false;
            button_cameraInfo2.Enabled = false;
            button_getIOState2.Enabled = false;
            button_getVehicleInfo2.Enabled = false;
            button_getPayInfo2.Enabled = false;
            button_settingMore2.Enabled = false;
        }
        //第三路，连接相机，提供了三个连接相机接口的调用方法
        /*
         * 连接接口使用说明：
         * 连接接口共6个：不带密码的：ICE_IPCSDK_OpenPreview， ICE_IPCSDK_Open， ICE_IPCSDK_OpenDevice
         *              带密码的：ICE_IPCSDK_OpenPreview_Passwd， ICE_IPCSDK_Open_Passwd， ICE_IPCSDK_OpenDevice_Passwd
         * 1.当需要视频时，推荐使用：ICE_IPCSDK_OpenPreview；如果是加密相机，则使用ICE_IPCSDK_OpenPreview_Passwd
         * 2.不需要视频时，推荐使用：ICE_IPCSDK_OpenDevice；如果是加密相机，则使用ICE_IPCSDK_OpenDevice_Passwd
         * 3.需要自己做视频显示时，使用：ICE_IPCSDK_Open；如果是加密相机，则使用ICE_IPCSDK_Open_Passwd
         */
        private void buttonConnect3_Click(object sender, EventArgs e)
        {
            if (radioButton_Preview.Checked == true)//选择连接方式为：视频预览
            {
                IntPtr videoHwnd = pictureBox3.Handle;             
                if (videoHwnd != IntPtr.Zero)
                {
                    if (checkBoxPassword.Checked == true)//使用密码连接
                    {
                        //使用带密码的接口连接相机，并且设置车牌识别数据回调onPlate
                        pUid[2] = ipcsdk.ICE_IPCSDK_OpenPreview_Passwd(textBoxIP3.Text, textBoxPassword.Text, 1, 1, (uint)videoHwnd, onPlate, new IntPtr(2));
                        if (pUid[2] == IntPtr.Zero)
                        {
                            MessageBox.Show("相机3连接失败，密码错误或者网络不好！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else 
                    {
                        //使用不带密码的接口连接相机
                        pUid[2] = ipcsdk.ICE_IPCSDK_OpenPreview(textBoxIP3.Text, 1, 1, (uint)videoHwnd, onPlate, new IntPtr(2));
                        if (pUid[2] == IntPtr.Zero)
                        {
                            MessageBox.Show("相机3连接失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }                    
                }
                else
                {
                    MessageBox.Show("未获得视频播放窗口");
                    return;
                }
                
                buttonStartVideo3.Enabled = true;
                buttonStartVideo3.Text = "结束视频";
            }
            else if (radioButton_Frame.Checked == true)//选择连接方法为：图像解码
            {
                if (checkBoxPassword.Checked == true)//使用密码连接
                {
                    //调用带密码的接口连接相机
                    pUid[2] = ipcsdk.ICE_IPCSDK_Open_Passwd(textBoxIP3.Text,textBoxPassword.Text, 1, 554, 8117, 8080, 1, 0, IntPtr.Zero, 0, IntPtr.Zero);
                    if (pUid[2] == IntPtr.Zero)
                    {
                        MessageBox.Show("相机3连接失败，密码错误或者网络不好！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    //调用不带密码的接口连接相机
                    pUid[2] = ipcsdk.ICE_IPCSDK_Open(textBoxIP3.Text, 1, 554, 8117, 8080, 1, 0, IntPtr.Zero, 0, IntPtr.Zero);
                    if (pUid[2] == IntPtr.Zero)
                    {
                        MessageBox.Show("相机3连接失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                //设置获得解码出的一帧图像的相关回调函数
                ipcsdk.ICE_IPCSDK_SetFrameCallback(pUid[2], onFrame, new IntPtr(2));
                //设置获取车牌识别数据的回调函数
                ipcsdk.ICE_IPCSDK_SetPlateCallback(pUid[2], onPlate, new IntPtr(2));
            }
            else if (radioButtonOnlyConn.Checked == true)//选择连接方式为：连接与码流分开
            {
                if (checkBoxPassword.Checked == true)//使用密码连接
                {
                    //调用带密码的连接接口
                    pUid[2] = ipcsdk.ICE_IPCSDK_OpenDevice_Passwd(textBoxIP3.Text,textBoxPassword.Text);
                    if (pUid[2] == IntPtr.Zero)
                    {
                        MessageBox.Show("相机3连接失败，密码错误或者网络不好！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    //调用不带密码的连接接口
                    pUid[2] = ipcsdk.ICE_IPCSDK_OpenDevice(textBoxIP3.Text);
                    if (pUid[2] == IntPtr.Zero)
                    {
                        MessageBox.Show("相机3连接失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                

                IntPtr videoHwnd = pictureBox3.Handle;
                if (videoHwnd != IntPtr.Zero)
                {
                    //连接视频，因为ICE_IPCSDK_OpenDevice不带视频流；如果不需要视频，可不调用该接口
                    UInt32 ret = ipcsdk.ICE_IPCSDK_StartStream(pUid[2], 1, (UInt32)videoHwnd);
                    if (ret == 0)
                    {
                        ipcsdk.ICE_IPCSDK_StopStream(pUid[2]);//连接视频失败，调用断开视频接口释放资源
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("未获得视频播放窗口");
                    return;
                }
                //设置车牌识别数据回调
                ipcsdk.ICE_IPCSDK_SetPlateCallback(pUid[2], onPlate, new IntPtr(2));
                buttonStartVideo3.Enabled = true;
                buttonStartVideo3.Text = "结束视频";
            }

            //设置断网续传回调
            ipcsdk.ICE_IPCSDK_SetPastPlateCallBack(pUid[2], onPastPlate, new IntPtr(2));

            //设置RS485透明串口回调
            ipcsdk.ICE_IPCSDK_SetSerialPortCallBack(pUid[2], onSerialPort, new IntPtr(2));//485
            //设置RS232透明串口回调
            ipcsdk.ICE_IPCSDK_SetSerialPortCallBack_RS232(pUid[2], onSerialPortRS232, new IntPtr(2));//232

            //IO状态变化事件
            ipcsdk.ICE_IPCSDK_SetIOEventCallBack(pUid[2], onIOEvent, new IntPtr(2));

            strIp[2] = textBoxIP3.Text;
            buttonConnect3.Enabled = false;
            buttonDisconnect3.Enabled = true;
            button_talk3.Enabled = true;
            button_trigger3.Enabled = true;
            button_openGate3.Enabled = true;
            button_reboot3.Enabled = true;
            buttonSyncTime3.Enabled = true;
            buttonSPortSend3.Enabled = true;
            buttonCapture3.Enabled = true;
            buttonRecord3.Enabled = true;
            button_WR3.Enabled = true;
            button_network3.Enabled = true;
            button_openGate2_3.Enabled = true;
            button_broadcast3.Enabled = true;
            button_broadcastGroup3.Enabled = true;
            button_WBinary3.Enabled = true;
            button_RBinary3.Enabled = true;
            button_RS232_3.Enabled = true;
            button_cameraInfo3.Enabled = true;
            button_getIOState3.Enabled = true;
            button_getVehicleInfo3.Enabled = true;
            button_getPayInfo3.Enabled = true;
            button_settingMore3.Enabled = true;

            bPreview[2] = true;
            bClose[2] = false;
        }

        private void buttonDisconnect3_Click(object sender, EventArgs e)
        {
            if (pUid[2] == IntPtr.Zero)
                return;

            bClose[2] = true;
            if (bTalk[2])//在进行对讲
            {
                ipcsdk.ICE_IPCSDK_EndTalk(pUid[2]);//结束对讲
                button_talk3.Text = "对讲";
                bTalk[2] = false;
            }

            if (bRecord[2])//在进行录像
            {
                buttonRecord3.Text = "开始录像";
                bRecord[2] = false;
                if (null != mythread[2])
                {
                    mythread[2].Abort();
                    mythread[2] = null;
                }
                ipcsdk.ICE_IPCSDK_StopRecord(pUid[2]);//结束录像
            }

            mutexThread.WaitOne();
            ipcsdk.ICE_IPCSDK_Close(pUid[2]);//断开连接
            pUid[2] = IntPtr.Zero;
            mutexThread.ReleaseMutex();

            if (bPreview[2])
            {
                buttonStartVideo3.Text = "开始视频";
                bPreview[2] = false;
            }

            labelStatus3.Text = "离线";
            frame_count[2] = 0;
            nCurrentStatus[2] = 0;
            nStatus[2] = 0;

            buttonConnect3.Enabled = true;
            buttonDisconnect3.Enabled = false;
            button_talk3.Enabled = false;
            button_trigger3.Enabled = false;
            button_openGate3.Enabled = false;
            button_reboot3.Enabled = false;
            buttonSyncTime3.Enabled = false;
            buttonSPortSend3.Enabled = false;
            buttonCapture3.Enabled = false;
            buttonRecord3.Enabled = false;
            buttonStartVideo3.Enabled = false;
            button_WR3.Enabled = false;
            button_network3.Enabled = false;
            button_openGate2_3.Enabled = false;
            button_broadcast3.Enabled = false;
            button_broadcastGroup3.Enabled = false;
            button_WBinary3.Enabled = false;
            button_RBinary3.Enabled = false;
            button_RS232_3.Enabled = false;
            button_cameraInfo3.Enabled = false;
            button_getIOState3.Enabled = false;
            button_getVehicleInfo3.Enabled = false;
            button_getPayInfo3.Enabled = false;
            button_settingMore3.Enabled = false;
        }

        //第四路，连接相机，提供了三个连接相机接口的调用方法
        /*
         * 连接接口使用说明：
         * 连接接口共6个：不带密码的：ICE_IPCSDK_OpenPreview， ICE_IPCSDK_Open， ICE_IPCSDK_OpenDevice
         *              带密码的：ICE_IPCSDK_OpenPreview_Passwd， ICE_IPCSDK_Open_Passwd， ICE_IPCSDK_OpenDevice_Passwd
         * 1.当需要视频时，推荐使用：ICE_IPCSDK_OpenPreview；如果是加密相机，则使用ICE_IPCSDK_OpenPreview_Passwd
         * 2.不需要视频时，推荐使用：ICE_IPCSDK_OpenDevice；如果是加密相机，则使用ICE_IPCSDK_OpenDevice_Passwd
         * 3.需要自己做视频显示时，使用：ICE_IPCSDK_Open；如果是加密相机，则使用ICE_IPCSDK_Open_Passwd
         */
        private void buttonConnect4_Click(object sender, EventArgs e)
        {
            if (radioButton_Preview.Checked == true)//选择连接方式为：视频预览
            {
                IntPtr videoHwnd = pictureBox4.Handle;
                
                if (videoHwnd != IntPtr.Zero)
                {
                    if (checkBoxPassword.Checked == true)//使用密码连接
                    {
                        //使用带密码的接口连接相机，并且设置车牌识别数据回调onPlate
                        pUid[3] = ipcsdk.ICE_IPCSDK_OpenPreview_Passwd(textBoxIP4.Text, textBoxPassword.Text, 1, 1, (uint)videoHwnd, onPlate, new IntPtr(3));
                        if (pUid[3] == IntPtr.Zero)
                        {
                            MessageBox.Show("相机4连接失败，密码错误或者网络不好！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        //使用不带密码的接口连接相机
                        pUid[3] = ipcsdk.ICE_IPCSDK_OpenPreview(textBoxIP4.Text, 1, 1, (uint)videoHwnd, onPlate, new IntPtr(3));
                        if (pUid[3] == IntPtr.Zero)
                        {
                            MessageBox.Show("相机4连接失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("未获得视频播放窗口");
                    return;
                }
                buttonStartVideo4.Enabled = true;
                buttonStartVideo4.Text = "结束视频";
            }
            else if (radioButton_Frame.Checked == true)//选择连接方法为：图像解码
            {
                if (checkBoxPassword.Checked == true)//使用密码连接
                {
                    //调用带密码的接口连接相机
                    pUid[3] = ipcsdk.ICE_IPCSDK_Open_Passwd(textBoxIP4.Text, textBoxPassword.Text, 1, 554, 8117, 8080, 1, 0, IntPtr.Zero, 0, IntPtr.Zero);
                    if (pUid[3] == IntPtr.Zero)
                    {
                        MessageBox.Show("相机4连接失败，密码错误或者网络不好！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    //调用不带密码的接口连接相机
                    pUid[3] = ipcsdk.ICE_IPCSDK_Open(textBoxIP4.Text, 1, 554, 8117, 8080, 1, 0, IntPtr.Zero, 0, IntPtr.Zero);
                    if (pUid[3] == IntPtr.Zero)
                    {
                        MessageBox.Show("相机4连接失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                //设置获得解码出的一帧图像的相关回调函数
                ipcsdk.ICE_IPCSDK_SetFrameCallback(pUid[3], onFrame, new IntPtr(3));
                //设置获取车牌识别数据的回调函数
                ipcsdk.ICE_IPCSDK_SetPlateCallback(pUid[3], onPlate, new IntPtr(3));
            }
            else if (radioButtonOnlyConn.Checked == true)//选择连接方式为：连接与码流分开
            {
                if (checkBoxPassword.Checked == true)//使用密码连接
                {
                    //调用带密码的连接接口
                    pUid[3] = ipcsdk.ICE_IPCSDK_OpenDevice_Passwd(textBoxIP4.Text,textBoxPassword.Text);
                    if (pUid[3] == IntPtr.Zero)
                    {
                        MessageBox.Show("相机4连接失败，密码错误或者网络不好！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                else
                {
                    //调用不带密码的连接接口
                    pUid[3] = ipcsdk.ICE_IPCSDK_OpenDevice(textBoxIP4.Text);
                    if (pUid[3] == IntPtr.Zero)
                    {
                        MessageBox.Show("相机4连接失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                

                IntPtr videoHwnd = pictureBox4.Handle;
                if (videoHwnd != IntPtr.Zero)
                {
                    //连接视频，因为ICE_IPCSDK_OpenDevice不带视频流；如果不需要视频，可不调用该接口
                    UInt32 ret = ipcsdk.ICE_IPCSDK_StartStream(pUid[3], 1, (UInt32)videoHwnd);
                    if (ret == 0)
                    {
                        ipcsdk.ICE_IPCSDK_StopStream(pUid[3]);//连接视频失败，调用断开视频接口释放资源
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("未获得视频播放窗口");
                    return;
                }
                ipcsdk.ICE_IPCSDK_SetPlateCallback(pUid[3], onPlate, new IntPtr(3));//设置车牌识别数据回调
                buttonStartVideo4.Enabled = true;
                buttonStartVideo4.Text = "结束视频";
            }


            //设置断网续传回调
            ipcsdk.ICE_IPCSDK_SetPastPlateCallBack(pUid[3], onPastPlate, new IntPtr(3));

            //设置RS485透明串口回调
            ipcsdk.ICE_IPCSDK_SetSerialPortCallBack(pUid[3], onSerialPort, new IntPtr(3));//485
            //设置RS232透明串口回调
            ipcsdk.ICE_IPCSDK_SetSerialPortCallBack_RS232(pUid[3], onSerialPortRS232, new IntPtr(3));//232

            //IO状态变化事件
            ipcsdk.ICE_IPCSDK_SetIOEventCallBack(pUid[3], onIOEvent, new IntPtr(3));

            strIp[3] = textBoxIP4.Text;
            buttonConnect4.Enabled = false;
            buttonDisconnect4.Enabled = true;
            button_talk4.Enabled = true;
            button_trigger4.Enabled = true;
            button_openGate4.Enabled = true;
            button_reboot4.Enabled = true;
            buttonSyncTime4.Enabled = true;
            buttonSPortSend4.Enabled = true;
            buttonCapture4.Enabled = true;
            buttonRecord4.Enabled = true;
            button_WR4.Enabled = true;
            button_network4.Enabled = true;
            button_openGate2_4.Enabled = true;
            button_broadcast4.Enabled = true;
            button_broadcastGroup4.Enabled = true;
            button_WBinary4.Enabled = true;
            button_RBinary4.Enabled = true;
            button_RS232_4.Enabled = true;
            button_cameraInfo4.Enabled = true;
            button_getIOState4.Enabled = true;
            button_getVehicleInfo4.Enabled = true;
            button_getPayInfo4.Enabled = true;
            button_settingMore4.Enabled = true;

            bPreview[3] = true;
            bClose[3] = false;
        }

        private void buttonDisconnect4_Click(object sender, EventArgs e)
        {
            if (pUid[3] == IntPtr.Zero)
                return;

            bClose[3] = true;
            if (bTalk[3])//在进行对讲
            {
                ipcsdk.ICE_IPCSDK_EndTalk(pUid[3]);//结束对讲
                button_talk4.Text = "对讲";
                bTalk[3] = false;
            }

            if (bRecord[3])//在进行录像
            {
                buttonRecord4.Text = "开始录像";
                bRecord[3] = false;
                if (null != mythread[3])
                {
                    mythread[3].Abort();
                    mythread[3] = null;
                }
                ipcsdk.ICE_IPCSDK_StopRecord(pUid[3]);//结束录像
            }

            mutexThread.WaitOne();
            ipcsdk.ICE_IPCSDK_Close(pUid[3]);//断开连接
            pUid[3] = IntPtr.Zero;
            mutexThread.ReleaseMutex();

            if (bPreview[3])
            {
                buttonStartVideo4.Text = "开始视频";
                bPreview[3] = false;
            }

            labelStatus4.Text = "离线";
            frame_count[3] = 0;
            nCurrentStatus[3] = 0;
            nStatus[3] = 0;

            buttonConnect4.Enabled = true;
            buttonDisconnect4.Enabled = false;
            button_talk4.Enabled = false;
            button_trigger4.Enabled = false;
            button_openGate4.Enabled = false;
            button_reboot4.Enabled = false;
            buttonSyncTime4.Enabled = false;
            buttonSPortSend4.Enabled = false;
            buttonCapture4.Enabled = false;
            buttonRecord4.Enabled = false;
            buttonStartVideo4.Enabled = false;
            button_WR4.Enabled = false;
            button_network4.Enabled = false;
            button_openGate2_4.Enabled = false;
            button_broadcast4.Enabled = false;
            button_broadcastGroup4.Enabled = false;
            button_WBinary4.Enabled = false;
            button_RBinary4.Enabled = false;
            button_RS232_4.Enabled = false;
            button_cameraInfo4.Enabled = false;
            button_getIOState4.Enabled = false;
            button_getVehicleInfo4.Enabled = false;
            button_getPayInfo4.Enabled = false;
            button_settingMore4.Enabled = false;
        }

        private void button_openGate_Click(object sender, EventArgs e)
        {
            if (pUid[0] != IntPtr.Zero)
            {
                ipcsdk.ICE_IPCSDK_OpenGate(pUid[0]);//开闸
            }
        }

        private void button_openGate2_Click(object sender, EventArgs e)
        {
            if (pUid[1] != IntPtr.Zero)
            {
                ipcsdk.ICE_IPCSDK_OpenGate(pUid[1]);//开闸
            }
        }

        private void button_openGate3_Click(object sender, EventArgs e)
        {
            if (pUid[2] != IntPtr.Zero)
            {
                ipcsdk.ICE_IPCSDK_OpenGate(pUid[2]);//开闸
            }
        }

        private void button_openGate4_Click(object sender, EventArgs e)
        {
            if (pUid[3] != IntPtr.Zero)
            {
                ipcsdk.ICE_IPCSDK_OpenGate(pUid[3]);//开闸
            }
        }

        private void button_trigger_Click(object sender, EventArgs e)
        {
            if (pUid[0] != IntPtr.Zero)
            {
                StringBuilder strNum = new StringBuilder(32);
                StringBuilder strColor = new StringBuilder(64);
                uint len = 0;
                //IntPtr pLen = Marshal.AllocHGlobal(32);
                byte[] pdata = new byte[1048576];
                uint success = ipcsdk.ICE_IPCSDK_Trigger(pUid[0], strNum, strColor, pdata, 1048576, ref len);//软触发
                //if (1 == success && len > 0)
                //{
                //    if (len > 0)
                //    {
                //        byte[] datajpg2 = new byte[len];
                //        Array.Copy(pdata, 0, datajpg2, 0, datajpg2.Length);//拷贝图片数据
                //        storePic(datajpg2, textBoxIP1.Text, strNum.ToString(), false, 0);//存图
                //    }
                //    labelPlate1.Text = count[0] + " " + strNum.ToString() + " " + strColor.ToString();
                //    count[0]++;
                //}
                pdata = null;
                strNum = null;
                strColor = null;
            }

        }

        private void button_trigger2_Click(object sender, EventArgs e)
        {
            if (pUid[1] != IntPtr.Zero)
            {
                StringBuilder strNum = new StringBuilder(32); 
                StringBuilder strColor = new StringBuilder(64);
                uint len = 0;
                byte[] pdata = new byte[1048576];
                uint success = ipcsdk.ICE_IPCSDK_Trigger(pUid[1], strNum, strColor, pdata, 1048576, ref len);//软触发
                //if (1 == success)
                //{
                //    if (len > 0)
                //    {
                //        byte[] datajpg2 = new byte[len];
                //        Array.Copy(pdata, 0, datajpg2, 0, datajpg2.Length);//拷贝图片数据
                //        storePic(datajpg2, textBoxIP.Text, strNum.ToString(), false);//存图
                //    }
                //    labelPlate.Text = count[1] + " " + strNum.ToString() + " " + strColor.ToString();
                //    count[1]++;
                //}
                pdata = null;
                strNum = null;
                strColor = null;
            }
        }

        private void button_trigger3_Click(object sender, EventArgs e)
        {
            if (pUid[2] != IntPtr.Zero)
            {
                StringBuilder strNum = new StringBuilder(32);;
                StringBuilder strColor = new StringBuilder(64);
                uint len = 0;
                byte[] pdata = new byte[1048576];
                uint success = ipcsdk.ICE_IPCSDK_Trigger(pUid[2], strNum, strColor, pdata, 1048576, ref len);//软触发
                //if (1 == success)
                //{
                //    if (len > 0)
                //    {
                //        byte[] datajpg2 = new byte[len];
                //        Array.Copy(pdata, 0, datajpg2, 0, datajpg2.Length);//拷贝图片数据
                //        storePic(datajpg2, textBoxIP.Text, strNum.ToString(), false);//存图
                //    }
                //    labelPlate.Text = count[2] + " " + strNum.ToString() + " " + strColor.ToString();
                //    count[2]++;
                //}
                pdata = null;
                strNum = null;
                strColor = null;
            }
        }

        private void button_trigger4_Click(object sender, EventArgs e)
        {
            if (pUid[3] != IntPtr.Zero)
            {
                StringBuilder strNum = new StringBuilder(32); 
                StringBuilder strColor = new StringBuilder(64);
                uint len = 0;
                byte[] pdata = new byte[1048576];
                uint success = ipcsdk.ICE_IPCSDK_Trigger(pUid[3], strNum, strColor, pdata, 1048576, ref len);//软触发
                //if (1 == success)
                //{
                //    if (len > 0)
                //    {
                //        byte[] datajpg2 = new byte[len];
                //        Array.Copy(pdata, 0, datajpg2, 0, datajpg2.Length);//拷贝图片数据
                //        storePic(datajpg2, textBoxIP.Text, strNum.ToString(), false);//存图
                //    }
                //    labelPlate.Text = count[3] + " " + strNum.ToString() + " " + strColor.ToString();
                //    count[3]++;
                //}
                pdata = null;
                strNum = null;
                strColor = null;
            }
        }

        private void button_reboot_Click(object sender, EventArgs e)
        {
            if (pUid[0] != IntPtr.Zero)
            {
                ipcsdk.ICE_IPCSDK_Reboot(pUid[0]);//重启
            }
        }

        private void button_reboot2_Click(object sender, EventArgs e)
        {
            if (pUid[1] != IntPtr.Zero)
            {
                ipcsdk.ICE_IPCSDK_Reboot(pUid[1]);//重启
            }
        }

        private void button_reboot3_Click(object sender, EventArgs e)
        {
            if (pUid[2] != IntPtr.Zero)
            {
                ipcsdk.ICE_IPCSDK_Reboot(pUid[2]);//重启
            }
        }

        private void button_reboot4_Click(object sender, EventArgs e)
        {
            if (pUid[3] != IntPtr.Zero)
            {
                ipcsdk.ICE_IPCSDK_Reboot(pUid[3]);//重启
            }
        }

        private void button_talk_Click(object sender, EventArgs e)
        {
            if (pUid[0] != IntPtr.Zero)
            {
                if (!bTalk[0])//开始对讲
                {
                    uint success = ipcsdk.ICE_IPCSDK_BeginTalk(pUid[0]);
                    if (success == 0)
                    {
                        MessageBox.Show("对讲启动失败！");
                        return;
                    }
                    button_talk.Text = "结束对讲";
                    bTalk[0] = true;
                }
                else//结束对讲
                {
                    ipcsdk.ICE_IPCSDK_EndTalk(pUid[0]);
                    button_talk.Text = "对讲";
                    bTalk[0] = false;
                }
            }
        }

        private void button_talk2_Click(object sender, EventArgs e)
        {
            if (pUid[1] != IntPtr.Zero)
            {
                if (!bTalk[1])//开始对讲
                {
                    uint success = ipcsdk.ICE_IPCSDK_BeginTalk(pUid[1]);
                    if (success == 0)
                    {
                        MessageBox.Show("对讲启动失败！");
                        return;
                    }
                    button_talk2.Text = "结束对讲";
                    bTalk[1] = true;
                }
                else//结束对讲
                {
                    ipcsdk.ICE_IPCSDK_EndTalk(pUid[1]);
                    button_talk2.Text = "对讲";
                    bTalk[1] = false;
                }
            }
        }

        private void button_talk3_Click(object sender, EventArgs e)
        {
            if (pUid[2] != IntPtr.Zero)
            {
                if (!bTalk[2])//开始对讲
                {
                    uint success = ipcsdk.ICE_IPCSDK_BeginTalk(pUid[2]);
                    if (success == 0)
                    {
                        MessageBox.Show("对讲启动失败！");
                        return;
                    }
                    button_talk3.Text = "结束对讲";
                    bTalk[2] = true;
                }
                else//结束对讲
                {
                    ipcsdk.ICE_IPCSDK_EndTalk(pUid[2]);
                    button_talk3.Text = "对讲";
                    bTalk[2] = false;
                }
            }
        }

        private void button_talk4_Click(object sender, EventArgs e)
        {
            if (pUid[3] != IntPtr.Zero)
            {
                if (!bTalk[3])//开始对讲
                {
                    uint success = ipcsdk.ICE_IPCSDK_BeginTalk(pUid[3]);
                    if (success == 0)
                    {
                        MessageBox.Show("对讲启动失败！");
                        return;
                    }
                    button_talk4.Text = "结束对讲";
                    bTalk[3] = true;
                }
                else//结束对讲
                {
                    ipcsdk.ICE_IPCSDK_EndTalk(pUid[3]);
                    button_talk4.Text = "对讲";
                    bTalk[3] = false;
                }
            }
        }

        private void buttonSyncTime1_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == pUid[0])
                return;
            //时间同步，相机采用utc时间
            ipcsdk.ICE_IPCSDK_SyncTime(pUid[0], (UInt16)DateTime.UtcNow.Year, (byte)DateTime.UtcNow.Month,
                (byte)DateTime.UtcNow.Day, (byte)DateTime.UtcNow.Hour, (byte)DateTime.UtcNow.Minute, (byte)DateTime.UtcNow.Second);
        }

        private void buttonSyncTime2_Click(object sender, EventArgs e)
        {
            if (pUid[1] == IntPtr.Zero)
                return;
            //时间同步，相机采用utc时间
            ipcsdk.ICE_IPCSDK_SyncTime(pUid[1], (UInt16)DateTime.UtcNow.Year, (byte)DateTime.UtcNow.Month,
                (byte)DateTime.UtcNow.Day, (byte)DateTime.UtcNow.Hour, (byte)DateTime.UtcNow.Minute, (byte)DateTime.UtcNow.Second);
        }

        private void buttonSyncTime3_Click(object sender, EventArgs e)
        {
            if (pUid[2] == IntPtr.Zero)
                return;
            //时间同步，相机采用utc时间
            ipcsdk.ICE_IPCSDK_SyncTime(pUid[2], (UInt16)DateTime.UtcNow.Year, (byte)DateTime.UtcNow.Month,
                (byte)DateTime.UtcNow.Day, (byte)DateTime.UtcNow.Hour, (byte)DateTime.UtcNow.Minute, (byte)DateTime.UtcNow.Second);
        }

        private void buttonSyncTime4_Click(object sender, EventArgs e)
        {
            if (pUid[3] == IntPtr.Zero)
                return;
            //时间同步，相机采用utc时间
            ipcsdk.ICE_IPCSDK_SyncTime(pUid[3], (UInt16)DateTime.UtcNow.Year, (byte)DateTime.UtcNow.Month,
                (byte)DateTime.UtcNow.Day, (byte)DateTime.UtcNow.Hour, (byte)DateTime.UtcNow.Minute, (byte)DateTime.UtcNow.Second);
        }

        private void buttonSPortSend1_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == pUid[0])
                return;
            string strSendData = "相机:" + textBoxIP[0].Text + " send data to camera.";
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(strSendData);
            //发送RS485数据
            ipcsdk.ICE_IPCSDK_TransSerialPort(pUid[0], byteArray, (UInt32)byteArray.Length);

            //发送16进制数据,byte数组中存储的数据类似0x30,0x31,0x32...
            byte[] byteArray_16 = new byte[16];
            for (int i = 0; i < 9; i++)
            {
                byteArray_16[i] = (byte)(0x30 + i);
            }
            ipcsdk.ICE_IPCSDK_TransSerialPort(pUid[0], byteArray_16, (UInt32)byteArray_16.Length);
        }

        private void buttonSPortSend2_Click(object sender, EventArgs e)
        {
            if (pUid[1] == IntPtr.Zero)
                return;
            string strSendData = "相机:" + textBoxIP[1].Text + " send data to camera.";
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(strSendData);
            //发送RS485数据
            ipcsdk.ICE_IPCSDK_TransSerialPort(pUid[1], byteArray, (UInt32)byteArray.Length);

            //发送16进制数据,byte数组中存储的数据类似0x30,0x31,0x32...
            byte[] byteArray_16 = new byte[16];
            for (int i = 0; i < 9; i++)
            {
                byteArray_16[i] = (byte)(0x30 + i);
            }
            ipcsdk.ICE_IPCSDK_TransSerialPort(pUid[1], byteArray_16, (UInt32)byteArray_16.Length);
        }

        private void buttonSPortSend3_Click(object sender, EventArgs e)
        {
            if (pUid[2] == IntPtr.Zero)
                return;
            string strSendData = "相机:" + textBoxIP[2].Text + " send data to camera.";
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(strSendData);
            //发送RS485数据
            ipcsdk.ICE_IPCSDK_TransSerialPort(pUid[2], byteArray, (UInt32)byteArray.Length);

            //发送16进制数据,byte数组中存储的数据类似0x30,0x31,0x32...
            byte[] byteArray_16 = new byte[16];
            for (int i = 0; i < 9; i++)
            {
                byteArray_16[i] = (byte)(0x30 + i);
            }
            ipcsdk.ICE_IPCSDK_TransSerialPort(pUid[2], byteArray_16, (UInt32)byteArray_16.Length);
        }

        private void buttonSPortSend4_Click(object sender, EventArgs e)
        {
            if (pUid[3] == IntPtr.Zero)
                return;
            string strSendData = "相机:" + textBoxIP[3].Text + " send data to camera.";
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(strSendData);
            //发送RS485数据
            ipcsdk.ICE_IPCSDK_TransSerialPort(pUid[3], byteArray, (UInt32)byteArray.Length);

            //发送16进制数据,byte数组中存储的数据类似0x30,0x31,0x32...
            byte[] byteArray_16 = new byte[16];
            for (int i = 0; i < 9; i++)
            {
                byteArray_16[i] = (byte)(0x30 + i);
            }
            ipcsdk.ICE_IPCSDK_TransSerialPort(pUid[3], byteArray_16, (UInt32)byteArray_16.Length);
        }

        private void buttonCapture1_Click(object sender, EventArgs e)
        {
            if (pUid[0] != IntPtr.Zero)
            {
                uint pLen = 0;
                byte[] pdata = new byte[1048576];
                UInt32 success = ipcsdk.ICE_IPCSDK_Capture(pUid[0], pdata, 1048576, ref pLen);//获取一张抓拍图
                if (1 == success && pLen > 0)
                {
                    if (pLen > 0)
                    {
                        byte[] datajpg2 = new byte[pLen];
                        Array.Copy(pdata, 0, datajpg2, 0, datajpg2.Length);//拷贝数据
                        storePic(datajpg2, textBoxIP[0].Text, "", false, 0, null, "");//保存图片
                        datajpg2 = null;
                    }
                    string info = textBoxIP[0].Text + @"进行了只抓拍不识别的操作";
                    if (info == null)
                       return;
                    listBoxInfo.Items.Insert(0, info);//在右侧显示栏中显示
                }
                pdata = null;
            }
        }

        private void buttonCapture2_Click(object sender, EventArgs e)
        {
            if (pUid[1] != IntPtr.Zero)
            {
                uint len = 0;
                byte[] pdata = new byte[1048576];
                UInt32 success = ipcsdk.ICE_IPCSDK_Capture(pUid[1], pdata, 1048576, ref len);//获取一张抓拍图
                if (1 == success && len > 0)
                {
                    if (len > 0)
                    {
                        byte[] datajpg2 = new byte[len];
                        Array.Copy(pdata, 0, datajpg2, 0, datajpg2.Length);//拷贝数据
                        storePic(datajpg2, textBoxIP[1].Text, "", false, 0, null, "");//保存图片
                        datajpg2 = null;
                    }
                    string info = textBoxIP[1].Text + @"进行了只抓拍不识别的操作";
                    if (info == null)
                        return;
                    listBoxInfo.Items.Insert(0, info);//在右侧显示栏中显示
                }
                pdata = null;
            }
        }

        private void buttonCapture3_Click(object sender, EventArgs e)
        {
            if (pUid[2] != IntPtr.Zero)
            {
                uint len = 0;
                byte[] pdata = new byte[1048576];
                UInt32 success = ipcsdk.ICE_IPCSDK_Capture(pUid[2], pdata, 1048576, ref len);//获取一张抓拍图
                if (1 == success && len > 0)
                {
                    if (len > 0)
                    {
                        byte[] datajpg2 = new byte[len];
                        Array.Copy(pdata, 0, datajpg2, 0, datajpg2.Length);//拷贝数据
                        storePic(datajpg2, textBoxIP[2].Text, "", false, 0, null, "");//保存图片
                        datajpg2 = null;
                    }
                    string info = textBoxIP[2].Text + @"进行了只抓拍不识别的操作";
                    if (info == null)
                        return;
                    listBoxInfo.Items.Insert(0, info);//在右侧显示栏中显示
                }
                pdata = null;
            }
        }

        private void buttonCapture4_Click(object sender, EventArgs e)
        {
            if (pUid[3] != IntPtr.Zero)
            {
                uint len = 0;
                byte[] pdata = new byte[1048576];
                UInt32 success = ipcsdk.ICE_IPCSDK_Capture(pUid[3], pdata, 1048576, ref len);//获取一张抓拍图
                if (1 == success && len > 0)
                {
                    if (len > 0)
                    {
                        byte[] datajpg2 = new byte[len];
                        Array.Copy(pdata, 0, datajpg2, 0, datajpg2.Length);//拷贝数据
                        storePic(datajpg2, textBoxIP[3].Text, "", false, 0, null, "");//保存图片
                        datajpg2 = null;
                    }
                    string info = textBoxIP[3].Text + @"进行了只抓拍不识别的操作";
                    if (info == null)
                        return;
                    listBoxInfo.Items.Insert(0, info);//在右侧显示栏中显示
                }
                pdata = null;
            }
        }

        //获取录像文件名
        private string getVideoName(int nIndex)
        {
            string strDir = m_strStorePath + @"录像\" + strIp[nIndex] + @"\" + DateTime.Now.ToString("yyyyMMdd");
            if (!Directory.Exists(strDir))
            {
                Directory.CreateDirectory(strDir);
            }

            string path = strDir + @"\" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".avi";

            if (File.Exists(path))
            {
                int videoCount = 0;
                while (videoCount < 10)
                {
                    path = strDir + @"\" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + videoCount.ToString() + ".avi";
                    if (!File.Exists(path))
                    {
                        return path;
                    }
                    videoCount++;
                }
            }

            return path;
        }

        //显示相机连接状态， 打开道闸2成功，发送RS485、RS232数据成功
        public void showStatus(int index, int type)
        {
            switch(type)
            {
                case 0://连接状态
                    if (nStatus[index] == 1)
                    {
                        labelStatus[index].Text = "在线 " + strMac[index];
                    }
                    else
                        labelStatus[index].Text = "离线 " + strMac[index];
                    break;
                case 1://打开道闸数
                     textBoxGateNum[index].Text = nGateNum[index].ToString();
                    break;
                case 2://软触发数
                    textBoxTriggerNum[index].Text = nTriggerNum[index].ToString();
                    break;
                case 3://打开道闸2数
                    nGate2Num[index]++;
                    string strText = nGate2Num[index].ToString() + ": sdk" + (index+1).ToString() + " 打开道闸2成功。";
                    listBoxInfo.Items.Insert(0, strText);
                    break;
                case 4://收到rs485数据
                    nRS485Num[index]++;
                    string strTextRS485 = nRS485Num[index].ToString() + ": sdk" + (index + 1).ToString() + " 发送RS485数据成功";
                    listBoxInfo.Items.Insert(0, strTextRS485);
                    break;
                case 5://收到rs232数据
                    nRS232Num[index]++;
                    string strTextRS232 = nRS232Num[index].ToString() + ": sdk" + (index + 1).ToString() + " 发送RS232数据成功";
                    listBoxInfo.Items.Insert(0, strTextRS232);
                    break;
            }
        }

        //显示软触发状态
        public void showTriggerStatus(int index, uint nStatus)
        {
            string strText = "相机" + (index+1).ToString();
            switch (nStatus)
            {
                case 0:
                    strText += "：软触发失败";
                    break;
                case 2:
                    strText += ": 正在识别";
                    break;
                case 3:
                    strText += ": 算法未启动";
                    break;
            }

            if (strText == null)
                return;
            listBoxInfo.Items.Insert(0, strText);
        }

        //显示收到的串口数据
        public void showPortData(string strIp, uint len, int index, string data, int type)
        {
            string strText = "";
            if (type == 0)
            {
                nRecvPortCount_RS485[index]++;
                strText = nRecvPortCount_RS485[index].ToString() + ":" + strIp + "接收到RS485数据 " + len.ToString() + "字节";
            }
            else if (type == 1)
            {
                nRecvPortCount_RS232[index]++;
                strText = nRecvPortCount_RS232[index].ToString() + ":" + strIp + "接收到RS232数据 " + len.ToString() + "字节"; ;
            }

            if (data != null)
                listBoxInfo.Items.Insert(0, data);
            if (strText != null)
                listBoxInfo.Items.Insert(0, strText);
        }

        //获取连接状态线程
        private void getStatus()
        {
            while (true)
            {
                Thread.Sleep(1000);
                for (int i = 0; i < 4; i++)
                {
                    if (pUid[i] != IntPtr.Zero || bClose[i])
                    {
                        //mutexThread.WaitOne();
                        nCurrentStatus[i] = ipcsdk.ICE_IPCSDK_GetStatus(pUid[i]);//获取连接状态
                        //mutexThread.ReleaseMutex();
                        if (nCurrentStatus[i] != nStatus[i] && pUid[i] != IntPtr.Zero)
                        {
                            //mutexThread.WaitOne();
                            ipcsdk.ICE_IPCSDK_GetDevID(pUid[i], strMac[i]);//获取相机mac地址
                            //mutexThread.ReleaseMutex();
                            nStatus[i] = nCurrentStatus[i];
                            IAsyncResult syncResult = this.BeginInvoke(updateStatus, i, 0);//委托，显示连接信息
                        }
                    }
                }
            }
        }

        //打开道闸线程
        private void openGate()
        {
            while (true)
            {
                Thread.Sleep(m_nOpenInterval);
                for (int i = 0; i < 4; i++)
                {
                    if (pUid[i] == IntPtr.Zero || bClose[i])
                        continue;

                    //IntPtr ppUid = new IntPtr(UID[i]);

                    //if (ICE_IPCSDK_GetStatus(pUid[i]) == 0)
                    //    continue;

                    //mutexThread.WaitOne();
                    UInt32 success = ipcsdk.ICE_IPCSDK_OpenGate(pUid[i]);//打开道闸
                    //mutexThread.ReleaseMutex();
                    if (success == 1)
                    {
                        nGateNum[i]++;
                        IAsyncResult syncResult = this.BeginInvoke(updateStatus, i, 1);//委托，显示打开道闸相关信息
                    }                    
                }
            }
        }

        //软触发线程
        private void trigger()
        {
            while (true)
            {
                Thread.Sleep(m_nTriggerInterval);
                for (int i = 0; i < 4; i++)
                {
                    if ((pUid[i] == IntPtr.Zero) || bClose[i])
                        continue;              

                    //if (ICE_IPCSDK_GetStatus(pUid[i]) == 0)
                    //    continue;

                    //StringBuilder strNum = new StringBuilder(32);
                    //StringBuilder strColor = new StringBuilder(64);
                    //uint len = 0;
                    //byte[] pdata = new byte[1048576];

                    //mutexThread.WaitOne();
                    uint success = ipcsdk.ICE_IPCSDK_TriggerExt(pUid[i]);
                    //mutexThread.ReleaseMutex();
                    if (success == 1)
                    {
                        nTriggerNum[i]++;
                        IAsyncResult syncResult = this.BeginInvoke(updateStatus, i, 2);//委托，显示软触发相关信息
                    }
                    else
                    {
                        IAsyncResult syncResult = this.BeginInvoke(triggerStatus, i, success);//委托，显示软触发相关信息
                    }
                    //pdata = null;
                    //strNum = null;
                    //strColor = null;
                }
            }
            
        }

        //打开道闸2线程
        private void openGate2()
        {
            while (true)
            {
                Thread.Sleep(m_nOpenInterval2);
                for (int i = 0; i < 4; i++)
                {
                    if (pUid[i] == IntPtr.Zero || bClose[i])
                        continue;

                    //mutexThread.WaitOne();
                    UInt32 success = ipcsdk.ICE_IPCSDK_ControlAlarmOut(pUid[i], 1);//打开道闸2
                    //mutexThread.ReleaseMutex();
                    if (success == 1)
                    {
                        nGateNum[i]++;
                        IAsyncResult syncResult = this.BeginInvoke(updateStatus, i, 3);//委托，显示打开道闸2相关信息
                    }
                }
            }
        }

        //发送rs485数据线程
        private void sendRS485()
        {
            while (true)
            {
                Thread.Sleep(m_nRS485Interval);
                for (int i = 0; i < 4; i++)
                {
                    if (pUid[i] == IntPtr.Zero || bClose[i])
                        continue;

                    //mutexThread.WaitOne();
                    string strSendData = @"sdk(" + (i+1).ToString() + @"): send rs485 data to camera.";
                    byte[] byteArray = System.Text.Encoding.Default.GetBytes(strSendData);
                    uint success = ipcsdk.ICE_IPCSDK_TransSerialPort(pUid[i], byteArray, (UInt32)byteArray.Length);//发送rs485数据
                    //mutexThread.ReleaseMutex();
                    if (success == 1)
                    {
                        nGateNum[i]++;
                        IAsyncResult syncResult = this.BeginInvoke(updateStatus, i, 4);//委托，显示发送rs485数据相关信息
                    }
                }
            }
        }

        //发送rs232数据线程
        private void sendRS232()
        {
            while (true)
            {
                Thread.Sleep(m_nRS232Interval);
                for (int i = 0; i < 4; i++)
                {
                    if (pUid[i] == IntPtr.Zero || bClose[i])
                        continue;

                    //mutexThread.WaitOne();
                    string strSendData = @"sdk(" + (i + 1).ToString() + @"): send rs232 data to camera.";
                    byte[] byteArray = System.Text.Encoding.Default.GetBytes(strSendData);
                    uint success = ipcsdk.ICE_IPCSDK_TransSerialPort_RS232(pUid[i], byteArray, (UInt32)byteArray.Length);//发送rs232数据
                    //mutexThread.ReleaseMutex();
                    if (success == 1)
                    {
                        nGateNum[i]++;
                        IAsyncResult syncResult = this.BeginInvoke(updateStatus, i, 5);//委托，显示发送rs232数据相关信息
                    }
                }
            }
        }

        //与Form2数据交互，获取Form2设置的数据
        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            if (form2.ShowDialog() == DialogResult.OK)
            {
                loadConfig(form2.m_strStorePath, form2.m_bOpenGate, form2.m_bTrigger, form2.m_nOpenInterval, form2.m_nTriggerInterval, form2.m_nRecordInterval,
                    form2.m_bOpenGate2, form2.m_bRS485, form2.m_bRS232, form2.m_nOpenInterval2, form2.m_nRS485Interval, form2.m_nRS232Interval);
                loadOsdConfig(form2.m_nVideoOsd, form2.m_nVideoColor, form2.m_bVideoDate, form2.m_bVideoLicense, form2.m_bVideoCustom, form2.m_strVideoCustom,
                        form2.m_nJpegOsd, form2.m_nJpegColor, form2.m_bJpegDate, form2.m_bJpegAlgo, form2.m_bJpegCustom, form2.m_strJpegCustom);
                ipcsdk.ICE_IPCSDK_LogConfig(form2.m_bEnableLog, form2.m_strLogPath);
            }
            form2.Dispose();
        }
        //清零
        private void buttonPlateZero1_Click(object sender, EventArgs e)
        {
            count[0] = 0;
            labelPlate1.Text = count[0].ToString();
        }

        private void buttonGateZero1_Click(object sender, EventArgs e)
        {
            nGateNum[0] = 0;
            textBoxGateNum1.Text = nGateNum[0].ToString();
        }

        private void buttonTriggerZero1_Click(object sender, EventArgs e)
        {
            nTriggerNum[0] = 0;
            textBoxTriggerNum1.Text = nTriggerNum[0].ToString();
        }

        private void buttonPlateZero2_Click(object sender, EventArgs e)
        {
            count[1] = 0;
            labelPlate2.Text = count[1].ToString();
        }

        private void buttonGateZero2_Click(object sender, EventArgs e)
        {
            nGateNum[1] = 0;
            textBoxGateNum2.Text = nGateNum[1].ToString();
        }

        private void buttonTriggerZero2_Click(object sender, EventArgs e)
        {
            nTriggerNum[1] = 0;
            textBoxTriggerNum2.Text = nTriggerNum[1].ToString();
        }

        private void buttonPlateZero3_Click(object sender, EventArgs e)
        {
            count[2] = 0;
            labelPlate3.Text = count[2].ToString();
        }

        private void buttonGateZero3_Click(object sender, EventArgs e)
        {
            nGateNum[2] = 0;
            textBoxGateNum3.Text = nGateNum[2].ToString();
        }

        private void buttonTriggerZero3_Click(object sender, EventArgs e)
        {
            nTriggerNum[2] = 0;
            textBoxTriggerNum3.Text = nTriggerNum[2].ToString();
        }

        private void buttonPlateZero4_Click(object sender, EventArgs e)
        {
            count[3] = 0;
            labelPlate4.Text = count[3].ToString();
        }

        private void buttonGateZero4_Click(object sender, EventArgs e)
        {
            nGateNum[3] = 0;
            textBoxGateNum4.Text = nGateNum[3].ToString();
        }

        private void buttonTriggerZero4_Click(object sender, EventArgs e)
        {
            nTriggerNum[3] = 0;
            textBoxTriggerNum4.Text = nTriggerNum[3].ToString();
        }

        private void buttonRecord1_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == pUid[0])
                return;
            if (!bRecord[0])//开始录像
            {
                try
                {
                    if (null != mythread[0])
                    {
                        mythread[0].Abort();
                        mythread[0] = null;
                    }
                    string strVideoName = getVideoName(0);//获取保存录像的文件名
                    uint flag = ipcsdk.ICE_IPCSDK_StartRecord(pUid[0], strVideoName);//开始录像
                    if (flag == 0)
                        return;
                    bRecord[0] = true;
                    if (m_nRecordInterval != 0 && (null == mythread[0]))//每段录像间隔时长不为0（将录像保存为固定时长的），则开启录像线程
                    {
                        //timerRecord1.Interval = m_nRecordInterval * 60 * 1000;
                        //timerRecord1.Enabled = true;
                        mythread[0] = new Thread(new ThreadStart(record1));
                        mythread[0].Start();
                    }
                    buttonRecord1.Text = "结束录像";
                }
                catch (System.Exception ex)
                {
                    //MessageBox.Show("r" + ex.Message);
                }                
            }
            else//结束录像
            {
                try
                {
                    bRecord[0] = false;
                    ipcsdk.ICE_IPCSDK_StopRecord(pUid[0]);
                    //timerRecord1.Enabled = false;
                    if (null != mythread[0])
                    {
                        mythread[0].Abort();
                        mythread[0] = null;
                    }
                    buttonRecord1.Text = "开始录像";
                }
                catch (System.Exception ex)
                {
                    //MessageBox.Show("s" + ex.Message);
                }
                
            }
        }

        private void buttonRecord2_Click(object sender, EventArgs e)
        {
            if (pUid[1] == IntPtr.Zero)
                return;

            if (!bRecord[1])//开始录像
            {
                if (null != mythread[1])
                {
                    mythread[1].Abort();
                    mythread[1] = null;
                }
                string strVideoName = getVideoName(1);//获取保存录像的文件名
                uint flag = ipcsdk.ICE_IPCSDK_StartRecord(pUid[1], strVideoName);//开始录像

                if (flag == 0)
                    return;
                buttonRecord2.Text = "结束录像";
                bRecord[1] = true;
                if (m_nRecordInterval != 0 && (null == mythread[1]))//每段录像间隔时长不为0（将录像保存为固定时长的），则开启录像线程
                {
                    mythread[1] = new Thread(new ThreadStart(record2));
                    mythread[1].Start();
                }
            }
            else//结束录像
            {
                buttonRecord2.Text = "开始录像";
                bRecord[1] = false;
                if (null != mythread[1])
                {
                    mythread[1].Abort();
                    mythread[1] = null;
                }
                ipcsdk.ICE_IPCSDK_StopRecord(pUid[1]);
            }
        }

        //录像线程1
        private void record1()
        {
            while (true)
            {
                Thread.Sleep(m_nRecordInterval * 60 * 1000);
                if (pUid[0] == IntPtr.Zero || bClose[0])
                {
                    return;
                }

                ipcsdk.ICE_IPCSDK_StopRecord(pUid[0]);
                string strpath = getVideoName(0);
                if (strpath == "")
                    return;
                ipcsdk.ICE_IPCSDK_StartRecord(pUid[0], strpath);
            }    
        }

        //录像线程2
        private void record2()
        {
            while (true)
            {
                Thread.Sleep(m_nRecordInterval * 60 * 1000);
                if (pUid[1] == IntPtr.Zero || bClose[1])
                {
                    return;
                }
                ipcsdk.ICE_IPCSDK_StopRecord(pUid[1]);
                string strpath = getVideoName(1);
                ipcsdk.ICE_IPCSDK_StartRecord(pUid[1], strpath);
            }
        }

        //录像线程3
        private void record3()
        {
            while (true)
            {
                Thread.Sleep(m_nRecordInterval * 60 * 1000);
                if (pUid[2] == IntPtr.Zero || bClose[2])
                {
                    return;
                }
                ipcsdk.ICE_IPCSDK_StopRecord(pUid[2]);
                string strpath = getVideoName(2);
                ipcsdk.ICE_IPCSDK_StartRecord(pUid[2], strpath);
            }
        }

        //录像线程4
        private void record4()
        {
            while (true)
            {
                Thread.Sleep(m_nRecordInterval * 60 * 1000);
                if (pUid[3] == IntPtr.Zero || bClose[3])
                {
                    return;
                }
                ipcsdk.ICE_IPCSDK_StopRecord(pUid[3]);
                string strpath = getVideoName(3);
                ipcsdk.ICE_IPCSDK_StartRecord(pUid[3], strpath);
            }
        }

        private void buttonRecord3_Click(object sender, EventArgs e)
        {
            if (pUid[2] == IntPtr.Zero)
                return;

            if (!bRecord[2])//开始录像
            {
                if (null != mythread[2])
                {
                    mythread[2].Abort();
                    mythread[2] = null;
                }
                string strVideoName = getVideoName(2);//获取保存录像的文件名
                uint flag = ipcsdk.ICE_IPCSDK_StartRecord(pUid[2], strVideoName);
                if (flag == 0)
                    return;
                buttonRecord3.Text = "结束录像";
                bRecord[2] = true;
                if (m_nRecordInterval != 0 && (null == mythread[2]))//每段录像间隔时长不为0（将录像保存为固定时长的），则开启录像线程
                {
                    mythread[2] = new Thread(new ThreadStart(record3));
                    mythread[2].Start();
                }
            }
            else//结束录像
            {
                buttonRecord3.Text = "开始录像";
                bRecord[2] = false;
                if (null != mythread[2])
                {
                    mythread[2].Abort();
                    mythread[2] = null;
                }
                ipcsdk.ICE_IPCSDK_StopRecord(pUid[2]);
            }
        }

        private void buttonRecord4_Click(object sender, EventArgs e)
        {
            if (pUid[3] == IntPtr.Zero)
                return;

            if (!bRecord[3])//开始录像
            {
                if (null != mythread[3])
                {
                    mythread[3].Abort();
                    mythread[3] = null;
                }
                string strVideoName = getVideoName(3);//获取保存录像的文件名
                uint flag = ipcsdk.ICE_IPCSDK_StartRecord(pUid[3], strVideoName);
                if (flag == 0)
                    return;
                buttonRecord4.Text = "结束录像";
                bRecord[3] = true;

                if (m_nRecordInterval != 0 && (null == mythread[3]))//每段录像间隔时长不为0（将录像保存为固定时长的），则开启录像线程
                {
                    mythread[3] = new Thread(new ThreadStart(record4));
                    mythread[3].Start();
                }
            }
            else//结束录像
            {
                buttonRecord4.Text = "开始录像";
                bRecord[3] = false;
                if (null != mythread[3])
                {
                    mythread[3].Abort();
                    mythread[3] = null;
                }
                ipcsdk.ICE_IPCSDK_StopRecord(pUid[3]);
            }
        }

        private void buttonStartVideo1_Click(object sender, EventArgs e)
        {
            if (pUid[0] == IntPtr.Zero)
                return;

            if (0 == ipcsdk.ICE_IPCSDK_GetStatus(pUid[0]))//获取相机连接状态
                return;

            if (!bPreview[0])//开始视频
            {
                IntPtr videoHwnd = pictureBox1.Handle;
                if (videoHwnd != IntPtr.Zero)
                {
                    UInt32 ret = ipcsdk.ICE_IPCSDK_StartStream(pUid[0], 1, (UInt32)videoHwnd);//开始视频
                }
                buttonRecord1.Enabled = true;
                buttonStartVideo1.Text = "结束视频";
                bPreview[0] = true;
            }
            else//关闭视频
            {
                if (bRecord[0])
                {
                    buttonRecord1.Text = "开始录像";
                    bRecord[0] = false;
                    if (null != mythread[0])
                    {
                        mythread[0].Abort();
                        mythread[0] = null;
                    }
                    ipcsdk.ICE_IPCSDK_StopRecord(pUid[0]);//没有开启视频的情况下不能录像
                }
                ipcsdk.ICE_IPCSDK_StopStream(pUid[0]);//关闭视频
                buttonStartVideo1.Text = "开始视频";
                bPreview[0] = false;
                buttonRecord1.Enabled = false;
            }
        }

        private void buttonStartVideo2_Click(object sender, EventArgs e)
        {
            if (pUid[1] == IntPtr.Zero)
                return;

            if (0 == ipcsdk.ICE_IPCSDK_GetStatus(pUid[1]))
                return;

            if (!bPreview[1])//开始视频
            {
                IntPtr videoHwnd = pictureBox2.Handle;
                if (videoHwnd != IntPtr.Zero)
                {
                    UInt32 ret = ipcsdk.ICE_IPCSDK_StartStream(pUid[1], 1, (UInt32)videoHwnd);
                }
                buttonRecord2.Enabled = true;
                buttonStartVideo2.Text = "结束视频";
                bPreview[1] = true;
            }
            else//关闭视频
            {
                if (bRecord[1])
                {
                    buttonRecord2.Text = "开始录像";
                    bRecord[1] = false;
                    if (null != mythread[1])
                    {
                        mythread[1].Abort();
                        mythread[1] = null;
                    }
                    ipcsdk.ICE_IPCSDK_StopRecord(pUid[1]);//没有开启视频的情况下不能录像
                }
                ipcsdk.ICE_IPCSDK_StopStream(pUid[1]);
                buttonStartVideo2.Text = "开始视频";
                bPreview[1] = false;
                buttonRecord2.Enabled = false;
            }
        }

        private void buttonStartVideo3_Click(object sender, EventArgs e)
        {
            if (pUid[2] == IntPtr.Zero)
                return;

            if (0 == ipcsdk.ICE_IPCSDK_GetStatus(pUid[2]))
                return;

            if (!bPreview[2])//开始视频
            {
                IntPtr videoHwnd = pictureBox3.Handle;
                if (videoHwnd != IntPtr.Zero)
                {
                    UInt32 ret = ipcsdk.ICE_IPCSDK_StartStream(pUid[2], 1, (UInt32)videoHwnd);
                }
                buttonRecord3.Enabled = true;
                buttonStartVideo3.Text = "结束视频";
                bPreview[2] = true;
            }
            else//关闭视频
            {
                if (bRecord[2])
                {
                    buttonRecord3.Text = "开始录像";
                    bRecord[2] = false;
                    if (null != mythread[2])
                    {
                        mythread[2].Abort();
                        mythread[2] = null;
                    }
                    ipcsdk.ICE_IPCSDK_StopRecord(pUid[2]);//没有开启视频的情况下不能录像
                }
                ipcsdk.ICE_IPCSDK_StopStream(pUid[2]);
                buttonStartVideo3.Text = "开始视频";
                bPreview[2] = false;
                buttonRecord3.Enabled = false;
            }
        }

        private void buttonStartVideo4_Click(object sender, EventArgs e)
        {
            if (pUid[3] == IntPtr.Zero)
                return;

            if (0 == ipcsdk.ICE_IPCSDK_GetStatus(pUid[3]))
                return;

            if (!bPreview[3])//开始视频
            {
                IntPtr videoHwnd = pictureBox4.Handle;
                if (videoHwnd != IntPtr.Zero)
                {
                    UInt32 ret = ipcsdk.ICE_IPCSDK_StartStream(pUid[3], 1, (UInt32)videoHwnd);
                }
                buttonRecord4.Enabled = true;
                buttonStartVideo4.Text = "结束视频";
                bPreview[3] = true;
            }
            else//关闭视频
            {
                if (bRecord[3])
                {
                    buttonRecord4.Text = "开始录像";
                    bRecord[3] = false;
                    if (null != mythread[3])
                    {
                        mythread[3].Abort();
                        mythread[3] = null;
                    }
                    ipcsdk.ICE_IPCSDK_StopRecord(pUid[3]);//没有开启视频的情况下不能录像
                }
                ipcsdk.ICE_IPCSDK_StopStream(pUid[3]);
                buttonStartVideo4.Text = "开始视频";
                bPreview[3] = false;
                buttonRecord4.Enabled = false;
            }
        }

        //写日志
        private void writeLog(string strText)
        {
            lock (this)
            {
                FileStream fs = new FileStream("D:\\log.txt", FileMode.Append);
                StreamWriter sw = new StreamWriter(fs);
                sw.Write(strText);
                sw.Close();
                fs.Close();
            }     
        }

        private void button_WR1_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == pUid[0])
            {
                return;
            }

            string data = "相机1: 发送并收到数据（data send and recv from camera1）";
            ipcsdk.ICE_IPCSDK_WriteUserData(pUid[0], data);//写入数据

            byte[] recvData = new byte[256]; 
            ipcsdk.ICE_IPCSDK_ReadUserData(pUid[0], recvData, 256);//读取数据
            if (recvData == null)
            {
                string errorData = "收取用户数据失败";
                listBoxInfo.Items.Insert(0, errorData);
                return;
            }
            string tmp = System.Text.Encoding.Default.GetString(recvData);
            listBoxInfo.Items.Insert(0, tmp);//在界面上显示读取到的数据
        }

        private void button_WR2_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == pUid[1])
            {
                return;
            }

            string data = "相机2: 发送并收到数据（data send and recv from camera2）";
            ipcsdk.ICE_IPCSDK_WriteUserData(pUid[1], data);//写入数据

            byte[] recvData = new byte[256];
            ipcsdk.ICE_IPCSDK_ReadUserData(pUid[1], recvData, 256);//读取数据
            if (recvData == null)
            {
                string errorData = "收取用户数据失败";
                listBoxInfo.Items.Insert(0, errorData);
                return;
            }
            string tmp = System.Text.Encoding.Default.GetString(recvData);
            listBoxInfo.Items.Insert(0, tmp);//在界面上显示读取到的数据
        }

        private void button_WR3_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == pUid[2])
            {
                return;
            }

            string data = "相机3: 发送并收到数据（data send and recv from camera3）";
            ipcsdk.ICE_IPCSDK_WriteUserData(pUid[2], data);//写入数据

            byte[] recvData = new byte[256];
            ipcsdk.ICE_IPCSDK_ReadUserData(pUid[2], recvData, 256);//读取数据
            if (recvData == null)
            {
                string errorData = "收取用户数据失败";
                listBoxInfo.Items.Insert(0, errorData);
                return;
            }
            string tmp = System.Text.Encoding.Default.GetString(recvData);
            listBoxInfo.Items.Insert(0, tmp);//在界面上显示读取到的数据
        }

        private void button_WR4_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == pUid[3])
            {
                return;
            }

            string data = "相机4: 发送并收到数据（data send and recv from camera4）";
            ipcsdk.ICE_IPCSDK_WriteUserData(pUid[3], data);//写入数据

            byte[] recvData = new byte[256];
            ipcsdk.ICE_IPCSDK_ReadUserData(pUid[3], recvData, 256);//读取数据
            if (recvData == null)
            {
                string errorData = "收取用户数据失败";
                listBoxInfo.Items.Insert(0, errorData);
                return;
            }
            string tmp = System.Text.Encoding.Default.GetString(recvData);
            listBoxInfo.Items.Insert(0, tmp);//在界面上显示读取到的数据
        }

        private void button_network1_Click(object sender, EventArgs e)
        {                        
            if (IntPtr.Zero == pUid[0])
                return;

            FormNetwork form = new FormNetwork();
            uint ip = 0;
            uint mask = 0;
            uint gateway = 0;

            uint pu32IdleState = 0;
            uint pu32DelayTime = 0;
            uint reserve = 0;


            uint success = ipcsdk.ICE_IPCSDK_GetIPAddr(pUid[0], ref ip, ref mask, ref gateway);//获取相机网络参数
            if (success == 0)
            {
                MessageBox.Show("获取ip失败！");
                return;
            }
            //获取开关量输出配置
            success = ipcsdk.ICE_IPCSDK_GetAlarmOutConfig(pUid[0], 1, ref pu32IdleState, ref pu32DelayTime, ref reserve);
            if (success == 0)
            {
                MessageBox.Show("获取开关量输出配置失败！");
                return;
            }

            byte[] btIP = BitConverter.GetBytes(ip);
            byte[] btMask = BitConverter.GetBytes(mask);
            byte[] btGateway = BitConverter.GetBytes(gateway);
            for (int i = 0; i < 4; i++)
            {
                form.strIP[i] = btIP[i].ToString();
                form.strMask[i] = btMask[i].ToString();
                form.strGateway[i] = btGateway[i].ToString();
            }

            form.pu32DelayTime = pu32DelayTime;
            form.pu32IdleState = pu32IdleState;

            //触发模式
            uint u32TriggerMode = 0;
            success = ipcsdk.ICE_IPCSDK_GetTriggerMode(pUid[0], ref u32TriggerMode);
            if (success == 0)
            {
                MessageBox.Show("获取触发模式失败！");
                return;
            }
            form.u32TriggerMode = u32TriggerMode;

            //串口设置
            ICE_UART_PARAM uart_param = new ICE_UART_PARAM();
            success = ipcsdk.ICE_IPCSDK_GetUARTCfg(pUid[0], ref uart_param);
            if (0 == success)
            {
                MessageBox.Show("获取串口参数失败");
                return;
            }

            form.uart_param = uart_param;

            //识别区域
            form.nWidth = 1280;
            form.nHeight = 720;
            uint nLeft = 0;
            uint nRight = 0;
            uint nBottom = 0;
            uint nTop = 0;
            success = ipcsdk.ICE_IPCSDK_GetLoop(pUid[0], ref nLeft, ref nBottom, ref nRight, ref nTop, form.nWidth, form.nHeight);
            if (0 == success)
            {
                MessageBox.Show("获取识别区域失败");
                return;
            }
            form.nLeftx = nLeft;
            form.nRightx = nRight;
            form.nLefty = nBottom;
            form.nRighty = nTop;

            //车款识别
            int nFilterByPlate = 0, nEnableNoPlateBrand = 0, nEnableBrand = 0;
            success = ipcsdk.ICE_IPCSDK_GetVehicleBrand(pUid[0], ref nFilterByPlate, ref nEnableNoPlateBrand, ref nEnableBrand);
            if (0 == success)
            {
                MessageBox.Show("获取配置车款识别参数失败");
                return;
            }

            form.nFilterByPlate = nFilterByPlate;
            form.nEnableNoPlateBrand = nEnableNoPlateBrand;
            form.nEnableBrand = nEnableBrand;

            if (form.ShowDialog() == DialogResult.Cancel || form.nChanged == 0)
                return; 

            if ((form.pu32IdleState != pu32IdleState) || (form.pu32DelayTime != pu32DelayTime))
            {
                //设置开关量输出参数
                success = ipcsdk.ICE_IPCSDK_SetAlarmOutConfig(pUid[0], 1, form.pu32IdleState, form.pu32DelayTime, reserve);
                if (success == 0)
                    MessageBox.Show("修改开关量失败！");
            }

            if (form.u32TriggerMode != u32TriggerMode)
            {
                //修改触发模式
                success = ipcsdk.ICE_IPCSDK_SetTriggerMode(pUid[0], form.u32TriggerMode);
                if (success == 0)
                    MessageBox.Show("修改触发模式失败！");
            }  

            //修改串口参数
            if (form.nUartChange)
            {
                success = ipcsdk.ICE_IPCSDK_SetUARTCfg(pUid[0], ref form.uart_param);
                if (0 == success)
                    MessageBox.Show("设置串口参数失败");
            }

            //修改识别区域
            if (form.bLoopChange)
            {
                success = ipcsdk.ICE_IPCSDK_SetLoop(pUid[0], form.nLeftx, form.nLefty, form.nRightx, form.nRighty, form.nWidth, form.nHeight);
                if (0 == success)
                    MessageBox.Show("设置串口参数失败");
            }

            //修改车款识别
            success = ipcsdk.ICE_IPCSDK_SetVehicleBrand(pUid[0], form.nFilterByPlate, form.nEnableNoPlateBrand, form.nEnableBrand);
            if (0 == success)
                MessageBox.Show("设置配置车款识别参数失败");

            //修改ip
            if ((ip != form.uIp) || (mask != form.uMask) || (gateway != form.uGateway))
            {
                success = ipcsdk.ICE_IPCSDK_SetIPAddr(pUid[0], form.uIp, form.uMask, form.uGateway);//设置网络参数
                if (success == 0)
                    MessageBox.Show("修改IP失败！");
            }
        }

        private void button_network2_Click(object sender, EventArgs e)
        {            
            if (IntPtr.Zero == pUid[1])
                return;

            FormNetwork form = new FormNetwork();
            uint ip = 0;
            uint mask = 0;
            uint gateway = 0;

            uint pu32IdleState = 0;
            uint pu32DelayTime = 0;
            uint reserve = 0;

            uint success = ipcsdk.ICE_IPCSDK_GetIPAddr(pUid[1], ref ip, ref mask, ref gateway);//获取相机网络参数
            if (success == 0)
            {
                MessageBox.Show("获取ip失败！");
                return;
            }
            //获取开关量输出配置
            success = ipcsdk.ICE_IPCSDK_GetAlarmOutConfig(pUid[1], 1, ref pu32IdleState, ref pu32DelayTime, ref reserve);
            if (success == 0)
            {
                MessageBox.Show("获取开关量输出配置失败！");
                return;
            }

            byte[] btIP = BitConverter.GetBytes(ip);
            byte[] btMask = BitConverter.GetBytes(mask);
            byte[] btGateway = BitConverter.GetBytes(gateway);
            for (int i = 0; i < 4; i++)
            {
                form.strIP[i] = btIP[i].ToString();
                form.strMask[i] = btMask[i].ToString();
                form.strGateway[i] = btGateway[i].ToString();
            }

            form.pu32DelayTime = pu32DelayTime;
            form.pu32IdleState = pu32IdleState;

            uint u32TriggerMode = 0;
            success = ipcsdk.ICE_IPCSDK_GetTriggerMode(pUid[1], ref u32TriggerMode);
            if (success == 0)
            {
                MessageBox.Show("获取触发模式失败！");
                return;
            }
            form.u32TriggerMode = u32TriggerMode;

            //串口设置
            ICE_UART_PARAM uart_param = new ICE_UART_PARAM();
            success = ipcsdk.ICE_IPCSDK_GetUARTCfg(pUid[1], ref uart_param);
            if (0 == success)
            {
                MessageBox.Show("获取串口参数失败");
                return;
            }
            form.uart_param = uart_param;

            //识别区域
            form.nWidth = 1280;
            form.nHeight = 720;
            uint nLeft = 0;
            uint nRight = 0;
            uint nBottom = 0;
            uint nTop = 0;
            success = ipcsdk.ICE_IPCSDK_GetLoop(pUid[1], ref nLeft, ref nBottom, ref nRight, ref nTop, form.nWidth, form.nHeight);
            if (0 == success)
            {
                MessageBox.Show("获取识别区域失败");
                return;
            }
            form.nLeftx = nLeft;
            form.nRightx = nRight;
            form.nLefty = nBottom;
            form.nRighty = nTop;

            //车款识别
            int nFilterByPlate = 0, nEnableNoPlateBrand = 0, nEnableBrand = 0;
            success = ipcsdk.ICE_IPCSDK_GetVehicleBrand(pUid[1], ref nFilterByPlate, ref nEnableNoPlateBrand, ref nEnableBrand);
            if (0 == success)
            {
                MessageBox.Show("获取配置车款识别参数失败");
                return;
            }
            form.nFilterByPlate = nFilterByPlate;
            form.nEnableNoPlateBrand = nEnableNoPlateBrand;
            form.nEnableBrand = nEnableBrand;

            if (form.ShowDialog() == DialogResult.Cancel || form.nChanged == 0)
                return;

            if ((form.pu32IdleState != pu32IdleState) || (form.pu32DelayTime != pu32DelayTime))
            {
                //设置开关量输出参数
                success = ipcsdk.ICE_IPCSDK_SetAlarmOutConfig(pUid[1], 1, form.pu32IdleState, form.pu32DelayTime, reserve);
                if (success == 0)
                    MessageBox.Show("修改开关量失败！");
            }

            if (form.u32TriggerMode != u32TriggerMode)
            {
                //修改触发模式
                success = ipcsdk.ICE_IPCSDK_SetTriggerMode(pUid[1], form.u32TriggerMode);
                if (success == 0)
                    MessageBox.Show("修改触发模式失败！");
            }

            //修改串口参数
            if (form.nUartChange)
            {
                success = ipcsdk.ICE_IPCSDK_SetUARTCfg(pUid[1], ref form.uart_param);
                if (0 == success)
                    MessageBox.Show("设置串口参数失败");
            }

            //修改识别区域
            if (form.bLoopChange)
            {
                success = ipcsdk.ICE_IPCSDK_SetLoop(pUid[1], form.nLeftx, form.nLefty, form.nRightx, form.nRighty, form.nWidth, form.nHeight);
                if (0 == success)
                    MessageBox.Show("设置串口参数失败");
            }

            //修改车款识别
            success = ipcsdk.ICE_IPCSDK_SetVehicleBrand(pUid[1], form.nFilterByPlate, form.nEnableNoPlateBrand, form.nEnableBrand);
            if (0 == success)
                MessageBox.Show("设置配置车款识别参数失败");

            //修改ip
            if ((ip != form.uIp) || (mask != form.uMask) || (gateway != form.uGateway))
            {
                success = ipcsdk.ICE_IPCSDK_SetIPAddr(pUid[1], form.uIp, form.uMask, form.uGateway);//设置网络参数
                if (success == 0)
                    MessageBox.Show("修改IP失败！");
            }
        }

        private void button_network3_Click(object sender, EventArgs e)
        {           
            if (IntPtr.Zero == pUid[2])
                return;
            FormNetwork form = new FormNetwork();
            uint ip = 0;
            uint mask = 0;
            uint gateway = 0;

            uint pu32IdleState = 0;
            uint pu32DelayTime = 0;
            uint reserve = 0;

            uint success = ipcsdk.ICE_IPCSDK_GetIPAddr(pUid[2], ref ip, ref mask, ref gateway);//获取相机网络参数
            if (success == 0)
            {
                MessageBox.Show("获取ip失败！");
                return;
            }
            //获取开关量输出配置
            success = ipcsdk.ICE_IPCSDK_GetAlarmOutConfig(pUid[2], 1, ref pu32IdleState, ref pu32DelayTime, ref reserve);
            if (success == 0)
            {
                MessageBox.Show("获取开关量输出配置失败！");
                return;
            }

            byte[] btIP = BitConverter.GetBytes(ip);
            byte[] btMask = BitConverter.GetBytes(mask);
            byte[] btGateway = BitConverter.GetBytes(gateway);
            for (int i = 0; i < 4; i++)
            {
                form.strIP[i] = btIP[i].ToString();
                form.strMask[i] = btMask[i].ToString();
                form.strGateway[i] = btGateway[i].ToString();
            }

            form.pu32DelayTime = pu32DelayTime;
            form.pu32IdleState = pu32IdleState;

            uint u32TriggerMode = 0;
            success = ipcsdk.ICE_IPCSDK_GetTriggerMode(pUid[2], ref u32TriggerMode);
            if (success == 0)
            {
                MessageBox.Show("获取触发模式失败！");
                return;
            }
            form.u32TriggerMode = u32TriggerMode;

            //串口设置
            ICE_UART_PARAM uart_param = new ICE_UART_PARAM();
            success = ipcsdk.ICE_IPCSDK_GetUARTCfg(pUid[2], ref uart_param);
            if (0 == success)
            {
                MessageBox.Show("获取串口参数失败");
                return;
            }
            form.uart_param = uart_param;

            //识别区域
            form.nWidth = 1280;
            form.nHeight = 720;
            uint nLeft = 0;
            uint nRight = 0;
            uint nBottom = 0;
            uint nTop = 0;
            success = ipcsdk.ICE_IPCSDK_GetLoop(pUid[2], ref nLeft, ref nBottom, ref nRight, ref nTop, form.nWidth, form.nHeight);
            if (0 == success)
            {
                MessageBox.Show("获取识别区域失败");
                return;
            }
            form.nLeftx = nLeft;
            form.nRightx = nRight;
            form.nLefty = nBottom;
            form.nRighty = nTop;

            //车款识别
            int nFilterByPlate = 0, nEnableNoPlateBrand = 0, nEnableBrand = 0;
            success = ipcsdk.ICE_IPCSDK_GetVehicleBrand(pUid[2], ref nFilterByPlate, ref nEnableNoPlateBrand, ref nEnableBrand);
            if (0 == success)
            {
                MessageBox.Show("获取配置车款识别参数失败");
                return;
            }
            form.nFilterByPlate = nFilterByPlate;
            form.nEnableNoPlateBrand = nEnableNoPlateBrand;
            form.nEnableBrand = nEnableBrand;

            if (form.ShowDialog() == DialogResult.Cancel || form.nChanged == 0)
                return;

            if ((form.pu32IdleState != pu32IdleState) || (form.pu32DelayTime != pu32DelayTime))
            {
                //设置开关量输出参数
                success = ipcsdk.ICE_IPCSDK_SetAlarmOutConfig(pUid[2], 1, form.pu32IdleState, form.pu32DelayTime, reserve);
                if (success == 0)
                    MessageBox.Show("修改开关量失败！");
            }

            if (form.u32TriggerMode != u32TriggerMode)
            {
                //修改触发模式
                success = ipcsdk.ICE_IPCSDK_SetTriggerMode(pUid[2], form.u32TriggerMode);
                if (success == 0)
                    MessageBox.Show("修改触发模式失败！");
            }

            //修改串口参数
            if (form.nUartChange)
            {
                success = ipcsdk.ICE_IPCSDK_SetUARTCfg(pUid[2], ref form.uart_param);
                if (0 == success)
                    MessageBox.Show("设置串口参数失败");
            }

            //修改识别区域
            if (form.bLoopChange)
            {
                success = ipcsdk.ICE_IPCSDK_SetLoop(pUid[2], form.nLeftx, form.nLefty, form.nRightx, form.nRighty, form.nWidth, form.nHeight);
                if (0 == success)
                    MessageBox.Show("设置串口参数失败");
            }

            //修改车款识别
            success = ipcsdk.ICE_IPCSDK_SetVehicleBrand(pUid[2], form.nFilterByPlate, form.nEnableNoPlateBrand, form.nEnableBrand);
            if (0 == success)
                MessageBox.Show("设置配置车款识别参数失败");

            //修改ip
            if ((ip != form.uIp) || (mask != form.uMask) || (gateway != form.uGateway))
            {
                success = ipcsdk.ICE_IPCSDK_SetIPAddr(pUid[2], form.uIp, form.uMask, form.uGateway);//设置网络参数
                if (success == 0)
                    MessageBox.Show("修改IP失败！");
            }
        }

        private void button_network4_Click(object sender, EventArgs e)
        {           
            if (IntPtr.Zero == pUid[3])
                return;

            FormNetwork form = new FormNetwork();
            uint ip = 0;
            uint mask = 0;
            uint gateway = 0;

            uint pu32IdleState = 0;
            uint pu32DelayTime = 0;
            uint reserve = 0;

            uint success = ipcsdk.ICE_IPCSDK_GetIPAddr(pUid[3], ref ip, ref mask, ref gateway);//获取相机网络参数
            if (success == 0)
            {
                MessageBox.Show("获取ip失败！");
                return;
            }
            //获取开关量输出配置
            success = ipcsdk.ICE_IPCSDK_GetAlarmOutConfig(pUid[3], 1, ref pu32IdleState, ref pu32DelayTime, ref reserve);
            if (success == 0)
            {
                MessageBox.Show("获取开关量输出配置失败！");
                return;
            }

            byte[] btIP = BitConverter.GetBytes(ip);
            byte[] btMask = BitConverter.GetBytes(mask);
            byte[] btGateway = BitConverter.GetBytes(gateway);
            for (int i = 0; i < 4; i++)
            {
                form.strIP[i] = btIP[i].ToString();
                form.strMask[i] = btMask[i].ToString();
                form.strGateway[i] = btGateway[i].ToString();
            }

            form.pu32DelayTime = pu32DelayTime;
            form.pu32IdleState = pu32IdleState;

            uint u32TriggerMode = 0;
            success = ipcsdk.ICE_IPCSDK_GetTriggerMode(pUid[3], ref u32TriggerMode);
            if (success == 0)
            {
                MessageBox.Show("获取触发模式失败！");
                return;
            }
            form.u32TriggerMode = u32TriggerMode;

            //串口设置
            ICE_UART_PARAM uart_param = new ICE_UART_PARAM();
            success = ipcsdk.ICE_IPCSDK_GetUARTCfg(pUid[3], ref uart_param);
            if (0 == success)
            {
                MessageBox.Show("获取串口参数失败");
                return;
            }
            form.uart_param = uart_param;

            //识别区域
            form.nWidth = 1280;
            form.nHeight = 720;
            uint nLeft = 0;
            uint nRight = 0;
            uint nBottom = 0;
            uint nTop = 0;
            success = ipcsdk.ICE_IPCSDK_GetLoop(pUid[3], ref nLeft, ref nBottom, ref nRight, ref nTop, form.nWidth, form.nHeight);
            if (0 == success)
            {
                MessageBox.Show("获取识别区域失败");
                return;
            }
            form.nLeftx = nLeft;
            form.nRightx = nRight;
            form.nLefty = nBottom;
            form.nRighty = nTop;

            //车款识别
            int nFilterByPlate = 0, nEnableNoPlateBrand = 0, nEnableBrand = 0;
            success = ipcsdk.ICE_IPCSDK_GetVehicleBrand(pUid[3], ref nFilterByPlate, ref nEnableNoPlateBrand, ref nEnableBrand);
            if (0 == success)
            {
                MessageBox.Show("获取配置车款识别参数失败");
                return;
            }
            form.nFilterByPlate = nFilterByPlate;
            form.nEnableNoPlateBrand = nEnableNoPlateBrand;
            form.nEnableBrand = nEnableBrand;

            if (form.ShowDialog() == DialogResult.Cancel || form.nChanged == 0)
                return;

            if ((form.pu32IdleState != pu32IdleState) || (form.pu32DelayTime != pu32DelayTime))
            {
                //设置开关量输出参数
                success = ipcsdk.ICE_IPCSDK_SetAlarmOutConfig(pUid[3], 1, form.pu32IdleState, form.pu32DelayTime, reserve);
                if (success == 0)
                    MessageBox.Show("修改开关量失败！");
            }

            if (form.u32TriggerMode != u32TriggerMode)
            {
                //修改触发模式
                success = ipcsdk.ICE_IPCSDK_SetTriggerMode(pUid[3], form.u32TriggerMode);
                if (success == 0)
                    MessageBox.Show("修改触发模式失败！");
            }

            //修改串口参数
            if (form.nUartChange)
            {
                success = ipcsdk.ICE_IPCSDK_SetUARTCfg(pUid[3], ref form.uart_param);
                if (0 == success)
                    MessageBox.Show("设置串口参数失败");
            }

            //修改识别区域
            if (form.bLoopChange)
            {
                success = ipcsdk.ICE_IPCSDK_SetLoop(pUid[3], form.nLeftx, form.nLefty, form.nRightx, form.nRighty, form.nWidth, form.nHeight);
                if (0 == success)
                    MessageBox.Show("设置串口参数失败");
            }

            //修改车款识别
            success = ipcsdk.ICE_IPCSDK_SetVehicleBrand(pUid[3], form.nFilterByPlate, form.nEnableNoPlateBrand, form.nEnableBrand);
            if (0 == success)
                MessageBox.Show("设置配置车款识别参数失败");

            //修改ip
            if ((ip != form.uIp) || (mask != form.uMask) || (gateway != form.uGateway))
            {
                success = ipcsdk.ICE_IPCSDK_SetIPAddr(pUid[3], form.uIp, form.uMask, form.uGateway);//设置网络参数
                if (success == 0)
                    MessageBox.Show("修改IP失败！");
            }
        }

        //打开设备搜索窗口
        private void IPSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIpSearch form = new FormIpSearch();
            form.ShowDialog();
        }

        private void buttonOpenGate2_1_Click(object sender, EventArgs e)
        {
            if (pUid[0] != IntPtr.Zero)
            {
                ipcsdk.ICE_IPCSDK_ControlAlarmOut(pUid[0], 1);//控制IO2输出
            }
        }

        private void button_openGate2_2_Click(object sender, EventArgs e)
        {
            if (pUid[1] != IntPtr.Zero)
            {
                ipcsdk.ICE_IPCSDK_ControlAlarmOut(pUid[1], 1);//控制IO2输出
            }
        }

        private void button_openGate2_3_Click(object sender, EventArgs e)
        {
            if (pUid[2] != IntPtr.Zero)
            {
                ipcsdk.ICE_IPCSDK_ControlAlarmOut(pUid[2], 1);//控制IO2输出
            }
        }

        private void button_openGate2_4_Click(object sender, EventArgs e)
        {
            if (pUid[3] != IntPtr.Zero)
            {
                ipcsdk.ICE_IPCSDK_ControlAlarmOut(pUid[3], 1);//控制IO2输出
            }
        }

        private void button_broadcast1_Click(object sender, EventArgs e)
        {
            if (pUid[0] == IntPtr.Zero)
                return;
            ipcsdk.ICE_IPCSDK_Broadcast(pUid[0], (ushort)comboBox_BIndex1.SelectedIndex);//语音播报
        }

        private void button_broadcast2_Click(object sender, EventArgs e)
        {
            if (pUid[1] == IntPtr.Zero)
                return;
            ipcsdk.ICE_IPCSDK_Broadcast(pUid[1], (ushort)comboBox_BIndex2.SelectedIndex);//语音播报
        }

        private void button_broadcast3_Click(object sender, EventArgs e)
        {
            if (pUid[2] == IntPtr.Zero)
                return;
            ipcsdk.ICE_IPCSDK_Broadcast(pUid[2], (ushort)comboBox_BIndex3.SelectedIndex);//语音播报
        }

        private void button_broadcast4_Click(object sender, EventArgs e)
        {
            if (pUid[3] == IntPtr.Zero)
                return;
            ipcsdk.ICE_IPCSDK_Broadcast(pUid[3], (ushort)comboBox_BIndex4.SelectedIndex);//语音播报
        }

        private void button_RS232_1_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == pUid[0])
                return;
            string strSendData = "相机1:" + textBoxIP[0].Text + " send rs232 data to camera.";
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(strSendData);
            //发送RS232数据
            ipcsdk.ICE_IPCSDK_TransSerialPort_RS232(pUid[0], byteArray, (UInt32)byteArray.Length);

            //发送16进制数据,byte数组中存储的数据类似0x30,0x31,0x32...
            byte[] byteArray_16 = new byte[16];
            for (int i = 0; i < 9; i++)
            {
                byteArray_16[i] = (byte)(0x30 + i);
            }
            ipcsdk.ICE_IPCSDK_TransSerialPort_RS232(pUid[0], byteArray_16, (UInt32)byteArray_16.Length);
        }

        private void button_RS232_2_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == pUid[1])
                return;
            string strSendData = "相机2:" + textBoxIP[1].Text + " send rs232 data to camera.";
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(strSendData);
            //发送RS232数据
            ipcsdk.ICE_IPCSDK_TransSerialPort_RS232(pUid[1], byteArray, (UInt32)byteArray.Length);

            //发送16进制数据,byte数组中存储的数据类似0x30,0x31,0x32...
            byte[] byteArray_16 = new byte[16];
            for (int i = 0; i < 9; i++)
            {
                byteArray_16[i] = (byte)(0x30 + i);
            }
            ipcsdk.ICE_IPCSDK_TransSerialPort_RS232(pUid[1], byteArray_16, (UInt32)byteArray_16.Length);
        }

        private void button_RS232_3_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == pUid[2])
                return;
            string strSendData = "相机3:" + textBoxIP[2].Text + " send rs232 data to camera.";
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(strSendData);
            //发送RS232数据
            ipcsdk.ICE_IPCSDK_TransSerialPort_RS232(pUid[2], byteArray, (UInt32)byteArray.Length);

            //发送16进制数据,byte数组中存储的数据类似0x30,0x31,0x32...
            byte[] byteArray_16 = new byte[16];
            for (int i = 0; i < 9; i++)
            {
                byteArray_16[i] = (byte)(0x30 + i);
            }
            ipcsdk.ICE_IPCSDK_TransSerialPort_RS232(pUid[2], byteArray_16, (UInt32)byteArray_16.Length);
        }

        private void button_RS232_4_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == pUid[3])
                return;
            string strSendData = "相机4:" + textBoxIP[3].Text + " send rs232 data to camera.";
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(strSendData);
            //发送RS232数据
            ipcsdk.ICE_IPCSDK_TransSerialPort_RS232(pUid[3], byteArray, (UInt32)byteArray.Length);

            //发送16进制数据,byte数组中存储的数据类似0x30,0x31,0x32...
            byte[] byteArray_16 = new byte[16];
            for (int i = 0; i < 9; i++)
            {
                byteArray_16[i] = (byte)(0x30 + i);
            }
            ipcsdk.ICE_IPCSDK_TransSerialPort_RS232(pUid[3], byteArray_16, (UInt32)byteArray_16.Length);
        }

        private void textBox_offset_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex r = new Regex("^[0-9]{1,}$");
            if (e.KeyChar != (char)8 && (!r.IsMatch(e.KeyChar.ToString())))
            {
                e.Handled = true;
            }
        }

        private void button_WBinary1_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == pUid[0])
            {
                return;
            }

            int nOffset = 0;
            uint flag = 0;
            int len = 0;

            if (textBox_offset.Text == "")
                nOffset = 0;
            else
                nOffset = Convert.ToInt32(textBox_offset.Text);

            string data = "二进制数据:send and recv from camera1.";

            byte[] recvData = new byte[4096];
            recvData.Initialize();
            ipcsdk.ICE_IPCSDK_ReadUserData(pUid[0], recvData, 4096);//读取用户数据

            for (int i = 0; i < recvData.Length; i++)
            {
                if (recvData[i] == '\0')
                    break;
                len++;
            }

            
            if (nOffset >= len)
                nOffset = len-1;
            else
            {
                int nChineseNum = 0;
                for (int i = 0; i < nOffset; i++ )
                {
                    if (recvData[i] >= 0 && recvData[i] <= 127)
                        continue;
                    else
                        nChineseNum++;//获取不是utf8格式的字节数
                }
                if (1 == nChineseNum % 2)
                    nOffset++;//如果不是utf8格式的字节数不是偶数，那么偏移量要+1，防止乱码
            }

            len = System.Text.Encoding.Default.GetByteCount(data);
            flag = ipcsdk.ICE_IPCSDK_WriteUserData_Binary(pUid[0], data, (uint)nOffset, (uint)len);//写入二进制数据
            if (flag == 0)
            {
                listBoxInfo.Items.Insert(0, "写入二进制数据失败");
                return;
            }

            Array.Clear(recvData, 0, recvData.Length);
            flag = ipcsdk.ICE_IPCSDK_ReadUserData(pUid[0], recvData, 4096);//读取用户数据
            if (flag == 0)
                listBoxInfo.Items.Insert(0, "读取数据失败");
            else
            {
                string tmp = System.Text.Encoding.Default.GetString(recvData);
                listBoxInfo.Items.Insert(0, tmp);//显示在右侧显示栏中
            }               
        }

        private void button_WBinary2_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == pUid[1])
            {
                return;
            }

            int nOffset = 0;
            uint flag = 0;
            int len = 0;

            if (textBox_offset.Text == "")
                nOffset = 0;
            else
                nOffset = Convert.ToInt32(textBox_offset.Text);

            string data = "二进制数据:send and recv from camera2.";

            byte[] recvData = new byte[4096];
            recvData.Initialize();
            ipcsdk.ICE_IPCSDK_ReadUserData(pUid[1], recvData, 4096);

            for (int i = 0; i < recvData.Length; i++)
            {
                if (recvData[i] == '\0')
                    break;
                len++;
            }


            if (nOffset >= len)
                nOffset = len - 1;
            else
            {
                int nChineseNum = 0;
                for (int i = 0; i < nOffset; i++)
                {
                    if (recvData[i] >= 0 && recvData[i] <= 127)
                        continue;
                    else
                        nChineseNum++;//获取不是utf8格式的字节数
                }
                if (1 == nChineseNum % 2)
                    nOffset++;//如果不是utf8格式的字节数不是偶数，那么偏移量要+1，防止乱码
            }

            len = System.Text.Encoding.Default.GetByteCount(data);
            flag = ipcsdk.ICE_IPCSDK_WriteUserData_Binary(pUid[1], data, (uint)nOffset, (uint)len);//写入二进制数据
            if (flag == 0)
            {
                listBoxInfo.Items.Insert(0, "写入二进制数据失败");
                return;
            }

            Array.Clear(recvData, 0, recvData.Length);
            flag = ipcsdk.ICE_IPCSDK_ReadUserData(pUid[1], recvData, 4096);//读取用户数据
            if (flag == 0)
                listBoxInfo.Items.Insert(0, "读取数据失败");
            else
            {
                string tmp = System.Text.Encoding.Default.GetString(recvData);
                listBoxInfo.Items.Insert(0, tmp);
            }  
        }

        private void button_WBinary3_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == pUid[2])
            {
                return;
            }

            int nOffset = 0;
            uint flag = 0;
            int len = 0;

            if (textBox_offset.Text == "")
                nOffset = 0;
            else
                nOffset = Convert.ToInt32(textBox_offset.Text);

            string data = "二进制数据:send and recv from camera3.";

            byte[] recvData = new byte[4096];
            recvData.Initialize();
            ipcsdk.ICE_IPCSDK_ReadUserData(pUid[2], recvData, 4096);

            for (int i = 0; i < recvData.Length; i++)
            {
                if (recvData[i] == '\0')
                    break;
                len++;
            }


            if (nOffset >= len)
                nOffset = len - 1;
            else
            {
                int nChineseNum = 0;
                for (int i = 0; i < nOffset; i++)
                {
                    if (recvData[i] >= 0 && recvData[i] <= 127)
                        continue;
                    else
                        nChineseNum++;//获取不是utf8格式的字节数
                }
                if (1 == nChineseNum % 2)
                    nOffset++;//如果不是utf8格式的字节数不是偶数，那么偏移量要+1，防止乱码
            }

            len = System.Text.Encoding.Default.GetByteCount(data);
            flag = ipcsdk.ICE_IPCSDK_WriteUserData_Binary(pUid[2], data, (uint)nOffset, (uint)len);//写入二进制数据
            if (flag == 0)
            {
                listBoxInfo.Items.Insert(0, "写入二进制数据失败");
                return;
            }

            Array.Clear(recvData, 0, recvData.Length);
            flag = ipcsdk.ICE_IPCSDK_ReadUserData(pUid[2], recvData, 4096);//读取用户数据
            if (flag == 0)
                listBoxInfo.Items.Insert(0, "读取数据失败");
            else
            {
                string tmp = System.Text.Encoding.Default.GetString(recvData);
                listBoxInfo.Items.Insert(0, tmp);
            }       
        }

        private void button_WBinary4_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == pUid[3])
            {
                return;
            }

            int nOffset = 0;
            uint flag = 0;
            int len = 0;

            if (textBox_offset.Text == "")
                nOffset = 0;
            else
                nOffset = Convert.ToInt32(textBox_offset.Text);

            string data = "二进制数据:send and recv from camera4.";

            byte[] recvData = new byte[4096];
            recvData.Initialize();
            ipcsdk.ICE_IPCSDK_ReadUserData(pUid[3], recvData, 4096);

            for (int i = 0; i < recvData.Length; i++)
            {
                if (recvData[i] == '\0')
                    break;
                len++;
            }


            if (nOffset >= len)
                nOffset = len - 1;
            else
            {
                int nChineseNum = 0;
                for (int i = 0; i < nOffset; i++)
                {
                    if (recvData[i] >= 0 && recvData[i] <= 127)
                        continue;
                    else
                        nChineseNum++;//获取不是utf8格式的字节数
                }
                if (1 == nChineseNum % 2)
                    nOffset++;//如果不是utf8格式的字节数不是偶数，那么偏移量要+1，防止乱码
            }

            len = System.Text.Encoding.Default.GetByteCount(data);
            flag = ipcsdk.ICE_IPCSDK_WriteUserData_Binary(pUid[3], data, (uint)nOffset, (uint)len);//写入二进制数据
            if (flag == 0)
            {
                listBoxInfo.Items.Insert(0, "写入二进制数据失败");
                return;
            }

            Array.Clear(recvData, 0, recvData.Length);
            flag = ipcsdk.ICE_IPCSDK_ReadUserData(pUid[3], recvData, 4096);//读取用户数据
            if (flag == 0)
                listBoxInfo.Items.Insert(0, "读取数据失败");
            else
            {
                string tmp = System.Text.Encoding.Default.GetString(recvData);
                listBoxInfo.Items.Insert(0, tmp);
            }         
        }

        private void button_RBinary1_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == pUid[0])
            {
                return;
            }

            int nOffset = 0;
            int recvLen = 0;

            if (textBox_offset.Text == "")
                nOffset = 0;
            else
                nOffset = Convert.ToInt32(textBox_offset.Text);

            byte[] recvData = new byte[4096];
            recvData.Initialize();
            ipcsdk.ICE_IPCSDK_ReadUserData(pUid[0], recvData, 4096);//读取用户数据

            for (int i = 0; i < recvData.Length; i++)
            {
                if (recvData[i] == '\0')
                    break;
                recvLen++;
            }


            if (nOffset > recvLen)
                nOffset = recvLen;
            else
            {
                int nChineseNum = 0;
                for (int i = 0; i < nOffset; i++)
                {
                    if (recvData[i] >= 0 && recvData[i] <= 127)
                        continue;
                    else
                        nChineseNum++;//获取不是utf8格式的字节数
                }
                if (1 == nChineseNum % 2)
                    nOffset++;//如果不是utf8格式的字节数不是偶数，那么偏移量要+1，防止乱码
            }

            Array.Clear(recvData, 0, recvData.Length);
            uint success = ipcsdk.ICE_IPCSDK_ReadUserData_Binary(pUid[0], recvData, 4096, (uint)nOffset, (uint)recvLen);//读取二进制数据
            if (success == 0)
            {
                string errorData = "收取二进制数据失败";
                listBoxInfo.Items.Insert(0, errorData);
                return;
            }
            string tmp = System.Text.Encoding.Default.GetString(recvData);
            listBoxInfo.Items.Insert(0, tmp);
        }

        private void button_RBinary2_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == pUid[1])
            {
                return;
            }

            int nOffset = 0;
            int recvLen = 0;

            if (textBox_offset.Text == "")
                nOffset = 0;
            else
                nOffset = Convert.ToInt32(textBox_offset.Text);

            byte[] recvData = new byte[4096];
            recvData.Initialize();
            ipcsdk.ICE_IPCSDK_ReadUserData(pUid[1], recvData, 4096);

            for (int i = 0; i < recvData.Length; i++)
            {
                if (recvData[i] == '\0')
                    break;
                recvLen++;
            }


            if (nOffset > recvLen)
                nOffset = recvLen;
            else
            {
                int nChineseNum = 0;
                for (int i = 0; i < nOffset; i++)
                {
                    if (recvData[i] >= 0 && recvData[i] <= 127)
                        continue;
                    else
                        nChineseNum++;//获取不是utf8格式的字节数
                }
                if (1 == nChineseNum % 2)
                    nOffset++;//如果不是utf8格式的字节数不是偶数，那么偏移量要+1，防止乱码
            }

            Array.Clear(recvData, 0, recvData.Length);
            uint success = ipcsdk.ICE_IPCSDK_ReadUserData_Binary(pUid[1], recvData, 4096, (uint)nOffset, (uint)recvLen);//读取二进制数据
            if (success == 0)
            {
                string errorData = "收取二进制数据失败";
                listBoxInfo.Items.Insert(0, errorData);
                return;
            }
            string tmp = System.Text.Encoding.Default.GetString(recvData);
            listBoxInfo.Items.Insert(0, tmp);
        }

        private void button_RBinary3_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == pUid[2])
            {
                return;
            }

            int nOffset = 0;
            int recvLen = 0;

            if (textBox_offset.Text == "")
                nOffset = 0;
            else
                nOffset = Convert.ToInt32(textBox_offset.Text);

            byte[] recvData = new byte[4096];
            recvData.Initialize();
            ipcsdk.ICE_IPCSDK_ReadUserData(pUid[2], recvData, 4096);

            for (int i = 0; i < recvData.Length; i++)
            {
                if (recvData[i] == '\0')
                    break;
                recvLen++;
            }


            if (nOffset > recvLen)
                nOffset = recvLen;
            else
            {
                int nChineseNum = 0;
                for (int i = 0; i < nOffset; i++)
                {
                    if (recvData[i] >= 0 && recvData[i] <= 127)
                        continue;
                    else
                        nChineseNum++;//获取不是utf8格式的字节数
                }
                if (1 == nChineseNum % 2)
                    nOffset++;//如果不是utf8格式的字节数不是偶数，那么偏移量要+1，防止乱码
            }

            Array.Clear(recvData, 0, recvData.Length);
            uint success = ipcsdk.ICE_IPCSDK_ReadUserData_Binary(pUid[2], recvData, 4096, (uint)nOffset, (uint)recvLen);//读取二进制数据
            if (success == 0)
            {
                string errorData = "收取二进制数据失败";
                listBoxInfo.Items.Insert(0, errorData);
                return;
            }
            string tmp = System.Text.Encoding.Default.GetString(recvData);
            listBoxInfo.Items.Insert(0, tmp);
        }

        private void button_RBinary4_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == pUid[3])
            {
                return;
            }

            int nOffset = 0;
            int recvLen = 0;

            if (textBox_offset.Text == "")
                nOffset = 0;
            else
                nOffset = Convert.ToInt32(textBox_offset.Text);

            byte[] recvData = new byte[4096];
            recvData.Initialize();
            ipcsdk.ICE_IPCSDK_ReadUserData(pUid[3], recvData, 4096);

            for (int i = 0; i < recvData.Length; i++)
            {
                if (recvData[i] == '\0')
                    break;
                recvLen++;
            }


            if (nOffset > recvLen)
                nOffset = recvLen;
            else
            {
                int nChineseNum = 0;
                for (int i = 0; i < nOffset; i++)
                {
                    if (recvData[i] >= 0 && recvData[i] <= 127)
                        continue;
                    else
                        nChineseNum++;//获取不是utf8格式的字节数
                }
                if (1 == nChineseNum % 2)
                    nOffset++;//如果不是utf8格式的字节数不是偶数，那么偏移量要+1，防止乱码
            }

            Array.Clear(recvData, 0, recvData.Length);
            uint success = ipcsdk.ICE_IPCSDK_ReadUserData_Binary(pUid[3], recvData, 4096, (uint)nOffset, (uint)recvLen);//读取二进制数据
            if (success == 0)
            {
                string errorData = "收取二进制数据失败";
                listBoxInfo.Items.Insert(0, errorData);
                return;
            }
            string tmp = System.Text.Encoding.Default.GetString(recvData);
            listBoxInfo.Items.Insert(0, tmp);
        }
        private void broadcastGroup(object msg)
        {
            int index = (int)msg;
            ipcsdk.ICE_IPCSDK_BroadcastGroup(pUid[index], textBox_groupIndex.Text);//语言组播

            threadBroadcast[index] = null;
        }
        private void button_broadcastGroup1_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == pUid[0])
                return;
            if (null == threadBroadcast[0])
            {
                threadBroadcast[0] = new Thread(new ParameterizedThreadStart(broadcastGroup));//开启语言组播线程
                threadBroadcast[0].Start(0);
            }
        }

        private void textBox_groupIndex_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex r = new Regex("^[0-9]{1,}$");
            if (e.KeyChar != (char)8 && (!r.IsMatch(e.KeyChar.ToString())) && (e.KeyChar != (char)32) 
                && (e.KeyChar != (char)44) && (e.KeyChar != (char)59))//退格键，空格，,， ;
            {
                e.Handled = true;
            }
        }

        private void button_broadcastGroup2_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == pUid[1])
                return;
            if (null == threadBroadcast[1])
            {
                threadBroadcast[1] = new Thread(new ParameterizedThreadStart(broadcastGroup));//开启语言组播线程
                threadBroadcast[1].Start(1);
            }
            
        }

        private void button_broadcastGroup3_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == pUid[2])
                return;
            if (null == threadBroadcast[2])
            {
                threadBroadcast[2] = new Thread(new ParameterizedThreadStart(broadcastGroup));//开启语言组播线程
                threadBroadcast[2].Start(2);
            }
            
        }

        private void button_broadcastGroup4_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == pUid[3])
                return;
            if (null == threadBroadcast[3])
            {
                threadBroadcast[3] = new Thread(new ParameterizedThreadStart(broadcastGroup));//开启语言组播线程
                threadBroadcast[3].Start(3);
            }
            
        }

        private void vbrCompareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormVbrCompare form = new FormVbrCompare();
            form.ShowDialog();
        }

        private void button_cameraInfo1_Click(object sender, EventArgs e)
        {
            ICE_CameraInfo info = new ICE_CameraInfo();
            uint success = ipcsdk.ICE_IPCSDK_GetCameraInfo(pUid[0], ref info);
            if (success == 1)
            {
                listBoxInfo.Items.Insert(0, "版本时间：" + info.szAppTime);
                if (0 == info.szIsEnc)
                    listBoxInfo.Items.Insert(0, "相机不加密");
                else
                    listBoxInfo.Items.Insert(0, "相机加密");
                listBoxInfo.Items.Insert(0, "相机算法版本：" + info.szAlgoVersion);
                listBoxInfo.Items.Insert(0, "相机app版本：" + info.szAppVersion);
            }
            else
            listBoxInfo.Items.Insert(0,"获取系统版本失败");
        }

        private void button_cameraInfo2_Click(object sender, EventArgs e)
        {
            ICE_CameraInfo info = new ICE_CameraInfo();
            uint success = ipcsdk.ICE_IPCSDK_GetCameraInfo(pUid[1], ref info);
            if (success == 1)
            {
                listBoxInfo.Items.Insert(0, "版本时间：" + info.szAppTime);
                if (0 == info.szIsEnc)
                    listBoxInfo.Items.Insert(0, "相机不加密");
                else
                    listBoxInfo.Items.Insert(0, "相机加密");
                listBoxInfo.Items.Insert(0, "相机算法版本：" + info.szAlgoVersion);
                listBoxInfo.Items.Insert(0, "相机app版本：" + info.szAppVersion);
            }
            else
                listBoxInfo.Items.Insert(0, "获取系统版本失败");
        }

        private void button_cameraInfo3_Click(object sender, EventArgs e)
        {
            ICE_CameraInfo info = new ICE_CameraInfo();
            uint success = ipcsdk.ICE_IPCSDK_GetCameraInfo(pUid[2], ref info);
            if (success == 1)
            {
                listBoxInfo.Items.Insert(0, "版本时间：" + info.szAppTime);
                if (0 == info.szIsEnc)
                    listBoxInfo.Items.Insert(0, "相机不加密");
                else
                    listBoxInfo.Items.Insert(0, "相机加密");
                listBoxInfo.Items.Insert(0, "相机算法版本：" + info.szAlgoVersion);
                listBoxInfo.Items.Insert(0, "相机app版本：" + info.szAppVersion);
            }
            else
                listBoxInfo.Items.Insert(0, "获取系统版本失败");
        }

        private void button_cameraInfo4_Click(object sender, EventArgs e)
        {
            ICE_CameraInfo info = new ICE_CameraInfo();
            uint success = ipcsdk.ICE_IPCSDK_GetCameraInfo(pUid[3], ref info);
            if (success == 1)
            {
                listBoxInfo.Items.Insert(0, "版本时间：" + info.szAppTime);
                if (0 == info.szIsEnc)
                    listBoxInfo.Items.Insert(0, "相机不加密");
                else
                    listBoxInfo.Items.Insert(0, "相机加密");
                listBoxInfo.Items.Insert(0, "相机算法版本：" + info.szAlgoVersion);
                listBoxInfo.Items.Insert(0, "相机app版本：" + info.szAppVersion);
            }
            else
                listBoxInfo.Items.Insert(0, "获取系统版本失败");
        }

        private void button_getIOState1_Click(object sender, EventArgs e)
        {
            if (pUid[0] == IntPtr.Zero)
                return;

            uint u32IOState = 0, reserve1 = 0, reserve2 = 0;
            uint success = 0;
            string strText = "相机1 ";
            uint i = 0;

            for (i = 0; i < 4; i++)
            {
                success = ipcsdk.ICE_IPCSDK_GetIOState(pUid[0], i, ref u32IOState, ref reserve1, ref reserve2);
                if (1 == success)
                    strText += "IO" + (i + 1).ToString() + "状态：" + u32IOState.ToString() + " ";
                else
                    strText += "IO" + (i + 1).ToString() + "状态获取失败 ";
            }

            listBoxInfo.Items.Insert(0, strText);//在右侧显示栏中显示
        }

        private void button_getIOState2_Click(object sender, EventArgs e)
        {
            if (pUid[1] == IntPtr.Zero)
                return;

            uint u32IOState = 0, reserve1 = 0, reserve2 = 0;
            uint success = 0;
            string strText = "相机2 ";
            uint i = 0;

            for (i = 0; i < 4; i++)
            {
                success = ipcsdk.ICE_IPCSDK_GetIOState(pUid[1], i, ref u32IOState, ref reserve1, ref reserve2);
                if (1 == success)
                    strText += "IO" + (i + 1).ToString() + "状态：" + u32IOState.ToString() + " ";
                else
                    strText += "IO" + (i + 1).ToString() + "状态获取失败 ";
            }

            listBoxInfo.Items.Insert(0, strText);//在右侧显示栏中显示
        }

        private void button_getIOState3_Click(object sender, EventArgs e)
        {
            if (pUid[2] == IntPtr.Zero)
                return;

            uint u32IOState = 0, reserve1 = 0, reserve2 = 0;
            uint success = 0;
            string strText = "相机3 ";
            uint i = 0;

            for (i = 0; i < 4; i++)
            {
                success = ipcsdk.ICE_IPCSDK_GetIOState(pUid[2], i, ref u32IOState, ref reserve1, ref reserve2);
                if (1 == success)
                    strText += "IO" + (i + 1).ToString() + "状态：" + u32IOState.ToString() + " ";
                else
                    strText += "IO" + (i + 1).ToString() + "状态获取失败 ";
            }

            listBoxInfo.Items.Insert(0, strText);//在右侧显示栏中显示
        }

        private void button_getIOState4_Click(object sender, EventArgs e)
        {
            if (pUid[3] == IntPtr.Zero)
                return;

            uint u32IOState = 0, reserve1 = 0, reserve2 = 0;
            uint success = 0;
            string strText = "相机4 ";
            uint i = 0;

            for (i = 0; i < 4; i++)
            {
                success = ipcsdk.ICE_IPCSDK_GetIOState(pUid[3], i, ref u32IOState, ref reserve1, ref reserve2);
                if (1 == success)
                    strText += "IO" + (i + 1).ToString() + "状态：" + u32IOState.ToString() + " ";
                else
                    strText += "IO" + (i + 1).ToString() + "状态获取失败 ";
            }

            listBoxInfo.Items.Insert(0, strText);//在右侧显示栏中显示
        }

        private void getVehicleInfo(int index)
        {
            if (pUid[index] == IntPtr.Zero)
                return;

            switch (index)
            {
                case 0:
                    button_getVehicleInfo1.Enabled = false;
                    break;
                case 1:
                    button_getVehicleInfo2.Enabled = false;
                    break;
                case 2:
                    button_getVehicleInfo3.Enabled = false;
                    break;
                case 3:
                    button_getVehicleInfo4.Enabled = false;
                    break;
            }
            
            byte[] buf = new byte[8 * 1024 * 1024];
            uint len = 0;
            String strText = "";

            uint success = ipcsdk.ICE_IPCSDK_getOfflineVehicleInfo(pUid[index], buf, 8 * 1024 * 1024, ref len);
            if (success <= 0)
            {
                strText = "相机" + (index + 1).ToString() + " 导出车辆在场信息失败！";
                MessageBox.Show(strText, "脱机计费", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (0 == len)
            {
                strText = "相机" + (index + 1).ToString() + " 车辆在场信息为空！";
                MessageBox.Show(strText, "脱机计费", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    byte[] bufTmp = new byte[len];
                    Array.Copy(buf, 0, bufTmp, 0, len);//拷贝数据
                    string strBuf = System.Text.Encoding.Default.GetString(bufTmp);
                    StreamWriter sw = new StreamWriter(@"D:\vehicleInfo_dll_csharp.csv", false, Encoding.UTF8);
                    if (null != sw)
                    {
                        sw.Write(strBuf);
                        sw.Close();
                    }
                    bufTmp = null;
                }
                catch (System.Exception ex)
                {

                }
                strText = "相机" + (index + 1).ToString() + " 导出车辆在场信息成功！";
                MessageBox.Show(strText, "脱机计费", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            buf = null;
            switch (index)
            {
                case 0:
                    button_getVehicleInfo1.Enabled = true;
                    break;
                case 1:
                    button_getVehicleInfo2.Enabled = true;
                    break;
                case 2:
                    button_getVehicleInfo3.Enabled = true;
                    break;
                case 3:
                    button_getVehicleInfo4.Enabled = true;
                    break;
            } 
        }

        void getPayInfo(int index)
        {
            if (pUid[index] == IntPtr.Zero)
                return;

            switch (index)
            {
                case 0:
                    button_getPayInfo1.Enabled = false;
                    break;
                case 1:
                    button_getPayInfo2.Enabled = false;
                    break;
                case 2:
                    button_getPayInfo3.Enabled = false;
                    break;
                case 3:
                    button_getPayInfo4.Enabled = false;
                    break;
            }

            byte[] buf = new byte[8 * 1024 * 1024];
            uint len = 0;
            String strText = "";

            uint success = ipcsdk.ICE_IPCSDK_getPayInfo(pUid[index], buf, 8 * 1024 * 1024, ref len);
            if (success <= 0)
            {
                strText = "相机" + (index + 1).ToString() + " 导出脱机计费信息失败！";
                MessageBox.Show(strText, "脱机计费", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (0 == len)
            {
                strText = "相机" + (index + 1).ToString() + " 脱机计费信息为空！";
                MessageBox.Show(strText, "脱机计费", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    byte[] bufTmp = new byte[len];
                    Array.Copy(buf, 0, bufTmp, 0, len);//拷贝数据
                    string strBuf = System.Text.Encoding.Default.GetString(bufTmp);
                    StreamWriter sw = new StreamWriter(@"D:\payInfo_dll_csharp.csv", false, Encoding.UTF8);
                    if (null != sw)
                    {
                        sw.Write(strBuf);
                        sw.Close();
                    }
                    bufTmp = null;
                }
                catch (System.Exception ex)
                {

                }
                strText = "相机" + (index + 1).ToString() + " 导出脱机计费信息成功！";
                MessageBox.Show(strText, "脱机计费", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            buf = null;
            switch (index)
            {
                case 0:
                    button_getPayInfo1.Enabled = true;
                    break;
                case 1:
                    button_getPayInfo2.Enabled = true;
                    break;
                case 2:
                    button_getPayInfo3.Enabled = true;
                    break;
                case 3:
                    button_getPayInfo4.Enabled = true;
                    break;
            } 
        }

        private void button_getVehicleInfo1_Click(object sender, EventArgs e)
        {
            getVehicleInfo(0);
        }

        private void button_getPayInfo1_Click(object sender, EventArgs e)
        {
            getPayInfo(0);
        }

        private void button_getVehicleInfo2_Click(object sender, EventArgs e)
        {
            getVehicleInfo(1);
        }

        private void button_getVehicleInfo3_Click(object sender, EventArgs e)
        {
            getVehicleInfo(2);
        }

        private void button_getVehicleInfo4_Click(object sender, EventArgs e)
        {
            getVehicleInfo(3);
        }

        private void button_getPayInfo2_Click(object sender, EventArgs e)
        {
            getPayInfo(1);
        }

        private void button_getPayInfo3_Click(object sender, EventArgs e)
        {
            getPayInfo(2);
        }

        private void button_getPayInfo4_Click(object sender, EventArgs e)
        {
            getPayInfo(3);
        }

        private void button_updateList_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.InitialDirectory = "c:\\";
            dlg.Filter = "csv文件|*.csv|文本文件|*.*|C#文件|*.cs|所有文件|*.*";
            dlg.RestoreDirectory = true;
            dlg.FilterIndex = 1;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                String strFileName = dlg.FileName;
                uint ret = ipcsdk.ICE_IPCSDK_UpdateWhiteListBatch(pUid[0], strFileName, 1);
                String[] strRet = new String[] {"网络原因导致升级失败", "升级成功", "Flash空间不足", "校验失败", "超时", "文件不存在"};
                MessageBox.Show(strRet[ret]);
            }
        }

        private void button_settingMore_Click(object sender, EventArgs e)
        {
            FormSetting formSetting = new FormSetting();
            formSetting.pUid = pUid[0];
            formSetting.ShowDialog();
        }

        private void button_settingMore2_Click(object sender, EventArgs e)
        {
            FormSetting formSetting = new FormSetting();
            formSetting.pUid = pUid[1];
            formSetting.ShowDialog();
        }

        private void button_settingMore3_Click(object sender, EventArgs e)
        {
            FormSetting formSetting = new FormSetting();
            formSetting.pUid = pUid[2];
            formSetting.ShowDialog();
        }

        private void button_settingMore4_Click(object sender, EventArgs e)
        {
            FormSetting formSetting = new FormSetting();
            formSetting.pUid = pUid[3];
            formSetting.ShowDialog();
        }
    }

    public class util
    {
        private static int width;
        private static int height;
        private static int length;
        private static int v;  //v值的起始位置
        private static int u;  //u值的起始位置
        private static int rdif, invgdif, bdif;
        private static int[] Table_fv1;
        private static int[] Table_fv2;
        private static int[] Table_fu1;
        private static int[] Table_fu2;
        private static int[] rgb = new int[3];
        private static int m, n, i, j, hfWidth;
        private static bool addHalf = true;
        private static int py;
        private static int pos, pos1;//dopod 595 图像调整
        private static byte temp;

        public static void YV12ToRGB(int iWidth, int iHeight)
        {
            Table_fv1 = new int[256] { -180, -179, -177, -176, -174, -173, -172, -170, -169, -167, -166, -165, -163, -162, -160, -159, -158, -156, -155, -153, -152, -151, -149, -148, -146, -145, -144, -142, -141, -139, -138, -137, -135, -134, -132, -131, -130, -128, -127, -125, -124, -123, -121, -120, -118, -117, -115, -114, -113, -111, -110, -108, -107, -106, -104, -103, -101, -100, -99, -97, -96, -94, -93, -92, -90, -89, -87, -86, -85, -83, -82, -80, -79, -78, -76, -75, -73, -72, -71, -69, -68, -66, -65, -64, -62, -61, -59, -58, -57, -55, -54, -52, -51, -50, -48, -47, -45, -44, -43, -41, -40, -38, -37, -36, -34, -33, -31, -30, -29, -27, -26, -24, -23, -22, -20, -19, -17, -16, -15, -13, -12, -10, -9, -8, -6, -5, -3, -2, 0, 1, 2, 4, 5, 7, 8, 9, 11, 12, 14, 15, 16, 18, 19, 21, 22, 23, 25, 26, 28, 29, 30, 32, 33, 35, 36, 37, 39, 40, 42, 43, 44, 46, 47, 49, 50, 51, 53, 54, 56, 57, 58, 60, 61, 63, 64, 65, 67, 68, 70, 71, 72, 74, 75, 77, 78, 79, 81, 82, 84, 85, 86, 88, 89, 91, 92, 93, 95, 96, 98, 99, 100, 102, 103, 105, 106, 107, 109, 110, 112, 113, 114, 116, 117, 119, 120, 122, 123, 124, 126, 127, 129, 130, 131, 133, 134, 136, 137, 138, 140, 141, 143, 144, 145, 147, 148, 150, 151, 152, 154, 155, 157, 158, 159, 161, 162, 164, 165, 166, 168, 169, 171, 172, 173, 175, 176, 178 };
            Table_fv2 = new int[256] { -92, -91, -91, -90, -89, -88, -88, -87, -86, -86, -85, -84, -83, -83, -82, -81, -81, -80, -79, -78, -78, -77, -76, -76, -75, -74, -73, -73, -72, -71, -71, -70, -69, -68, -68, -67, -66, -66, -65, -64, -63, -63, -62, -61, -61, -60, -59, -58, -58, -57, -56, -56, -55, -54, -53, -53, -52, -51, -51, -50, -49, -48, -48, -47, -46, -46, -45, -44, -43, -43, -42, -41, -41, -40, -39, -38, -38, -37, -36, -36, -35, -34, -33, -33, -32, -31, -31, -30, -29, -28, -28, -27, -26, -26, -25, -24, -23, -23, -22, -21, -21, -20, -19, -18, -18, -17, -16, -16, -15, -14, -13, -13, -12, -11, -11, -10, -9, -8, -8, -7, -6, -6, -5, -4, -3, -3, -2, -1, 0, 0, 1, 2, 2, 3, 4, 5, 5, 6, 7, 7, 8, 9, 10, 10, 11, 12, 12, 13, 14, 15, 15, 16, 17, 17, 18, 19, 20, 20, 21, 22, 22, 23, 24, 25, 25, 26, 27, 27, 28, 29, 30, 30, 31, 32, 32, 33, 34, 35, 35, 36, 37, 37, 38, 39, 40, 40, 41, 42, 42, 43, 44, 45, 45, 46, 47, 47, 48, 49, 50, 50, 51, 52, 52, 53, 54, 55, 55, 56, 57, 57, 58, 59, 60, 60, 61, 62, 62, 63, 64, 65, 65, 66, 67, 67, 68, 69, 70, 70, 71, 72, 72, 73, 74, 75, 75, 76, 77, 77, 78, 79, 80, 80, 81, 82, 82, 83, 84, 85, 85, 86, 87, 87, 88, 89, 90, 90 };
            Table_fu1 = new int[256] { -44, -44, -44, -43, -43, -43, -42, -42, -42, -41, -41, -41, -40, -40, -40, -39, -39, -39, -38, -38, -38, -37, -37, -37, -36, -36, -36, -35, -35, -35, -34, -34, -33, -33, -33, -32, -32, -32, -31, -31, -31, -30, -30, -30, -29, -29, -29, -28, -28, -28, -27, -27, -27, -26, -26, -26, -25, -25, -25, -24, -24, -24, -23, -23, -22, -22, -22, -21, -21, -21, -20, -20, -20, -19, -19, -19, -18, -18, -18, -17, -17, -17, -16, -16, -16, -15, -15, -15, -14, -14, -14, -13, -13, -13, -12, -12, -11, -11, -11, -10, -10, -10, -9, -9, -9, -8, -8, -8, -7, -7, -7, -6, -6, -6, -5, -5, -5, -4, -4, -4, -3, -3, -3, -2, -2, -2, -1, -1, 0, 0, 0, 1, 1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 7, 7, 8, 8, 8, 9, 9, 9, 10, 10, 11, 11, 11, 12, 12, 12, 13, 13, 13, 14, 14, 14, 15, 15, 15, 16, 16, 16, 17, 17, 17, 18, 18, 18, 19, 19, 19, 20, 20, 20, 21, 21, 22, 22, 22, 23, 23, 23, 24, 24, 24, 25, 25, 25, 26, 26, 26, 27, 27, 27, 28, 28, 28, 29, 29, 29, 30, 30, 30, 31, 31, 31, 32, 32, 33, 33, 33, 34, 34, 34, 35, 35, 35, 36, 36, 36, 37, 37, 37, 38, 38, 38, 39, 39, 39, 40, 40, 40, 41, 41, 41, 42, 42, 42, 43, 43 };
            Table_fu2 = new int[256] { -227, -226, -224, -222, -220, -219, -217, -215, -213, -212, -210, -208, -206, -204, -203, -201, -199, -197, -196, -194, -192, -190, -188, -187, -185, -183, -181, -180, -178, -176, -174, -173, -171, -169, -167, -165, -164, -162, -160, -158, -157, -155, -153, -151, -149, -148, -146, -144, -142, -141, -139, -137, -135, -134, -132, -130, -128, -126, -125, -123, -121, -119, -118, -116, -114, -112, -110, -109, -107, -105, -103, -102, -100, -98, -96, -94, -93, -91, -89, -87, -86, -84, -82, -80, -79, -77, -75, -73, -71, -70, -68, -66, -64, -63, -61, -59, -57, -55, -54, -52, -50, -48, -47, -45, -43, -41, -40, -38, -36, -34, -32, -31, -29, -27, -25, -24, -22, -20, -18, -16, -15, -13, -11, -9, -8, -6, -4, -2, 0, 1, 3, 5, 7, 8, 10, 12, 14, 15, 17, 19, 21, 23, 24, 26, 28, 30, 31, 33, 35, 37, 39, 40, 42, 44, 46, 47, 49, 51, 53, 54, 56, 58, 60, 62, 63, 65, 67, 69, 70, 72, 74, 76, 78, 79, 81, 83, 85, 86, 88, 90, 92, 93, 95, 97, 99, 101, 102, 104, 106, 108, 109, 111, 113, 115, 117, 118, 120, 122, 124, 125, 127, 129, 131, 133, 134, 136, 138, 140, 141, 143, 145, 147, 148, 150, 152, 154, 156, 157, 159, 161, 163, 164, 166, 168, 170, 172, 173, 175, 177, 179, 180, 182, 184, 186, 187, 189, 191, 193, 195, 196, 198, 200, 202, 203, 205, 207, 209, 211, 212, 214, 216, 218, 219, 221, 223, 225 };
            width = iWidth;
            height = iHeight;
            length = iWidth * iHeight;
            v = length;//nYLen
            u = v + (length >> 2);
            hfWidth = iWidth >> 1;
            addHalf = true;
        }

        public static bool Convert(int cwidth, int cheight, byte[] yv12y, byte[] yv12u, byte[] yv12v, ref  byte[] rgb24)
        {
            try
            {
                YV12ToRGB(cwidth, cheight);
                if (yv12y.Length == 0 || rgb24.Length == 0)
                    return false;
                m = -width;
                n = -hfWidth;
                for (int y = 0; y < height; y++)
                {
                    if (y == 139)
                    {
                    }
                    m += width;
                    if (addHalf)
                    {
                        n += hfWidth;
                        addHalf = false;
                    }
                    else
                    {
                        addHalf = true;
                    }
                    for (int x = 0; x < width; x++)
                    {
                        i = m + x;
                        j = n + (x >> 1);
                        py = (int)yv12y[i];
                        rdif = Table_fv1[(int)yv12v[j]];
                        invgdif = Table_fu1[(int)yv12u[j]] + Table_fv2[(int)yv12v[j]];
                        bdif = Table_fu2[(int)yv12u[j]];

                        rgb[2] = py + rdif;//R
                        rgb[1] = py - invgdif;//G
                        rgb[0] = py + bdif;//B

                        j = v - width - m + x;
                        i = (j << 1) + j;

                        // copy this pixel to rgb data
                        for (j = 0; j < 3; j++)
                        {

                            if (rgb[j] >= 0 && rgb[j] <= 255)
                            {
                                rgb24[i + j] = (byte)rgb[j];
                            }
                            else
                            {
                                rgb24[i + j] = (byte)((rgb[j] < 0) ? 0 : 255);
                            }

                        }
                        if (x % 4 == 3)
                        {
                            pos = (m + x - 1) * 3;
                            pos1 = (m + x) * 3;
                            temp = rgb24[pos];
                            rgb24[pos] = rgb24[pos1];
                            rgb24[pos1] = temp;

                            temp = rgb24[pos + 1];
                            rgb24[pos + 1] = rgb24[pos1 + 1];
                            rgb24[pos1 + 1] = temp;

                            temp = rgb24[pos + 2];
                            rgb24[pos + 2] = rgb24[pos1 + 2];
                            rgb24[pos1 + 2] = temp;
                        }
                    }
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            return true;
        }
    }
}
