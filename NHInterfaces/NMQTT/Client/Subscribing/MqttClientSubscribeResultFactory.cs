using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace System.Data.NMQTT
{
    public sealed class MqttClientSubscribeResultFactory
    {
#if !NET40
        static readonly IReadOnlyCollection<MqttUserProperty> EmptyUserProperties = new List<MqttUserProperty>();
#endif

        public MqttClientSubscribeResult Create(MqttSubscribePacket subscribePacket, MqttSubAckPacket subAckPacket)
        {
            if (subscribePacket == null) throw new ArgumentNullException(nameof(subscribePacket));
            if (subAckPacket == null) throw new ArgumentNullException(nameof(subAckPacket));
            
            // MQTTv5.0.0 handling.
            if (subAckPacket.ReasonCodes.Any() && subAckPacket.ReasonCodes.Count != subscribePacket.TopicFilters.Count)
            {
                throw new MqttProtocolViolationException(
                    "The reason codes are not matching the topic filters [MQTT-3.9.3-1].");
            }
            
            var items = new List<MqttClientSubscribeResultItem>();
            for (var i = 0; i < subscribePacket.TopicFilters.Count; i++)
            {
                items.Add(CreateSubscribeResultItem(i, subscribePacket, subAckPacket));
            }
            
            var result = new MqttClientSubscribeResult
            {
                PacketIdentifier = subAckPacket.PacketIdentifier,
                ReasonString = subAckPacket.ReasonString,
#if NET40
                UserProperties = new EReadOnlyCollection<MqttUserProperty>(subAckPacket.UserProperties ?? new List<MqttUserProperty>()),
                Items = new EReadOnlyCollection<MqttClientSubscribeResultItem>(items)
#else
                UserProperties = subAckPacket.UserProperties ?? EmptyUserProperties,
                Items = items
#endif
            };
            
            return result;
        }

        static MqttClientSubscribeResultItem CreateSubscribeResultItem(int index, MqttSubscribePacket subscribePacket, MqttSubAckPacket subAckPacket)
        {
            var resultCode = (MqttClientSubscribeResultCode) subAckPacket.ReasonCodes[index];

            return new MqttClientSubscribeResultItem
            {
                TopicFilter = subscribePacket.TopicFilters[index],
                ResultCode = resultCode,
            };
        }
    }
}