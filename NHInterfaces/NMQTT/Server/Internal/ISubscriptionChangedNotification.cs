using System.Collections.Generic;

namespace System.Data.NMQTT
{
    public interface ISubscriptionChangedNotification
    {
        void OnSubscriptionsAdded(MqttSession clientSession, List<string> subscriptionsTopics);

        void OnSubscriptionsRemoved(MqttSession clientSession, List<string> subscriptionTopics);
    }
}