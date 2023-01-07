using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FINGER_PRINT_BYCARD_V50
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.ACS_CARD_NO_LEN)]
        public byte[] byCardNo;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_CARD_READER_NUM_512)]
        public byte[] byEnableCardReader;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_FINGER_PRINT_NUM)]
        public byte[] byFingerPrintID;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NET_SDK_EMPLOYEE_NO_LEN)]
        public byte[] byEmployeeNo;
        public void Init()
        {
            byCardNo = new byte[HikHCNetSdk.ACS_CARD_NO_LEN];
            byEnableCardReader = new byte[HikHCNetSdk.MAX_CARD_READER_NUM_512];
            byFingerPrintID = new byte[HikHCNetSdk.MAX_FINGER_PRINT_NUM];
            byRes1 = new byte[2];
            byEmployeeNo = new byte[HikHCNetSdk.NET_SDK_EMPLOYEE_NO_LEN];
        }
    }

}
