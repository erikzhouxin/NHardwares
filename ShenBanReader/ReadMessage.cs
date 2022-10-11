using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// 消息信息
    /// </summary>
    public class ReadMessage : IReadMessage
    {
        /// <summary>
        /// 内部构造
        /// </summary>
        internal ReadMessage() { }
        /// <summary>
        /// 寄存器地址
        /// </summary>
        public byte ReadId { get; internal protected set; }
        /// <summary>
        /// 命令
        /// </summary>
        public byte Cmd { get; internal protected set; }
        /// <summary>
        /// AryData
        /// </summary>
        public byte[] AryData { get; internal protected set; }
        /// <summary>
        /// 交换数据
        /// </summary>
        public byte[] TranData { get; internal protected set; }
        /// <summary>
        /// 数据包类型
        /// </summary>
        public byte PacketType { get; internal protected set; }
        /// <summary>
        /// 数据长度
        /// </summary>
        public byte DataLen { get; internal protected set; }
        /// <summary>
        /// 校验位
        /// </summary>
        public byte Check { get; internal protected set; }
    }
    /// <summary>
    /// 信息模型接口
    /// </summary>
    public interface IReadMessage
    {
        /// <summary>
        /// 寄存器地址
        /// </summary>
        byte ReadId { get; }
        /// <summary>
        /// 命令
        /// </summary>
        byte Cmd { get; }
        /// <summary>
        /// AryData
        /// </summary>
        byte[] AryData { get; }
        /// <summary>
        /// 交换数据
        /// </summary>
        byte[] TranData { get; }
        /// <summary>
        /// 数据包类型
        /// </summary>
        byte PacketType { get; }
        /// <summary>
        /// 数据长度
        /// </summary>
        byte DataLen { get; }
        /// <summary>
        /// 校验位
        /// </summary>
        byte Check { get; }
    }
    /// <summary>
    /// 接收信息
    /// </summary>
    internal class ReadReceiveMessage
    {
        public object Locker = new object();
        public int Length = 0;
        public byte[] Buffer = new byte[ReadSetter.Current.ReadPollBuffLength];
        /// <summary>
        /// 添加内容
        /// </summary>
        /// <param name="res"></param>
        /// <returns></returns>
        public byte[][] GetOrAdd(byte[] res)
        {
            lock (Locker)
            {
                try
                {
                    int tCount = res.Length + Length;
                    byte[] tBuffer = new byte[tCount];
                    Array.Copy(Buffer, tBuffer, Length);
                    Array.Copy(res, 0, tBuffer, Length, res.Length);
                    // 分析接收数据，以0xA0为数据起点，以协议中数据长度为数据终止点
                    int nIndex = 0; // 当数据中存在A0时，记录数据的终止点
                    List<byte[]> result = new List<byte[]>();
                    for (int nLoop = 0; nLoop < tCount; nLoop++)
                    {
                        if (tBuffer[nLoop] == 0xA0)
                        {
                            if (tCount > nLoop + 1)
                            {
                                int nLen = Convert.ToInt32(tBuffer[nLoop + 1]);
                                int tempLoop = nLoop + 1 + nLen;
                                if (tempLoop < tCount)
                                {
                                    byte[] btAryAnaly = new byte[nLen + 2];
                                    Array.Copy(tBuffer, nLoop, btAryAnaly, 0, nLen + 2);
                                    result.Add(btAryAnaly);
                                    nIndex = tempLoop + 1;
                                }
                                nLoop = tempLoop;
                            }
                        }
                    }
                    Length = 0;
                    if (nIndex < tCount)
                    {
                        Length = tCount - nIndex;
                        Array.Clear(Buffer, 0, 4096);
                        Array.Copy(tBuffer, nIndex, Buffer, 0, Length);
                    }
                    return result.ToArray();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return new byte[0][];
        }
    }
}
