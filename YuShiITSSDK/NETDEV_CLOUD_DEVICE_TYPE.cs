namespace System.Data.YuShiITSSDK
{
    /* Cloud Device Type */
    public enum NETDEV_CLOUD_DEVICE_TYPE
    {
        NETDEV_CLOUD_DEV_TYPE_IPC = 0,            /* IPC */
        NETDEV_CLOUD_DEV_TYPE_NVR = 1,            /* NVR */
        NETDEV_CLOUD_DEV_TYPE_VMS = 2,            /* VMS */
        NETDEV_CLOUD_DEV_TYPE_DVR = 3,            /* DVR */
        NETDEV_CLOUD_DEV_TYPE_EC = 4,            /* Encode device */
        NETDEV_CLOUD_DEV_TYPE_DC = 5,            /* Decode device */
        NETDEV_CLOUD_DEV_TYPE_INVALID = 0xff                    /* Invalid value */
    }

}
