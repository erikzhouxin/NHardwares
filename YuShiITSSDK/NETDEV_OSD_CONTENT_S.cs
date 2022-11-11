using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /// <summary>
    /// @struct NETDEV_OSD_CONTENT_S
    /// @brief 通道OSD所有内容 All contents of channel OSD
    /// @attention none
    /// </summary>
    public struct NETDEV_OSD_CONTENT_S
    {
        public uint udwNum;                                  /*OSD区域数量 Number of OSD area*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = ItsNetDevSdk.NETDEV_LEN_32)]
        public NETDEV_OSD_CONTENT_INFO_S[] astContentList;   /*OSD区域内容信息列表 Content list of OSD area*/
    };

}
