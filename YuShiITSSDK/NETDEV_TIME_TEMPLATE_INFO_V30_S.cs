using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @struct tagstNETDEVTimeTemplateInfo
     * @brief 
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_TEMPLATE_INFO_V30_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_NAME_MAX_LEN)]
        public byte[] szTamplateName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_DESCRIBE_MAX_LEN)]
        public byte[] szTamplateDesc;
        public Int32 dwTemplateType;                                                 /* See #NETDEV_TIME_TEMPLATE_TYPE_E */
        public NETDEV_TIME_RANGE_S stTimeRange;
    }

}
