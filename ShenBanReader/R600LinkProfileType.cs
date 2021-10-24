using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// R600射频通讯链路类型
    /// </summary>
    public enum R600LinkProfileType
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// 配置0  Tari 25uS; FM0 40KHz
        /// </summary>
        P0 = 0xd0,
        /// <summary>
        /// 配置1(推荐且为默认)   Tari 25uS; Miller 4 250KHz
        /// </summary>
        P1 = 0xd1,
        /// <summary>
        /// 配置2  Tari 25uS; Miller 4 300KHz;
        /// </summary>
        P2 = 0xd2,
        /// <summary>
        /// 配置3 Tari 6.25uS; FM0 400KHz;
        /// </summary>
        P3 = 0xd3,
    }
}
