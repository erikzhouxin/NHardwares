using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// R600的射频频谱
    /// </summary>
    public enum R600FreqRegionType
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// FCC
        /// </summary>
        FCC = 0x01,
        /// <summary>
        /// ETSI
        /// </summary>
        ETSI = 0x02,
        /// <summary>
        /// CHN
        /// </summary>
        CHN = 0x03,
        /// <summary>
        /// 自定义
        /// </summary>
        Custom = 0x04,
    }
}
