namespace System.Data.YuShiITSSDK
{
    /** NETDEV_RESOLUTION_CAPABILITY_S
     * @brief 分辨率具体信息 Resolution details
     * @attention
     */
    public struct NETDEV_RESOLUTION_CAPABILITY_S
    {
        public Int32 udwWidth;                                                                  /* 图像宽度 Image width*/
        public Int32 udwHeight;                                                                 /* 图像高度 Image height*/
        public Int32 udwMinBitRate;                                                             /* 最小码率 Minimum bit rate*/
        public Int32 udwMaxBitRate;                                                             /* 最大码率 Maximum bit rate*/
        public Int32 udwDefaultBitRate;                                                         /* 默认码率 Default bit rate*/
    }

}
