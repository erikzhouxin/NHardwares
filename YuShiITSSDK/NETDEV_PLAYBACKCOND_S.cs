using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 按时间回放录像参数 结构体定义 Parameters of play back by time Structure definition
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PLAYBACKCOND_S
    {
        public Int32 dwChannelID;                /* 回放的通道  Playback channel */
        public Int64 tBeginTime;                 /* 回放开始时间  Playback start time */
        public Int64 tEndTime;                   /* 回放结束时间  Playback end time */
        public Int32 dwLinkMode;                 /* 传输协议，参见枚举#NETDEV_TRANS_PROTOCAL_E  Transport protocol, see enumeration #NETDEV_PROTOCAL_E */
        public IntPtr hPlayWnd;                  /* 播放窗口句柄 Play window handle */
        public Int32 dwFileType;                 /* 录像存储类型，参见枚举#NETDEV_STORE_TYPE_E  Recording storage type, see enumeration #NETDEV_PLAN_STORE_TYPE_E */
        public Int32 dwDownloadSpeed;            /* 下载速度 参见枚举#NETDEV_E_DOWNLOAD_SPEED_E  Download speed, see enumeration #NETDEV_E_DOWNLOAD_SPEED_E */
        public Int32 dwStreamMode;               /* 启流模式，参见枚举#NETDEV_STREAM_MODE_E  stream mode see #NETDEV_STREAM_MODE_E*/
        public Int32 dwStreamIndex;              /* 存储码流类型, 参见枚举#NETDEV_LIVE_STREAM_INDEX_E */
        public Int32 dwRecordLocation;           /* 录像存储位置 Record Position, 参见枚举#NETDEV_RECORD_LOCATION_E*/
        public Int32 dwTransType;                /* 传输类型，参见枚举#NETDEV_TRANS_TYPE_E */
        public Int32 bCloudStorage;              /* 是否开启云存储回放模式 */
        public Int32 bOneFrameEnable;            /* 是否开启单帧解码模式，开启后对解码效率有影响 */
        public Int32 dwPlaySpeed;                /* 回放播放速度，参考枚举#NETDEV_VOD_PLAY_STATUS_E  Playback speed, see enumeration #NETDEV_VOD_PLAY_STATUS_E*/
        NETDEV_DECODE_VIDEO_DATA_CALLBACK_PF cbPlayDecodeVideoCALLBACK;   /* 解码后数据回调函数 Decode data callback function */
        public Int64 tPlayTime;                  /* 播放时间  Playback time */
        public UInt32 udwServerID;               /* 录像所属服务器ID Video server ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 212)]
        public byte[] szReserve;                 /* 保留字段   */
    }

}
