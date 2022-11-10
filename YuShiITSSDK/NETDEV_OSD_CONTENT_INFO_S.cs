using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /**  NETDEV_OSD_CONTENT_INFO_S
     * @brief 通道OSD内容信息 Channel OSD content
     * @attention
     */
    public struct NETDEV_OSD_CONTENT_INFO_S
    {
        public uint bEnabled;                                        /* OSD区域使能 Enable OSD area*/
        public uint udwOSDID;                                        /* OSD区域序号，范围[0,7] Area No., ranges from 0 to 7.*/
        public uint udwAreaOSDNum;                                   /* 当前区域内OSD数目 Number of OSD in current area*/
        public uint udwTopLeftX;                                     /* OSD区域横坐标,范围[0,9999] X-axis of OSD area, ranges from 0 to 999*/
        public uint udwTopLeftY;                                     /* OSD区域纵坐标,范围[0,9999] Y-axisof OSD area, ranges from 0 to 999*/
        public uint udwBotRightX;                                    /* old无此参数，OSD区域横坐标,范围[0,9999] X-axis of OSD area, ranges from 0 to 999*/
        public uint udwBotRightY;                                    /* old无此参数，OSD区域纵坐标,范围[0,9999] Y-axisof OSD area, ranges from 0 to 999*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_LEN_8)]
        public NETDEV_CONTENT_INFO_S[] astContentInfo;               /* 当前区域内OSD内容信息 OSD content in current area*/
    };

}
