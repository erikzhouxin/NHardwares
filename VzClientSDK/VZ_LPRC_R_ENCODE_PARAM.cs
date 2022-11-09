using System.Runtime.InteropServices;

namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 编码参数
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VZ_LPRC_R_ENCODE_PARAM
    {
        /// <summary>
        /// 当前选择的码流
        /// </summary>
        public int default_stream;
        /// <summary>
        /// 码流类型
        /// </summary>
        public int stream_id;
        /// <summary>
        /// 分辨率
        /// </summary>
        public int resolution;
        /// <summary>
        /// [0, 25]，帧率
        /// </summary>
        public int frame_rate;
        /// <summary>
        /// h264
        /// </summary>
        public int encode_type;
        /// <summary>
        /// 码流类型，对应码流控制
        /// </summary>
        public int rate_type;
        /// <summary>
        /// 码流上限
        /// </summary>
        public int data_rate;
        /// <summary>
        /// 视频质量
        /// </summary>
        public int video_quality;
    }
}
