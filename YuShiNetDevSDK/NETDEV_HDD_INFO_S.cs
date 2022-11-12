using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_HDD_INFO_S
    {
        public Int32 udwID;                                 /* 磁盘编号 */
        public Int32 udwType;                               /* 磁盘类型 参见枚举#NETDEV_HDD_TYPE_E */
        public Int32 udwWorkMode;                           /* 磁盘工作模式 参见枚举#NETDEV_HDD_WORK_MODE_E */
        public Int32 udwTotalCapacity;                      /* 硬盘总容量(MB) Total Capacity */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szRAIDName;                          /* 阵列名称 */
        public Int32 udwStatus;                            /* 磁盘状态 参见枚举#NETDEV_HDD_STATUS_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szManufacturer;                      /* 厂商名称 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                                    /* Reserved */
    }

}
