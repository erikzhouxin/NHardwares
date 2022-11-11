using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**
     * @brief 通道OSD内容样式 Display Style of channel OSD
     * @attention
     */
    [StructLayout(LayoutKind.Sequential)]
    public struct NETDEV_OSD_CONTENT_STYLE_S
    {
        public UInt32 udwFontStyle;                         /* 字体形式，参见枚举NETDEV_OSD_FONT_STYLE_E。  Font style. For enumeration, seeNETDEV_OSD_FONT_STYLE_E*/
        public UInt32 udwFontSize;                          /* 字体大小，参见枚举NETDEV_OSD_FONT_SIZE_E。  Font Size. For enumeration, seeNETDEV_OSD_FONT_SIZE_E*/
        public UInt32 udwColor;                             /* 文字颜色，颜色以RGB的方式描述 0xABCDEF，AB：表示R的值，00~FF，CD：表示G的值，00~FF，EF：表示B的值，00~FF。默认：0xFF0000（红色）Color*/
        public UInt32 udwDateFormat;                        /* 日期格式，参见枚举NETDEV_OSD_DATE_FORMAT_E。Date Format. For enumeration, seeNETDEV_OSD_DATE_FORMAT_E */
        public UInt32 udwTimeFormat;                        /* 时间格式，参见枚举NETDEV_OSD_TIME_FORMAT_E。Date Format. For enumeration, seeNETDEV_OSD_DATE_FORMAT_E */
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_8)]
        public UInt32[] audwFontAlignList;                   /* 区域内字体对齐，固定8个区域，IPC支持,参见枚举NETDEV_OSD_ALIGN_E。Font align in area, 8 areasfixed, IPcamera supported. For enumeration, seeNETDEV_OSD_ALIGN_E */
        public UInt32 udwMargin;                            /* 边缘空的字符数，IPC支持，参见枚举NETDEV_OSD_MIN_MARGIN_E。 Number of character with margin, IP camera supported. For enumeration, seeNETDEV_OSD_MIN_MARGIN_E */
    }

}
