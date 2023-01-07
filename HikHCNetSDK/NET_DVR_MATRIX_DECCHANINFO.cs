using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //连接的通道配置 2007-11-05
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MATRIX_DECCHANINFO
    {
        public uint dwEnable;/* 是否启用 0－否 1－启用*/
        public NET_DVR_MATRIX_DECINFO struDecChanInfo;/* 轮循解码通道信息 */
    }
}
