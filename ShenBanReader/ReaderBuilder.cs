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
        public static IReadSetter GetReaderSetter()
        {
            return ReadSetter.Current;
        }
        #region // R600系列
        /// <summary>
        /// 创建读写器
        /// </summary>
        public static IR600Reader GetR600Reader(IR600CallMethod recall)
        {
            var result = new R600Reader();
            result.RegistCallback(recall);
            return result;
        }
        /// <summary>
        /// 创建读写器
        /// </summary>
        public static IR600Reader GetR600Reader(IR600CallAction recall)
        {
            var result = new R600Reader();
            result.RegistCallback(recall);
            return result;
        }
        /// <summary>
        /// 创建队列读写器
        /// </summary>
        public static IR600Queue GetR600Queue()
        {
            var result = new R600Queue();
            return result;
        }
        /// <summary>
        /// 创建队列读写器
        /// </summary>
        public static IR600Queue GetR600Queue(IR600CallMethod recall)
        {
            var result = new R600Queue();
            result.RegistCallback(recall);
            return result;
        }
        /// <summary>
        /// 创建队列读写器
        /// </summary>
        public static IR600Queue GetR600Queue(IR600CallAction recall)
        {
            var result = new R600Queue();
            result.RegistCallback(recall);
            return result;
        }
        #endregion
        #region // R2000系列
        /// <summary>
        /// 获取顺序读内容
        /// </summary>
        /// <returns></returns>
        public static IR2000Queue GetR2000Queue()
        {
            return new R2000Queue();
        }
        /// <summary>
        /// 获取原始访问方式
        /// </summary>
        /// <returns></returns>
        [Obsolete("替代方案:IR600Reader")]
        public static IR2000Reactor Get2000Reactor()
        {
            return new R2000Reactor();
        }
        /// <summary>
        /// 获取逻辑阅读器
        /// </summary>
        /// <returns></returns>
        public static IReadLogical GetLogicReader()
        {
            return new ReadLogical();
        }
        #endregion
    }
}
