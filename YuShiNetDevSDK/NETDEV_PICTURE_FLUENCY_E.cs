namespace System.Data.YuShiNetDevSDK
{
    public enum NETDEV_PICTURE_FLUENCY_E
    {
        NETDEV_PICTURE_REAL = 0,                /* Real-time first */
        NETDEV_PICTURE_FLUENCY = 1,                /* Fluency first */
        NETDEV_PICTURE_BALANCE_NEW = 3,                /* Balance */
        NETDEV_PICTURE_RTMP_FLUENCY = 4,                /* RTMP fluency first */

        NETDEV_PICTURE_FLUENCY_INVALID = 0xff              /* Invalid value */
    }

}
