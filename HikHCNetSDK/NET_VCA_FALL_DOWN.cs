using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //倒地参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_FALL_DOWN
    {
        public NET_VCA_POLYGON struRegion;//区域范围
        public ushort wDuration;      /* 触发事件阈值 1-60s*/
        public byte bySensitivity;       /* 灵敏度参数，范围[1,5] */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
