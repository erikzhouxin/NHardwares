using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.ShenBanReader
{
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
}
