using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.DeYaIceIpcSDK
{
    /// <summary>
    /// 报警类型枚举值
    /// </summary>
    public enum ICE_VDC_ALARM_TYPE
    {
        /// <summary>
        /// 实时_硬触发+临时车辆(0),
        /// </summary>
        ICE_VDC_HD_TRIGER,
        /// <summary>
        /// 实时_视频触发+临时车辆（1），
        /// </summary>
        ICE_VDC_VIDEO_TRIGER,
        /// <summary>
        /// 实时_软触发+临时车辆（2），
        /// </summary>
        ICE_VDC_SOFT_TRIGER,
        /// <summary>
        /// 实时_硬触发+有效白名单(3),
        /// </summary>
        ICE_VDC_HD_TRIGER_AND_WHITELIST,
        /// <summary>
        /// 实时_视频触发+有效白名单（4），
        /// </summary>
        ICE_VDC_VIDEO_TRIGER_AND_WHITELIST,
        /// <summary>
        /// 实时_软触发+有效白名单（5），
        /// </summary>
        ICE_VDC_SOFT_TRIGER_AND_WHITELIST,
        /// <summary>
        /// 实时_硬触发+黑名单(6),
        /// </summary>
        ICE_VDC_HD_TRIGER_AND_BLACKLIST,
        /// <summary>
        /// 实时_视频触发+黑名单（7），
        /// </summary>
        ICE_VDC_VIDEO_TRIGER_AND_BLACKLIST,
        /// <summary>
        /// 实时_软触发+黑名单（8），
        /// </summary>
        ICE_VDC_SOFT_TRIGER_AND_BLACKLIST,
        /// <summary>
        /// 脱机_硬触发+临时车辆(9),
        /// </summary>
        ICE_VDC_NC_HD_TRIGER,
        /// <summary>
        /// 脱机_视频触发+临时车辆（10），
        /// </summary>
        ICE_VDC_NC_VIDEO_TRIGER,
        /// <summary>
        /// 脱机_软触发+临时车辆（11），
        /// </summary>
        ICE_VDC_NC_SOFT_TRIGER,
        /// <summary>
        /// 脱机_硬触发+有效白名单(12),
        /// </summary>
        ICE_VDC_NC_HD_TRIGER_AND_WHITELIST,
        /// <summary>
        /// 脱机_视频触发+有效白名单（13），
        /// </summary>
        ICE_VDC_NC_VIDEO_TRIGER_AND_WHITELIST,
        /// <summary>
        /// 脱机_软触发+有效白名单（14），
        /// </summary>
        ICE_VDC_NC_SOFT_TRIGER_AND_WHITELIST,
        /// <summary>
        /// 脱机_硬触发+黑名单(15),
        /// </summary>
        ICE_VDC_NC_HD_TRIGER_AND_BLACKLIST,
        /// <summary>
        /// 脱机_视频触发+黑名单（16），
        /// </summary>
        ICE_VDC_NC_VIDEO_TRIGER_AND_BLACKLIST,
        /// <summary>
        /// 脱机_软触发+黑名单（17），
        /// </summary>
        ICE_VDC_NC_SOFT_TRIGER_AND_BLACKLIST,
        /// <summary>
        /// 实时_硬触发+过期白名单(18),
        /// </summary>
        ICE_VDC_HD_TRIGER_AND_OVERDUE_WHITELIST,
        /// <summary>
        /// 实时_视频触发+过期白名单（19），
        /// </summary>
        ICE_VDC_VIDEO_TRIGER_AND_OVERDUE_WHITELIST,
        /// <summary>
        /// 实时_软触发+过期白名单（20），
        /// </summary>
        ICE_VDC_SOFT_TRIGER_AND_OVERDUE_WHITELIST,
        /// <summary>
        /// 脱机_硬触发+过期白名单(21),
        /// </summary>
        ICE_VDC_NC_HD_TRIGER_AND_OVERDUE_WHITELIST,
        /// <summary>
        /// 脱机_视频触发+过期白名单（22），
        /// </summary>
        ICE_VDC_NC_VIDEO_TRIGER_AND_OVERDUE_WHITELIST,
        /// <summary>
        /// 脱机_软触发+过期白名单（23），
        /// </summary>
        ICE_VDC_NC_SOFT_TRIGER_AND_OVERDUE_WHITELIST,
        /// <summary>
        /// 未知
        /// </summary>
        ICE_VDC_ALARM_UNKOWN,
    }
}
