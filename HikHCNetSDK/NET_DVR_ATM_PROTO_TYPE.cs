using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //协议信息数据结构
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ATM_PROTO_TYPE
    {
        public uint dwAtmType; //ATM协议类型，同时作为索引序号 ATM 配置中的dwAtmType 自定义时为1025
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = HikHCNetSdk.ATM_DESC_LEN)]
        public string chDesc; //ATM协议简单描述
    }
}
