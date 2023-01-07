using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //单条字符叠加信息结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_ITS_OVERLAP_SINGLE_ITEM_PARAM
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;//保留
        public byte byItemType;//类型
        public byte byChangeLineNum;//叠加项后的换行数，取值范围：[0,10]，默认：0 
        public byte bySpaceNum;//叠加项后的空格数，取值范围：[0-255]，默认：0
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 15, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;//保留
    }
}
