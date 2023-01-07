using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //rtsp配置 ipcamera专用
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_RTSPCFG
    {
        public uint dwSize;//长度
        public ushort wPort;//rtsp服务器侦听端口
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 54, ArraySubType = UnmanagedType.I1)]
        public byte[] byReserve;//预留
    }

}
