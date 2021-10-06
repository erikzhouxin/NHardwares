using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// 消息接收事件委托
    /// </summary>
    /// <param name="btAryBuffer"></param>
    public delegate void R600ReceivedEventHandler(byte[] btAryBuffer);
    /// <summary>
    /// 接受数据回调
    /// </summary>
    /// <param name="btAryReceiveData"></param>
    public delegate void R600ReciveCallback(byte[] btAryReceiveData);
    /// <summary>
    /// 发送数据回调
    /// </summary>
    /// <param name="btArySendData"></param>
    public delegate void R600SendCallback(byte[] btArySendData);
    /// <summary>
    /// 解析数据回调
    /// </summary>
    /// <param name="msgTran"></param>
    public delegate void R600AnalyCallback(R600MessageTran msgTran);
}
