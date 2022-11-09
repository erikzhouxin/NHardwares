using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 中心服务器网络设备端口触发
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_LPRC_CENTER_SERVER_GIONIN
    {
        /// <summary>
        /// 中心服务器网络设备端口触发使能
        /// </summary>
        public Byte enable;
        /// <summary>
        /// 中心服务器网络设备端口触发地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VzClientSdk.URLLENGTH)]
        public string url;              
    }
}
