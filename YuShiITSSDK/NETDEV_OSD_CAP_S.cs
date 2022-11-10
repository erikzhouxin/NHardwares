using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 通道OSD的能力集 OSD Capabilities
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OSD_CAP_S
    {
        public Int32 bIsSupportCfg;                                                     /* 是否支持配置,0：不支持 1：支持  Support configuration or not. 0-No, 1-Ye*/
        public Int32 bIsSupportFontSizeCfg;                                             /* 是否支持OSD大小配置 Support configuration of OSD size or not*/
        public Int32 bIsSupportFontColorCfg;                                            /* 是否支持OSD颜色配置 Support configuration of OSD color or not*/
        public Int32 udwMaxAreaNum;                                                     /* 支持最大的OSD区域数 Maximum number of OSD area*/
        public Int32 udwMaxOSDNum;                                                      /* 支持最大的OSD个数 Maximum number of OSD*/
        public Int32 udwMaxPerAreaOSDNum;                                               /* 每个区域支持最大的OSD个数 Maximum number of OSD in each area*/
        public Int32 udwSupportedOSDTypeNum;                                            /* 支持的OSD内容类型数量Number of OSD content type*/
        public Int32 udwSupportedTimeFormatNum;                                         /*支持的时间OSD格式数量 Number of OSD time format*/
        public Int32 udwSupportedDateFormatNum;                                         /*支持的日期OSD格式数量 Number of OSD date format*/

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_OSD_DATE_FORMAT_MAX_NUM)]
        public Int32[] aduwSupportedDateFormatList;                                          /* 日期OSD格式列表，参见枚举NETDEV_OSD_DATE_FORMAT_E See# NETDEV_OSD_TIME_FORMAT_E */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_OSD_TIME_FORMAT_MAX_NUM)]
        public Int32[] audwSupportedTimeFormatList;       /*时间OSD格式列表，参见枚举NETDEV_OSD_TIME_FORMAT_E See# NETDEV_OSD_TIME_FORMAT_E */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_OSD_TYPE_MAX_NUM)]
        public Int32[] audwSupportedOSDTypeList;                                    /* 支持配置的OSD内容类型列表，参见枚举NETDEV_OSD_CONTENT_TYPE_E See# NETDEV_OSD_CONTENT_TYPE_E */

        public Int32 udwSupportedFontSizeNum;                                           /*支持的OSD字体大小个数 Number of OSD font size */
        public Int32 udwSupportedFontStyleNum;                                          /*支持的OSD字体形式个数 Number of OSD font style */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_4)]
        public Int32[] audwSupportedFontSizeList;                                   /*支持的OSD字体大小列表，参见枚举 NETDEV_OSD_FONT_SIZE_E See# NETDEV_OSD_FONT_SIZE_E */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_4)]
        public Int32[] audwSupportedFontStyleList;                                   /*支持的OSD字体形式列表，参见枚举 NETDEV_OSD_FONT_STYLE_ESee# NETDEV_OSD_FONT_STYLE_E */

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] byRes;                                   /*保留字段  Reserved */
    }

}
