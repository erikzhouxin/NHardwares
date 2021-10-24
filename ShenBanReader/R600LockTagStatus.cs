using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// 锁定状态
    /// </summary>
    public enum R600LockTagStatus
    {
        /// <summary>
        /// 永久写保护：成功锁定
        /// </summary>
        Success = 0x00,
        /// <summary>
        /// 永久写保护：已是锁定状态
        /// </summary>
        Locked = 0xFE,
        /// <summary>
        /// 永久写保护：无法锁定
        /// </summary>
        Failed = 0xFF,
    }
}
