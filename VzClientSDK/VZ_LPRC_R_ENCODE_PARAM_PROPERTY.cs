using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 编码参数属性
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_LPRC_R_ENCODE_PARAM_PROPERTY
    {
        /// <summary>
        /// 当前选择的码流
        /// </summary>
        public int encode_stream;
        /// <summary>
        /// 分辨率
        /// </summary>
        public int resolution_cur;
        /// <summary>
        /// 分辨率
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.Struct)]
        public VZ_LPRC_R_RESOLUTION[] resolution;
        /// <summary>
        /// 当前帧率
        /// </summary>
        public int frame_rate_cur;
        /// <summary>
        /// 最小帧率
        /// </summary>
        public int frame_rate_min;
        /// <summary>
        /// 最大帧率
        /// </summary>
        public int frame_rate_max;
        /// <summary>
        /// 码率控制
        /// </summary>
        public int rate_type_cur;
        /// <summary>
        /// 码率类型
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.Struct)]
        public VZ_LPRC_R_RATE_TYPE[] rate_type;
        /// <summary>
        /// 码流上限
        /// </summary>
        public int data_rate_cur;
        /// <summary>
        /// 码率最小值
        /// </summary>
        public int data_rate_min;
        /// <summary>
        /// 码率最大值
        /// </summary>
        public int data_rate_max;
        /// <summary>
        /// 视频质量
        /// </summary>
        public int video_quality_cur;
        /// <summary>
        /// 视频质量
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.Struct)]
        public VZ_LPRC_R_VIDEO_QUALITY[] video_quality;
    }
}
