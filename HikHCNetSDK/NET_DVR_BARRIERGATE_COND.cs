using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //出入口控制条件
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_BARRIERGATE_COND
    {
        public byte byLaneNo;//车道号：0- 表示无效值(设备需要做有效值判断)，1- 车道1
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
