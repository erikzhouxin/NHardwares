using System.Runtime.InteropServices;

namespace System.Data.HikHCNetSDK
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct NET_DVR_VOOUT
    {
        public byte byVideoFormat;/* 输出制式,0-PAL,1-NTSC */
        public byte byMenuAlphaValue;/* 菜单与背景图象对比度 */
        public ushort wScreenSaveTime;/* 屏幕保护时间 0-从不,1-1分钟,2-2分钟,3-5分钟,4-10分钟,5-20分钟,6-30分钟 */
        public ushort wVOffset;/* 视频输出偏移 */
        public ushort wBrightness;/* 视频输出亮度 */
        public byte byStartMode;/* 启动后视频输出模式(0:菜单,1:预览)*/
        public byte byEnableScaler;/* 是否启动缩放 (0-不启动, 1-启动)*/
    }

}
