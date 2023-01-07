using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_MATRIXPARA
    {
        public ushort wDisplayLogo;/* 显示视频通道号 */
        public ushort wDisplayOsd;/* 显示时间 */
    }

}
