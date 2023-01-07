using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PROTO_TYPE_EX
    {
        public ushort wType;               /*ipc协议值*/
        public ushort wCommunitionType;     /*0：模拟 1：数字 2：兼容模拟、数字*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.DESC_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byDescribe; /*协议描述字段*/
    }
}
