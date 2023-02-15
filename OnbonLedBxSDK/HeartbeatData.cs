using System.Runtime.InteropServices;

namespace System.Data.OnbonLedBxSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct HeartbeatData
    {
        public string password;    //密码
        public string ip;          //控制器IP地址
        public string subNetMask;  // 子网掩码
        public string gate;           // 网关
        public short port;            // 端口
        public string mac;           // MAC地址
        public string netID;       // 控制器网络ID
    }
}
