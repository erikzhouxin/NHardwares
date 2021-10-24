using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// 信息模型接口
    /// </summary>
    public interface IR600Message
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
    /// 消息模型
    /// </summary>
    internal class R600Message : IR600Message
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
            byte btCK = R600Reader.CheckByte(this.TranData, 0, this.TranData.Length - 1);
            if (btCK != aryData[nLen - 1]) { return; }

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
    }
}
