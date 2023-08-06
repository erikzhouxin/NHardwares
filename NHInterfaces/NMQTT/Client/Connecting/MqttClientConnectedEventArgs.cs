using System;

namespace System.Data.NMQTT
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class MqttClientConnectedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectResult"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public MqttClientConnectedEventArgs(MqttClientConnectResult connectResult)
        {
            ConnectResult = connectResult ?? throw new ArgumentNullException(nameof(connectResult));
        }

        /// <summary>
        ///     Gets the authentication result.
        ///     Hint: MQTT 5 feature only.
        /// </summary>
        public MqttClientConnectResult ConnectResult { get; }
    }
}