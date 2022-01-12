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
        public static IR2000Queue GetR2000Queue()
        {
            return new R2000Queue();
        }
        /// <summary>
        /// 创建读写器
        /// </summary>
        public static IR600Reader GetR2000Reader()
        {
            return new R600Reader();
        }
        /// <summary>
        /// 创建读写器
        /// </summary>
        public static IR600Reader GetReader(IR600Recall recall)
        {
            var result = new R600Reader();
            result.RegistCallback(recall);
            return result;
        }
        /// <summary>
        /// 创建读写器
        /// </summary>
        public static IR600Reader GetReader(IR600Callback recall)
        {
            var result = new R600Reader();
            result.RegistCallback(recall);
            return result;
        }
        /// <summary>
        /// 创建队列读写器
        /// </summary>
        public static IR600Queue GetQueue()
        {
            var result = new R600Queue();
            return result;
        }
        /// <summary>
        /// 创建队列读写器
        /// </summary>
        public static IR600Queue GetQueue(IR600Recall recall)
        {
            var result = new R600Queue();
            result.RegistCallback(recall);
            return result;
        }
        /// <summary>
        /// 创建队列读写器
        /// </summary>
        public static IR600Queue GetQueue(IR600Callback recall)
        {
            var result = new R600Queue();
            result.RegistCallback(recall);
            return result;
        }
    }
}
