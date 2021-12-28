using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// 读写器设置接口
    /// </summary>
    public interface IReaderSetter
    {
        /// <summary>
        /// 串口读写超时时间(100-1000)
        /// </summary>
        int ReadPollTimeout { get; set; }
        /// <summary>
        /// 串口读写等待接收时间(10-300)
        /// </summary>
        int ReadPollTimeWaiter { get; set; }
        /// <summary>
        /// 串口读写缓冲长度(1024-10240)
        /// </summary>
        int ReadPollBuffLength { get; set; }
    }
    /// <summary>
    /// 读写器设置实现
    /// </summary>
    internal class ReaderSetter : IReaderSetter
    {
        public static IReaderSetter Current { get; } = new ReaderSetter();
        private int _readPollTimeout = 500;
        /// <summary>
        /// 串口读写超时时间
        /// </summary>
        public int ReadPollTimeout { get => _readPollTimeout; set => _readPollTimeout = value >= 100 && value <= 1000 ? value : _readPollTimeout; }
        private int _readPollTimeWaiter = 50;
        /// <summary>
        /// 串口读写等待接收时间
        /// </summary>
        public int ReadPollTimeWaiter { get => _readPollTimeWaiter; set => _readPollTimeWaiter = value >= 10 && value <= 300 ? value : _readPollTimeWaiter; }
        private int _readPollBuffLength = 4096;
        /// <summary>
        /// 串口读写缓冲长度
        /// </summary>
        public int ReadPollBuffLength { get => _readPollBuffLength; set => _readPollBuffLength = value >= 1024 && value <= 10240 ? value : _readPollBuffLength; }
        /// <summary>
        /// 私有构造
        /// </summary>
        private ReaderSetter() { }
    }
}
