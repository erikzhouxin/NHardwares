using System;
using System.Collections.Generic;
using System.Data.Cobber;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace System.Data.NSerialPort
{
    /// <summary>
    /// 串口配置模型接口
    /// </summary>
    public interface ISerialPortConfigModel
    {
        /// <summary>
        /// 串口名称
        /// </summary>
        string PortName { get; }
        /// <summary>
        /// 波特率
        /// </summary>
        int PortRate { get; }
        /// <summary>
        /// 数据位
        /// </summary>
        DataBitsType DataBits { get; }
        /// <summary>
        /// 停止位 此值不能为0
        /// </summary>
        StopBitsType StopBits { get; }
        /// <summary>
        /// 校验位
        /// </summary>
        DataParityType Parity { get; }
        /// <summary>
        /// 缓存长度触发回调
        /// </summary>
        int ThresholdLen { get; }
        /// <summary>
        /// 读超时(毫秒数)
        /// </summary>
        int ReadTimeout { get; }
    }
    /// <summary>
    /// 串口配置模型
    /// </summary>
    public class SerialPortConfigModel : ISerialPortConfigModel
    {
        /// <summary>
        /// 串口名称
        /// </summary>
        public virtual string PortName { get; set; }
        /// <summary>
        /// 波特率
        /// </summary>
        public virtual int PortRate { get; set; }
        /// <summary>
        /// 数据位
        /// </summary>
        public virtual DataBitsType DataBits { get; set; }
        /// <summary>
        /// 停止位 此值不能为0
        /// </summary>
        public virtual StopBitsType StopBits { get; set; }
        /// <summary>
        /// 校验位
        /// </summary>
        public virtual DataParityType Parity { get; set; }
        /// <summary>
        /// 缓存长度触发回调
        /// </summary>
        public virtual int ThresholdLen { get; set; }
        /// <summary>
        /// 读超时
        /// </summary>
        public virtual int ReadTimeout { get; set; }
    }
    /// <summary>
    /// 串口数据长度类型
    /// </summary>
    [EDisplay("串口数据长度类型")]
    public enum DataBitsType
    {
        /// <summary>
        /// 未知
        /// </summary>
        [EDisplay("未知")]
        Unknown = 0,
        /// <summary>
        /// 长度8位
        /// </summary>
        [EDisplay("8位")]
        Len8 = 8,
        /// <summary>
        /// 长度7位
        /// </summary>
        [EDisplay("7位")]
        Len7 = 7,
        /// <summary>
        /// 长度6位
        /// </summary>
        [EDisplay("6位")]
        Len6 = 6,
        /// <summary>
        /// 长度5位
        /// </summary>
        [EDisplay("5位")]
        Len5 = 5,
    }
    /// <summary>
    /// 串口校验位类型
    /// </summary>
    [EDisplay("串口校验位类型")]
    public enum DataParityType
    {
        /// <summary>
        /// 无校验
        /// </summary>
        [EDisplay("无校验")]
        Unknown,
        /// <summary>
        /// 奇校验
        /// </summary>
        [EDisplay("奇校验")]
        Odd,
        /// <summary>
        /// 偶校验
        /// </summary>
        [EDisplay("偶校验")]
        Even,
        /// <summary>
        /// 奇偶校验位保留为1
        /// </summary>
        [EDisplay("校验位为1")]
        Mark,
        /// <summary>
        /// 奇偶校验位保留为0
        /// </summary>
        [EDisplay("校验位为0")]
        Space
    }
    /// <summary>
    /// 串口停止位类型
    /// </summary>
    [EDisplay("串口停止位类型")]
    public enum StopBitsType
    {
        /// <summary>
        /// 无
        /// </summary>
        [EDisplay("无")]
        Unknown = 0,
        /// <summary>
        /// 1位
        /// </summary>
        [EDisplay("1位")]
        One = 1,
        /// <summary>
        /// 2位
        /// </summary>
        [EDisplay("2位")]
        Two = 2,
        /// <summary>
        /// 1.5位
        /// </summary>
        [EDisplay("1.5位")]
        OnePoFive = 3,
    }
}
