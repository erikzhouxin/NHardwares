using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    /* IP通道匹配参数 */
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_IPCHANINFO
    {
        public byte byEnable;/* 该通道是否在线 */
        public byte byIPID;/* IP设备ID 取值1- MAX_IP_DEVICE */
        public byte byChannel;/* 通道号 */
        public byte byIPIDHigh; // IP设备ID的高8位
        public byte byTransProtocol;//传输协议类型0-TCP/auto(具体有设备决定)，1-UDP 2-多播 3-仅TCP 4-auto
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 31, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;//保留,置0
        public void Init()
        {
            byRes = new byte[31];
        }
    }

}
