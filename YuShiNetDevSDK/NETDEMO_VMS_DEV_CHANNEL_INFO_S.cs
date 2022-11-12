namespace System.Data.YuShiNetDevSDK
{
    public class NETDEMO_VMS_DEV_CHANNEL_INFO_S
    {
        public NETDEV_DEV_CHN_ENCODE_INFO_S stChnInfo;
        public NETDEV_CRUISE_LIST_S stCruiseList; /* 通道的预置位巡航路径信息 */
        public NETDEMO_IMAGE_INFO_S m_imageInfo;

        public Int32 m_dwSubFaceStructAlarmID = -1;
        public Int32 m_dwSubVehicleStructAlarmID = -1;
    }
}
