using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //物品遗留
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_LEFT
    {
        public NET_VCA_POLYGON struRegion; // 区域范围
        public ushort wDuration;       // 触发物品遗留报警阈值 10-100秒
        public byte bySensitivity;   // 灵敏度参数，范围[1,5] 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;        // 保留字节
    }

}
