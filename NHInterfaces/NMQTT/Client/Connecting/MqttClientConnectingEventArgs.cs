using System;

namespace System.Data.NMQTT
{
    public sealed class MqttClientConnectingEventArgs : EventArgs
    {
        public MqttClientConnectingEventArgs(MqttClientOptions clientOptions)
        {
            ClientOptions = clientOptions;
        }

        public MqttClientOptions ClientOptions { get; }
    }
}