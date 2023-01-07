using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_ATM_PROTO_LIST
    {
        public uint dwAtmProtoNum;/*协议列表的个数*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_ATM_PROTOCOL_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_ATM_PROTO_TYPE[] struAtmProtoType;/*协议列表信息*/
    }
}
