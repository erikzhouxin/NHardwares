using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FINGERPRINT_COND
    {
        public int dwSize;
        public int dwFingerprintNum;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.ACS_CARD_NO_LEN)]
        public byte[] byCardNo;
        public int dwEnableReaderNo;
        public byte byFingerPrintID;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 131)]
        public byte[] byRes;

        public void Init()
        {
            byCardNo = new byte[HikHCNetSdk.ACS_CARD_NO_LEN];
            byRes = new byte[131];
        }
    }
}
