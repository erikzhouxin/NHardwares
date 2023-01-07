using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CAPTURE_FINGERPRINT_CFG
    {
        public int dwSize;
        public int dwFingerPrintDataSize;    //指纹数据大小
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_FINGER_PRINT_LEN)]
        public byte[] byFingerData;        //指纹数据内容
        public int dwFingerPrintPicSize;    //指纹图片大小，等于0时，代表无指纹图片数据
        public IntPtr pFingerPrintPicBuffer;       //指纹图片缓存
        public byte byFingerNo;              //手指编号，范围1-10
        public byte byFingerPrintQuality;    //指纹质量，范围1-100
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 62)]
        public byte[] byRes;

        public void Init()
        {
            byFingerData = new byte[HikHCNetSdk.MAX_FINGER_PRINT_LEN];
            byRes = new byte[62];
        }
    }

}
