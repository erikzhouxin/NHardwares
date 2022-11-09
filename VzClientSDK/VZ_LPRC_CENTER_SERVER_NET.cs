namespace System.Data.VzClientSDK
{
    /**************************************中心服务器***********************************************/

    //中心服务器网络
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
    public struct VZ_LPRC_CENTER_SERVER_NET
    {
        [System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = VzClientSdk.LPRC_CENTER_IPLEN)]
        public string centerServerIp;    //中心服务器地址

        public UInt16 port;              //中心服务器端口

        public Byte enableSsl;           //是否使用ssl协议

        public UInt16 sslPort;           //ssl协议端口 

        public UInt16 timeout;           //超时时间设置错误, 范围【1~30】
    }
}
