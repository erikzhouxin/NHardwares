using System.Collections.Generic;

namespace System.Data.YuShiNetDevSDK
{
    public class NETDEMO_PlayBackInfo
    {
        public IntPtr m_devHandle = IntPtr.Zero;
        public List<NETDEV_FINDDATA_S> m_findPlayBackDataList = new List<NETDEV_FINDDATA_S>();
        public int m_curSelectedChannelID = -1;
        public int m_curSelectedDeviceIndex = -1;
        public int m_nextPlayBackPanelIndex = 0;

        public System.Timers.Timer m_timer = new System.Timers.Timer(500);//初始化为100毫秒
    }
}
