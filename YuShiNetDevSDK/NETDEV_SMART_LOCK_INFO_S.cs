using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_SMART_LOCK_INFO_S
    {
        public UInt32 udwType;                        /* 锁类型 0: WIFI锁 1: NBIoT锁 */
        public UInt32 udwSignal;                      /* 锁信号 详见 NETDEV_LOCK_SIGNAL_E */
        public UInt32 udwStatus;                      /* 锁状态 0：在线  1：离线*/
        public UInt32 udwBatteryPercent;              /* 电量，取值范围[0,100] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szSN;                           /* 锁设备序列号，字符串范围[0,20] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szIMEI;                         /* 国际移动设备识别码 Type为1时携带,字符串长度范围[1,16] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_256)]
        public byte[] szVersion;                      /* 锁版本信息 字符串长度范围[1,64] */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_480)]
        public byte[] szRoomName;                     /* 绑定房间名称 字符串长度范围[1, 128]*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
        public byte[] byRes;                          /* 保留字节 */
    };

}
