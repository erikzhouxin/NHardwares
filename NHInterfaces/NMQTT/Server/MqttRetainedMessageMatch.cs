using System;

namespace System.Data.NMQTT
{
    public sealed class MqttRetainedMessageMatch
    {
        public MqttRetainedMessageMatch(MqttApplicationMessage applicationMessage, MqttQualityOfServiceLevel subscriptionQualityOfServiceLevel)
        {
            ApplicationMessage = applicationMessage ?? throw new ArgumentNullException(nameof(applicationMessage));
            SubscriptionQualityOfServiceLevel = subscriptionQualityOfServiceLevel;
        }

        public MqttApplicationMessage ApplicationMessage { get; }

        public MqttQualityOfServiceLevel SubscriptionQualityOfServiceLevel { get; set; }
    }
}