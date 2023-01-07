using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_STD_CONFIG
    {
        public IntPtr lpCondBuffer;
        public uint dwCondSize;
        public IntPtr lpInBuffer;
        public uint dwInSize;
        public IntPtr lpOutBuffer;
        public uint dwOutSize;
        public IntPtr lpStatusBuffer;
        public uint dwStatusSize;
        public IntPtr lpXmlBuffer;
        public uint dwXmlSize;
        public byte byDataType;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 23, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
