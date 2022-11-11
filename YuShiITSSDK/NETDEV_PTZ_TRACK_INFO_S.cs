using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 云台轨迹巡航路径信息 结构体定义 Route information of PTZ route patrol Structure definition
     * @attention 无 None
     */
    public struct NETDEV_PTZ_TRACK_INFO_S
    {
        public Int32 dwTrackNum;                                           /* 已存在的巡航轨迹的数量  Number of existing patrol routes */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ItsNetDevSdk.NETDEV_LEN_64)]
        public String TrackName;                                           /* 轨迹名称  Route name */
    }

}
