using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //标签信息结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_FINDLABEL_DATA
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.LABEL_NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sLabelName;   // 标签名称
        public NET_DVR_TIME struTimeLabel;      // 标签时间
        public NET_DVR_LABEL_IDENTIFY struLabelIdentify; // 标签标识
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;           // 保留字节
    }
}
