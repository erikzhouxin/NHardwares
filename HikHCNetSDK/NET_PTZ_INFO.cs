using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_PTZ_INFO
    {
        public float fPan;
        public float fTilt;
        public float fZoom;
        public uint dwFocus;// 聚焦参数，聚焦范围：归一化0-100000
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
