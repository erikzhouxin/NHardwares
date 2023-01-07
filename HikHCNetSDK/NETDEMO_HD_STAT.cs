namespace System.Data.HikHCNetSDK
{
    public enum HD_STAT
    {
        HD_STAT_OK = 0,/* 正常 */
        HD_STAT_UNFORMATTED = 1,/* 未格式化 */
        HD_STAT_ERROR = 2,/* 错误 */
        HD_STAT_SMART_FAILED = 3,/* SMART状态 */
        HD_STAT_MISMATCH = 4,/* 不匹配 */
        HD_STAT_IDLE = 5, /* 休眠*/
        NET_HD_STAT_OFFLINE = 6,/*网络盘处于未连接状态 */
        HD_RIADVD_EXPAND = 7,    /* 虚拟磁盘可扩容 */
        HD_STAT_REPARING = 10,   /* 硬盘正在修复(9000 2.0) */
        HD_STAT_FORMATING = 11,   /* 硬盘正在格式化(9000 2.0) */
    }

}
