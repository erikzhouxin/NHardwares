using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace System.Data.NMQTT
{
    #region // Exceptions
    /// <summary>
    /// MQTT通信异常
    /// </summary>
    public class MqttCommunicationException : Exception
    {
        /// <summary>
        /// 异常构造
        /// </summary>
        /// <param name="innerException"></param>
        public MqttCommunicationException(Exception innerException)
            : base(innerException?.Message ?? "MQTT communication failed.", innerException)
        {
        }
        /// <summary>
        /// 消息异常构造
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public MqttCommunicationException(string message, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
    /// <summary>
    /// MQTT通信超时异常
    /// </summary>
    public sealed class MqttCommunicationTimedOutException : MqttCommunicationException
    {
        /// <summary>
        /// 构造
        /// </summary>
        public MqttCommunicationTimedOutException() : base("The operation has timed out.")
        {
        }
        /// <summary>
        /// 异常构造
        /// </summary>
        /// <param name="innerException"></param>
        public MqttCommunicationTimedOutException(Exception innerException) : base("The operation has timed out.", innerException)
        {
        }
    }
    /// <summary>
    /// MQTT配置异常
    /// </summary>
    public class MqttConfigurationException : Exception
    {
        /// <summary>
        /// 构造
        /// </summary>
        protected MqttConfigurationException()
        {
        }
        /// <summary>
        /// 异常构造
        /// </summary>
        /// <param name="innerException"></param>
        public MqttConfigurationException(Exception innerException)
            : base(innerException.Message, innerException)
        {
        }
        /// <summary>
        /// 消息构造
        /// </summary>
        /// <param name="message"></param>
        public MqttConfigurationException(string message)
            : base(message)
        {
        }
    }
    /// <summary>
    /// MQTT违反协议异常
    /// </summary>
    public class MqttProtocolViolationException : Exception
    {
        /// <summary>
        /// 消息构造
        /// </summary>
        /// <param name="message"></param>
        public MqttProtocolViolationException(string message)
            : base(message)
        {
        }
    }
    #endregion Exceptions
    #region // Adapter
    /// <summary>
    /// MQTT连接失败异常
    /// </summary>
    public sealed class MqttConnectingFailedException : MqttCommunicationException
    {
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        /// <param name="connectResult"></param>
        public MqttConnectingFailedException(string message, Exception innerException, MqttClientConnectResult connectResult)
            : base(message, innerException)
        {
            Result = connectResult;
        }
        /// <summary>
        /// 
        /// </summary>
        public MqttClientConnectResult Result { get; }
        /// <summary>
        /// 
        /// </summary>
        public MqttClientConnectResultCode ResultCode => Result?.ResultCode ?? MqttClientConnectResultCode.UnspecifiedError;
    }
    #endregion Adapter
}
