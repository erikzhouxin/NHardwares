using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MATRIX_TRAN_CHAN_INFO_V30
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
        public byte byRes1;/* 保留 */
        public NET_DVR_IPADDR struRemoteDevIP;/* Remote Device IP */
        public ushort wRemoteDevPort;/* Remote Net Communication Port */
        public byte byIsEstablished;/* 透明通道建立成功标志，0-没有成功，1-建立成功 */
        public byte byRes2;/* 保留 */
        public TTY_CONFIG RemoteSerialDevCfg;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byUsername;/* 32BYTES */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] byPassword;/* 16BYTES */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes3;
    }
}
