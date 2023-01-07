using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //通过获取DVR的网络状态：单位bps
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DEVICE_NET_USING_INFO
    {
        public uint dwSize;    //结构体大小
        public uint dwPreview;   //预览
        public uint dwPlayback;  //回放
        public uint dwIPCModule; //IPC接入
        public uint dwNetDiskRW; //网盘读写
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] res;
    }
}
