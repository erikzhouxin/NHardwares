using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.HardwareInterfaces
{
    /// <summary>
    /// IO控制器类型
    /// <see cref="System.Data.NHInterfaces.IOControlType"/>
    /// </summary>
    [Obsolete("替代方案:NHInterfaces.IOControlType,2023.x.x之后的版本将不再提供")]
    public enum IOControlType
    {
        /// <summary>
        /// 未知
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// 有人8路IO控制器
        /// USR-IO808-EWR
        /// </summary>
        USR_IO808_EWR = 4,
    }
}
