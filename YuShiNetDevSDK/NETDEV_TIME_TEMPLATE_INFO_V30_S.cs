using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    /**
     * @struct tagstNETDEVTimeTemplateInfo
     * @brief 时间模板详细信息
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_TIME_TEMPLATE_INFO_V30_S
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_NAME_MAX_LEN)]
        public byte[] szTamplateName;                            /* 模板名称 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_DESCRIBE_MAX_LEN)]
        public byte[] szTamplateDesc;                        /* 模板描述 */
        public Int32 dwTemplateType;                                                 /* 时间模板类型 参见NETDEV_TIME_TEMPLATE_TYPE_E */
        public NETDEV_TIME_RANGE_S stTimeRange;                                     /* 共8个时间范围 */
    }

}
