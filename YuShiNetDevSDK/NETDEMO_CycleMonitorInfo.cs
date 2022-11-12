using System.Collections.Generic;

namespace System.Data.YuShiNetDevSDK
{
    /*循环监视信息*/
    public class NETDEMO_CycleMonitorInfo
    {
        /*单个监视对象信息*/
        public struct CYCLE_MONITOR_CHANNEL_INFO_S
        {
            public int deviceIndex;
            public IntPtr devhandle;
            public int channelID;/*1 ~ &*/
        }

        public NETDEMO_MONITOR_TYPE_E monitorType = NETDEMO_MONITOR_TYPE_E.NETDEMO_MONITOR_SINGLE_SCREEN;
        public int panelNo = 0; /*0 ~ 15*/
        public int monitorCount = 0;
        public int intervalTime = 20;/*秒*/
        public List<CYCLE_MONITOR_CHANNEL_INFO_S> channelInfoList = new List<CYCLE_MONITOR_CHANNEL_INFO_S>();
    }
}
