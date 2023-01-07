using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DESC_NODE
    {
        public int iValue;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.DESC_LEN_32, ArraySubType = UnmanagedType.I1)]
        public byte[] byDescribe; //描述字段 
        public uint dwFreeSpace; //获取磁盘列表专用,单位为M
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;              //保留  
    }
}
