using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //前端设备地址信息，智能分析仪表示的是前端设备的地址信息，其他设备表示本机的地址
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_DEV_INFO
    {
        public NET_DVR_IPADDR struDevIP;//前端设备地址，
        public ushort wPort;//前端设备端口号， 
        public byte byChannel;//前端设备通道，
        public byte byIvmsChannel;// 保留字节
    }
}
