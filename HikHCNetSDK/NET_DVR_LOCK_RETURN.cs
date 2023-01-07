using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_LOCK_RETURN
    {
        public uint dwSize;      //结构体大小
        public NET_DVR_TIME strBeginTime;
        public NET_DVR_TIME strEndTime;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
