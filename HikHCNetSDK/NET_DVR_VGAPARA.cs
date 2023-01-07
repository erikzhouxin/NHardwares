using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    //DVR视频输出
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VGAPARA
    {
        public ushort wResolution;/* 分辨率 */
        public ushort wFreq;/* 刷新频率 */
        public uint dwBrightness;/* 亮度 */
    }

}
