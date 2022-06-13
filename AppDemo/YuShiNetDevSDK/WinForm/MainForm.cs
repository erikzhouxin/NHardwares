using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using System.Collections;
using System.Data.YuShiNetDevSDK;

namespace YuShiITSSDK.NWinFormUI
{
    public partial class MainForm : Form
    {
        public int m_dwPtzSpeed;
        public int gstBvecDevInfo;
        public SortedList m_VecDevInfo = new SortedList();
        public static string strModulePath = Path.GetDirectoryName(System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName);

        //返回取得字符串缓冲区的长度
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault,
                                                          StringBuilder lpReturnedString, int nSize, string lpFileName);

        public MainForm()
        {
            InitializeComponent();
            InitOSDTab();
            initDgUserInfo();
            CheckForIllegalCrossThreadCalls = false;
            int iRet = NETDEVSDK.NETDEV_Init();
            if (NETDEVSDK.TRUE != iRet)
            {
                MessageBox.Show("it is not a admin oper");
            }

            NETDEVSDK.NETDEV_EnableCarplate(0);

            _sdkCallBackFuncList.Add(this, this.AlarmMessCallBack);

            _sdkExcepCallBackFuncList.Add(this, this.ExceptionCallBack);
        }

     

        public event NETDEV_PIC_UPLOAD_PF MultiPicDataCallBackFun;
        public event NETDEV_DISCOVERY_CALLBACK_PF SetDevDiscoveryCallBackHandl;
        private static Dictionary<object, NETDEVSDK.NETDEV_AlarmMessCallBack_PF> _sdkCallBackFuncList = new Dictionary<object, NETDEVSDK.NETDEV_AlarmMessCallBack_PF>();
        private static Dictionary<object, NETDEVSDK.NETDEV_ExceptionCallBack_PF> _sdkExcepCallBackFuncList = new Dictionary<object, NETDEVSDK.NETDEV_ExceptionCallBack_PF>();


        public void Demo_AutoConnetThread()
        {
            IntPtr m_lpTmpPlayHandle = IntPtr.Zero;
            IntPtr m_lpTmpPicHandle = IntPtr.Zero;
            String strIP = IP.Text;
            int iPort = Convert.ToInt32(PORT.Text);
            String strUser = USER.Text;
            String strPasswd = PASSWORD.Text;
            IntPtr pstDevInfo = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_DEVICE_INFO_S)));
            while (true)
            {
                Thread.Sleep(2000);
                if (NETDEVSDK.FALSE != NETDEVSDK.bautoconnect)
                {
                    do
                    {

                        NETDEVSDK.m_lpDevHandle = NETDEVSDK.NETDEV_Login(strIP, (Int16)iPort, strUser, strPasswd, pstDevInfo);
                        if (IntPtr.Zero != NETDEVSDK.m_lpDevHandle)
                        {
                            IntPtr ptrAlarmCB = Marshal.GetFunctionPointerForDelegate(_sdkCallBackFuncList[this]);
                            Int32 bRet = NETDEVSDK.NETDEV_SetAlarmCallBack(NETDEVSDK.m_lpDevHandle, ptrAlarmCB, IntPtr.Zero);
                            if (NETDEVSDK.TRUE != bRet)
                            {
                                MessageBox.Show("Set alarm callback failed.");
                            }
                        }
                        Thread.Sleep(2000);
                        NETDEVSDK.bStreamConnect = NETDEVSDK.TRUE;
                    } while (IntPtr.Zero == NETDEVSDK.m_lpDevHandle);
                }

                NETDEVSDK.bautoconnect = NETDEVSDK.FALSE;

                if (NETDEVSDK.TRUE == NETDEVSDK.bStreamConnect)
                {
                    if (NETDEVSDK.lpRePlayHandle == NETDEVSDK.m_oPlayHandleMap && IntPtr.Zero != NETDEVSDK.m_oPlayHandleMap)
                    {
                        NETDEV_PREVIEWINFO_S stNetInfo = new NETDEV_PREVIEWINFO_S();

                        stNetInfo.dwChannelID = 1;
                        stNetInfo.hPlayWnd = VID_STREAM.Handle;
                        stNetInfo.dwStreamType = (Int32)NETDEV_LIVE_STREAM_INDEX_E.NETDEV_LIVE_STREAM_INDEX_MAIN;
                        stNetInfo.dwLinkMode = (Int32)NETDEV_PROTOCAL_E.NETDEV_TRANSPROTOCAL_RTPTCP;
                        m_lpTmpPlayHandle = NETDEVSDK.NETDEV_RealPlay(NETDEVSDK.m_lpDevHandle, ref stNetInfo, IntPtr.Zero, IntPtr.Zero);

                        if (IntPtr.Zero != m_lpTmpPlayHandle)
                        {
                            NETDEVSDK.m_oPlayHandleMap = m_lpTmpPlayHandle;
                        }
                    }

                    if (NETDEVSDK.lpRePicHandle == NETDEVSDK.m_oPicHandleMap && IntPtr.Zero != NETDEVSDK.m_oPicHandleMap)
                    {
                        NETDEVSDK.m_oPicHandleMap = (IntPtr)NETDEVSDK.NETDEV_StartPicStream(NETDEVSDK.m_lpDevHandle, PIC_STREAM.Handle, false, "", MultiPicDataCallBackFun, IntPtr.Zero);
                        if (IntPtr.Zero != m_lpTmpPicHandle)
                        {
                            NETDEVSDK.m_oPicHandleMap = m_lpTmpPicHandle;
                        }

                    }

                    if (IntPtr.Zero != NETDEVSDK.m_oPlayHandleMap && IntPtr.Zero != NETDEVSDK.m_oPicHandleMap)
                    {
                        NETDEVSDK.bStreamConnect = 0;
                    }
                }
            }

        }

        private void ExceptionCallBack(IntPtr lpUserID, Int32 dwType, IntPtr stAlarmInfo, IntPtr lpExpHandle, IntPtr lpUserData)
        {
            if ((int)NETDEV_EXCEPTION_TYPE_E.NETDEV_EXCEPTION_EXCHANGE == dwType)
            {
                NETDEVSDK.NETDEV_Logout(NETDEVSDK.m_lpDevHandle);
                NETDEVSDK.m_lpDevHandle = IntPtr.Zero;
                NETDEVSDK.lpRePicHandle = NETDEVSDK.m_oPicHandleMap;
                NETDEVSDK.lpRePlayHandle = NETDEVSDK.m_oPlayHandleMap;
                NETDEVSDK.bautoconnect = NETDEVSDK.TRUE;
            }
        }

        private void AlarmMessCallBack(IntPtr lpUserID, Int32 dwChannelID, NETDEV_ALARM_INFO_S stAlarmInfo, IntPtr lpBuf, Int32 dwBufLen, IntPtr lpUserData)
        {
            switch (stAlarmInfo.dwAlarmType)
            {
                case (int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_NET_FAILED:
                case (int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_NET_TIMEOUT:
                case (int)NETDEV_ALARM_TYPE_E.NETDEV_ALARM_SHAKE_FAILED:
                    {
                        NETDEVSDK.bStreamConnect = NETDEVSDK.TRUE;
                        if (NETDEVSDK.m_oPlayHandleMap == lpUserID)
                        {
                            NETDEVSDK.lpRePlayHandle = lpUserID;
                            NETDEVSDK.NETDEV_StopRealPlay(lpUserID);
                        }
                        if (NETDEVSDK.m_oPicHandleMap == lpUserID)
                        {
                            NETDEVSDK.lpRePicHandle = lpUserID;
                            NETDEVSDK.NETDEV_StopPicStream(lpUserID);
                        }
                    }
                    break;

                default:
                    {
                        break;
                    }
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {
            //first logout

            if (IntPtr.Zero != NETDEVSDK.m_lpDevHandle)
            {
                NETDEVSDK.NETDEV_StopRealPlay(NETDEVSDK.m_lpDevHandle);
            }

            NETDEVSDK.NETDEV_Logout(NETDEVSDK.m_lpDevHandle);

            NETDEVSDK.m_lpDevHandle = IntPtr.Zero;

            //then login

            String strIP = IP.Text;
            int iPort = Convert.ToInt32(PORT.Text);
            String strUser = USER.Text;
            String strPasswd = PASSWORD.Text;

            IntPtr pstDevInfo = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEV_DEVICE_INFO_S)));

            NETDEVSDK.m_lpDevHandle = NETDEVSDK.NETDEV_Login(strIP, (Int16)iPort, strUser, strPasswd, pstDevInfo);
            if (NETDEVSDK.m_lpDevHandle == IntPtr.Zero)
            {
                MessageBox.Show("Login failed,the error is [" + NETDEVSDK.NETDEV_GetLastError().ToString() + "]");
                return;
            }

            IntPtr ptrAlarmCB = Marshal.GetFunctionPointerForDelegate(_sdkCallBackFuncList[this]);

            NETDEVSDK.NETDEV_SetAlarmCallBack(NETDEVSDK.m_lpDevHandle, ptrAlarmCB, IntPtr.Zero);

            IntPtr ptrExcepCB = Marshal.GetFunctionPointerForDelegate(_sdkExcepCallBackFuncList[this]);

            NETDEVSDK.NETDEV_SetExceptionCallBack(ptrExcepCB, IntPtr.Zero);

            MessageBox.Show("Login succeed");

            Marshal.FreeHGlobal(pstDevInfo);
            m_dwPtzSpeed = 5;

            Thread hThread = new Thread(Demo_AutoConnetThread);
            hThread.IsBackground = true;
            hThread.Start();
            //创建一个线程
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }

            if (IntPtr.Zero != NETDEVSDK.m_oPlayHandleMap)
            {
                NETDEVSDK.NETDEV_StopRealPlay(NETDEVSDK.m_oPlayHandleMap);
            }
            //后期要加“判断照片流是否已停止播放”

            NETDEVSDK.NETDEV_Logout(NETDEVSDK.m_lpDevHandle);

            NETDEVSDK.m_oPlayHandleMap = IntPtr.Zero;
            NETDEVSDK.m_lpDevHandle = IntPtr.Zero;
            MessageBox.Show("Logout succeed");
            NETDEVSDK.NETDEV_Cleanup();
        }

        private void Setlog_Click(object sender, EventArgs e)
        {
            String strLogPath = LOGDIR.Text;
            int lRet = NETDEVSDK.NETDEV_SetLogPath(strLogPath);
            if (NETDEVSDK.TRUE != lRet)
            {
                MessageBox.Show("Set Log Path failed");
            }
            MessageBox.Show("Set Log Path succeed");
            return;
        }

        private void Realplay_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            int bRet;
            if (IntPtr.Zero != NETDEVSDK.m_oPlayHandleMap)
            {
                bRet = NETDEVSDK.NETDEV_StopRealPlay(NETDEVSDK.m_oPlayHandleMap);
                if (NETDEVSDK.TRUE == bRet)
                {
                    NETDEVSDK.m_oPlayHandleMap = IntPtr.Zero;
                }
            }

            NETDEV_PREVIEWINFO_S stNetInfo = new NETDEV_PREVIEWINFO_S();

            stNetInfo.dwChannelID = 1;
            stNetInfo.hPlayWnd = VID_STREAM.Handle;
            stNetInfo.dwStreamType = (Int32)NETDEV_LIVE_STREAM_INDEX_E.NETDEV_LIVE_STREAM_INDEX_MAIN;
            stNetInfo.dwLinkMode = (Int32)NETDEV_PROTOCAL_E.NETDEV_TRANSPROTOCAL_RTPTCP;//only support

            NETDEVSDK.m_oPlayHandleMap = NETDEVSDK.NETDEV_RealPlay(NETDEVSDK.m_lpDevHandle, ref stNetInfo, IntPtr.Zero, IntPtr.Zero);
            if (IntPtr.Zero == NETDEVSDK.m_oPlayHandleMap)
            {
                MessageBox.Show("Realplay failed.");
            }

        }

        private void Stopplay_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }

            if (IntPtr.Zero == NETDEVSDK.m_oPlayHandleMap)
            {
                return;
            }

            int bRet = NETDEVSDK.NETDEV_StopRealPlay(NETDEVSDK.m_oPlayHandleMap);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("Stop RealPlay failed");
            }

            NETDEVSDK.m_oPlayHandleMap = IntPtr.Zero;
        }

        private void Snapshot_Click(object sender, EventArgs e)
        {
            String strSavePath = "C:\\NetDEVSDK\\Pic\\netDev";

            if (IntPtr.Zero != NETDEVSDK.m_oPlayHandleMap)
            {
                String strOut;
                int bRet = NETDEVSDK.NETDEV_CapturePicture(NETDEVSDK.m_oPlayHandleMap, strSavePath, (int)NETDEV_PICTURE_FORMAT_E.NETDEV_PICTURE_JPG);
                if (NETDEVSDK.TRUE != bRet)
                {
                    strOut = "Get Capture failed.";
                }
                else
                {
                    strOut = "Get Capture succeed, the path is " + strSavePath + ".jpg";
                }
                MessageBox.Show(strOut);
            }
        }

        private void Switch_Click(object sender, EventArgs e)
        {
            Int32 ulRet = NETDEVSDK.NETDEV_SetOutputSwitchStatusCfg(NETDEVSDK.m_lpDevHandle);
            if (NETDEVSDK.TRUE != ulRet)
            {
                MessageBox.Show("NETDEV_SetOutputSwitchStatusCfg fail");
                return;
            }
            MessageBox.Show("Succeed");
        }

        private void GetDev_Click(object sender, EventArgs e)
        {

            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            NETDEV_DEVICE_BASICINFO_S stDeviceInfo = new NETDEV_DEVICE_BASICINFO_S();
            stDeviceInfo.szDevModel = new char[64];
            stDeviceInfo.szFirmwareVersion = new char[64];
            stDeviceInfo.szMacAddress = new char[64];
            stDeviceInfo.szSerialNum = new char[64];
            stDeviceInfo.byRes = new byte[512];

            Int32 dwBytesReturned = 0;
            Int32 lChannelID = 1;
            int bRet = NETDEVSDK.NETDEV_GetDevConfig(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_DEVICECFG, ref stDeviceInfo, Marshal.SizeOf(stDeviceInfo), ref dwBytesReturned);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("Get Device Info failed.");
            }
            else
            {
                int i;
                String DevModel = new String(stDeviceInfo.szDevModel);
                for (i = 0; i < 64; i++)
                {
                    if ('\0' == stDeviceInfo.szDevModel[i])
                    {
                        break;
                    }
                }
                DevModel = DevModel.Remove(i, 64 - i);

                String SerialNum = new String(stDeviceInfo.szSerialNum);
                for (i = 0; i < 64; i++)
                {
                    if ('\0' == stDeviceInfo.szSerialNum[i])
                    {
                        break;
                    }
                }
                SerialNum = SerialNum.Remove(i, 64 - i);

                String FirmwareVersion = new String(stDeviceInfo.szFirmwareVersion);
                for (i = 0; i < 64; i++)
                {
                    if ('\0' == stDeviceInfo.szFirmwareVersion[i])
                    {
                        break;
                    }
                }
                FirmwareVersion = FirmwareVersion.Remove(i, 64 - i);

                String MacAddress = new String(stDeviceInfo.szMacAddress);
                for (i = 0; i < 64; i++)
                {
                    if ('\0' == stDeviceInfo.szMacAddress[i])
                    {
                        break;
                    }
                }
                MacAddress = MacAddress.Remove(i, 64 - i);
                for (i = 0; i < 5; i++)
                {
                    MacAddress = MacAddress.Insert((i + 1) * 2 + i, ":");
                }
                DEV_TYPE.Text = DevModel;
                DEV_SERIAL.Text = SerialNum;
                SOFT_VER.Text = FirmwareVersion;
                MAC_ADDR.Text = MacAddress;
            }
            return;
        }
        private void GetNetcfg_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            NETDEV_NETWORKCFG_S stNetworkcfg = new NETDEV_NETWORKCFG_S();
            stNetworkcfg.szIpv4Address = new char[32];
            stNetworkcfg.szIPv4GateWay = new char[32];
            stNetworkcfg.byRes = new byte[512];

            Int32 dwBytesReturned = 0;
            int lChannelID = 1;
            int bRet = NETDEVSDK.NETDEV_GetDevConfig(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_NETWORKCFG, ref stNetworkcfg, Marshal.SizeOf(stNetworkcfg), ref dwBytesReturned);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("Get Network Interfaces failed.");
            }
            else
            {
                String Ipv4Address = new String(stNetworkcfg.szIpv4Address);
                int i;
                for (i = 0; i < 32; i++)
                {
                    if ('\0' == stNetworkcfg.szIpv4Address[i])
                    {
                        break;
                    }
                }
                Ipv4Address = Ipv4Address.Remove(i, 32 - i);
                String IPv4SubnetMask = new String(stNetworkcfg.szIPv4SubnetMask);
                for (i = 0; i < 32; i++)
                {
                    if ('\0' == stNetworkcfg.szIPv4SubnetMask[i])
                    {
                        break;
                    }
                }
                IPv4SubnetMask = IPv4SubnetMask.Remove(i, 32 - i);

                IPADDR.Text = Ipv4Address;
                SUBNETMASK.Text = IPv4SubnetMask;
                DHCP.Text = stNetworkcfg.dwIPv4DHCP.ToString();
                MTU.Text = stNetworkcfg.dwMTU.ToString();
            }
            return;
        }

        private void SetNetcfg_Click(object sender, EventArgs e)
        {
            //have some question
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            NETDEV_NETWORKCFG_S stNetworkSetcfg = new NETDEV_NETWORKCFG_S();
            stNetworkSetcfg.szIpv4Address = new char[32];
            stNetworkSetcfg.szIPv4GateWay = new char[32];
            stNetworkSetcfg.byRes = new byte[512];
            Int32 dwBytesReturned = 0;
            int lChannelID = 1;
            int bRet = NETDEVSDK.NETDEV_GetDevConfig(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_NETWORKCFG, ref stNetworkSetcfg, Marshal.SizeOf(stNetworkSetcfg), ref dwBytesReturned);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("Get Network Interfaces failed.");
                return;
            }
            if ("" != IPADDR.Text)
            {
                IPADDR.Text = (stNetworkSetcfg.szIpv4Address).ToString();

            }
            if ("" != SUBNETMASK.Text)
            {
                SUBNETMASK.Text = stNetworkSetcfg.szIPv4SubnetMask.ToString();
            }
            if ("" != DHCP.Text)
            {
                DHCP.Text = stNetworkSetcfg.dwIPv4DHCP.ToString();
            }
            if ("" != MTU.Text)
            {
                MTU.Text = stNetworkSetcfg.dwMTU.ToString();
            }

            bRet = NETDEVSDK.NETDEV_SetDevConfig(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_SET_NETWORKCFG, ref stNetworkSetcfg, Marshal.SizeOf(stNetworkSetcfg));
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("Set Network Interfaces failed.");
                return;
            }
            else
            {
                MessageBox.Show("Set Network Interfaces succeed.");
            }
            return;
        }

        private void FocusIn_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            int lChannelID = 1;
            int bRet = NETDEVSDK.NETDEV_PTZControl_Other(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_ZOOMTELE, m_dwPtzSpeed);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("PTZ control zoom-tele failed.");
            }

            return;
        }

        private void FocusOut_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            int lChannelID = 1;
            int bRet = NETDEVSDK.NETDEV_PTZControl_Other(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_ZOOMWIDE, m_dwPtzSpeed);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("PTZ control zoom-wide failed.");
            }

            return;
        }

        private void FocusFar_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            int lChannelID = 1;
            int lRet = NETDEVSDK.NETDEV_PTZControl_Other(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_FOCUSFAR, m_dwPtzSpeed);
            if (NETDEVSDK.TRUE != lRet)
            {
                MessageBox.Show("PTZ control Focus Far failed.");
            }

            return;
        }

        private void FocusNear_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            int lChannelID = 1;
            int lRet = NETDEVSDK.NETDEV_PTZControl_Other(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_FOCUSNEAR, m_dwPtzSpeed);
            if (NETDEVSDK.TRUE != lRet)
            {
                MessageBox.Show("PTZ control Focus Near failed.");
            }

            return;
        }

        private void PTZCTR_NW_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            int lChannelID = 1;
            int bRet = NETDEVSDK.NETDEV_PTZControl_Other(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_LEFTUP, m_dwPtzSpeed);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("PTZ control left-up failed.");
            }

            return;
        }

        private void PTZCTR_L_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            int lChannelID = 1;
            int bRet = NETDEVSDK.NETDEV_PTZControl_Other(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_PANLEFT, m_dwPtzSpeed);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("PTZ control left failed.");
            }

            return;
        }

        private void PTZCTR_SW_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            int lChannelID = 1;
            int bRet = NETDEVSDK.NETDEV_PTZControl_Other(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_LEFTDOWN, m_dwPtzSpeed);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("PTZ control left-down failed.");
            }

            return;
        }

        private void PTZCTR_UP_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            int lChannelID = 1;
            int bRet = NETDEVSDK.NETDEV_PTZControl_Other(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_TILTUP, m_dwPtzSpeed);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("PTZ control tilt-up failed.");
            }

            return;
        }

        private void PTZCTR_STOP_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            int lChannelID = 1;
            int bRet = NETDEVSDK.NETDEV_PTZControl_Other(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_ALLSTOP, 0);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("PTZ control all stop failed.");
            }

            return;
        }

        private void PTZCTR_DN_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            int lChannelID = 1;
            int bRet = NETDEVSDK.NETDEV_PTZControl_Other(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_TILTDOWN, m_dwPtzSpeed);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("PTZ control down failed.");
            }

            return;
        }

        private void PTZCTR_NE_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            int lChannelID = 1;
            int bRet = NETDEVSDK.NETDEV_PTZControl_Other(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_RIGHTUP, m_dwPtzSpeed);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("PTZ control right-up failed.");
            }

            return;
        }

        private void PTZCTR_R_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            int lChannelID = 1;
            int bRet = NETDEVSDK.NETDEV_PTZControl_Other(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_PANRIGHT, m_dwPtzSpeed);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("PTZ control right failed.");
            }

            return;
        }

        private void PTZCTR_SE_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            int lChannelID = 1;
            int bRet = NETDEVSDK.NETDEV_PTZControl_Other(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_PTZ_E.NETDEV_PTZ_RIGHTDOWN, m_dwPtzSpeed);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("PTZ control right-down failed.");
            }

            return;
        }

        private void SetPreset_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            Int32 l_PresetID = Convert.ToInt32(PresetID.Text);
            if (0 > l_PresetID || l_PresetID >= NETDEVSDK.NETDEV_MAX_PRESET_NUM)
            {
                MessageBox.Show("Preset ID invalid.");
            }
            String szPresetName = PresetID.Text + "\0";
            int lChannelID = 1;
            int bRet = NETDEVSDK.NETDEV_PTZPreset_Other(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_PTZ_PRESETCMD_E.NETDEV_PTZ_SET_PRESET, szPresetName, l_PresetID);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("Set preset failed.");
            }
            else
            {
                GetPreset_Click(sender, e);
            }
        }

        private void GetPreset_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            NETDEV_PTZ_ALLPRESETS_S stPtzPresets = new NETDEV_PTZ_ALLPRESETS_S();
            stPtzPresets.astPreset = new NETDEV_PTZ_PRESET_S[256];

            Int32 dwBytesReturned = 0;
            int lChannelID = 1;
            int bRet = NETDEVSDK.NETDEV_GetDevConfig(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_PTZPRESETS, ref stPtzPresets, Marshal.SizeOf(stPtzPresets), ref dwBytesReturned);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("Get presets failed.");
            }
            else
            {
                String strTemp;
                String strOut = "";

                for (Int32 i = 0; i < stPtzPresets.dwSize; i++)
                {
                    strTemp = "NO." + i + "   ID：" + stPtzPresets.astPreset[i].dwPresetID.ToString() + "\n";
                    strOut += strTemp;
                }

                MessageBox.Show(strOut);
            }

            return;
        }

        private void GotoPreset_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            Int32 l_PresetID = Convert.ToInt32(PresetID.Text);
            if (0 > l_PresetID && l_PresetID >= NETDEVSDK.NETDEV_MAX_PRESET_NUM)
            {
                MessageBox.Show("Preset ID invalid.");
            }

            String strPresetName = "";

            int lChannelID = 1;
            int bRet = NETDEVSDK.NETDEV_PTZPreset_Other(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_PTZ_PRESETCMD_E.NETDEV_PTZ_GOTO_PRESET, strPresetName, l_PresetID);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("Go to preset failed.");
            }

            return;
        }

        private void DeletePreset_Click(object sender, EventArgs e)
        {
            Int32 l_PresetID = Convert.ToInt32(PresetID.Text);
            if (0 > l_PresetID && l_PresetID >= NETDEVSDK.NETDEV_MAX_PRESET_NUM)
            {
                MessageBox.Show("Preset ID invalid.");
            }

            String strPresetName = "";
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            int lChannelID = 1;
            int bRet = NETDEVSDK.NETDEV_PTZPreset_Other(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_PTZ_PRESETCMD_E.NETDEV_PTZ_CLE_PRESET, strPresetName, l_PresetID);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("Delete preset failed.");
            }
            else
            {
                GetPreset_Click(sender, e);
            }
        }

        private void GetPatrol_Click(object sender, EventArgs e)
        {
            NETDEV_CRUISE_LIST_S stCuriseList = new NETDEV_CRUISE_LIST_S();
            stCuriseList.astCruiseInfo = new NETDEV_CRUISE_INFO_S[16];
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            int lChannelID = 1;
            int bRet = NETDEVSDK.NETDEV_PTZGetCruise(NETDEVSDK.m_lpDevHandle, lChannelID, ref stCuriseList);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("Get Cruise failed.");
            }
            else
            {
                String strTemp;
                String strOut = "";
                for (Int32 i = 0; i < stCuriseList.dwSize; i++)
                {
                    strTemp = "[Cruise]NO." + i + "   ID：" + stCuriseList.astCruiseInfo[i].dwCuriseID.ToString() + "\n";
                    strOut += strTemp;

                    for (Int32 k = 0; k < stCuriseList.astCruiseInfo[i].dwSize; k++)
                    {
                        strTemp = "\t [Preset] NO." + k + "   ID：" + stCuriseList.astCruiseInfo[i].astCruisePoint[k].dwPresetID.ToString() + "  StayTime： " + stCuriseList.astCruiseInfo[i].astCruisePoint[k].dwStayTime.ToString() + "\n";
                        strOut += strTemp;
                    }
                }

                MessageBox.Show(strOut);
            }

            return;
        }

        private void EditPatrol_Click(object sender, EventArgs e)
        {
            Int32 m_lCruiseID = Convert.ToInt32(PatrolID.Text);

            NETDEV_CRUISE_INFO_S stCruiseInfo = new NETDEV_CRUISE_INFO_S();
            stCruiseInfo.szCuriseName = new char[32];
            stCruiseInfo.astCruisePoint = new NETDEV_CRUISE_POINT_S[32];
            stCruiseInfo.dwCuriseID = m_lCruiseID;
            //(VOID)_snprintf(stCruiseInfo.szCuriseName, (NETDEV_LEN_32 - 1), "%u", stCruiseInfo.dwCuriseID);
            stCruiseInfo.dwSize = 3;

            stCruiseInfo.astCruisePoint[0].dwPresetID = 3;
            stCruiseInfo.astCruisePoint[0].dwStayTime = 14000;

            stCruiseInfo.astCruisePoint[1].dwPresetID = 4;
            stCruiseInfo.astCruisePoint[1].dwStayTime = 15000;

            stCruiseInfo.astCruisePoint[2].dwPresetID = 5;
            stCruiseInfo.astCruisePoint[2].dwStayTime = 16000;
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            int lChannelID = 1;
            int bRet = NETDEVSDK.NETDEV_PTZCruise_Other(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_PTZ_CRUISECMD_E.NETDEV_PTZ_MODIFY_CRUISE, ref stCruiseInfo);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("Edit Cruise failed.");
            }
            else
            {
                GetPatrol_Click(sender, e);
            }

            return;
        }

        private void AddPatrol_Click(object sender, EventArgs e)
        {
            NETDEV_CRUISE_INFO_S stCruiseInfo = new NETDEV_CRUISE_INFO_S();
            stCruiseInfo.szCuriseName = new char[32];
            stCruiseInfo.astCruisePoint = new NETDEV_CRUISE_POINT_S[32];

            stCruiseInfo.dwSize = 2;
            stCruiseInfo.astCruisePoint[0].dwPresetID = 1;
            stCruiseInfo.astCruisePoint[0].dwStayTime = 11000;

            stCruiseInfo.astCruisePoint[1].dwPresetID = 2;
            stCruiseInfo.astCruisePoint[1].dwStayTime = 12000;
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            int lChannelID = 1;
            int bRet = NETDEVSDK.NETDEV_PTZCruise_Other(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_PTZ_CRUISECMD_E.NETDEV_PTZ_ADD_CRUISE, ref stCruiseInfo);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("Add Cruise failed.");
            }
            else
            {
                GetPatrol_Click(sender, e);
            }

            return;
        }

        private void DeletePatrol_Click(object sender, EventArgs e)
        {
            Int32 m_lCruiseID = Convert.ToInt32(PatrolID.Text);
            NETDEV_CRUISE_INFO_S stCruiseInfo = new NETDEV_CRUISE_INFO_S();
            stCruiseInfo.dwCuriseID = m_lCruiseID;
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            int lChannelID = 1;
            int bRet = NETDEVSDK.NETDEV_PTZCruise_Other(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_PTZ_CRUISECMD_E.NETDEV_PTZ_DEL_CRUISE, ref stCruiseInfo);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("failed.");
            }
            else
            {
                GetPatrol_Click(sender, e);
            }

            return;
        }

        private void StartPatrol_Click(object sender, EventArgs e)
        {
            Int32 m_lCruiseID = Convert.ToInt32(PatrolID.Text);
            NETDEV_CRUISE_INFO_S stCruiseInfo = new NETDEV_CRUISE_INFO_S();
            stCruiseInfo.dwCuriseID = m_lCruiseID;
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            int lChannelID = 1;
            int bRet = NETDEVSDK.NETDEV_PTZCruise_Other(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_PTZ_CRUISECMD_E.NETDEV_PTZ_RUN_CRUISE, ref stCruiseInfo);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("Start Curise failed.");
            }

            return;
        }

        private void StopPatrol_Click(object sender, EventArgs e)
        {
            Int32 m_lCruiseID = Convert.ToInt32(PatrolID.Text);
            NETDEV_CRUISE_INFO_S stCruiseInfo = new NETDEV_CRUISE_INFO_S();
            stCruiseInfo.dwCuriseID = m_lCruiseID;
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }
            int lChannelID = 1;
            int bRet = NETDEVSDK.NETDEV_PTZCruise_Other(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_PTZ_CRUISECMD_E.NETDEV_PTZ_STOP_CRUISE, ref stCruiseInfo);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("Stop Cruise failed.");
            }

            return;
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

        public void PicDataCallback(IntPtr pstUniviewData, uint ulStreamHandle)
        {
            //指针转换为对应结构体
            NETDEVSDK.NETDEV_PIC_DATA_S info = new NETDEVSDK.NETDEV_PIC_DATA_S();
            byte[] pByte = new byte[Marshal.SizeOf(info)];
            Marshal.Copy(pstUniviewData, pByte, 0, Marshal.SizeOf(info));
            info = (NETDEVSDK.NETDEV_PIC_DATA_S)BytesToStruct(pByte, info.GetType());

            //车牌号码
            string carPlate = new string(info.szCarPlate).TrimEnd('\0');

            //时间
            string time = new string(info.szPassTime).TrimEnd('\0');

            //保存过车图片
            for (int i = 0; i < info.ulPicNumber; i++)
            {
                string passTime = new string(info.acPassTime);

                int size = (int)info.aulDataLen[i];
                byte[] buffer = new byte[size];
                Marshal.Copy(info.apcData[i], buffer, 0, size);

                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    using (Image image = Image.FromStream(ms))
                    {
                        image.Save(string.Format(@".\{0}_{1}.bmp", time, i));
                    }
                }
            }
        }

        private void PicPlay_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                return;
            }

            if (IntPtr.Zero != NETDEVSDK.m_oPicHandleMap)
            {
                int bRet = NETDEVSDK.NETDEV_StopPicStream(NETDEVSDK.m_oPicHandleMap);
                if (NETDEVSDK.TRUE == bRet)
                {
                    NETDEVSDK.m_oPicHandleMap = IntPtr.Zero;
                }
            }
            MultiPicDataCallBackFun = PicDataCallback;
            NETDEVSDK.m_oPicHandleMap = (IntPtr)NETDEVSDK.NETDEV_StartPicStream(NETDEVSDK.m_lpDevHandle, PIC_STREAM.Handle, false, "", MultiPicDataCallBackFun, IntPtr.Zero);
            if (IntPtr.Zero == NETDEVSDK.m_oPicHandleMap)
            {
                MessageBox.Show("NETDEV_StartPicStream fail");
            }
            return;
        }

        private void StopPicPlay_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == NETDEVSDK.m_oPicHandleMap)
            {
                return;
            }
            if (IntPtr.Zero != NETDEVSDK.m_oPicHandleMap)
            {
                int ulRet = NETDEVSDK.NETDEV_StopPicStream(NETDEVSDK.m_oPicHandleMap);
                if (NETDEVSDK.TRUE != ulRet)
                {
                    MessageBox.Show("NETDEV_StopPicStream fail");
                    return;
                }
            }
            MessageBox.Show("Succeed!");
            NETDEVSDK.m_oPicHandleMap = IntPtr.Zero;
            return;
        }

        private void Capture_Click(object sender, EventArgs e)
        {
            Int32 ulRet = NETDEVSDK.NETDEV_Trigger(NETDEVSDK.m_lpDevHandle);
            if (NETDEVSDK.TRUE != ulRet)
            {
                MessageBox.Show("NETDEV_Trigger fail");
                return;
            }
            MessageBox.Show("抓拍成功");

        }

        private void CaptureSyn_Click(object sender, EventArgs e)
        {
            IntPtr pPicDataInfo = IntPtr.Zero;

            Int32 ulRet = NETDEVSDK.NETDEV_TriggerSync(NETDEVSDK.m_lpDevHandle, ref pPicDataInfo);
            if (NETDEVSDK.TRUE != ulRet)
            {
                MessageBox.Show("NETDEV_TriggerSync fail, error code=" + ulRet);
                return;
            }

            NETDEVSDK.NETDEV_PIC_DATA_S stDevInfo = new NETDEVSDK.NETDEV_PIC_DATA_S();
            byte[] pByte = new byte[Marshal.SizeOf(stDevInfo)];
            Marshal.Copy(pPicDataInfo, pByte, 0, Marshal.SizeOf(stDevInfo));
            stDevInfo = (NETDEVSDK.NETDEV_PIC_DATA_S)BytesToStruct(pByte, stDevInfo.GetType());

            MessageBox.Show("抓拍成功");

            //时间
            string time = new string(stDevInfo.szPassTime).TrimEnd('\0');
            for (int i = 0; i < stDevInfo.ulPicNumber; i++)
            {
                int size = (int)stDevInfo.aulDataLen[i];
                byte[] buffer = new byte[size];
                Marshal.Copy(stDevInfo.apcData[i], buffer, 0, size);

                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    using (Image image = Image.FromStream(ms))
                    {
                        image.Save(string.Format(@".\{0}_{1}.bmp", time, i));
                    }
                }
            }

        }

        private void ParkStatus_Click(object sender, EventArgs e)
        {
            Int32 i = 0;
            String status = "";
            Int32 lChannelID = 1;
            Int32 dwBytesReturned = 0;
            NETDEV_PARKSTATUS_INFO_S parkStatusAll = new NETDEV_PARKSTATUS_INFO_S();
            NETDEV_CARPORT_CFG_S carportInfo = new NETDEV_CARPORT_CFG_S();

            IntPtr ptrStatusAll = Marshal.AllocHGlobal(Marshal.SizeOf(parkStatusAll));
            IntPtr ptrCarportInfo = Marshal.AllocHGlobal(Marshal.SizeOf(carportInfo));

            Int32 bRet = NETDEVSDK.NETDEV_GetDevConfig(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_PARKSTATUSINFO, ref parkStatusAll, Marshal.SizeOf(parkStatusAll), ref dwBytesReturned);
            if (NETDEVSDK.TRUE != bRet)
            {
                MessageBox.Show("获取所有车位状态失败，错误码=" + bRet);
                return;
            }

            Int32 result = NETDEVSDK.NETDEV_GetDevConfig(NETDEVSDK.m_lpDevHandle, lChannelID, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_CARPORTCFG, ref carportInfo, Marshal.SizeOf(carportInfo), ref dwBytesReturned);
            if (NETDEVSDK.TRUE != result)
            {
                MessageBox.Show("获取所有车位状态失败，错误码=" + result);
                return;
            }

            for (i = 0; i < parkStatusAll.ulParkNum; i++)
            {
                status = status + "车位：" + parkStatusAll.astParkSatus[i].lParkID + "有车:" + parkStatusAll.astParkSatus[i].lParkingLotStatus + "使能:" + carportInfo.astParkAreaInfo[i].ulParkDetstaus + "\r\n";
            }

            MessageBox.Show(status);
        }

        private void GetVersion_Click(object sender, EventArgs e)
        {
            Int32 iVersion = 0;
            iVersion = NETDEVSDK.NETDEV_GetSDKVersion();

            Int32 iVerMain = Convert.ToInt32((iVersion & 0xFFFF0000) >> 16);
            Int32 iVerSub = Convert.ToInt32((iVersion & 0x0000FFFF));
            MessageBox.Show("SDK Version: V" + iVerMain + "." + iVerSub);
            return;
        }

        public void DEV_DISCOVERY_CB(IntPtr pstDevInfo, IntPtr lpUserData)
        {
            //指针转换为对应结构体
            NETDEV_DISCOVERY_DEVINFO_S info = new NETDEV_DISCOVERY_DEVINFO_S();
            byte[] pByte = new byte[Marshal.SizeOf(info)];
            Marshal.Copy(pstDevInfo, pByte, 0, Marshal.SizeOf(info));
            info = (NETDEV_DISCOVERY_DEVINFO_S)BytesToStruct(pByte, info.GetType());

        }

        private void Discovery_Click(object sender, EventArgs e)
        {
            SetDevDiscoveryCallBackHandl = DEV_DISCOVERY_CB;
            NETDEVSDK.NETDEV_SetDiscoveryCallBack(SetDevDiscoveryCallBackHandl, IntPtr.Zero);

            Int32 lRet = NETDEVSDK.NETDEV_Discovery("0.0.0.0", "0.0.0.0");
            if (NETDEVSDK.TRUE != lRet)
            {
                MessageBox.Show("设备发现失败，错误码=" + lRet);
                return;
            }
        }

        private void AutoDiscovery_Click(object sender, EventArgs e)
        {
            SetDevDiscoveryCallBackHandl = DEV_DISCOVERY_CB;
            NETDEVSDK.NETDEV_SetDiscoveryCallBack(SetDevDiscoveryCallBackHandl, IntPtr.Zero);

            Int32 lRet = NETDEVSDK.NETDEV_Discovery(BEGIN_IP.Text, END_IP.Text);
            if (NETDEVSDK.TRUE != lRet)
            {
                MessageBox.Show("设备自动发现失败，请输入IP");
                return;
            }
        }

        private void InitOSDTab()
        {
            string[] fontStyle = new string[] { "背景", "描边", "空心", "正常" };
            cbFontStyle.Items.AddRange(fontStyle);

            string[] fontSize = new string[] {"特大", "大", "中", "小"};
            cbFontSize.Items.AddRange(fontSize);
        }

        private void btnGetOSDStyle_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                MessageBox.Show("当前无用户登录");
                return;
            }

            int ulRet = NETDEVSDK.TRUE;
            Int32 dwBytesReturned = 0;
            NETDEVSDK.NETDEV_OSD_CONTENT_STYLE_S stuStyleCfgs = new NETDEVSDK.NETDEV_OSD_CONTENT_STYLE_S();
            IntPtr ptrStuStyleCfgs = IntPtr.Zero;

            //获取叠加OSD样式
            try
            {
                ptrStuStyleCfgs = Marshal.AllocHGlobal(Marshal.SizeOf(stuStyleCfgs));
                Marshal.StructureToPtr(stuStyleCfgs, ptrStuStyleCfgs, true);

                ulRet = NETDEVSDK.NETDEV_GetDevConfig(NETDEVSDK.m_lpDevHandle, 1, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_OSD_CONTENT_STYLE_CFG, ptrStuStyleCfgs, Marshal.SizeOf(stuStyleCfgs), ref dwBytesReturned);
                if (NETDEVSDK.TRUE != ulRet)
                {
                    string strError = string.Format("Get OSD style config fail.");
                    MessageBox.Show(strError);
                    return;
                }
                stuStyleCfgs = (NETDEVSDK.NETDEV_OSD_CONTENT_STYLE_S)Marshal.PtrToStructure(ptrStuStyleCfgs, stuStyleCfgs.GetType());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                Marshal.FreeHGlobal(ptrStuStyleCfgs);
            }

            //combobox各项目的索引号与字体效果和字体大小的值分别对应相等，直接赋值给索引
            if (stuStyleCfgs.udwFontStyle >= (uint)NETDEV_OSD_FONT_STYLE_E.NETDEV_OSD_FONT_STYLE_BACKGROUND && stuStyleCfgs.udwFontStyle <= (uint)NETDEV_OSD_FONT_STYLE_E.NETDEV_OSD_FONT_STYLE_NORMAL)
            {
                cbFontStyle.SelectedIndex = (int)stuStyleCfgs.udwFontStyle;
            }

            if (stuStyleCfgs.udwFontSize >= (uint)NETDEV_OSD_FONT_SIZE_E.NETDEV_OSD_FONT_SIZE_LARGE && stuStyleCfgs.udwFontSize <= (uint)NETDEV_OSD_FONT_SIZE_E.NETDEV_OSD_FONT_SIZE_SMALL)
            {
                cbFontSize.SelectedIndex = (int)stuStyleCfgs.udwFontSize;
            }
        }

        private void btnSetOSD_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero == NETDEVSDK.m_lpDevHandle)
            {
                MessageBox.Show("当前无用户登录");
                return;
            }

            int ulRet = NETDEVSDK.TRUE;
            Int32 dwBytesReturned = 0;

            string strOsdTest = tbOSDContent.Text;
            NETDEVSDK.NETDEV_OSD_CONTENT_S stuInfoOsdCfgs = new NETDEVSDK.NETDEV_OSD_CONTENT_S();
            NETDEVSDK.NETDEV_OSD_CONTENT_STYLE_S stuStyleCfgs = new NETDEVSDK.NETDEV_OSD_CONTENT_STYLE_S();
            IntPtr pInfoOsdCfgsA = IntPtr.Zero;
            IntPtr pInfoOsdCfgsB = IntPtr.Zero;
            IntPtr pstuStyleCfgsA = IntPtr.Zero;
            IntPtr pstuStyleCfgsB = IntPtr.Zero;

            //获取叠加OSD配置
            try
            {
                pInfoOsdCfgsA = Marshal.AllocHGlobal(Marshal.SizeOf(stuInfoOsdCfgs));
                Marshal.StructureToPtr(stuInfoOsdCfgs, pInfoOsdCfgsA, true);

                ulRet = NETDEVSDK.NETDEV_GetDevConfig(NETDEVSDK.m_lpDevHandle, 1, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_INFOOSDCFG, pInfoOsdCfgsA, Marshal.SizeOf(stuInfoOsdCfgs), ref dwBytesReturned);
                if (NETDEVSDK.TRUE != ulRet)
                {
                    string strError = string.Format("Get OSD info config fail, error code:{0:D}", ulRet);
                    MessageBox.Show(strError);
                    return;
                }
                stuInfoOsdCfgs = (NETDEVSDK.NETDEV_OSD_CONTENT_S)Marshal.PtrToStructure(pInfoOsdCfgsA, stuInfoOsdCfgs.GetType());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                Marshal.FreeHGlobal(pInfoOsdCfgsA);
            }

            //区域1
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
                        stuInfoOsdCfgs.astContentList[i].astContentInfo[j].szOSDText = System.Text.Encoding.UTF8.GetBytes(strOsdTest.PadRight(64, '\0'));
                    }
                    else
                    {
                        stuInfoOsdCfgs.astContentList[i].astContentInfo[j].udwContentType = (uint)NETDEV_OSD_CONTENT_TYPE_E.NETDEV_OSD_CONTENT_TYPE_NOTUSE;
                    }
                }
            }

            //设置叠加OSD配置
            try
            {
                pInfoOsdCfgsB = Marshal.AllocHGlobal(Marshal.SizeOf(stuInfoOsdCfgs));
                Marshal.StructureToPtr(stuInfoOsdCfgs, pInfoOsdCfgsB, true);

                ulRet = NETDEVSDK.NETDEV_SetDevConfig(NETDEVSDK.m_lpDevHandle, 1, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_SET_OSD_CONTENT_CFG, pInfoOsdCfgsB, ref dwBytesReturned);
                if (NETDEVSDK.TRUE != ulRet)
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

            //获取叠加OSD样式
            try
            {
                pstuStyleCfgsA = Marshal.AllocHGlobal(Marshal.SizeOf(stuStyleCfgs));
                Marshal.StructureToPtr(stuStyleCfgs, pstuStyleCfgsA, true);

                ulRet = NETDEVSDK.NETDEV_GetDevConfig(NETDEVSDK.m_lpDevHandle, 1, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_OSD_CONTENT_STYLE_CFG, pstuStyleCfgsA, Marshal.SizeOf(stuStyleCfgs), ref dwBytesReturned);
                if (NETDEVSDK.TRUE != ulRet)
                {
                    string strError = string.Format("Get OSD style config fail.");
                    MessageBox.Show(strError);
                    return;
                }
                stuStyleCfgs = (NETDEVSDK.NETDEV_OSD_CONTENT_STYLE_S)Marshal.PtrToStructure(pstuStyleCfgsA, stuStyleCfgs.GetType());
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                Marshal.FreeHGlobal(pstuStyleCfgsA);
            }

            //将选择的字体效果和字体大小的索引值赋给叠加OSD样式结构体对应的字段
            if (cbFontStyle.SelectedIndex >= (int)NETDEV_OSD_FONT_STYLE_E.NETDEV_OSD_FONT_STYLE_BACKGROUND && cbFontStyle.SelectedIndex <= (int)NETDEV_OSD_FONT_STYLE_E.NETDEV_OSD_FONT_STYLE_NORMAL)
            {
                stuStyleCfgs.udwFontStyle = (uint)cbFontStyle.SelectedIndex;
            }

            if (cbFontSize.SelectedIndex >= (int)NETDEV_OSD_FONT_SIZE_E.NETDEV_OSD_FONT_SIZE_LARGE && cbFontSize.SelectedIndex <= (int)NETDEV_OSD_FONT_SIZE_E.NETDEV_OSD_FONT_SIZE_SMALL)
            {
                stuStyleCfgs.udwFontSize = (uint)cbFontSize.SelectedIndex;
            }

            //设置叠加OSD样式
            try
            {
                int ulStyleCfgsSize = Marshal.SizeOf(stuStyleCfgs);
                pstuStyleCfgsB = Marshal.AllocHGlobal(Marshal.SizeOf(stuStyleCfgs));
                Marshal.StructureToPtr(stuStyleCfgs, pstuStyleCfgsB, true);

                ulRet = NETDEVSDK.NETDEV_SetDevConfig(NETDEVSDK.m_lpDevHandle, 1, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_SET_OSD_CONTENT_STYLE_CFG, pstuStyleCfgsB, ref ulStyleCfgsSize);
                if (NETDEVSDK.TRUE != ulRet)
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
            finally
            {
                Marshal.FreeHGlobal(pstuStyleCfgsB);
            }
        }

        private void initDgUserInfo()
        {
            dgUserInfo.Columns[0].Width = 60;
            dgUserInfo.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgUserInfo.Columns[1].Width = 140;
            dgUserInfo.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgUserInfo.Columns[2].Width = 100;
            dgUserInfo.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgUserInfo.Columns[3].Width = 100;
            dgUserInfo.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgUserInfo.Columns[4].Width = 142;
            dgUserInfo.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void getUsersLoginInfo()
        {
            string strPathName;
            string strUserIndex;
            StringBuilder strIniValue = new StringBuilder();
            StuDevInfo oStuDevInfo = new StuDevInfo();

            //写日志文件
            strPathName = string.Format("{0}\\UserLoginInfo.ini", strModulePath);

            while (gstBvecDevInfo == NETDEVSDK.FALSE)
            {
                gstBvecDevInfo = NETDEVSDK.TRUE;
                m_VecDevInfo.Clear();
                if (dgUserInfo.Rows.Count > 0)
                {
                    dgUserInfo.Rows.Clear();
                }

                lblUserNum.Text = "用户数量：0";

                for (int i = 0; i < 80; i++)
                {
                    strUserIndex = string.Format("DEVICE{0:D}", i);
                    GetPrivateProfileString(strUserIndex, "IP", null, strIniValue, NETDEVSDK.MAX_PATH, strPathName);
                    oStuDevInfo.strDevIP = strIniValue.ToString();
                    GetPrivateProfileString(strUserIndex, "admin", null, strIniValue, NETDEVSDK.MAX_PATH, strPathName);
                    oStuDevInfo.strDevAdmin = strIniValue.ToString();
                    GetPrivateProfileString(strUserIndex, "password", null, strIniValue, NETDEVSDK.MAX_PATH, strPathName);
                    oStuDevInfo.strDevPassWord = strIniValue.ToString();

                    if (string.IsNullOrEmpty(oStuDevInfo.strDevIP) || string.IsNullOrEmpty(oStuDevInfo.strDevAdmin) ||
                        string.IsNullOrEmpty(oStuDevInfo.strDevPassWord))
                    {
                        break;
                    }

                    oStuDevInfo.bLogin = NETDEVSDK.FALSE;
                    oStuDevInfo.bStartStream = NETDEVSDK.FALSE;
                    oStuDevInfo.lpDevHandle = IntPtr.Zero;
                    oStuDevInfo.lpPicHandle = IntPtr.Zero;
                    oStuDevInfo.lpStreamHandle = IntPtr.Zero;
                    oStuDevInfo.ulPicCount = 0;

                    m_VecDevInfo.Add(i, oStuDevInfo);
                }
            }
            gstBvecDevInfo = NETDEVSDK.FALSE;

            return;
        }

        public void SetListCtrl()
        {
            int iCount = m_VecDevInfo.Count;
            string strIndex = "";

            while (gstBvecDevInfo == NETDEVSDK.FALSE)
            {
                gstBvecDevInfo = NETDEVSDK.TRUE;
                int iRowIndex = 0;

                for (int i = 0; i < iCount; i++)
                {
                    strIndex = string.Format("{0:D}", i + 1);
                    StuDevInfo oStuDevInfo = (StuDevInfo)m_VecDevInfo.GetByIndex(m_VecDevInfo.IndexOfKey(i));

                    iRowIndex = dgUserInfo.Rows.Add();    //插入行
                    dgUserInfo.Rows[iRowIndex].Cells[0].Value = strIndex;     //设置数据
                    dgUserInfo.Rows[iRowIndex].Cells[1].Value = oStuDevInfo.strDevIP;    //设置数据
                    dgUserInfo.Rows[iRowIndex].Cells[2].Value = oStuDevInfo.strDevAdmin.ToString();
                    dgUserInfo.Rows[iRowIndex].Cells[3].Value = "未连接";
                    dgUserInfo.Rows[iRowIndex].Cells[4].Value = "0";
                }
            }
            gstBvecDevInfo = NETDEVSDK.FALSE;

            return;
        }

        public void PicDataCallBackFun(IntPtr pstUniviewData, uint ulStreamHandle)
        {
            //指针转换为对应结构体
            NETDEVSDK.NETDEV_PIC_DATA_S info = new NETDEVSDK.NETDEV_PIC_DATA_S();
            byte[] pByte = new byte[Marshal.SizeOf(info)];
            Marshal.Copy(pstUniviewData, pByte, 0, Marshal.SizeOf(info));
            info = (NETDEVSDK.NETDEV_PIC_DATA_S)BytesToStruct(pByte, info.GetType());
            string szTmp = "";
            string cameraIP = "";
            int iRowIndex = 0;

            char szclor = (char)info.cVehicleColor;

            for (int i = 0; i < m_VecDevInfo.Count; i++)
            {
                StuDevInfo oStuDevInfo = (StuDevInfo)m_VecDevInfo.GetByIndex(m_VecDevInfo.IndexOfKey(i));
                if ((uint)oStuDevInfo.lpStreamHandle == ulStreamHandle)
                {
                    iRowIndex = i;
                    cameraIP = oStuDevInfo.strDevIP;
                    break;
                }
            }

            szTmp = string.Format("{0}\\pic_{1}", strModulePath, cameraIP);
            try
            {
                if (!Directory.Exists(szTmp))
                {
                    Directory.CreateDirectory(szTmp);
                }
            }
            catch (Exception e)
            {
                string strError = string.Format("Create path \"{0}\" fail.", szTmp);
                MessageBox.Show(strError);
                return;
            }
            
            //车牌号码
            string carPlate = new string(info.szCarPlate).TrimEnd('\0');

            //时间
            string time = new string(info.szPassTime).TrimEnd('\0');

            //保存过车图片
            for (int i = 0; i < info.ulPicNumber; i++)
            {
                string passTime = new string(info.acPassTime);

                int size = (int)info.aulDataLen[i];
                byte[] buffer = new byte[size];
                Marshal.Copy(info.apcData[i], buffer, 0, size);

                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    using (Image image = Image.FromStream(ms))
                    {
                        image.Save(string.Format("{0}\\{1}_{2}.bmp", szTmp, time, i));
                    }
                }

                StuDevInfo oStuDevInfo = (StuDevInfo)m_VecDevInfo.GetByIndex(m_VecDevInfo.IndexOfKey(iRowIndex));
                oStuDevInfo.ulPicCount++;

                dgUserInfo.Rows[iRowIndex].Cells[4].Value = oStuDevInfo.ulPicCount.ToString();
                m_VecDevInfo.SetByIndex(m_VecDevInfo.IndexOfKey(iRowIndex), oStuDevInfo);
            }
        }

        public void Demo_LoginThread()
        {
            IntPtr lpDevHandle = IntPtr.Zero;
            IntPtr lpPicHandle = IntPtr.Zero;
            string strUserIp;
            string strUserName;
            string strUserWord;
            int iCount = 0;
            int iIndexLog = 0;

            while (gstBvecDevInfo == NETDEVSDK.FALSE)
            {
                gstBvecDevInfo = NETDEVSDK.TRUE;
                int iSize = m_VecDevInfo.Count;

                for (int i = 0; i < iSize; i++)
                {
                    IntPtr pstDevInfo = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(NETDEVSDK.NETDEV_DEVICE_INFO_S)));
                    StuDevInfo oStuDevInfo = (StuDevInfo)m_VecDevInfo.GetByIndex(m_VecDevInfo.IndexOfKey(i));
                    strUserIp = oStuDevInfo.strDevIP;
                    strUserName = oStuDevInfo.strDevAdmin;
                    strUserWord = oStuDevInfo.strDevPassWord;

                    if (oStuDevInfo.bLogin == NETDEVSDK.FALSE)
                    {
                        lpDevHandle = NETDEVSDK.NETDEV_Login(strUserIp, 0, strUserName, strUserWord, pstDevInfo);
                        if (IntPtr.Zero == lpDevHandle)
                        {
                            iIndexLog++;
                            if (iIndexLog > 2)
                            {
                                iIndexLog = 0;
                                continue;
                            }
                            i--;
                            continue;
                        }

                        oStuDevInfo.bLogin = NETDEVSDK.TRUE;
                        oStuDevInfo.lpDevHandle = lpDevHandle;

                        IntPtr pi = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(int)));
                        MultiPicDataCallBackFun = PicDataCallBackFun;
                        lpPicHandle = (IntPtr)NETDEVSDK.NETDEV_StartPicStream(lpDevHandle, IntPtr.Zero, false, "", MultiPicDataCallBackFun, pi);
                        oStuDevInfo.lpStreamHandle = pi;
                        Marshal.FreeHGlobal(pi);
                        if (IntPtr.Zero == lpPicHandle)
                        {
                            NETDEVSDK.NETDEV_Logout(lpDevHandle);
                            oStuDevInfo.bLogin = NETDEVSDK.FALSE;
                            oStuDevInfo.lpDevHandle = IntPtr.Zero;
                            iIndexLog++;
                            if (iIndexLog > 2)
                            {
                                iIndexLog = 0;
                                continue;
                            }
                            i--;
                            continue;
                        }
                        iCount++;
                        oStuDevInfo.ulUserId = (uint)i;
                        oStuDevInfo.bStartStream = NETDEVSDK.TRUE;
                        oStuDevInfo.lpPicHandle = lpPicHandle;
                        m_VecDevInfo.SetByIndex(m_VecDevInfo.IndexOfKey(i), oStuDevInfo);
                        dgUserInfo.Rows[i].Cells[3].Value = "已连接";    //设置数据
                    }

                    Marshal.FreeHGlobal(pstDevInfo);
                }

                lblUserNum.Text = string.Format("用户数量：{0:D}", iCount);
                btnMultiLogout.Enabled = true;
                MessageBox.Show("连接完成");
            }
            gstBvecDevInfo = NETDEVSDK.FALSE;

            return;
        }

        private void btnMultiLogin_Click(object sender, EventArgs e)
        {
            btnMultiLogin.Enabled = false;

            getUsersLoginInfo();

            SetListCtrl();

            Thread thread = new Thread(Demo_LoginThread);
            thread.IsBackground = true;
            thread.Start();//启动新线程

            return;
        }

        private void btnMultiLogout_Click(object sender, EventArgs e)
        {
            string strUserIp = "";
            string strUserName = "";
            string strUserWord = "";

            btnMultiLogout.Enabled = false;           

            while (gstBvecDevInfo == NETDEVSDK.FALSE)
            {
                gstBvecDevInfo = NETDEVSDK.TRUE;

                ICollection key = m_VecDevInfo.Keys;

                foreach (int k in key)
                {
                    StuDevInfo oStuDevInfo = (StuDevInfo)m_VecDevInfo.GetByIndex(m_VecDevInfo.IndexOfKey(k));
                    strUserIp = oStuDevInfo.strDevIP;
                    strUserName = oStuDevInfo.strDevAdmin;
                    strUserWord = oStuDevInfo.strDevPassWord;

                    if (oStuDevInfo.bStartStream == NETDEVSDK.TRUE)
                    {
                        int ulRet = NETDEVSDK.NETDEV_StopPicStream(oStuDevInfo.lpPicHandle);
                        if (NETDEVSDK.TRUE != ulRet)
                        {
                            gstBvecDevInfo = NETDEVSDK.FALSE;
                            return;
                        }
                        oStuDevInfo.bStartStream = NETDEVSDK.FALSE;
                        oStuDevInfo.lpPicHandle = IntPtr.Zero;
                        oStuDevInfo.lpStreamHandle = IntPtr.Zero;
                        oStuDevInfo.ulPicCount = 0;
                    }

                    if (oStuDevInfo.bLogin == NETDEVSDK.TRUE)
                    {
                        int ulRet = NETDEVSDK.NETDEV_Logout(oStuDevInfo.lpDevHandle);
                        if (NETDEVSDK.TRUE != ulRet)
                        {
                            gstBvecDevInfo = NETDEVSDK.FALSE;
                            return;
                        }
                        oStuDevInfo.bLogin = NETDEVSDK.FALSE;
                        oStuDevInfo.lpDevHandle = IntPtr.Zero;
                    }
                    oStuDevInfo.strDevAdmin = "";
                    oStuDevInfo.strDevIP = "";
                    oStuDevInfo.ulUserId = 0;
                }
                if (dgUserInfo.Rows.Count > 0)
                {
                    dgUserInfo.Rows.Clear();
                }
                lblUserNum.Text = "用户数量：0";
            }

            gstBvecDevInfo = NETDEVSDK.FALSE;
            btnMultiLogin.Enabled = true;
        }
    }
}
