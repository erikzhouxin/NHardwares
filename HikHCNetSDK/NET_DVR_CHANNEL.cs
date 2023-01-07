using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //设备通道参数结构体
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_CHANNEL
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_DOMAIN_NAME, ArraySubType = UnmanagedType.I1)]
        public byte[] byAddress;    //设备IP或域名
        public ushort wDVRPort;                 //端口号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;                   //保留
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUserName;            //主机用户名
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassword;       //主机密码
        public uint dwChannel;                   //通道号
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;                  //保留
    }
}
