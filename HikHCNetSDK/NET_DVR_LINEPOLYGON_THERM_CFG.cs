using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_LINEPOLYGON_THERM_CFG
    {
        public float fMaxTemperature;//最高温
        public float fMinTemperature;//最低温
        public float fAverageTemperature;//平均温
        public float fTemperatureDiff;//温差
        public NET_VCA_POLYGON struRegion;//区域（当规则标定类型为框/线的时候生效）
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
