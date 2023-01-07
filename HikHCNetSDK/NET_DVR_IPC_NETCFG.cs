using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //通过DVR设置前端IPC的IP地址
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IPC_NETCFG
    {
        public uint dwSize;      //结构体大小
        public NET_DVR_IPADDR struIP;       //IPC的IP地址
        public ushort wPort;       //IPC的端口
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 126)]
        public string res;
    }
}
