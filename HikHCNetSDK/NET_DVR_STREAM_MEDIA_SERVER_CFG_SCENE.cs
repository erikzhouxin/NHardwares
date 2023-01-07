using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*流媒体服务器基本配置*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_STREAM_MEDIA_SERVER_CFG_SCENE
    {
        public byte byValid;            /*是否启用流媒体服务器取流,0表示无效*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_DVR_IPADDR struDevIP;    /*流媒体服务器地址*/
        public ushort wDevPort;         /*流媒体服务器端口*/
        public byte byTransmitType;     /*传输协议类型0-TCP，1-UDP */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
