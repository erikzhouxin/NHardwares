using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //辅助区域列表
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_AUXAREA_LIST
    {
        public uint dwSize; // 结构体大小
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_AUXAREA_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_AUXAREA[] struArea; //辅助区域
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;   // 保留
    }
}
