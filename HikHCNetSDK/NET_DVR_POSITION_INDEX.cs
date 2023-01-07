using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_POSITION_INDEX
    {
        public byte byIndex;    // 场景索引
        public byte byRes1;
        public ushort wDwell;   // 停留时间 
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;   // 保留字节
    }


}
