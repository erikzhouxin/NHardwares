using System;

namespace System.Data.NMQTT
{
    public sealed class MqttClientDisconnectedException : MqttCommunicationException
    {
        public MqttClientDisconnectedException(Exception innerException) : base("The MQTT client is disconnected.", innerException)
        {
        }
    }
}