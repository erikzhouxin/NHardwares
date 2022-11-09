namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 识别结果的类型
    /// </summary>
    public enum VZ_LPRC_RESULT_TYPE : uint
    {
        /// <summary>
        /// 实时识别结果
        /// </summary>
        VZ_LPRC_RESULT_REALTIME,
        /// <summary>
        /// 稳定识别结果
        /// </summary>
        VZ_LPRC_RESULT_STABLE,
        /// <summary>
        /// 调用“VzLPRClient_ForceTrigger”触发的识别结果
        /// </summary>
        VZ_LPRC_RESULT_FORCE_TRIGGER,
        /// <summary>
        /// 外部IO信号触发的识别结果
        /// </summary>
        VZ_LPRC_RESULT_IO_TRIGGER,
        /// <summary>
        /// 虚拟线圈触发的识别结果
        /// </summary>
        VZ_LPRC_RESULT_VLOOP_TRIGGER,
        /// <summary>
        /// 由_FORCE_\_IO_\_VLOOP_中的一种或多种同时触发，具体需要根据每个识别结果的TH_PlateResult::uBitsTrigType来判断
        /// </summary>
        VZ_LPRC_RESULT_MULTI_TRIGGER,
        /// <summary>
        /// 结果种类个数
        /// </summary>
        VZ_LPRC_RESULT_TYPE_NUM
    }
}
