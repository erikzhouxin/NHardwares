using System;

namespace System.Data.NMQTT
{
    public class MqttConfigurationException : Exception
    {
        protected MqttConfigurationException()
        {
        }

        public MqttConfigurationException(Exception innerException)
            : base(innerException.Message, innerException)
        {
        }

        public MqttConfigurationException(string message)
            : base(message)
        {
        }
    }
}
