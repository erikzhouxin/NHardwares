using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// 消息模型
    /// </summary>
    internal class R600Message : IReadMessage
    {
        /// <summary>
        /// 寄存器地址
        /// </summary>
        public byte ReadId { get; }
        /// <summary>
        /// 命令
        /// </summary>
        public byte Cmd { get; }
        /// <summary>
        /// AryData
        /// </summary>
        public byte[] AryData { get; }
        /// <summary>
        /// 交换数据
        /// </summary>
        public byte[] TranData { get; }
        /// <summary>
        /// 数据包类型
        /// </summary>
        public byte PacketType { get; }
        /// <summary>
        /// 数据长度
        /// </summary>
        public byte DataLen { get; }
        /// <summary>
        /// 校验位
        /// </summary>
        public byte Check { get; }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="aryData"></param>
        public R600Message(byte[] aryData)
        {
            int nLen = aryData.Length;
            this.TranData = new byte[nLen];
            aryData.CopyTo(this.TranData, 0);
            byte btCK = ReaderCaller.CheckByte(this.TranData, 0, this.TranData.Length - 1);
            if (btCK != aryData[nLen - 1])
            {
                AryData = new byte[] { };
                return;
            }

            this.PacketType = aryData[0];
            this.DataLen = aryData[1];
            this.ReadId = aryData[2];
            this.Cmd = aryData[3];
            this.Check = aryData[nLen - 1];

            if (nLen > 5)
            {
                this.AryData = new byte[nLen - 5];
                for (int nloop = 0; nloop < nLen - 5; nloop++)
                {
                    this.AryData[nloop] = aryData[4 + nloop];
                }
            }
        }
        public static R600Message[] Analysis(byte[] received)
        {
            if (received == null || received.Length == 0) { return new R600Message[] { }; }
            var result = new List<R600Message>();
            for (int i = 0; i < received.Length; i++)
            {
                var item = received[i];
                if (item == 0xA0)
                {
                    if (i + 1 < received.Length)
                    {
                        var currLen = received[i + 1];
                        var len = currLen + 2;
                        var index = i + len;
                        if (index > received.Length)
                        {
                            var data = new byte[received.Length - i + 1];
                            Array.Copy(received, i, data, 0, data.Length);
                            result.Add(new R600Message(data));
                            i = received.Length;
                        }
                        else
                        {
                            var data = new byte[len];
                            Array.Copy(received, i, data, 0, len);
                            result.Add(new R600Message(data));
                            i = index - 1;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return result.ToArray();
        }
    }
}
