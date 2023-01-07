using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //进入/离开区域参数
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_AREA
    {
        public NET_VCA_POLYGON struRegion;//区域范围
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }

}
