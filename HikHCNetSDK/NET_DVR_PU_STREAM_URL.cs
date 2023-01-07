using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PU_STREAM_URL
    {
        public byte byEnable;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 240, ArraySubType = UnmanagedType.I1)]
        public byte[] strURL;
        public byte byTransPortocol;
        public ushort wIPID;
        public byte byChannel;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        public void Init()
        {
            strURL = new byte[240];
            byRes = new byte[7];
        }
    }

}
