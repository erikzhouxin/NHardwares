using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //IVMS屏蔽区域链表
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_IVMS_MASK_REGION_LIST
    {
        public uint dwSize;//结构长度
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DAYS * HikHCNetSdk.MAX_TIMESEGMENT, ArraySubType = UnmanagedType.Struct)]
        public NET_VCA_MASK_REGION_LIST[] struList;
    }
}
