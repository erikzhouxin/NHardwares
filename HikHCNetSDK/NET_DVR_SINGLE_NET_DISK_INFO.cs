using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //网络硬盘结构配置
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_SINGLE_NET_DISK_INFO
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;//保留
        public NET_DVR_IPADDR struNetDiskAddr;//网络硬盘地址
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PATHNAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sDirectory;// PATHNAME_LEN = 128
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 68, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;//保留
    }
}
