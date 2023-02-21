using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    /// <summary>
    /// 心跳数据
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct HeartbeatData
    {
        /// <summary>
        /// 密码
        /// </summary>
        public string password;
        /// <summary>
        /// 控制器IP地址
        /// </summary>
        public string ip;
        /// <summary>
        /// 子网掩码
        /// </summary>
        public string subNetMask;
        /// <summary>
        /// 网关
        /// </summary>
        public string gate;
        /// <summary>
        /// 端口
        /// </summary>
        public short port;
        /// <summary>
        /// MAC地址
        /// </summary>
        public string mac;
        /// <summary>
        /// 控制器网络ID
        /// </summary>
        public string netID;
    }
}
