using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FINGERPRINT_RECORD
    {
        public int dwSize;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.ACS_CARD_NO_LEN)]
        public byte[] byCardNo; //指纹关联的卡号
        public int dwFingerPrintLen; //指纹数据长度
        public int dwEnableReaderNo;//需要下发指纹的读卡器编号
        public byte byFingerPrintID;//手指编号，有效值范围为1-10
        public byte byFingerType;//指纹类型  0-普通指纹，1-胁迫指纹
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 30)]
        public byte[] byRes1;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_FINGER_PRINT_LEN)]
        public byte[] byFingerData;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 96)]
        public byte[] byRes;
        public void Init()
        {
            byCardNo = new byte[HikHCNetSdk.ACS_CARD_NO_LEN];
            byRes1 = new byte[30];
            byFingerData = new byte[HikHCNetSdk.MAX_FINGER_PRINT_LEN];
            byRes = new byte[96];
        }
    }

}
