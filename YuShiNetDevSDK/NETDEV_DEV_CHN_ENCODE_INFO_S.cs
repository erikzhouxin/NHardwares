using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEV_CHN_ENCODE_INFO_S
    {
        public NETDEV_DEV_CHN_BASE_INFO_S stChnBaseInfo;  /* 通道基本信息 */
        public Int32 dwMaxStream;    /* 支持的最大流个数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public NETDEV_STREAM_FORMAT_INFO_S[] astStreamFormatList;             /* Disk info*/
        public Int32 bSupportPTZ;    /* 是否支持云台 */
        public Int32 bScrambleEnable;    /* 码流是否加扰使能 */
        public Int32 dwAudioResID;   /* 音频资源ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_32)]
        public byte[] szGBResID;    /** 国标资源ID */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 224)]
        public byte[] byRes;
    };

}
