using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_ATM_FRAMEFORMAT_V30
    {
        public uint dwSize;                 //结构大小
        public byte byEnable;               /*是否启用0,不启用;1,启用*/
        public byte byInputMode;            /**输入方式:0-网络监听、1网络协议、2-串口监听、3-串口协议*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 34, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;              //保留字节 
        public NET_DVR_IPADDR struAtmIp;                /*ATM 机IP 网络监听时使用 */
        public ushort wAtmPort;             /* 网络协议方式时是使用*/
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;              // 保留字节
        public uint dwAtmType;              /*ATM协议类型，从NET_DVR_ATM_PROTOCOL结构中获取，如果类型为自定义时使用用户自定义协议*/
        public NET_DVR_ATM_USER_DEFINE_PROTOCOL struAtmUserDefineProtocol; //用户自定义协议，当ATM类型为自定时需要使用该定义
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 8, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes3;
    }
}
