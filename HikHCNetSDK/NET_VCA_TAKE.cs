using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    // 物品拿取
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_TAKE
    {
        public NET_VCA_POLYGON struRegion;     // 区域范围
        public ushort wDuration;      // 触发物品拿取报警阈值10-100秒
        public byte bySensitivity;  // 灵敏度参数，范围[1,5] 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;       // 保留字节
    }

}
