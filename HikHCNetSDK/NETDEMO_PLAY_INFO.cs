using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct PLAY_INFO
    {
        public int iUserID;      //注册用户ID
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string strDeviceIP;
        public int iDevicePort;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string strDevAdmin;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string strDevPsd;
        public int iChannel;      //播放通道号(从0开始)
        public int iLinkMode;   //最高位(31)为0表示主码流，为1表示子码流，0－30位表示码流连接方式: 0：TCP方式,1：UDP方式,2：多播方式,3 - RTP方式，4-音视频分开(TCP)
        public bool bUseMedia;     //是否启用流媒体
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 20)]
        public string strMediaIP; //流媒体IP地址
        public int iMediaPort;   //流媒体端口号
    }
}
