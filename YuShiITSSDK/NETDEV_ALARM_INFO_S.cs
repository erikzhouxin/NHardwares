using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**/
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_ALARM_INFO_S
    {
        public Int32 dwAlarmType;                    /* ,#NETDEV_ALARM_TYPE_E  Alarm type, see enumeration #NETDEV_ALARM_TYPE_E */
        public Int64 tAlarmTime;                     /* Alarm time */
        public Int32 dwChannelID;                    /* ,NVR  Channel ID for NVR */
        public UInt16 wIndex;                         /* ,  Index number,  disk slot index number */
        public string pszName;                       /* , Alarm source name, alarm input/output name */
        public Int32 dwTotalBandWidth;               /* ,MBps */
        public Int32 dwUnusedBandwidth;              /* ,MBps */
        public Int32 dwTotalStreamNum;               /* */
        public Int32 dwFreeStreamNum;                /* */
        public Int32 dwMediaMode;                    /* ,#NETDEV_MEDIA_MODE_E */
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public string byRes;                          /* Reserved */
    }

}
