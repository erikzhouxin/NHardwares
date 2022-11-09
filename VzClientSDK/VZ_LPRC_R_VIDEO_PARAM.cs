using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 视频参数
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_LPRC_R_VIDEO_PARAM
    {
        /// <summary>
        /// 亮度
        /// </summary>
        public int brightness;
        /// <summary>
        /// 对比度
        /// </summary>
        public int contrast;
        /// <summary>
        /// 饱和度
        /// </summary>
        public int saturation;
        /// <summary>
        /// 清晰度
        /// </summary>
        public int sharpness;
        /// <summary>
        /// 色调
        /// </summary>
        public int hue;
        /// <summary>
        /// 曝光
        /// </summary>
        public int exposure;
        /// <summary>
        /// 最大曝光时间
        /// </summary>
        public int max_exposure;
        /// <summary>
        /// 增强
        /// </summary>
        public int gain;
        /// <summary>
        /// 最大增强
        /// </summary>
        public int max_gain;
        /// <summary>
        /// 降噪
        /// </summary>
        public int denoise;
        /// <summary>
        /// 翻转
        /// </summary>
        public int flip;
        /// <summary>
        /// 频率
        /// </summary>
        public int frquency;
        /// <summary>
        /// 夜间模式
        /// </summary>
        public int night_mode;
    }
}
