using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //公告信息阅读回执
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_NOTICEDATA_RECEIPT_INFO
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_NOTICE_NUMBER_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byNoticeNumber; //公告编号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 224, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;  //保留
    }
}
