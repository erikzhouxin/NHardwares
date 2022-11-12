namespace System.Data.YuShiNetDevSDK
{
    public enum NETDEV_DEVICETYPE_E
    {
        NETDEV_DTYPE_UNKNOWN = 0,                   /* Unknown type */
        NETDEV_DTYPE_IPC = 1,                       /* IPC range */
        NETDEV_DTYPE_IPC_FISHEYE = 2,               /* Fisheye IPC*/
        NETDEV_DTYPE_IPC_ECONOMIC_FISHEYE = 3,      /* Economic fisheye IPC */
        NETDEV_DTYPE_NVR = 101,                     /* NVR range */
        NETDEV_DTYPE_NVR_BACKUP = 102,              /* NVR back up */
        NETDEV_DTYPE_HNVR = 103,                    /* Mixture NVR */
        NETDEV_DTYPE_DC = 201,                      /* DC range */
        NETDEV_DTYPE_DC_ADU = 202,                  /* ADU range */
        NETDEV_DTYPE_EC = 301,                      /* EC range */
        NETDEV_DTYPE_VMS = 501,                     /* VMS range */

        NETDEV_DTYPE_INVALID = 0xFFFF               /* Invalid value */
    }

}
