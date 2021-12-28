using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// 读写器创建者
    /// </summary>
    public static class ReaderBuilder
    {
        /// <summary>
        /// 读写器设置项
        /// </summary>
        /// <returns></returns>
        public static IReaderSetter GetReaderSetter()
        {
            return ReaderSetter.Current;
        }
        /// <summary>
        /// 获取顺序读内容
        /// </summary>
        /// <returns></returns>
        public static R2000Queue GetR2000Queue()
        {
            return new R2000Queue();
        }
    }
}
