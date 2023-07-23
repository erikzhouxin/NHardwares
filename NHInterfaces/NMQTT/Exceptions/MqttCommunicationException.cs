using System;

namespace System.Data.NMQTT
{
    public class MqttCommunicationException : Exception
    {
        public MqttCommunicationException(Exception innerException)
            : base(innerException?.Message ?? "MQTT communication failed.", innerException)
        {
        }

        public MqttCommunicationException(string message, Exception innerException = null)
            : base(message, innerException)
        {
        }
    }
}
