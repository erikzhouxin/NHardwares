using System.Collections.Generic;

namespace System.Data.NMQTT
{
    public sealed class MqttPubRelPacket : MqttPacketWithIdentifier
    {
        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public MqttPubRelReasonCode ReasonCode { get; set; } = MqttPubRelReasonCode.Success;

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
            return $"PubRel: [PacketIdentifier={PacketIdentifier}] [ReasonCode={ReasonCode}]";
        }
    }
}