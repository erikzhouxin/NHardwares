namespace System.Data.YuShiNetDevSDK
{
    public enum NETDEV_VIDEO_QUALITY_E
    {
        NETDEV_VQ_L0 = 0,                    /* Highest */
        NETDEV_VQ_L1 = 1,
        NETDEV_VQ_L2 = 4,                    /* Higher */
        NETDEV_VQ_L3 = 8,
        NETDEV_VQ_L4 = 12,                   /* Medium */
        NETDEV_VQ_L5 = 16,
        NETDEV_VQ_L6 = 20,                   /* Low */
        NETDEV_VQ_L7 = 24,
        NETDEV_VQ_L8 = 28,                   /* Lower */
        NETDEV_VQ_L9 = 31,                   /* Lowest */

        NETDEV_VQ_LEVEL_INVALID = -1         /* Valid */
    }

}
