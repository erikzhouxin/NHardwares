using System.Collections.Generic;

namespace System.Data.YuShiNetDevSDK
{
    public class NETDEMO_VMS_DEVICE_INFO_S
    {
        public NETDEV_TIME_CFG_S stSystemTime;
        public List<NETDEMO_VMS_ORG_INFO_S> stOrgInfoList = new List<NETDEMO_VMS_ORG_INFO_S>();
    }
}
