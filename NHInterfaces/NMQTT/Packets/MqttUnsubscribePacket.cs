using System.Collections.Generic;

namespace System.Data.NMQTT
{
    public sealed class MqttUnsubscribePacket : MqttPacketWithIdentifier
    {
        public List<string> TopicFilters { get; set; } = new List<string>();

        /// <summary>
        ///     Added in MQTTv5.
        /// </summary>
        public List<MqttUserProperty> UserProperties { get; set; }

        public override string ToString()
        {
            var topicFiltersText = string.Join(",", TopicFilters);
            return $"Unsubscribe: [PacketIdentifier={PacketIdentifier}] [TopicFilters={topicFiltersText}]";
        }
    }
}