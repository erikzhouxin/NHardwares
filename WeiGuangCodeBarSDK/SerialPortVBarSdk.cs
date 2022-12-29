using System;
using System.Collections.Generic;
using System.Data.NSerialPort;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace System.Data.WeiGuangCodeBarSDK
{
    /// <summary>
    /// 串口微光SDK
    /// </summary>
    public static class SerialPortVBarSdk
    {
        /// <summary>
        /// 尝试创建微光
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static ISerialPortTalkModel CreateVBar(this ISerialPortConfigModel config)
        {
            return config.CreateTalk();
        }
        /// <summary>
        /// 尝试连接微光
        /// </summary>
        /// <param name="config"></param>
        /// <param name="talk"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static bool TryConnectVBar(this ISerialPortConfigModel config, out ISerialPortTalkModel talk, out Exception ex)
        {
            return config.TryConnect(out talk, out ex);
        }
    }
}
