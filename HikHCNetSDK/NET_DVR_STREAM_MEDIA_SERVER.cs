using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /*流媒体服务器基本配置*/
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_STREAM_MEDIA_SERVER
    {
        public byte byValid;/*是否启用流媒体服务器取流,0表示无效，非0表示有效*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.MAX_DOMAIN_NAME)]
        public string byAddress;/* 设备IP地址或者域名 */
        public ushort wDevPort;/*流媒体服务器端口*/
        public byte byTransmitType;/*传输协议类型 0-TCP，1-UDP*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
