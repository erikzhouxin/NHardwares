using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace System.Data.NMQTT
{
    public sealed class MqttClientUnsubscribeResultFactory
    {
#if !NET40
        static readonly IReadOnlyCollection<MqttUserProperty> EmptyUserProperties = new List<MqttUserProperty>();
#endif

        public MqttClientUnsubscribeResult Create(MqttUnsubscribePacket unsubscribePacket, MqttUnsubAckPacket unsubAckPacket)
        {
            if (unsubscribePacket == null) throw new ArgumentNullException(nameof(unsubscribePacket));
            if (unsubAckPacket == null) throw new ArgumentNullException(nameof(unsubAckPacket));

            // MQTTv3.1.1 has no reason code at all!
            if (unsubAckPacket.ReasonCodes != null && unsubAckPacket.ReasonCodes.Count != unsubscribePacket.TopicFilters.Count)
            {
                throw new MqttProtocolViolationException(
                    "The return codes are not matching the topic filters [MQTT-3.9.3-1].");
            }

            var items = new List<MqttClientUnsubscribeResultItem>();
            for (var i = 0; i < unsubscribePacket.TopicFilters.Count; i++)
            {
                items.Add(CreateUnsubscribeResultItem(i, unsubscribePacket, unsubAckPacket));
            }
            
            var result = new MqttClientUnsubscribeResult
            {
                PacketIdentifier = unsubAckPacket.PacketIdentifier,
                ReasonString = unsubAckPacket.ReasonString,
#if NET40
                UserProperties = new EReadOnlyCollection<MqttUserProperty>(unsubAckPacket.UserProperties ?? new List<MqttUserProperty>()),
                Items = new EReadOnlyCollection<MqttClientUnsubscribeResultItem>(items)
#else
                UserProperties = unsubAckPacket.UserProperties ?? EmptyUserProperties,
                Items = items
#endif
            };
            
            return result;
        }
        
        static MqttClientUnsubscribeResultItem CreateUnsubscribeResultItem(int index, MqttUnsubscribePacket unsubscribePacket, MqttUnsubAckPacket unsubAckPacket)
        {
            var resultCode = MqttClientUnsubscribeResultCode.Success;
            
            if (unsubAckPacket.ReasonCodes != null)
            {
                // MQTTv3.1.1 has no reason code and no return code!.
                resultCode = (MqttClientUnsubscribeResultCode) unsubAckPacket.ReasonCodes[index];
            }
            
            return new MqttClientUnsubscribeResultItem
            {
                TopicFilter = unsubscribePacket.TopicFilters[index],
                ResultCode = resultCode
            };
        }
    }
}