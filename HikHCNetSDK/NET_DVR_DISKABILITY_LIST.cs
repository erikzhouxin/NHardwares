using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DISKABILITY_LIST
    {
        public uint dwSize;            //结构长度
        public uint dwNodeNum;       //能力结点个数
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_NODE_NUM, ArraySubType = UnmanagedType.Struct)]
        public NET_DVR_DESC_NODE[] struDescNode;  //描述参数  
    }
}
