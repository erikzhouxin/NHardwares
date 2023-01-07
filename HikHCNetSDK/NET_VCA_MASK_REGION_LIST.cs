using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //屏蔽区域链表结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_VCA_MASK_REGION_LIST
    {
        public uint dwSize;//结构长度
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes; //保留，置0
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_MASK_REGION_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_VCA_MASK_REGION[] struMask;//屏蔽区域数组
    }
}
