using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagstNETDEVTimeTemplate
     * @brief 时间模板信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_TEMPLATE_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_NAME_MAX_LEN)]
        public byte[] szTamplateName;        /* 模板名称 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_DESCRIBE_MAX_LEN)]
        public byte[] szTamplateDesc;    /* 模板描述 */
        public Int32 dwTamplateID;                               /* 模板ID */
    }

}
