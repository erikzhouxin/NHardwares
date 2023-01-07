using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //2005-08-01
    /* 解码设备透明通道设置 */
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_PORTINFO
    {
        public uint dwEnableTransPort;/* 是否启动透明通道 0－不启用 1－启用*/
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sDecoderIP;/* DVR IP地址 */
        public ushort wDecoderPort;/* 端口号 */
        public ushort wDVRTransPort;/* 配置前端DVR是从485/232输出，1表示232串口,2表示485串口 */
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 4)]
        public string cReserve;
    }
}
