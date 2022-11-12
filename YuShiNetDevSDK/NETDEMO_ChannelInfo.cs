namespace System.Data.YuShiNetDevSDK
{
    public class NETDEMO_ChannelInfo
    {
        public NETDEV_VIDEO_CHL_DETAIL_INFO_S m_devVideoChlInfo = new NETDEV_VIDEO_CHL_DETAIL_INFO_S();
        public NETDEV_CRUISE_LIST_S m_CruiseInfoList;
        public NETDEMO_BASIC_INFO_S m_basicInfo;
        public NETDEMO_NETWORK_INFO_S m_networkInfo;
        public NETDEMO_VIDEO_STREAM_INFO_S m_videoStreamInfo;
        public NETDEMO_IMAGE_INFO_S m_imageInfo;
        public NETDEMO_VIDEO_OSD_S m_OSDInfo;
        public NETDEMO_INPUT_INFO_S m_IOInfo;
        public NETDEMO_PRIVACY_MASK_INFO_S m_privacyMaskInfo;
        public NETDEMO_MOTION_ALARM_INFO_S m_MotionAlarmInfo;
        public NETDEMO_TAMPER_ALARM_INFO_S m_tamperAlarmInfo;

        public NETDEMO_ChannelInfo()
        {
            /**/
            m_CruiseInfoList = new NETDEV_CRUISE_LIST_S();
            m_CruiseInfoList.astCruiseInfo = new NETDEV_CRUISE_INFO_S[NetDevSdk.NETDEV_MAX_CRUISEROUTE_NUM];
            for (int i = 0; i < m_CruiseInfoList.astCruiseInfo.Length; i++)
            {
                m_CruiseInfoList.astCruiseInfo[i].astCruisePoint = new NETDEV_CRUISE_POINT_S[NetDevSdk.NETDEV_MAX_CRUISEPOINT_NUM];
            }

            m_basicInfo = new NETDEMO_BASIC_INFO_S();
            m_basicInfo.existFlag = false;

            m_networkInfo = new NETDEMO_NETWORK_INFO_S();
            m_networkInfo.existFlag = false;
            m_networkInfo.stNetWorkPort.astUpnpPort = new NETDEV_UPNP_PORT_STATE_S[NetDevSdk.NETDEV_LEN_16];

            m_videoStreamInfo = new NETDEMO_VIDEO_STREAM_INFO_S();
            m_videoStreamInfo.videoStreamInfoList = new NETDEV_VIDEO_STREAM_INFO_S[3];
            m_videoStreamInfo.existFlag = false;

            m_imageInfo = new NETDEMO_IMAGE_INFO_S();
            m_imageInfo.existFlag = false;

            m_OSDInfo = new NETDEMO_VIDEO_OSD_S();
            m_OSDInfo.existFlag = false;
            m_OSDInfo.OSDInfo.astTextOverlay = new NETDEV_OSD_TEXT_OVERLAY_S[NetDevSdk.NETDEV_OSD_TEXTOVERLAY_NUM];

            m_IOInfo = new NETDEMO_INPUT_INFO_S();
            m_IOInfo.existFlag = false;
            m_IOInfo.stInPutInfo.astAlarmInputInfo = new NETDEV_ALARM_INPUT_INFO_S[NetDevSdk.NETDEV_MAX_ALARM_IN_NUM];

            m_privacyMaskInfo = new NETDEMO_PRIVACY_MASK_INFO_S();
            m_privacyMaskInfo.existFlag = false;
            m_privacyMaskInfo.privacyMaskInfo.astArea = new NETDEV_PRIVACY_MASK_AREA_INFO_S[NetDevSdk.NETDEV_MAX_PRIVACY_MASK_AREA_NUM];

            m_MotionAlarmInfo = new NETDEMO_MOTION_ALARM_INFO_S();
            m_MotionAlarmInfo.existFlag = false;
            m_MotionAlarmInfo.MotionAlarmInfo.awScreenInfo = new NETDEV_Int16Array[NetDevSdk.NETDEV_SCREEN_INFO_ROW];
            for (int i = 0; i < NetDevSdk.NETDEV_SCREEN_INFO_ROW; i++)
            {
                m_MotionAlarmInfo.MotionAlarmInfo.awScreenInfo[i].data = new short[NetDevSdk.NETDEV_SCREEN_INFO_COLUMN];
            }

            m_tamperAlarmInfo = new NETDEMO_TAMPER_ALARM_INFO_S();
            m_tamperAlarmInfo.existFlag = false;
        }
    }
}
