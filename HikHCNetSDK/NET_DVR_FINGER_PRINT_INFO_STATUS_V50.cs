using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FINGER_PRINT_INFO_STATUS_V50
    {
        public int dwSize;
        public int dwCardReaderNo;
        public byte byStatus;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 63)]
        public byte[] byRes;
        public void Init()
        {
            byRes = new byte[63];
        }
    }

}
