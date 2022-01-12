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
        public int Length;
        public byte[] Buffer = new byte[ReadSetter.Current.ReadPollBuffLength];
    }
}
