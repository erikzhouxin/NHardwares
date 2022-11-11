using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 按文件名回放录像参数 结构体定义 Parameters of play back recordings by file name Structure definition
     * @attention 无 None
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PLAYBACKINFO_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = ItsNetDevSdk.NETDEV_LEN_260)]
        public String szName;                   /* 回放的控制块名称  Playback control block name*/
        public Int64 tBeginTime;                /* 回放开始时间  Playback start time */
        public Int64 tEndTime;                  /* 回放结束时间  Playback end time */
        public Int32 dwLinkMode;                /* 传输协议,参见枚举#NETDEV_PROTOCAL_E  Transport protocol, see enumeration #NETDEV_PROTOCAL_E */
        public IntPtr hPlayWnd;                 /* 播放窗口句柄  Play window handle */
        public Int32 dwFileType;                /* 录像存储类型,参见枚举#NETDEV_PLAN_STORE_TYPE_E  Recording storage type, see enumeration #NETDEV_PLAN_STORE_TYPE_E */
        public Int32 dwDownloadSpeed;           /* 下载速度 参见枚举#NETDEV_E_DOWNLOAD_SPEED_E  Download speed, see enumeration #NETDEV_E_DOWNLOAD_SPEED_E */
        public Int32 dwStreamMode;              /*  启流模式，参见枚举#NETDEV_STREAM_MODE_E  stream mode see #NETDEV_STREAM_MODE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
        public byte[] szReserve;                /* 保留字段  Reserved */
    }

}
