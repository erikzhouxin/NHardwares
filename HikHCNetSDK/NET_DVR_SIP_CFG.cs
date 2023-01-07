using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_SIP_CFG
    {
        public uint dwSize;
        public byte byEnableAutoLogin;    //使能自动注册，0-不使能，1-使能
        public byte byLoginStatus;  //注册状态，0-未注册，1-已注册，此参数只能获取
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes1;
        public NET_DVR_IPADDR stuServerIP;  //SIP服务器IP
        public ushort wServerPort;    //SIP服务器端口
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes2;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byUserName;  //注册用户名
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byPassWord; //注册密码
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_NUMBER_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byLocalNo;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.MAX_NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byDispalyName; //设备显示名称
        public ushort wLocalPort;     //本地端口
        public byte byLoginCycle;   //注册周期，1-99分钟
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 129, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
    }
}
