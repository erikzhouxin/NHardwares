using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
    * @struct tagstNETDEVVehicleRcordInfo
    * @brief 
    * @attention
    */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_VEHICLE_RECORD_INFO_S
    {
        public UInt32 udwRecordID;
        public UInt32 udwChannelID;
        public UInt32 udwPassingTime;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_260)]
        public byte[] szChannelName;
        public NETDEV_PLATE_ATTR_INFO_S stPlateAttr;
        public NETDEV_VEH_ATTR_S stVehAttr;
        public NETDEV_FILE_INFO_S stPlateImage;
        public NETDEV_FILE_INFO_S stVehicleImage;
        public NETDEV_FILE_INFO_S stPanoImage;
        public NETDEV_MONITOR_ALARM_INFO_S stMonitorAlarmInfo;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 132)]
        public byte[] byRes;
    }

}
