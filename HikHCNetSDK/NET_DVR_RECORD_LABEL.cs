using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //录像标签
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_RECORD_LABEL
    {
        public uint dwSize;                 // 结构体大小
        public NET_DVR_TIME struTimeLabel;          // 标签的时间 
        public byte byQuickAdd;             // 是否快速添加 快速添加时标签名称无效
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;               // 保留字节
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.LABEL_NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sLabelName;   // 标签的名称 长度为40字节  
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 40, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;               // 保留字节
    }
}
