using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FACE_PARAM_BYREADER
    {
        public int dwCardReaderNo;
        public byte byClearAllCard;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byCardNo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 548, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;

        public void Init()
        {
            byRes1 = new byte[3];
            byCardNo = new byte[HikHCNetSdk.ACS_CARD_NO_LEN];
            byRes = new byte[548];
        }
    }
}
