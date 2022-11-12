using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_PLAYBACKINFO_S
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_260)]
        public String szName;         /* Playback control block name*/
        public Int64 tBeginTime;                     /* Playback start time */
        public Int64 tEndTime;                       /* Playback end time */
        public Int32 dwLinkMode;                     /* #NETDEV_PROTOCAL_E  Transport protocol, see enumeration #NETDEV_PROTOCAL_E */
        public IntPtr hPlayWnd;                       /* Play window handle */
        public Int32 dwFileType;                     /* #NETDEV_PLAN_STORE_TYPE_E  Recording storage type, see enumeration #NETDEV_PLAN_STORE_TYPE_E */
        public Int32 dwDownloadSpeed;                /* #NETDEV_E_DOWNLOAD_SPEED_E  Download speed, see enumeration #NETDEV_E_DOWNLOAD_SPEED_E */
        public Int32 dwStreamMode;                 /* stream mode see #NETDEV_STREAM_MODE_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
        public byte[] szReserve;                    /* Reserved */
    }

}
