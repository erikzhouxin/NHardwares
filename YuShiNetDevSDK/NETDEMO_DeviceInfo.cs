using System.Collections.Generic;

namespace System.Data.YuShiNetDevSDK
{
    public class NETDEMO_DeviceInfo
    {
        public NETDEMO_DEVICE_TYPE_E m_eDeviceType = NETDEMO_DEVICE_TYPE_E.NETDEMO_DEVICE_IPC_OR_NVR;

        //本地设备信息
        public String m_ip = null;
        public Int32 m_port = 0;
        public String m_userName = null;
        public String m_password = null;

        /* VMS */
        public NETDEMO_VMS_DEVICE_INFO_S stVmsDevInfo;

        /*共用信息*/
        public IntPtr m_lpDevHandle = IntPtr.Zero;
        public Int32 m_channelNumber = 0;
        public NETDEV_DEVICE_INFO_S m_stDevInfo;//设备信息，用于登录出参

        /* IPC/NVR */
        public Int32 m_dwSubFaceStructAlarmID = -1;
        public Int32 m_dwSubVehicleStructAlarmID = -1;
        public Int32 m_dwSubFaceRecogAlarmID = -1;
        public Int32 m_dwSubVehicleRecogAlarmID = -1;

        public List<NETDEMO_ChannelInfo> m_channelInfoList = new List<NETDEMO_ChannelInfo>();

        //public List<NETDEV_VIDEO_CHL_DETAIL_INFO_S> m_devVideoChlInfoList = new List<NETDEV_VIDEO_CHL_DETAIL_INFO_S>();
        //public List<>  = new List<NETDEV_CRUISE_LIST_S>();

        static readonly object m_RealPlayInfolocker = new object();
        public List<NETDEMO_RealPlayInfo> m_RealPlayInfoList = new List<NETDEMO_RealPlayInfo>();

        public void addRealPlayInfo(NETDEMO_RealPlayInfo objRealPlayInfo)
        {
            lock (m_RealPlayInfolocker)
            {
                for (int i = 0; i < m_RealPlayInfoList.Count; i++)
                {
                    if (m_RealPlayInfoList[i].m_channel == objRealPlayInfo.m_channel &&
                        m_RealPlayInfoList[i].m_panelIndex == objRealPlayInfo.m_panelIndex)
                    {
                        return;
                    }
                }
                m_RealPlayInfoList.Add(objRealPlayInfo);
            }
        }

        public void removeRealPlayInfo(NETDEMO_RealPlayInfo objRealPlayInfo)
        {
            lock (m_RealPlayInfolocker)
            {
                for (int i = 0; i < m_RealPlayInfoList.Count; i++)
                {
                    if (m_RealPlayInfoList[i].m_channel == objRealPlayInfo.m_channel &&
                        m_RealPlayInfoList[i].m_panelIndex == objRealPlayInfo.m_panelIndex)
                    {
                        m_RealPlayInfoList.RemoveAt(i);
                    }
                }
            }
        }

        public void initDeviceInfo()
        {
            /*共用信息*/
            m_lpDevHandle = IntPtr.Zero;
            m_channelNumber = 0;
            stVmsDevInfo = null;
            m_channelInfoList.Clear();

            m_dwSubFaceStructAlarmID = -1;
            m_dwSubVehicleStructAlarmID = -1;

            m_dwSubFaceRecogAlarmID = -1;
            m_dwSubVehicleRecogAlarmID = -1;
        }
    }
}
