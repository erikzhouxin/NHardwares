using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //标定线链表
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_LINE_SEG_LIST
    {
        public uint dwSize;//结构长度
        public byte bySegNum;//标定线条数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = System.Runtime.InteropServices.UnmanagedType.I1)]
        public byte[] byRes;//保留，置0
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_SEGMENT_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_VCA_LINE_SEGMENT[] struSeg;
    }
}
