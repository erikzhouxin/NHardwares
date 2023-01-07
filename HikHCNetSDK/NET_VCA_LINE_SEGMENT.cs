using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_LINE_SEGMENT
    {
        public NET_VCA_POINT struStartPoint;//表示高度线时，表示头部点
        public NET_VCA_POINT struEndPoint;//表示高度线时，表示脚部点
        public float fValue;//高度值，单位米
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
