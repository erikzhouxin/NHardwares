using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 中心服务器网络设备串口
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_LPRC_CENTER_SERVER_SERIAL
    {
        /// <summary>
        /// 中心服务器网络设备串口使能
        /// </summary>
        public Byte enable;
        /// <summary>
        /// 中心服务器网络设备串口地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VzClientSdk.URLLENGTH)]
        public string url;              
    }
}
