using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_STORAGE_CONTAINER_INFO_LIST_S
    {
        public Int32 udwLocalHDDNum;                                        /* 本地硬盘数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LOCAL_DISK_MAX_NUM)]
        public NETDEV_STORAGE_CONTAINER_INFO_S[] astLocalHDDList;           /* 本地存储盘信息列表 */
        public Int32 udwSDNum;                                              /* SD卡数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_SD_CARD_DISK_MAX_NUM)]
        public NETDEV_STORAGE_CONTAINER_INFO_S[] astSDList;                 /* SD卡信息列表 */
        public Int32 udwArrayNum;                                           /* 阵列数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_ARRAY_MAX_NUM)]
        public NETDEV_STORAGE_CONTAINER_INFO_S[] astArrayList;              /* 阵列信息列表 */
        public Int32 udwExtendCabinet1HDDNum;                               /* 拓展柜-1存储盘数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_EXTEND_CABINET_DISK_MAX_NUM)]
        public NETDEV_STORAGE_CONTAINER_INFO_S[] astExtendCabinet1HDDList;  /* 拓展柜-1 信息列表 */
        public Int32 udwExtendCabinet2HDDNum;                               /* 拓展柜-2存储盘数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_EXTEND_CABINET_DISK_MAX_NUM)]
        public NETDEV_STORAGE_CONTAINER_INFO_S[] astExtendCabinet2HDDList;  /* 拓展柜-2 信息列表 */
        public Int32 udwNASNum;                                             /* NAS数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_NAS_MAX_NUM)]
        public NETDEV_EXTEND_STORAGE_CONTAINER_INFO_S[] astNASList;         /* NAS信息列表 */
        public Int32 udweSATANum;                                           /* eSATA硬盘数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_ESATA_MAX_NUM)]
        public NETDEV_EXTEND_STORAGE_CONTAINER_INFO_S[] asteSATAList;      /* eSATA信息列表 */
        public Int32 udwIPSANNum;                                           /* IPSAN数量 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_ESATA_MAX_NUM)]
        public NETDEV_EXTEND_STORAGE_CONTAINER_INFO_S[] astIPSANList;      /* IPSAN信息列表 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szReserve;                                    /* Reserved */
    }

}
