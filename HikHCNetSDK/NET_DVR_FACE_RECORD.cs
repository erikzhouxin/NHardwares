using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NET_DVR_FACE_RECORD
    {
        public int dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.ACS_CARD_NO_LEN)]
        public byte[] byCardNo;
        public int dwFaceLen;
        public IntPtr pFaceBuffer;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;

        public void Init()
        {
            byCardNo = new byte[HikHCNetSdk.ACS_CARD_NO_LEN];
            byRes = new byte[128];
        }
    }
}
