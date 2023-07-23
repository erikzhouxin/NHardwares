using System;

namespace System.Data.NMQTT
{
    public sealed class MqttSubscribePacketFactory
    {
        public MqttSubscribePacket Create(MqttClientSubscribeOptions clientSubscribeOptions)
        {
            if (clientSubscribeOptions == null)
            {
                throw new ArgumentNullException(nameof(clientSubscribeOptions));
            }

            var packet = new MqttSubscribePacket
            {
                TopicFilters = clientSubscribeOptions.TopicFilters,
                SubscriptionIdentifier = clientSubscribeOptions.SubscriptionIdentifier,
                UserProperties = clientSubscribeOptions.UserProperties
            };

            return packet;
        }
    }
}