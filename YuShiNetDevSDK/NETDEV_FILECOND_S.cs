using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_FILECOND_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public String szFileName;                    /* Recording file name */
        public Int32 dwChannelID;                    /* Channel ID */
        public Int32 dwStreamType;                   /* #NETDEV_LIVE_STREAM_INDEX_E  Stream type, see enumeration #NETDEV_LIVE_STREAM_INDEX_E */
        public Int32 dwFileType;                     /* Recording storage type, see enumeration # NETDEV_PLAN_STORE_TYPE_E */
        public Int64 tBeginTime;                     /* Start time */
        public Int64 tEndTime;                       /* End time */
        public Int32 dwRecordLocation;               /* Record Position, see enumeration# NETDEV_RECORD_LOCATION_E */
        public Int32 udwServerID;                    /* 录像所属服务器ID Video server ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
        public byte[] szReserve;                    /* Reserved */
    }

}
