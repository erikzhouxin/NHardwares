using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// R600数据区域类型
    /// </summary>
    public enum R600AreaType
    {
        /// <summary>
        /// 保留区(密码区)
        /// </summary>
        Reserved = 0,
        /// <summary>
        /// EPC区域
        /// </summary>
        EPC = 0x01,
        /// <summary>
        /// 标签ID
        /// </summary>
        TID = 0x02,
        /// <summary>
        /// 用户区
        /// </summary>
        User = 0x03,
    }
}
