using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //ATM进入区域参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_ENTER_REGION
    {
        public uint dwSize;
        public byte byEnable;//是否激活，0-否，非0-是
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_VCA_POLYGON struPolygon;//进入区域
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
    }
}
