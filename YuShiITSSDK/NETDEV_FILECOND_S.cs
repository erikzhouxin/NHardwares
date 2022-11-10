using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 录像查找 结构体定义 Recording query Structure definition
     *        根据文件类型.时间查找设备录像文件 Query recording files according to file type and time
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FILECOND_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NETDEMO.NETDEV_LEN_64)]
        public String szFileName;                    /* 录像文件名  Recording file name */
        public Int32 dwChannelID;                    /* 通道号  Channel ID */
        public Int32 dwStreamType;                   /* 码流类型,参见枚举#NETDEV_LIVE_STREAM_INDEX_E  Stream type, see enumeration #NETDEV_LIVE_STREAM_INDEX_E */
        public Int32 dwFileType;                     /* 录像存储类型,参见枚举# NETDEV_STORE_TYPE_E  Recording storage type, see enumeration #NETDEV_STORE_TYPE_E */
        public Int64 tBeginTime;                     /* 起始时间  Start time */
        public Int64 tEndTime;                       /* 结束时间  End time */
        public Int32 dwRecordLocation;               /* 录像存储位置 Record Position, 参见枚举#NETDEV_RECORD_LOCATION_E */
        public Int32 udwServerID;                    /* 录像所属服务器ID Video server ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
        public byte[] szReserve;                    /* Reserved */
    }

}
