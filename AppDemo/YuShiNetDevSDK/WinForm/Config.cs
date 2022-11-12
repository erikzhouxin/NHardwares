using GeneralDef;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Data.YuShiNetDevSDK;

namespace YuShiNetDevSDK.WinForm
{
    public class Config
    {
        static INetDevSdkProxy NETDEVSDK = NetDevSdk.Create();
        private const int MAXMOTIONOBJECTSIZE = 100;
        public enum CONFIG_TYPE_E
        {
            CONFIG_BASIC_TYPE = 0,
            CONFIG_NETWORK_TYPE = 1,
            CONFIG_VIDEO_TYPE = 2,
            CONFIG_IMAGE_TYPE = 3,
            CONFIG_OSD_TYPE = 4,
            CONFIG_IO_TYPE = 5,
            CONFIG_PRIVACY_MASK_TYPE = 6,
            CONFIG_MOTION_TYPE = 7,
            CONFIG_TEMPER_TYPE = 8
        }

        private NetDemo m_oNetDemo;
        private int m_curCfgTabIndex = 0;
        private List<NETDEMO_DeviceInfo> m_deviceInfoList = null;

        public Config(NetDemo oNetDemo)
        {
            m_oNetDemo = oNetDemo;
            m_deviceInfoList = oNetDemo.getDeviceInfoList();
        }

        //config tab
        public void cfgTabSwitch(int index)
        {
            m_curCfgTabIndex = index;
            switch (index)
            {
                case (int)CONFIG_TYPE_E.CONFIG_BASIC_TYPE:
                    getBasicInfo();
                    break;
                case (int)CONFIG_TYPE_E.CONFIG_NETWORK_TYPE:
                    getNetworkInfo();
                    break;
                case (int)CONFIG_TYPE_E.CONFIG_VIDEO_TYPE:
                    getVideoInfo();
                    break;
                case (int)CONFIG_TYPE_E.CONFIG_IMAGE_TYPE:
                    getIamgeInfo();
                    break;
                case (int)CONFIG_TYPE_E.CONFIG_OSD_TYPE:
                    getOSDInfo();
                    break;
                case (int)CONFIG_TYPE_E.CONFIG_IO_TYPE:
                    getIOInfo();
                    break;
                case (int)CONFIG_TYPE_E.CONFIG_PRIVACY_MASK_TYPE:
                    getPrivacyMaskInfo();
                    break;
                case (int)CONFIG_TYPE_E.CONFIG_MOTION_TYPE:
                    getMotionInfo();
                    break;
                case (int)CONFIG_TYPE_E.CONFIG_TEMPER_TYPE:
                    getTemperInfo();
                    break;
                default:
                    break;

            }
        }

        /*************************** Basic Cfg start *****************************/
        /*获取基本配置信息*/
        private void getBasicInfo()
        {
            int dwDeviceIndex = m_oNetDemo.getDeviceIndex();
            if (dwDeviceIndex < 0)
            {
                return;
            }

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS == m_deviceInfoList[dwDeviceIndex].m_eDeviceType)
            {
                /* not support */
            }
            else
            {
                if (m_deviceInfoList[dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_basicInfo.existFlag == false)
                {
                    refreshBasicInfo();
                }
                else
                {
                    readBasicInfo();
                }
            }
        }

        public void refreshBasicInfo()
        {
            /* Get Device System time */
            int dwDeviceIndex = m_oNetDemo.getDeviceIndex();
            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS == m_deviceInfoList[dwDeviceIndex].m_eDeviceType)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Not Support", -1);
                return ;
            }

            NETDEV_TIME_CFG_S stTimeCfg = new NETDEV_TIME_CFG_S();
            int iRet = NETDEVSDK.NETDEV_GetSystemTimeCfg(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, ref stTimeCfg);
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get device system time", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            else
            {
                m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get device system time");
                m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_basicInfo.stSystemTime = stTimeCfg;
            }

            m_oNetDemo.showSystemTime(stTimeCfg);

            /* Get Device name */
            NETDEV_DEVICE_BASICINFO_S stDeviceInfo = new NETDEV_DEVICE_BASICINFO_S();
            Int32 dwBytesReturned = 0;
            iRet = NETDEVSDK.NETDEV_GetDevConfig(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, m_oNetDemo.getChannelID(), (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_DEVICECFG, ref stDeviceInfo, Marshal.SizeOf(stDeviceInfo), ref dwBytesReturned);
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get device name", NETDEVSDK.NETDEV_GetLastError());
                return;
            }

            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get device name");

            string strDevName = GetDefaultString(stDeviceInfo.szDeviceName);
            m_oNetDemo.showDeviceName(strDevName);
            m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_basicInfo.szDeviceName = strDevName;
            
            /* Get disk info */
            NETDEV_DISK_INFO_LIST_S stDiskInfoList = new NETDEV_DISK_INFO_LIST_S();
            iRet = NETDEVSDK.NETDEV_GetDevConfig(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, m_oNetDemo.getChannelID(), (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_DISKSINFO, ref stDiskInfoList, Marshal.SizeOf(stDiskInfoList), ref dwBytesReturned);
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get disk info", NETDEVSDK.NETDEV_GetLastError());
                return;
            }

            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get disk info");

            m_oNetDemo.showDiskInfoList(stDiskInfoList);
            m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_basicInfo.stDiskInfoList = stDiskInfoList;

            m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_basicInfo.existFlag = true;
        }

        private void readBasicInfo()
        {
            m_oNetDemo.showSystemTime(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_basicInfo.stSystemTime);
            m_oNetDemo.showDeviceName(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_basicInfo.szDeviceName);
            m_oNetDemo.showDiskInfoList(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_basicInfo.stDiskInfoList);
        }

        public void saveStstemTime(int timeZone,string Date, String time)
        {
            int dwDeviceIndex = m_oNetDemo.getDeviceIndex();
            if (dwDeviceIndex < 0)
            {
                return;
            }

            /* Save system time */
            NETDEV_TIME_CFG_S stTimeCfg = new NETDEV_TIME_CFG_S();
            stTimeCfg.stTime.dwYear = Convert.ToInt32(Date.Split('/')[0]);
            stTimeCfg.stTime.dwMonth = Convert.ToInt32(Date.Split('/')[1]);
            stTimeCfg.stTime.dwDay = Convert.ToInt32(Date.Split('/')[2]);

            stTimeCfg.stTime.dwHour = Convert.ToInt32(time.Split(':')[0]);
            stTimeCfg.stTime.dwMinute = Convert.ToInt32(time.Split(':')[1]);
            stTimeCfg.stTime.dwSecond = Convert.ToInt32(time.Split(':')[2]);

            stTimeCfg.dwTimeZone = (NETDEV_TIME_ZONE_E)timeZone;

            int iRet = NETDEVSDK.NETDEV_SetSystemTimeCfg(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, ref stTimeCfg);
            if(NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_oNetDemo.getDeviceInfoList()[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Save device system time", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            m_oNetDemo.showSuccessLogInfo(m_oNetDemo.getDeviceInfoList()[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Save device system time");

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS == m_deviceInfoList[dwDeviceIndex].m_eDeviceType)
            {
                m_deviceInfoList[dwDeviceIndex].stVmsDevInfo.stSystemTime = stTimeCfg;
            }
            else
            {
                m_deviceInfoList[dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_basicInfo.stSystemTime = stTimeCfg;
            }
        }

        public void saveDeviceName(String deviceName)
        {
            byte[] byDevName;
            GetUTF8Buffer(deviceName, NetDevSdk.NETDEV_LEN_256, out byDevName);
            int iRet = NETDEVSDK.NETDEV_ModifyDeviceName(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, byDevName);
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Save device name", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Save device name");
            m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_basicInfo.szDeviceName = deviceName;
        }

        /*************************** Basic Cfg end *****************************/
        

        /*************************** Network Cfg start *****************************/
        private void getNetworkInfo()
        {
            int dwDeviceIndex = m_oNetDemo.getDeviceIndex();
            if (dwDeviceIndex < 0)
            {
                return;
            }

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS == m_deviceInfoList[dwDeviceIndex].m_eDeviceType)
            {
                /* not support */
            }
            else
            {
                if (m_deviceInfoList[dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_networkInfo.existFlag == false)
                {
                    refreshNetworkInfo();
                }
                else
                {
                    readNetworkInfo();
                }
            }
        }

        public void refreshNetworkInfo()
        {
            /* Get Network Config */
            NETDEV_NETWORKCFG_S stNetworkcfg = new NETDEV_NETWORKCFG_S();

            Int32 dwBytesReturned = 0;
            int iRet = NETDEVSDK.NETDEV_GetDevConfig(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, m_oNetDemo.getChannelID(), (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_NETWORKCFG, ref stNetworkcfg, Marshal.SizeOf(stNetworkcfg), ref dwBytesReturned);
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get network cfg", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get network cfg");

            m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_networkInfo.stNetWorkIP = stNetworkcfg;
            m_oNetDemo.showBaseNetworkInfo(stNetworkcfg);

            /* Get protocal port */
            NETDEV_UPNP_NAT_STATE_S stNatState = new NETDEV_UPNP_NAT_STATE_S();

            iRet = NETDEVSDK.NETDEV_GetUpnpNatState(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, ref stNatState);
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get upnp nat state", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get upnp nat state");

            m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_networkInfo.stNetWorkPort = stNatState;
            m_oNetDemo.showPortNetworkInfo(stNatState);

            /* Get NTP config */
            NETDEV_SYSTEM_NTP_INFO_S stNTPInfo = new NETDEV_SYSTEM_NTP_INFO_S();

            /* Failed to return Get information when NTP is not enabled for the NVR. Please perform Set operation first. */
            iRet = NETDEVSDK.NETDEV_GetDevConfig(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, m_oNetDemo.getChannelID(), (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_NTPCFG, ref stNTPInfo, Marshal.SizeOf(stNTPInfo), ref dwBytesReturned);
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get NTP cfg", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get NTP cfg");

            m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_networkInfo.stNetWorkNTP = stNTPInfo;
            m_oNetDemo.showNTPNetworkInfo(stNTPInfo);

            m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_networkInfo.existFlag = true;
        }

        private void readNetworkInfo()
        {
            m_oNetDemo.showBaseNetworkInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_networkInfo.stNetWorkIP);
            m_oNetDemo.showPortNetworkInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_networkInfo.stNetWorkPort);
            m_oNetDemo.showNTPNetworkInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_networkInfo.stNetWorkNTP);
        }

        public void saveBaseNetworkInfo(NETDEV_NETWORKCFG_S stNetworkSetcfg)
        {
            int iRet = NETDEVSDK.NETDEV_SetDevConfig(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, m_oNetDemo.getChannelID(), (int)NETDEV_CONFIG_COMMAND_E.NETDEV_SET_NETWORKCFG, ref stNetworkSetcfg, Marshal.SizeOf(stNetworkSetcfg));
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Save network cfg", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Save network cfg");

            m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_networkInfo.stNetWorkIP = stNetworkSetcfg;
        }

        public void savePortNetworkInfo(NETDEV_UPNP_NAT_STATE_S stNatState)
        {
            int iRet = NETDEVSDK.NETDEV_SetUpnpNatState(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, ref stNatState);
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Save upnp nat state", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Save upnp nat state");

            m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_networkInfo.stNetWorkPort = stNatState;
        }

        public void saveNTPNetworkInfo(NETDEV_SYSTEM_NTP_INFO_S stNTPInfo)
        {
            int iRet = NETDEVSDK.NETDEV_SetDevConfig(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, m_oNetDemo.getChannelID(), (int)NETDEV_CONFIG_COMMAND_E.NETDEV_SET_NTPCFG, ref stNTPInfo, Marshal.SizeOf(stNTPInfo));
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Set NTP cfg", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Set NTP cfg");

            m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_networkInfo.stNetWorkNTP = stNTPInfo;
        }

        /*************************** Network Cfg end *****************************/


        /*************************** video Cfg start *****************************/
        private void getVideoInfo()
        {
            if (m_oNetDemo.getChannelID() < 0)
            {
                return;
            }

            int dwDeviceIndex = m_oNetDemo.getDeviceIndex();
            if (dwDeviceIndex < 0)
            {
                return;
            }

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS == m_deviceInfoList[dwDeviceIndex].m_eDeviceType)
            {
                /* not support */
            }
            else
            {
                if (m_deviceInfoList[dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_videoStreamInfo.existFlag == false)
                {
                    refreshVideoInfo();
                }
                else
                {
                    readVideoInfo();
                }
            }
        }

        public void refreshVideoInfo()
        {
            int dwDeviceIndex = m_oNetDemo.getDeviceIndex();
            if (dwDeviceIndex < 0)
            {
                return;
            }

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS == m_deviceInfoList[dwDeviceIndex].m_eDeviceType)
            {
                /* not support */
            }
            else
            {
                /* Get video stream info */
                Int32 dwBytesReturned = 0;

                for (Int32 i = 0; i < 3; i++)
                {
                    NETDEV_VIDEO_STREAM_INFO_S stStreamInfo = new NETDEV_VIDEO_STREAM_INFO_S();
                    stStreamInfo.enStreamType = (NETDEV_LIVE_STREAM_INDEX_E)i;

                    int iRet = NETDEVSDK.NETDEV_GetDevConfig(m_deviceInfoList[dwDeviceIndex].m_lpDevHandle, m_oNetDemo.getChannelID(), (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_STREAMCFG, ref stStreamInfo, Marshal.SizeOf(stStreamInfo), ref dwBytesReturned);
                    if (NetDevSdk.TRUE != iRet)
                    {
                        m_oNetDemo.showFailLogInfo(m_deviceInfoList[dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get stream info, stream type : " + stStreamInfo.enStreamType, NETDEVSDK.NETDEV_GetLastError());
                    }
                    else
                    {
                        m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get stream info, stream type : " + stStreamInfo.enStreamType);
                    }

                    m_deviceInfoList[dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_videoStreamInfo.videoStreamInfoList[i] = stStreamInfo;
                }

                m_oNetDemo.showVideoInfo(m_deviceInfoList[dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_videoStreamInfo.videoStreamInfoList[0]);/*默认显示主流*/
                m_deviceInfoList[dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_videoStreamInfo.existFlag = true;
            }
        }

        private void readVideoInfo()
        {
            m_oNetDemo.showVideoInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_videoStreamInfo.videoStreamInfoList[0]);/*默认显示主流*/
        }

        public void saveVideoInfo(NETDEV_VIDEO_STREAM_INFO_S stStreamInfo)
        {
            int iRet = NETDEVSDK.NETDEV_SetDevConfig(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, m_oNetDemo.getChannelID(), (int)NETDEV_CONFIG_COMMAND_E.NETDEV_SET_STREAMCFG, ref stStreamInfo, Marshal.SizeOf(stStreamInfo));
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Save stream info", NETDEVSDK.NETDEV_GetLastError());
                m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_videoStreamInfo.existFlag = false;
                return;
            }
            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Save stream info");

        }
        /*************************** video Cfg end *****************************/


        /*************************** Image Cfg start *****************************/
        private void getIamgeInfo()
        {
            if (m_oNetDemo.getChannelID() < 0)
            {
                //m_netDemo.m_curSelectedTreeChannelIndex = 0;

                return;
            }

            int dwDeviceIndex = m_oNetDemo.getDeviceIndex();
            if (dwDeviceIndex < 0)
            {
                return;
            }

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS == m_deviceInfoList[dwDeviceIndex].m_eDeviceType)
            {
                /* not support */
            }
            else
            {
                if (m_deviceInfoList[dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_imageInfo.existFlag == false)
                {
                    refreshImageInfo();
                }
                else
                {
                    readImageInfo();
                }
            }
        }

        public void refreshImageInfo()
        {
            int dwDeviceIndex = m_oNetDemo.getDeviceIndex();
            int dwOrgIndex = m_oNetDemo.getOrgIndex();
            int dwSubDeviceIndex = m_oNetDemo.getSubDeviceIndex();
            int dwChannelIndex = m_oNetDemo.getChannelIndex();

            if (dwDeviceIndex < 0 || dwChannelIndex < 0)
            {
                return;
            }

            /* Get Image Config */
            Int32 dwBytesReturned = 0;
            NETDEV_IMAGE_SETTING_S stImageInfo = new NETDEV_IMAGE_SETTING_S();

            int iRet = NETDEVSDK.NETDEV_GetDevConfig(m_deviceInfoList[dwDeviceIndex].m_lpDevHandle, m_oNetDemo.getChannelID(), (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_IMAGECFG, ref stImageInfo, Marshal.SizeOf(stImageInfo), ref dwBytesReturned);
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get image info", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get image info");

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS == m_deviceInfoList[dwDeviceIndex].m_eDeviceType)
            {
                m_deviceInfoList[dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList[dwSubDeviceIndex].stChnInfoList[dwChannelIndex].m_imageInfo.imageInfo = stImageInfo;
            }
            else
            {
                m_deviceInfoList[dwDeviceIndex].m_channelInfoList[dwChannelIndex].m_imageInfo.imageInfo = stImageInfo;
            }
            
            m_oNetDemo.showImageInfo(stImageInfo);
        
        }

        public void readImageInfo()
        {
            m_oNetDemo.showImageInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_imageInfo.imageInfo);
        }

        public void saveImageInfo(NETDEV_IMAGE_SETTING_S stImageInfo)
        {
            int dwDeviceIndex = m_oNetDemo.getDeviceIndex();
            int dwOrgIndex = m_oNetDemo.getOrgIndex();
            int dwSubDeviceIndex = m_oNetDemo.getSubDeviceIndex();
            int dwChannelIndex = m_oNetDemo.getChannelIndex();

            if (dwDeviceIndex < 0 || dwChannelIndex < 0)
            {
                return;
            }

            int iRet = NETDEVSDK.NETDEV_SetDevConfig(m_deviceInfoList[dwDeviceIndex].m_lpDevHandle, m_oNetDemo.getChannelID(), (int)NETDEV_CONFIG_COMMAND_E.NETDEV_SET_IMAGECFG, ref stImageInfo, Marshal.SizeOf(stImageInfo));
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Save image info", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Save image info");

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS == m_deviceInfoList[dwDeviceIndex].m_eDeviceType)
            {
                m_deviceInfoList[dwDeviceIndex].stVmsDevInfo.stOrgInfoList[dwOrgIndex].stVmsDevBasicInfoList[dwSubDeviceIndex].stChnInfoList[dwChannelIndex].m_imageInfo.imageInfo = stImageInfo;
            }
            else
            {
                m_deviceInfoList[dwDeviceIndex].m_channelInfoList[dwChannelIndex].m_imageInfo.imageInfo = stImageInfo;
            }
        }

        /*************************** Image Cfg end *****************************/


        /*************************** OSD Cfg start *****************************/
        private void getOSDInfo()
        {
            if (m_oNetDemo.getChannelID() < 0)
            {
                //m_netDemo.m_curSelectedTreeChannelIndex = 0;

                return;
            }

            int dwDeviceIndex = m_oNetDemo.getDeviceIndex();
            if (dwDeviceIndex < 0)
            {
                return;
            }

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS == m_deviceInfoList[dwDeviceIndex].m_eDeviceType)
            {
                /* not support */
            }
            else
            {
                if (m_deviceInfoList[dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_OSDInfo.existFlag == false)
                {
                    refreshOSDInfo();
                }
                else
                {
                    readOSDInfo();
                }
            }
        }

        public void refreshOSDInfo()
        {
            /* Get OSD */
            NETDEV_VIDEO_OSD_CFG_S stOSDInfo = new NETDEV_VIDEO_OSD_CFG_S();

            Int32 dwOutBufferSize = Marshal.SizeOf(typeof(NETDEV_VIDEO_OSD_CFG_S));
            IntPtr lpOutBuffer = Marshal.AllocHGlobal(dwOutBufferSize);
            Marshal.StructureToPtr(stOSDInfo, lpOutBuffer, true);

            Int32 dwBytesReturned = 0;
            int iRet = NETDEVSDK.NETDEV_GetDevConfig(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, m_oNetDemo.getChannelID(), (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_OSDCFG, lpOutBuffer, dwOutBufferSize, ref dwBytesReturned);
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get OSD cfg fail", NETDEVSDK.NETDEV_GetLastError());
                Marshal.FreeHGlobal(lpOutBuffer);
                return;
            }
            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get OSD cfg");

            
            stOSDInfo = (NETDEV_VIDEO_OSD_CFG_S)Marshal.PtrToStructure(lpOutBuffer, typeof(NETDEV_VIDEO_OSD_CFG_S));
            Marshal.FreeHGlobal(lpOutBuffer);

            m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_OSDInfo.OSDInfo = stOSDInfo;
            m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_OSDInfo.existFlag = true;

            m_oNetDemo.showOSDInfo(stOSDInfo);

        }

        private void readOSDInfo()
        {
            m_oNetDemo.showOSDInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_OSDInfo.OSDInfo);
        }

        public void saveOSDInfo(NETDEV_VIDEO_OSD_CFG_S stOSDInfo)
        {
            Int32 dwInBufferSize = Marshal.SizeOf(typeof(NETDEV_VIDEO_OSD_CFG_S));
            IntPtr lpInBuffer = Marshal.AllocHGlobal(dwInBufferSize);
            Marshal.StructureToPtr(stOSDInfo, lpInBuffer, true);

            int iRet = NETDEVSDK.NETDEV_SetDevConfig(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, m_oNetDemo.getChannelID(), (int)NETDEV_CONFIG_COMMAND_E.NETDEV_SET_OSDCFG, lpInBuffer,ref dwInBufferSize);

            Marshal.FreeHGlobal(lpInBuffer);
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Save OSD cfg", NETDEVSDK.NETDEV_GetLastError());
                return;
            }
            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Save OSD cfg");

            m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_OSDInfo.OSDInfo = stOSDInfo;
        }

        /*************************** OSD Cfg end *****************************/


        /*************************** IO Cfg start *****************************/
        private void getIOInfo()
        {
            if (m_oNetDemo.getChannelIndex() < 0)
            {
                //m_netDemo.m_curSelectedTreeChannelIndex = 0;

                return;
            }

            int dwDeviceIndex = m_oNetDemo.getDeviceIndex();
            if (dwDeviceIndex < 0)
            {
                return;
            }

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS == m_deviceInfoList[dwDeviceIndex].m_eDeviceType)
            {
                /* not support */
            }
            else
            {
                if (m_deviceInfoList[dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_IOInfo.existFlag == false)
                {
                    refreshIOInfo();
                }
                else
                {
                    readIOInfo();
                }
            }
        }

        public void refreshIOInfo()
        {
            int iChannelID = 0;
            if (m_oNetDemo.getChannelIndex() < 0)
            {
                //m_netDemo.m_curSelectedTreeChannelIndex = 0;

                return;
            }

            if (m_oNetDemo.getChannelIndex() == 0)
            {

            }
            else
            {
                iChannelID = m_oNetDemo.getChannelID();
            }

            int dwDeviceIndex = m_oNetDemo.getDeviceIndex();
            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS != m_deviceInfoList[dwDeviceIndex].m_eDeviceType)
            {
                /* Get alarm input info */
                getAlarmInputInfo(iChannelID);

                /* Get alarm output info */
                getAlarmOutputInfo(iChannelID);

                m_deviceInfoList[dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_IOInfo.existFlag = true;
            }
        }

        private void readIOInfo()
        {
            m_oNetDemo.showAlarmInputInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_IOInfo.stInPutInfo);
            m_oNetDemo.showAlarmOutputInfo(0);
        }

        public bool saveAlarmOutputInfo(NETDEV_ALARM_OUTPUT_INFO_S stAlarmOutputInfo)
        {
            int iRet = NETDEVSDK.NETDEV_SetDevConfig(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, m_oNetDemo.getChannelID(), (int)NETDEV_CONFIG_COMMAND_E.NETDEV_SET_ALARM_OUTPUTCFG, ref stAlarmOutputInfo, Marshal.SizeOf(stAlarmOutputInfo));
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Save alarm output", NETDEVSDK.NETDEV_GetLastError());
                return false;
            }

            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Save alarm output");

            return true;
        }

        public void getAlarmInputInfo(int channelID)
        {
            NETDEV_ALARM_INPUT_LIST_S stAlarmInputList = new NETDEV_ALARM_INPUT_LIST_S();
            stAlarmInputList.astAlarmInputInfo = new NETDEV_ALARM_INPUT_INFO_S[NetDevSdk.NETDEV_MAX_ALARM_IN_NUM];

            Int32 dwBytesReturned = 0;
            int iRet = NETDEVSDK.NETDEV_GetDevConfig(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, channelID, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_ALARM_INPUTCFG, ref stAlarmInputList, Marshal.SizeOf(stAlarmInputList), ref dwBytesReturned);
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get alarm input info", NETDEVSDK.NETDEV_GetLastError());
                m_oNetDemo.initIOCfgTab();
                return;
            }

            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get alarm input info");

            m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_IOInfo.stInPutInfo = stAlarmInputList;
            m_oNetDemo.showAlarmInputInfo(stAlarmInputList);
        }

        public void getAlarmOutputInfo(int channelID)
        {
            NETDEV_ALARM_OUTPUT_LIST_S stAlarmOutputList = new NETDEV_ALARM_OUTPUT_LIST_S();
            stAlarmOutputList.astAlarmOutputInfo = new NETDEV_ALARM_OUTPUT_INFO_S[NetDevSdk.NETDEV_MAX_ALARM_OUT_NUM];
            
            Int32 dwBytesReturned = 0;
            int iRet = NETDEVSDK.NETDEV_GetDevConfig(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, channelID, (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_ALARM_OUTPUTCFG, ref stAlarmOutputList, Marshal.SizeOf(stAlarmOutputList), ref dwBytesReturned);
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get alarm output info", NETDEVSDK.NETDEV_GetLastError());
                m_oNetDemo.initIOAlarmOutputCfgTab();
                return;
            }

            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get alarm output info");

            m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_IOInfo.stOutPutInfo = stAlarmOutputList;
            m_oNetDemo.showAlarmOutputInfo(0);
        }
        /*************************** IO Cfg end *****************************/


        /*************************** Privacy Mask Cfg start *****************************/
        private void getPrivacyMaskInfo()
        {
            if (m_oNetDemo.getChannelID() < 0)
            {
                //m_netDemo.m_curSelectedTreeChannelIndex = 0;

                return;
            }

            int dwDeviceIndex = m_oNetDemo.getDeviceIndex();
            if (dwDeviceIndex < 0)
            {
                return;
            }

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS == m_deviceInfoList[dwDeviceIndex].m_eDeviceType)
            {
                /* not support */
            }
            else
            {
                if (m_deviceInfoList[dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_privacyMaskInfo.existFlag == false)
                {
                    refreshPrivacyMaskInfo();
                }
                else
                {
                    readPrivacyMaskInfo();
                }
            }
        }

        public void refreshPrivacyMaskInfo()
        {
            Int32 dwBytesReturned = 0;

            NETDEV_PRIVACY_MASK_CFG_S stPrivacyMaskInfo = new NETDEV_PRIVACY_MASK_CFG_S();
            stPrivacyMaskInfo.astArea = new NETDEV_PRIVACY_MASK_AREA_INFO_S[NetDevSdk.NETDEV_MAX_PRIVACY_MASK_AREA_NUM];
            int iRet = NETDEVSDK.NETDEV_GetDevConfig(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, m_oNetDemo.getChannelID(), (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_PRIVACYMASKCFG, ref stPrivacyMaskInfo, Marshal.SizeOf(stPrivacyMaskInfo), ref dwBytesReturned);
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get privacy mask cfg", NETDEVSDK.NETDEV_GetLastError());
                return;
            }

            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get privacy mask cfg");

            m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_privacyMaskInfo.privacyMaskInfo = stPrivacyMaskInfo;
            m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_privacyMaskInfo.existFlag = true;
            m_oNetDemo.showPrivacyMaskInfo(stPrivacyMaskInfo);
        }

        private void readPrivacyMaskInfo()
        {
            m_oNetDemo.showPrivacyMaskInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_privacyMaskInfo.privacyMaskInfo);
        }

        public void deletePrivacyMaskInfo(int index)
        {
            int iRet = NETDEVSDK.NETDEV_SetDevConfig(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, m_oNetDemo.getChannelID(), (int)NETDEV_CONFIG_COMMAND_E.NETDEV_DELETE_PRIVACYMASKCFG, ref index, Marshal.SizeOf(index));
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Delete privacy mask cfg", NETDEVSDK.NETDEV_GetLastError());
                return;
            }

            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Delete privacy mask cfg");
        }

        public void savePrivacyMaskInfo(NETDEV_PRIVACY_MASK_CFG_S stPrivacyMaskInfo)
        {
            int iRet = NETDEVSDK.NETDEV_SetDevConfig(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, m_oNetDemo.getChannelID(), (int)NETDEV_CONFIG_COMMAND_E.NETDEV_SET_PRIVACYMASKCFG, ref stPrivacyMaskInfo, Marshal.SizeOf(stPrivacyMaskInfo));
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Save privacy mask cfg", NETDEVSDK.NETDEV_GetLastError());
                return;
            }

            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Save privacy mask cfg");

            m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_privacyMaskInfo.privacyMaskInfo = stPrivacyMaskInfo;
        }

        /*************************** Privacy Mask Cfg end *****************************/


        /*************************** Motion Cfg start *****************************/
        private void getMotionInfo()
        {
            if (m_oNetDemo.getChannelID() < 0)
            {
                //m_netDemo.m_curSelectedTreeChannelIndex = 0;

                return;
            }

            int dwDeviceIndex = m_oNetDemo.getDeviceIndex();
            if (dwDeviceIndex < 0)
            {
                return;
            }

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS == m_deviceInfoList[dwDeviceIndex].m_eDeviceType)
            {
                /* not support */
            }
            else
            {
                if (m_deviceInfoList[dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_MotionAlarmInfo.existFlag == false)
                {
                    refreshMotionInfo();
                }
                else
                {
                    readMotionInfo();
                }
            }
        }

        public void refreshMotionInfo()
        {
            NETDEV_MOTION_ALARM_INFO_S stMotionAlarmInfo = new NETDEV_MOTION_ALARM_INFO_S();
            stMotionAlarmInfo.awScreenInfo = new NETDEV_Int16Array[NetDevSdk.NETDEV_SCREEN_INFO_ROW];

            for (int i = 0; i < NetDevSdk.NETDEV_SCREEN_INFO_ROW; i++)
            {
                stMotionAlarmInfo.awScreenInfo[i].data = new short[NetDevSdk.NETDEV_SCREEN_INFO_COLUMN];
            }

            Int32 dwBytesReturned = 0;
            int iRet = NETDEVSDK.NETDEV_GetDevConfig(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, m_oNetDemo.getChannelID(), (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_MOTIONALARM, ref stMotionAlarmInfo, Marshal.SizeOf(stMotionAlarmInfo), ref dwBytesReturned);
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get motion cfg", NETDEVSDK.NETDEV_GetLastError());
                return;
            }

            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get motion cfg");
            
            if (stMotionAlarmInfo.dwObjectSize > MAXMOTIONOBJECTSIZE)
            {
                stMotionAlarmInfo.dwObjectSize = MAXMOTIONOBJECTSIZE;
            }

            m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_MotionAlarmInfo.MotionAlarmInfo = stMotionAlarmInfo;
            m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_MotionAlarmInfo.existFlag = true;
            m_oNetDemo.showMotionInfo(ref stMotionAlarmInfo);
        }

        private void readMotionInfo()
        {
            m_oNetDemo.showMotionInfo(ref m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_MotionAlarmInfo.MotionAlarmInfo);
        }

        public void saveMotionInfo(ref NETDEV_MOTION_ALARM_INFO_S stMotionAlarmInfo)
        {
            int iRet = NETDEVSDK.NETDEV_SetDevConfig(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, m_oNetDemo.getChannelID(), (int)NETDEV_CONFIG_COMMAND_E.NETDEV_SET_MOTIONALARM, ref stMotionAlarmInfo, Marshal.SizeOf(stMotionAlarmInfo));
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Save motion cfg", NETDEVSDK.NETDEV_GetLastError());
                return;
            }

            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Save motion cfg");

            m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_MotionAlarmInfo.MotionAlarmInfo = stMotionAlarmInfo;
        }
        /*************************** Motion Cfg end *****************************/


        /*************************** Temper Cfg start *****************************/
        private void getTemperInfo()
        {
            if (m_oNetDemo.getChannelIndex() < 0)
            {
                //m_netDemo.m_curSelectedTreeChannelIndex = 0;

                return;
            }

            int dwDeviceIndex = m_oNetDemo.getDeviceIndex();
            if (dwDeviceIndex < 0)
            {
                return;
            }

            if (NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_VMS == m_deviceInfoList[dwDeviceIndex].m_eDeviceType)
            {
                /* not support */
            }
            else
            {
                if (m_deviceInfoList[dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_tamperAlarmInfo.existFlag == false)
                {
                    refreshTemperInfo();
                }
                else
                {
                    readTemperInfo();
                }
            }
        }

        public void refreshTemperInfo()
        {
            NETDEV_TAMPER_ALARM_INFO_S stTamperAlarmInfo = new NETDEV_TAMPER_ALARM_INFO_S();
            Int32 dwBytesReturned = 0;
            int iRet = NETDEVSDK.NETDEV_GetDevConfig(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, m_oNetDemo.getChannelID(), (int)NETDEV_CONFIG_COMMAND_E.NETDEV_GET_TAMPERALARM, ref stTamperAlarmInfo, Marshal.SizeOf(stTamperAlarmInfo), ref dwBytesReturned);
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get tamper info", NETDEVSDK.NETDEV_GetLastError());
                return;
            }

            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Get tamper info");

            m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_tamperAlarmInfo.tamperAlarmInfo = stTamperAlarmInfo;
            m_oNetDemo.showTemperInfo(ref stTamperAlarmInfo);
            m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_tamperAlarmInfo.existFlag = true;
        }

        private void readTemperInfo()
        {
            m_oNetDemo.showTemperInfo(ref m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_tamperAlarmInfo.tamperAlarmInfo);
        }

        public void saveTemperInfo(NETDEV_TAMPER_ALARM_INFO_S stTamperAlarmInfo)
        {
            int iRet = NETDEVSDK.NETDEV_SetDevConfig(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_lpDevHandle, m_oNetDemo.getChannelID(), (int)NETDEV_CONFIG_COMMAND_E.NETDEV_SET_TAMPERALARM, ref stTamperAlarmInfo, Marshal.SizeOf(stTamperAlarmInfo));
            if (NetDevSdk.TRUE != iRet)
            {
                m_oNetDemo.showFailLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Save tamper info", NETDEVSDK.NETDEV_GetLastError());
                return;
            }

            m_oNetDemo.showSuccessLogInfo(m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_ip + " chl:" + (m_oNetDemo.getChannelID()), "Save tamper info");

            m_deviceInfoList[m_oNetDemo.m_CurSelectTreeNodeInfo.dwDeviceIndex].m_channelInfoList[m_oNetDemo.getChannelIndex()].m_tamperAlarmInfo.tamperAlarmInfo = stTamperAlarmInfo;
        }

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

        /*************************** Temper Cfg end *****************************/
    }
}