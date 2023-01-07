using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_TOILET_TARRY
    {
        public NET_VCA_POLYGON struRegion;//区域范围
        public ushort wDelay;        //如厕超时时间[1,3600]，单位：秒
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 6, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
