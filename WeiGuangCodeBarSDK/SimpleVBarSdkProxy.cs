using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace System.Data.WeiGuangCodeBarSDK
{
    /// <summary>
    /// 简单微光条码识别代理
    /// </summary>
    public interface ISimpleVBarSdkProxy
    {
        /// <summary>
        /// 打开信道
        /// </summary>
        /// <param name="type"></param>
        /// <param name="parm"></param>
        /// <returns></returns>
        IntPtr Vbar_channel_open(int type, long parm);
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="dev"></param>
        /// <param name="data"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        int Vbar_channel_send(IntPtr dev, byte[] data, int length);
        /// <summary>
        /// 接收数据
        /// </summary>
        /// <param name="dev"></param>
        /// <param name="buffer"></param>
        /// <param name="size"></param>
        /// <param name="milliseconds"></param>
        /// <returns></returns>
        int Vbar_channel_recv(IntPtr dev, byte[] buffer, int size, int milliseconds);
        /// <summary>
        /// 关闭信道
        /// </summary>
        /// <param name="dev"></param>
        void Vbar_channel_close(IntPtr dev);
    }
}
