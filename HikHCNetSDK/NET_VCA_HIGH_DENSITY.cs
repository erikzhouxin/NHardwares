using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //人员聚集参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_HIGH_DENSITY
    {
        public NET_VCA_POLYGON struRegion;//区域范围
        public float fDensity;//密度比率, 范围: [0.1, 1.0]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public ushort wDuration;      // 触发人员聚集参数报警阈值 20-360s
    }

}
