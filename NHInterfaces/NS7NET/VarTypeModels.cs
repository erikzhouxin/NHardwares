using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.NS7NET
{
    /// <summary>
    /// CPU类型
    /// </summary>
    public enum CpuType
    {
        /// <summary>
        /// S7200
        /// </summary>
        S7200,
        /// <summary>
        /// S7300
        /// </summary>
        S7300 = 10,
        /// <summary>
        /// S7400
        /// </summary>
        S7400 = 20,
        /// <summary>
        /// S71200
        /// </summary>
        S71200 = 30,
        /// <summary>
        /// S71500
        /// </summary>
        S71500 = 40
    }
    /// <summary>
    /// 变量类型
    /// </summary>
    public enum VarType
    {
        /// <summary>
        /// 位
        /// </summary>
        Bit,
        /// <summary>
        /// 字节
        /// </summary>
        Byte,
        /// <summary>
        /// 字(无符号短整型)
        /// </summary>
        Word,
        /// <summary>
        /// 双字(无符号整型)
        /// </summary>
        DWord,
        /// <summary>
        /// 短整型
        /// </summary>
        Int,
        /// <summary>
        /// 整型
        /// </summary>
        DInt,
        /// <summary>
        /// 实数
        /// </summary>
        Real,
        /// <summary>
        /// 字符串
        /// </summary>
        String,
        /// <summary>
        /// 计时器
        /// </summary>
        Timer,
        /// <summary>
        /// 计数器
        /// </summary>
        Counter
    }
    /// <summary>
    /// 数据类型
    /// </summary>
    public enum DataType
    {
        /// <summary>
        /// 输入
        /// </summary>
        Input = 129,
        /// <summary>
        /// 输出
        /// </summary>
        Output,
        /// <summary>
        /// 缓存
        /// </summary>
        Memory,
        /// <summary>
        /// 数据块
        /// </summary>
        DataBlock,
        /// <summary>
        /// 计时器
        /// </summary>
        Timer = 29,
        /// <summary>
        /// 计数器
        /// </summary>
        Counter = 28
    }
    /// <summary>
    /// 错误代码
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// 无错误
        /// </summary>
        NoError,
        /// <summary>
        /// 不支持的CPU类型
        /// </summary>
        WrongCPU_Type,
        /// <summary>
        /// 连接错误
        /// </summary>
        ConnectionError,
        /// <summary>
        /// IP地址不可达
        /// </summary>
        IPAddressNotAvailable,
        /// <summary>
        /// 错误的变量格式
        /// </summary>
        WrongVarFormat = 10,
        /// <summary>
        /// 错误接收字节数
        /// </summary>
        WrongNumberReceivedBytes,
        /// <summary>
        /// 发送数据错误
        /// </summary>
        SendData = 20,
        /// <summary>
        /// 读取数据错误
        /// </summary>
        ReadData = 30,
        /// <summary>
        /// 写入数据错误
        /// </summary>
        WriteData = 50
    }
    /// <summary>
    /// 数据项
    /// </summary>
    public class DataItem
    {
        /// <summary>
        /// 数据类型
        /// </summary>
        public DataType DataType { get; set; }
        /// <summary>
        /// 变量类型
        /// </summary>
        public VarType VarType { get; set; }
        /// <summary>
        /// 数据节点
        /// </summary>
        public int DB { get; set; }
        /// <summary>
        /// 起始地址
        /// </summary>
        public int StartByteAdr { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        public object Value { get; set; }
        /// <summary>
        /// 构造
        /// </summary>
        public DataItem()
        {
            this.VarType = VarType.Byte;
            this.Count = 1;
        }
    }
    /// <summary>
    /// 字节数组
    /// </summary>
    internal class ByteArray
    {
        private readonly List<byte> _list;
        /// <summary>
        /// 数组
        /// </summary>
        public byte[] Array => _list.ToArray();
        /// <summary>
        /// 构造
        /// </summary>
        public ByteArray()
        {
            this._list = new List<byte>();
        }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="size"></param>
        public ByteArray(int size)
        {
            this._list = new List<byte>(size);
        }
        /// <summary>
        /// 清理
        /// </summary>
        public void Clear()
        {
            this._list.Clear();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="item"></param>
        public void Add(byte item)
        {
            this._list.Add(item);
        }
        /// <summary>
        /// 添加多个
        /// </summary>
        /// <param name="items"></param>
        public void Add(byte[] items)
        {
            this._list.AddRange(items);
        }
        /// <summary>
        /// 添加多个
        /// </summary>
        /// <param name="byteArray"></param>
        public void Add(ByteArray byteArray)
        {
            this._list.AddRange(byteArray.Array);
        }
    }
}
