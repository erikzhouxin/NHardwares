using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //能力列表
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ABILITY_LIST
    {
        public uint dwAbilityType;  //能力类型 COMPRESSION_ABILITY_TYPE
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;        //保留字节
        public uint dwNodeNum;      //能力结点个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_NODE_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_DESC_NODE[] struDescNode;  //描述参数  
    }
}
