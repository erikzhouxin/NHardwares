using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CAPTURE_FINGERPRINT_COND
    {
        public int dwSize;
        public byte byFingerPrintPicType;    //图片类型：0-无意义
        public byte byFingerNo;              //手指编号，范围1-10
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 126)]
        public byte[] byRes;

        public void Init()
        {
            byRes = new byte[126];
        }
    }

}
