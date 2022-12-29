using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.NS7NET
{
    /// <summary>
    /// NS7NET调用
    /// </summary>
    public static class S7NetSdk
    {
        /// <summary>
        /// 创建PLC接口
        /// </summary>
        /// <param name="cpu"></param>
        /// <param name="ip"></param>
        /// <param name="rack"></param>
        /// <param name="slot"></param>
        /// <returns></returns>
        public static IS7NetPlc Create(this CpuType cpu, string ip, short rack, short slot)
        {
            return new S7NetPlc(cpu, ip, rack, slot);
        }
    }
}
