using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_HDCFG
    {
        public uint dwSize;
        public uint dwHDCount;/*硬盘数(不可设置)*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DISKNUM_V30, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_SINGLE_HD[] struHDInfo;//硬盘相关操作都需要重启才能生效；
    }

}
