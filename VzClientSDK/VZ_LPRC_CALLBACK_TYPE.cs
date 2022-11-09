namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 设置回调函数时需要制定的类型
    /// </summary>
    public enum VZ_LPRC_CALLBACK_TYPE : uint
    {
        /// <summary>
        /// SDK通用信息反馈
        /// </summary>
        VZ_LPRC_CALLBACK_COMMON_NOTIFY = 0,
        /// <summary>
        /// 车牌号码字符
        /// </summary>
        VZ_LPRC_CALLBACK_PLATE_STR,
        /// <summary>
        /// 完整图像
        /// </summary> 
        VZ_LRPC_CALLBACK_FULL_IMAGE,
        /// <summary>
        /// 截取图像
        /// </summary> 
        VZ_LPRC_CALLBACK_CLIP_IMAGE,
        /// <summary>
        /// 实时识别结果
        /// </summary> 
        VZ_LPRC_CALLBACK_PLATE_RESULT,
        /// <summary>
        /// 稳定识别结果
        /// </summary>
        VZ_LPRC_CALLBACK_PLATE_RESULT_STABLE,
        /// <summary>
        /// 触发的识别结果，包括API（软件）和IO（硬件）方式的
        /// </summary> 
        VZ_LPRC_CALLBACK_PLATE_RESULT_TRIGGER,
        /// <summary>
        /// 视频帧回调
        /// </summary>
        VZ_LPRC_CALLBACK_VIDEO,
    }
}
