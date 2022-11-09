using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 中心服务器网络设备注册
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_LPRC_CENTER_SERVER_DEVICE_REG
    {
        /// <summary>
        /// 中心服务器设备注册类型 0:取消心跳 1:普通心跳 2:comet轮询
        /// </summary>
        public Byte type;
        /// <summary>
        /// 中心服务器设备注册地址
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = VzClientSdk.URLLENGTH)]
        public string url;
    }
}
