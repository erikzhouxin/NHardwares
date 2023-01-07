using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_OVER_TIME
    {
        public NET_VCA_POLYGON struRegion;    // 区域范围
        public ushort wDuration;  // 操作报警时间阈值 4s-60000s
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;   // 保留字节
    }

}
