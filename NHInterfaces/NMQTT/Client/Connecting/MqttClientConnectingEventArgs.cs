using System;

namespace System.Data.NMQTT
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientConnectingEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="clientOptions"></param>
        public MqttClientConnectingEventArgs(MqttClientOptions clientOptions)
        {
            ClientOptions = clientOptions;
        }
        /// <summary>
        /// 
        /// </summary>
        public MqttClientOptions ClientOptions { get; }
    }
}