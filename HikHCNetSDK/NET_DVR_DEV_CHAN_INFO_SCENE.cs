using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_DEV_CHAN_INFO_SCENE
    {
        public NET_DVR_IPADDR struIP;               /* DVR IP地址 */
        public ushort wDVRPort;             /* 端口号 */
        public byte byChannel;      /* 通道号，对于9000等设备的IPC接入，通道号从33开始 */
        public byte byTransProtocol;        /* 传输协议类型0-TCP，1-UDP ，2-MCAST，3-RTP*/
        public byte byTransMode;            /* 传输码流模式 0－主码流 1－子码流*/
        public byte byFactoryType;              /*前端设备厂家类型*/
        public byte byDeviceType;           //设备类型，1-IPC，2- ENCODER
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.I1)]
        public byte[] byRes;
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.NAME_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sUserName;    /* 监控主机登陆帐号 */
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = HikHCNetSdk.PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
        public byte[] sPassword;    /* 监控主机密码 */
    }
}
