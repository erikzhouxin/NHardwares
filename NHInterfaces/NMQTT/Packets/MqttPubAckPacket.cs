using System.Collections.Generic;

namespace System.Data.NMQTT
{
    public sealed class MqttPubAckPacket : MqttPacketWithIdentifier
    {
        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public MqttPubAckReasonCode ReasonCode { get; set; } = MqttPubAckReasonCode.Success;

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public string ReasonString { get; set; }

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; set; }

        public override string ToString()
        {
            return $"PubAck: [PacketIdentifier={PacketIdentifier}] [ReasonCode={ReasonCode}]";
        }
    }
}