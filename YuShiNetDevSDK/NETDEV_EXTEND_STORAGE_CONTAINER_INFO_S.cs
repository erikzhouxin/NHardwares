using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_EXTEND_STORAGE_CONTAINER_INFO_S
    {
        public Int32 udwID;                                 /* 磁盘编号 */
        public Int32 udwRemainCapacity;                     /* 存储容器剩余容量(MB) */
        public Int32 udwTotalCapacity;                      /* 存储容器总容量(MB) */
        public Int32 udwAddressType;                        /* IP地址类型,参见枚举#NETDEV_ADDR_TYPE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szIPAddress;                          /* 服务器IP地址 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_256)]
        public byte[] szPath;                               /* NAS服务器存储路径 */
        public Int32 udwUsageType;                          /* 用途,参见枚举#NETDEV_STORAGE_CONTAINER_USAGE_TYPE_E */
        public Int32 udwStatus;                             /* 存储容器状态 参见枚举#NETDEV_STORAGE_CONTAINER_STATUS_E */
        public Int32 udwProperty;                           /* 存储盘属性,当udwStatus为0时无效 参见枚举#NETDEV_STORAGE_CONTAINER_PROPERTY_E */
        public Int32 udwFormatProgress;                     /* 格式化进度，百分比 */
        public Int32 udwGroupID;                            /* 盘组序号 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] szReserve;                                    /* Reserved */
    }

}
