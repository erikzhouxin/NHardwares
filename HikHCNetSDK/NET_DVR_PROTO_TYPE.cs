using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //协议类型
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_PROTO_TYPE
    {
        public uint dwType;               /*ipc协议值*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.DESC_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byDescribe; /*协议描述字段*/
    }

}
