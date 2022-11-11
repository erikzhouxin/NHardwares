using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 云台预置位巡航路径详细信息 结构体定义 PTZ preset patrol route information Structure definition 
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_CRUISE_INFO_S
    {
        public Int32 dwCuriseID;                                     /* 轨迹ID  Route ID */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ItsNetDevSdk.NETDEV_LEN_32)]
        public string szCuriseName;                                  /* 轨迹名称  Route name */
        public Int32 dwSize;                                         /* 路径包含的轨迹点数量  Number of presets included in the route */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_MAX_CRUISEPOINT_NUM)]
        public NETDEV_CRUISE_POINT_S[] astCruisePoint;               /* 路径包含的轨迹点信息   Information of presets included in the route */
    }

}
