namespace System.Data.YuShiITSSDK
{
    /**
     * @brief Device capability commond
     * @attention 
     */
    public enum NETDEV_CAPABILITY_COMMOND_E
    {
        NETDEV_CAP_VIDEO_ENCODE = 1,            /* see# NETDEV_VIDEO_STREAM_CAP_S。 Video encoding capability. See # NETDEV_VIDEO_STREAM_CAP_S for reference*/
        NETDEV_CAP_OSD = 2,                             /* See# NETDEV_OSD_CAP_S。 OSD parameter capability. See # NETDEV_OSD_CAP_S for reference*/
        NETDEV_CAP_SMART = 3,                           /* See# NETDEV_SMART_CAP_S。 Smart capability. See # NETDEV_SMART_CAP_S for reference */
        NETDEV_CAP_VIDEO_ENCODE_EX = 4,                 /* See# NETDEV_VIDEO_STREAM_CAP_EX_S。 Video encoding capability. See # NETDEV_VIDEO_STREAM_CAP_EX_S for reference */
        NETDEV_CAP_IMAGE = 5,                           /* See# NETDEV_IMAGE_CAP_S。 Image capability See # NETDEV_IMAGE_CAP_S for reference*/
        NETDEV_CAP_AUDIO = 6,                           /* See# NETDEV_AUDIO_CAPABILITY_INFO_S */
        NETDEV_CAP_VIDEO_SNAPSHOT = 7,                  /* See# NETDEV_VIDEO_SNAP_CAP_S Video snapshot capability. See # NETDEV_VIDEO_SNAP_CAP_S for reference*/
        NETDEV_CAP_FACE_RECOGNAZE = 10,                 /* See# NETDEV_DEV_FACE_CAP_INFO_S */
        NETDEV_CAP_DEV_NIC = 11,                        /* See# NETDEV_NIC_CAP_INFO_S */
        NETDEV_CAP_DEV_EXCEPTION_ALARM = 12,            /* See# NETDEV_EXCP_ALARM_CAP_INFO_S */
        NETDEV_CAP_CHANNELS_ALARM = 13,                 /* See# NETDEV_CHN_ALARM_CAP_INFO_S */

        NETDEV_CAP_INVALID = 0Xff
    };

}
