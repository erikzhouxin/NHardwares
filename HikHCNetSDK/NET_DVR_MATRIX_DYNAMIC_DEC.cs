using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //启动/停止动态解码
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MATRIX_DYNAMIC_DEC
    {
        public uint dwSize;
        public NET_DVR_MATRIX_DECINFO struDecChanInfo;/* 动态解码通道信息 */
    }
}
