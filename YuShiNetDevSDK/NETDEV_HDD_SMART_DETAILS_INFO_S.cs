using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_HDD_SMART_DETAILS_INFO_S
    {
        public Int32 udwAttributeID;                                /* 属性ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szAttributeName;                              /* 属性名称 */
        public Int32 udwStatus;                                     /* 状态 参见枚举#NETDEV_HDD_SMART_ASSESSMENT_STATUS_E */
        public Int32 udwHex;                                        /* 显示为十六进制 */
        public Int32 udwThresh;                                     /* 阈值 */
        public Int32 udwCurrentValue;                               /* 当前值 */
        public Int32 udwWorstValue;                                 /* 最差值 */
        public Int32 udwActualValue;                                /* 实际值 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                                    /* Reserved */
    }

}
