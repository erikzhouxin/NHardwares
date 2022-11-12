using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_TIME_SECTION_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public string szBeginTime;                                                   /* 开始时间*/
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public string szEndTime;                                                   /* 结束时间 */
        public UInt32 udArmingType;                /* 布防类型 参考NETDEV_ARMING_TYPE_E*/
    };

}
