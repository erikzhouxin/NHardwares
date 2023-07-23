using System;

namespace System.Data.NMQTT
{
    public sealed class MqttUnsubscribePacketFactory
    {
        public MqttUnsubscribePacket Create(MqttClientUnsubscribeOptions clientUnsubscribeOptions)
        {
            if (clientUnsubscribeOptions == null)
            {
                throw new ArgumentNullException(nameof(clientUnsubscribeOptions));
            }

            var packet = new MqttUnsubscribePacket
            {
                UserProperties = clientUnsubscribeOptions.UserProperties
            };

            if (clientUnsubscribeOptions.TopicFilters != null)
            {
                packet.TopicFilters.AddRange(clientUnsubscribeOptions.TopicFilters);
            }

            return packet;
        }
    }
}