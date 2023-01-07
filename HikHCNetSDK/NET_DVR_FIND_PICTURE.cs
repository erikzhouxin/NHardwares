using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FIND_PICTURE
    {
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.PICTURE_NAME_LEN)]
        public string sFileName;//图片名
        public NET_DVR_TIME struTime;//图片的时间
        public uint dwFileSize;//图片的大小
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.CARDNUM_LEN_V30)]
        public string sCardNum; //卡号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;        //  保留字节
    }
}
