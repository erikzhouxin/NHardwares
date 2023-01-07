using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DISK_QUOTA_CFG
    {
        public uint dwSize;         // 结构体大小
        public NET_DVR_DISK_QUOTA struPicQuota;    //  图片配额
        public NET_DVR_DISK_QUOTA struRecordQuota;    //  录像配额
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 60, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;      //保留字节
    }
}
