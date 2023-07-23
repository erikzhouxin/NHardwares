using System;

namespace System.Data.NMQTT
{
    public sealed class MqttCommunicationTimedOutException : MqttCommunicationException
    {
        public MqttCommunicationTimedOutException() : base("The operation has timed out.")
        {
        }

        public MqttCommunicationTimedOutException(Exception innerException) : base("The operation has timed out.", innerException)
        {
        }
    }
}
