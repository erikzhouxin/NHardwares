using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FACE_PARAM_CTRL_ByReader
    {
        public int dwSize;
        public byte byMode;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_DVR_FACE_PARAM_BYREADER struProcessMode;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;

        public void Init()
        {
            byRes1 = new byte[3];
            byRes = new byte[64];
            struProcessMode = new NET_DVR_FACE_PARAM_BYREADER();
            struProcessMode.Init();
        }
    }
}
