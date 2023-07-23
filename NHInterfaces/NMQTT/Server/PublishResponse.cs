using System.Collections.Generic;

namespace System.Data.NMQTT
{
    public sealed class PublishResponse
    {
        public MqttPubAckReasonCode ReasonCode { get; set; } = MqttPubAckReasonCode.Success;

        public string ReasonString { get; set; }

        public List<MqttUserProperty> UserProperties { get; set; }
    }
}