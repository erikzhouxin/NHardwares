using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VIDEO_TIME_SECTION_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ItsNetDevSdk.NETDEV_LEN_64)]
        public string szBeginTime;                                                   /* begin*/
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ItsNetDevSdk.NETDEV_LEN_64)]
        public string szEndTime;                                                   /* end */
        public UInt32 udArmingType;                /* See NETDEV_ARMING_TYPE_E*/
    };

}
