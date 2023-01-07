using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //辅助区域
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_AUXAREA
    {
        public uint dwAreaType;   //区域类型，参见AREA_TYPE_ENUM
        public byte byEnable;     //0-不启用，1-启用
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;     //保留
        public NET_VCA_POLYGON struPolygon; //区域
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;   //保留
    }
}
