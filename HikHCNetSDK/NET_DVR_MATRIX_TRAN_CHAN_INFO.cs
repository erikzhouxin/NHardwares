using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct NET_DVR_MATRIX_TRAN_CHAN_INFO
    {
        public byte byTranChanEnable;/* 当前透明通道是否打开 0：关闭 1：打开 */
        /*
         *	多路解码器本地有1个485串口，1个232串口都可以作为透明通道,设备号分配如下：
         *	0 RS485
         *	1 RS232 Console
         */
        public byte byLocalSerialDevice;/* Local serial device */
        /*
         *	远程串口输出还是两个,一个RS232，一个RS485
         *	1表示232串口
         *	2表示485串口
         */
        public byte byRemoteSerialDevice;/* Remote output serial device */
        public byte res1;/* 保留 */
        [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
        public string sRemoteDevIP;/* Remote Device IP */
        public ushort wRemoteDevPort;/* Remote Net Communication Port */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
        public byte[] res2;/* 保留 */
        public TTY_CONFIG RemoteSerialDevCfg;
    }
}
