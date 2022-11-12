using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PLAYBACKCOND_S
    {
        public Int32 dwChannelID;                /* Playback channel */
        public Int64 tBeginTime;                 /* Playback start time */
        public Int64 tEndTime;                   /* Playback end time */
        public Int32 dwLinkMode;                 /* #NETDEV_PROTOCAL_E  Transport protocol, see enumeration #NETDEV_PROTOCAL_E */
        public IntPtr hPlayWnd;                   /* Play window handle */
        public Int32 dwFileType;                 /*#NETDEV_PLAN_STORE_TYPE_E  Recording storage type, see enumeration #NETDEV_PLAN_STORE_TYPE_E */
        public Int32 dwDownloadSpeed;            /* #NETDEV_E_DOWNLOAD_SPEED_E */
        public Int32 dwStreamMode;                 /* stream mode see #NETDEV_STREAM_MODE_E */
        public Int32 dwStreamIndex;              /* 存储码流类型, 参见枚举#NETDEV_LIVE_STREAM_INDEX_E */
        public Int32 dwRecordLocation;           /* 录像存储位置 Record Position, 参见枚举#NETDEV_RECORD_LOCATION_E */
        public Int32 dwTransType;                /* 传输类型，参见枚举#NETDEV_TRANS_TYPE_E */
        public Int32 bCloudStorage;              /* 是否开启云存储回放模式 */
        public Int32 bOneFrameEnable;            /* 是否开启单帧解码模式，开启后对解码效率有影响 */
        public Int32 dwPlaySpeed;                /* Playback speed, see enumeration #NETDEV_VOD_PLAY_STATUS_E*/
        NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF cbPlayDecodeVideoCALLBACK;       /*  Decode data callback function */
        public Int64 tPlayTime;                  /* Playback time */
        public UInt32 udwServerID;                /* Video server ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 212)]
        public byte[] szReserve;                    /* Reserved */
    }

}
