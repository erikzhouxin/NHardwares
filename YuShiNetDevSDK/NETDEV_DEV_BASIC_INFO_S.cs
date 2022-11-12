using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_DEV_BASIC_INFO_S
    {
        public NETDEV_IPADDR_INFO_S stDevAddr;                         /* 设备IP地址信息 */
        public NETDEV_USER_SIMPLE_INFO_S stDevUserInfo;                /* 设备用户名、密码 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] szDevName;                    /* 设备名称 */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 516)]
        public string szDevDesc;                /* 设备描述 */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        public string szDevModel;               /* 设备型号 */
        public Int32 dwDevID;                                          /* 设备ID */
        public Int32 dwDevStatus;                                      /* 设备状态, 参考# NETDEV_DEVICE_STATUS_E */
        public Int32 dwDevType;                                        /* 设备类型，参考# NETDEV_DEVICE_MAIN_TYPE_E */
        public Int32 dwDevSubType;                                     /* 设备子类型，参考# NETDEV_DEVICE_SUB_TYPE_E */
        public Int32 dwOrgID;                                          /* 组织编号 */
        public Int32 dwAccessProtocol;                                 /* 接入协议 */
        public Int32 dwAccessMode;                                     /* 接入方式 参考# NETDEV_DEVICE_ACCESS_MODE_E*/
        public Int32 dwServerID;                                       /* 所属服务器ID */
        public Int32 dwAudioResID;                                     /* 音频通道ID */
        public Int32 dwIsPTZNeeded;                                           /* 是否需要云台 0:  不需要 1:  需要 255: 自适应 */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
        public string szVIIDCode;                 /* 视图库编码,仅卡口设备时有效 */
        public Int32 dwVIIDStatus;                                     /* 视图库状态，用来标识当前设备是否已通过视图库协议连接，0：离线 1：在线 */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public string szSerialNum;                        /* 设备序列号*/
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_128)]
        public string szSoftVersion;                     /* 软件版本号*/
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = NetDevSdk.NETDEV_LEN_32)]
        public string szMacAddr;                          /* MAC地址*/
        public Int32 dwStoreStatus;                                    /* 设备存储状态。0: 空闲 1: 未格式化 2: 格式化中3: 运行中*/
        public NETDEV_ONVIF_INFO_S stOnvifInfo;                        /* onvif信息 */
        public NETDEV_GBINFO_S stGBInfo;                               /* 国标信息 当AccessProtocol值为3时该节点必选，其他可选*/
        public IntPtr pstSmartLockInfo;                               /* 锁设备信息 需调用者分配内存,参见NETDEV_SMART_LOCK_INFO_S */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szManufacture;                              /* 厂商名称 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_32)]
        public byte[] szDeviceCode;                               /* 设备编码 [1,32] 添加播放盒时必选  */
        public IntPtr pstPlayerInfo;                              /* 播放盒信息 当Type为11时必选 需要malloc分配内存,NETDEV_IPM_PLAYER_BASIC_INFO_S */
        public UInt32 udwCustomProtocolID;                        /* 自定义协议ID，当AccessProtocol值为4时该节点必选 */
        public UInt32 udwChlMaxNum;                               /* 设备通道号最大数量，当AccessProtocol值为4时该节点必选 */
        public UInt32 udwChlIndexNum;                             /* 设备通道号数量，当AccessProtocol值为4时该节点必选，上限256 */
        public IntPtr pudwChlIndexList;                           /* 通道号列表，需动态分配内存，建议分配256个 UINT32 */
        public Int32 dwImageProtocol;                            /* 图片协议，设备类型Type为5智能设备时必带 1:私有 2:视图库 */
    };

}
