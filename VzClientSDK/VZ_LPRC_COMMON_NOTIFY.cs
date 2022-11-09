namespace System.Data.VzClientSDK
{
    /// <summary>
    /// 通用信息反馈类型
    /// </summary>
    public enum VZ_LPRC_COMMON_NOTIFY : uint
    {
        /// <summary>
        /// 无错误
        /// </summary>
        VZ_LPRC_NO_ERR = 0,
        /// <summary>
        /// 用户名密码错误
        /// </summary>
        VZ_LPRC_ACCESS_DENIED,
        /// <summary>
        /// 网络连接故障
        /// </summary>
        VZ_LPRC_NETWORK_ERR,
    }
}
