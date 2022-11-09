using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 视频质量
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_LPRC_R_VIDEO_QUALITY
    {
        /// <summary>
        /// 视频质量类型
        /// </summary>
        public int video_quality_type;
        /// <summary>
        /// 视频质量内容
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string video_quality_content;
    }
}
