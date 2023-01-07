using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NET_DVR_USER_LOGIN_INFO
    {
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NET_DVR_DEV_ADDRESS_MAX_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sDeviceAddress;
        public byte byUseTransport;
        public ushort wPort;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NET_DVR_LOGIN_USERNAME_MAX_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUserName;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NET_DVR_LOGIN_PASSWD_MAX_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassword;
        public LOGINRESULTCALLBACK cbLoginResult;
        public IntPtr pUser;
        public bool bUseAsynLogin;
        public byte byProxyType; //0:不使用代理，1：使用标准代理，2：使用EHome代理
        public byte byUseUTCTime;    //0-不进行转换，默认,1-接口上输入输出全部使用UTC时间,SDK完成UTC时间与设备时区的转换,2-接口上输入输出全部使用平台本地时间，SDK完成平台本地时间与设备时区的转换
        public byte byLoginMode; //0-Private, 1-ISAPI, 2-自适应
        public byte byHttps;    //0-不适用tls，1-使用tls 2-自适应
        public int iProxyID;    //代理服务器序号，添加代理服务器信息时，相对应的服务器数组下表值
        public byte byVerifyMode;  //认证方式，0-不认证，1-双向认证，2-单向认证；认证仅在使用TLS的时候生效;    
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 119, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes3;
    }

}
