using System.Collections.Generic;

namespace System.Data.NMQTT
{
    public sealed class MqttClientUnexpectedDisconnectReceivedException : MqttCommunicationException
    {
        public MqttClientUnexpectedDisconnectReceivedException(MqttDisconnectPacket disconnectPacket) 
            : base($"Unexpected DISCONNECT (Reason code={disconnectPacket.ReasonCode}) received.")
        {
            ReasonCode = disconnectPacket.ReasonCode;
            SessionExpiryInterval = disconnectPacket.SessionExpiryInterval;
            ReasonString = disconnectPacket.ReasonString;
            ServerReference = disconnectPacket.ServerReference;
            UserProperties = disconnectPacket.UserProperties;
        }

        public MqttDisconnectReasonCode? ReasonCode { get; }

        public uint? SessionExpiryInterval { get; }

        public string ReasonString { get; }

        public List<MqttUserProperty> UserProperties { get; }

        public string ServerReference { get; }
    }
}
