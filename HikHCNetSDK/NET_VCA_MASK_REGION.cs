using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //屏蔽区域
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_MASK_REGION
    {
        public byte byEnable;//是否激活, 0-否，非0-是
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;//保留，置0
        public NET_VCA_POLYGON struPolygon;//屏蔽多边形
    }
}
