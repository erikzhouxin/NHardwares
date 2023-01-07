using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_ITS_PICTURE_INFO
    {
        public uint dwDataLen;
        public byte byType;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] byRes1;
        public uint dwRedLightTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] byAbsTime;
        public NET_VCA_RECT struPlateRect;
        public NET_VCA_RECT struPlateRecgRect;
        public IntPtr pBuffer;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        public byte[] byRes2;
    }
}
