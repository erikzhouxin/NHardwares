using System.Collections.Generic;

namespace System.Data.YuShiNetDevSDK
{
    public class NETDEMO_VMS_DEV_BASIC_INFO_S
    {
        public NETDEV_DEV_BASIC_INFO_S stDevBasicInfo;
        public List<NETDEMO_VMS_DEV_CHANNEL_INFO_S> stChnInfoList = new List<NETDEMO_VMS_DEV_CHANNEL_INFO_S>();
    }
}
