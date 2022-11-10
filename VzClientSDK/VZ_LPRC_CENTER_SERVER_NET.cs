using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 中心服务器网络
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_LPRC_CENTER_SERVER_NET
    {
        /// <summary>
        /// 中心服务器地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VzClientSdk.LPRC_CENTER_IPLEN)]
        public string centerServerIp;
        /// <summary>
        /// 中心服务器端口
        /// </summary>
        public UInt16 port;
        /// <summary>
        /// 是否使用ssl协议
        /// </summary>
        public Byte enableSsl;
        /// <summary>
        /// ssl协议端口
        /// </summary>
        public UInt16 sslPort;
        /// <summary>
        /// 超时时间设置错误, 范围【1~30】
        /// </summary>
        public UInt16 timeout;        
    }
}
