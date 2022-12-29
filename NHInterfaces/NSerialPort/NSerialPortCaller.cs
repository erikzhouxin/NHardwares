using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.NSerialPort
{
    /// <summary>
    /// 串口调用
    /// </summary>
    public static class NSerialPortCaller
    {
        /// <summary>
        /// 创建串口Talk
        /// </summary>
        public static ISerialPortTalkModel CreateTalk() => new SerialPortTalkModel();
        /// <summary>
        /// 创建串口Talk
        /// </summary>
        public static ISerialPortTalkModel CreateTalk(this ISerialPortConfigModel config) => new SerialPortTalkModel(config);
        /// <summary>
        /// 尝试连接
        /// </summary>
        /// <param name="config"></param>
        /// <param name="talk"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static bool TryConnect(this ISerialPortConfigModel config, out ISerialPortTalkModel talk, out Exception ex)
        {
            talk = new SerialPortTalkModel();
            return talk.Connect(config, out ex);
        }
    }
}
