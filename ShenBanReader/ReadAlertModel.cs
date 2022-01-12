using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.ShenBanReader
{
    /// <summary>
    /// R600提示结果类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ReadAlertModel<T>
    {
        /// <summary>
        /// 错误构造
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="data"></param>
        public ReadAlertModel(ReadCmdType cmd, int code, string message, string clazz, string method, T data)
        {
            IsSuccess = false;
            Cmd = cmd;
            Code = code;
            Message = message;
            Clazz = clazz;
            Method = method;
            Data = data;
        }
        /// <summary>
        /// 成功构造
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="data"></param>
        public ReadAlertModel(ReadCmdType cmd, T data)
        {
            IsSuccess = true;
            Cmd = cmd;
            Code = 200;
            Message = string.Empty;
            Clazz = string.Empty;
            Method = cmd.ToString();
            Data = data;
        }

        /// <summary>
        /// 是成功
        /// </summary>
        public bool IsSuccess { get; }
        /// <summary>
        /// 提示信息
        /// </summary>
        public String Message { get; }
        /// <summary>
        /// 错误代码
        /// </summary>
        public int Code { get; }
        /// <summary>
        /// 类名
        /// </summary>
        public string Clazz { get; }
        /// <summary>
        /// 方法名
        /// </summary>
        public String Method { get; }
        /// <summary>
        /// 数据内容
        /// </summary>
        public T Data { get; }
        /// <summary>
        /// 命令
        /// </summary>
        public ReadCmdType Cmd { get; }
    }
    /// <summary>
    /// R600提示结果类
    /// </summary>
    public class ReadAlertError : ReadAlertModel<IReadMessage>
    {
        /// <summary>
        /// 错误构造
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="clazz"></param>
        /// <param name="method"></param>
        /// <param name="data"></param>
        public ReadAlertError(ReadCmdType cmd, int code, string message, string clazz, string method, IReadMessage data) : base(cmd, code, message, clazz, method, data)
        {

        }
    }
}
