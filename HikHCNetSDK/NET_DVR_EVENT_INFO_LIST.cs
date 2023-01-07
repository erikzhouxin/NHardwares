using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_EVENT_INFO_LIST
    {
        public byte byNum;      // 事件实时信息个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;           // 保留字节
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_RULE_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_EVENT_INFO[] struEventInfo;  // 事际实时信息
    }



}
