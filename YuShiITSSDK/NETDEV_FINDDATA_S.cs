using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 录像查找数据 结构体定义 Recording query data Structure definition
     *        逐个获取查找到的文件信息 Get the information of found files one by one
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FINDDATA_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public String szFileName;                               /* 录像文件名  Recording file name */
        public Int64 tBeginTime;                                /* 起始时间  Start time */
        public Int64 tEndTime;                                  /* 结束时间  End time */
        public byte byFileType;                                 /* 录像存储类型  参见枚举#NETDEV_STORE_TYPE_E Recording storage type #NETDEV_STORE_TYPE_E */
        public Int32 udwServerID;                               /* 录像所属服务器ID */
        public Int32 udwFileSize;                               /* 录像文件大小 Recording file size */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 163)]
        public byte[] szReserve;                    /* Reserved */
    }

}
