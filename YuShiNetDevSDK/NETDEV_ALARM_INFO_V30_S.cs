using System.Runtime.InteropServices;

namespace System.Data.YuShiNetDevSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_INFO_V30_S
    {
        public Int32 dwAlarmType;                                  /* 告警类型，参见枚举#NETDEV_ALARM_TYPE_E  Alarm type, see enumeration #NETDEV_ALARM_TYPE_E */
        public Int32 dwAlarmSubType;                               /* 告警子类型，参见NETDEV_ALARM_SUBTYPE_E */
        public Int32 dwAlarmLevel;                                 /* 告警等级，1到5级，1级最严重 */
        public Int64 tAlarmTimeStamp;                              /* 告警发生时间  Alarm occurrence time */
        public Int32 dwChannelID;                                  /* 通道ID,非一体机设备使用  Channel ID */
        public Int32 dwAlarmID;                                    /* 告警ID，一体机设备使用 */
        public Int32 dwAlarmSrcID;                                 /* 告警源ID 参见枚举#NETDEV_ALARM_SRC_TYPE_E
                                                        note:
                                                        1. dwAlarmSrcType为NETDEV_ALARM_SRC_LOCAL_HARD_DISK到NETDEV_ALARM_SRC_SD_STORAGE_DISK之间，dwAlarmID代表存储盘索引；
                                                        2. dwAlarmSrcType为8，dwAlarmID代表视频通道号；
                                                        3. dwAlarmSrcType为9，dwAlarmID代表报警输入通道号，报警源见dwInputSwitchID字段。
                                                        4. dwAlarmSrcType为10,dwAlarmID默认为0,代表系统本身
                                                        */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 68)]
        public string szAlarmSrc;      /* 告警源信息（名称） */
        public Int32 IsAlarmSnapExisted;                            /* 告警是否有抓图 0没有抓图 1有抓图  vms使用*/
        public UInt16 wIndex;                                     /* 索引号  Index number, index number */
        public Int32 dwTotalBandWidth;                           /* 当前带宽总量,单位为MBps  Current total bandwidth (in MBps) */
        public Int32 dwUnusedBandwidth;                          /* 未使用的带宽,单位为MBps  Bandwidth left (in MBps)*/
        public Int32 dwTotalStreamNum;                           /* 总路数 Total cameras*/
        public Int32 dwFreeStreamNum;                            /* 未使用路数 Cameras left */
        public Int32 dwMediaMode;                                /* 流类型,参见枚举#NETDEV_MEDIA_MODE_E Stream type. For enumerations, see#NETDEV_MEDIA_MODE_E*/
        public Int32 dwEventCode;                                  /* 事件类型，用于上报解码层事件类型，参见枚举# NETDEV_PLAYER_RUN_INFO_TYPE_E */
        public Int32 dwReserved;                                   /* 异常上报保留参数，用于上报解码层保留参数 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_256)]
        public byte[] szFileName;                                     /* ND上报字符串参数信息 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_64)]
        public byte[] szDeviceID;                                     /* 告警设备ID，国标协议接入时填写国标注册码。长度[1,32]。IPC、VM平台支持 */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NetDevSdk.NETDEV_LEN_32)]
        public byte[] szRelatedID;                                    /* 告警事件与告警数据的关联ID,同一个相机内全局唯一。长度为15个字符.当告警存在与之关联数据时，需携带此字段 */
        public Int32 dwObjectNum;                                    /* 目标个数  Object Num */
        public IntPtr pstObjectList;                                  /* 目标列表 Object List 需根据dwObjectNum动态申请内存,NETDEV_OBJECT_LIST_S */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 144)]
        public byte[] byRes;
    };

}
