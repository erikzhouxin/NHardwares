using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FACE_PARAM_BYCARD
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byCardNo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CARD_READER_NUM_512, ArraySubType = UnmanagedType.I1)]
        public byte[] byEnableCardReader;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_FACE_NUM, ArraySubType = UnmanagedType.I1)]
        public byte[] byFaceID;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 42, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;

        public void Init()
        {
            byCardNo = new byte[HikHCNetSdk.ACS_CARD_NO_LEN];
            byEnableCardReader = new byte[HikHCNetSdk.MAX_CARD_READER_NUM_512];
            byFaceID = new byte[HikHCNetSdk.MAX_FACE_NUM];
            byRes1 = new byte[42];
        }
    }
}
