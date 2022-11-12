namespace System.Data.YuShiNetDevSDK
{
    public enum NETDEV_VOD_PLAY_CTRL_E
    {
        NETDEV_PLAY_CTRL_PLAY = 0,           /* Play */
        NETDEV_PLAY_CTRL_PAUSE = 1,           /* Pause */
        NETDEV_PLAY_CTRL_RESUME = 2,           /* Resume */
        NETDEV_PLAY_CTRL_GETPLAYTIME = 3,           /* Obtain playing time */
        NETDEV_PLAY_CTRL_SETPLAYTIME = 4,           /* Configure playing time */
        NETDEV_PLAY_CTRL_GETPLAYSPEED = 5,           /* Obtain playing speed */
        NETDEV_PLAY_CTRL_SETPLAYSPEED = 6,           /* Configure playing speed */
        NETDEV_PLAY_CTRL_SINGLE_FRAME = 7            /* Configure single frame playing speed */
    }

}
