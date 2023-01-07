using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //Upnp端口映射状态结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_UPNP_NAT_STATE
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_UPNP_PORT_STATE[] strUpnpPort;//端口映射状态:：数组0- web server端口，数组1- 管理端口，数组2- rtsp端
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 200, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;//保留
    }
}
