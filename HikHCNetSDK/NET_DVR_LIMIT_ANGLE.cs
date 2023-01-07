using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_LIMIT_ANGLE
    {
        public byte byEnable;   // 是否启用场景限位功能
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_DVR_PTZPOS struUp;     // 上限位
        public NET_DVR_PTZPOS struDown;   // 下限位
        public NET_DVR_PTZPOS struLeft;   // 左限位
        public NET_DVR_PTZPOS struRight;  // 右限位
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }


}
