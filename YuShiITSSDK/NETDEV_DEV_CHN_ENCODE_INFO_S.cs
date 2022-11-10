using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEV_CHN_ENCODE_INFO_S
    {
        public NETDEV_DEV_CHN_BASE_INFO_S stChnBaseInfo;
        public Int32 dwMaxStream;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public NETDEV_STREAM_FORMAT_INFO_S[] astStreamFormatList;             /* Disk info*/
        public Int32 bSupportPTZ;
        public Int32 bScrambleEnable;
        public Int32 dwAudioResID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_32)]
        public byte[] szGBResID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 224)]
        public byte[] byRes;
    };

}
