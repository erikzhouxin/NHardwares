using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //单帧统计结果时使用
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct UNION_STATFRAME
    {
        public uint dwRelativeTime;     // 相对时标
        public uint dwAbsTime;          // 绝对时标
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 92, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }


}
