using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace System.Data.ShenBanReader
{
    internal interface ReadTalkModel : IDisposable
    {
        /// <summary>
        /// 接收到发来的消息
        /// </summary>
        event Action<byte[]> Received;
        /// <summary>
        /// 连接到服务端
        /// </summary>
        /// <param name="ip">IP地址</param>
        /// <param name="port">端口号</param>
        /// <param name="message">消息提示</param>
        /// <returns></returns>
        bool Connect(IPAddress ip, int port, out string message);
        /// <summary>
        /// 连接到服务端
        /// </summary>
        /// <param name="portName">串口号</param>
        /// <param name="bautRate">波特率</param>
        /// <param name="message">消息提示</param>
        /// <returns></returns>
        bool Connect(string portName, int bautRate, out string message);
        /// <summary>
        /// 发送数据包
        /// </summary>
        /// <param name="aryBuffer"></param>
        /// <returns></returns>
        bool Send(byte[] aryBuffer);
        /// <summary>
        /// 注销连接
        /// </summary>
        void Exit();
        /// <summary>
        /// 校验是否连接服务器
        /// </summary>
        /// <returns></returns>
        bool IsConnect();
    }
}
