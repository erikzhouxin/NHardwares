using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_POINT_THERM_CFG
    {
        public float fTemperature;//当前温度
        public NET_VCA_POINT struPoint;//点测温坐标（当规则标定类型为点的时候生效）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 120, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
