using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_INFO_V30_S
    {
        public Int32 dwAlarmType;                                  /* See #NETDEV_ALARM_TYPE_E  Alarm type, see enumeration #NETDEV_ALARM_TYPE_E */
        public Int32 dwAlarmSubType;                               /* See #NETDEV_ALARM_SUBTYPE_E */
        public Int32 dwAlarmLevel;
        public Int64 tAlarmTimeStamp;                              /* Alarm occurrence time */
        public Int32 dwChannelID;                                  /* Channel ID */
        public Int32 dwAlarmID;
        public Int32 dwAlarmSrcID;                                 /* See #NETDEV_ALARM_SRC_TYPE_E
                                                      
                                                        */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 68)]
        public string szAlarmSrc;
        public Int32 IsAlarmSnapExisted;
        public UInt16 wIndex;                                     /* Index number, index number */
        public Int32 dwTotalBandWidth;                           /* Current total bandwidth (in MBps) */
        public Int32 dwUnusedBandwidth;                          /* Bandwidth left (in MBps)*/
        public Int32 dwTotalStreamNum;                           /* Total cameras*/
        public Int32 dwFreeStreamNum;                            /* Cameras left */
        public Int32 dwMediaMode;                                /* Stream type. For enumerations, see#NETDEV_MEDIA_MODE_E*/

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] byRes;
    };

}
