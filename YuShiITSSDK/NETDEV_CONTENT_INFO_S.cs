using System.Runtime.InteropServices;

namespace System.Data.YuShiITSSDK
{
    /// <summary>
    /// @struct NETDEV_CONTENT_INFO_S
    /// @brief OSD 内容信息 Content
    /// @attention none
    /// </summary>
    public struct NETDEV_CONTENT_INFO_S
    {

        public uint udwContentType;         /*OSD内容类型,参见枚举NETDEV_OSD_CONTENT_TYPE_E  OSD content type. For enumeration, see NETDEV_OSD_CONTENT_TYPE_E*/
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = NETDEVSDK.NETDEV_OSD_TEXT_MAX_LEN)]
        public byte[] szOSDText;            /*OSD文本信息  OSD text*/
    };

}
