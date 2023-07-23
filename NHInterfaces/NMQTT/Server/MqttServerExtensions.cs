using System;
using System.Text;
using System.Threading.Tasks;

namespace System.Data.NMQTT
{
    public static class MqttServerExtensions
    {
        public static Task InjectApplicationMessage(
            this MqttServer server,
            string topic,
            string payload = null,
            MqttQualityOfServiceLevel qualityOfServiceLevel = MqttQualityOfServiceLevel.AtMostOnce,
            bool retain = false)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }

            if (topic == null)
            {
                throw new ArgumentNullException(nameof(topic));
            }

            var payloadBuffer = EmptyBuffer.Array;
            if (payload is string stringPayload)
            {
                payloadBuffer = Encoding.UTF8.GetBytes(stringPayload);
            }

            return server.InjectApplicationMessage(
                new InjectedMqttApplicationMessage(
                    new MqttApplicationMessage
                    {
                        Topic = topic,
                        Payload = payloadBuffer,
                        QualityOfServiceLevel = qualityOfServiceLevel,
                        Retain = retain
                    }));
        }

        public static Task SubscribeAsync(this MqttServer server, string clientId, params MqttTopicFilter[] topicFilters)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }

            if (clientId == null)
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            if (topicFilters == null)
            {
                throw new ArgumentNullException(nameof(topicFilters));
            }

            return server.SubscribeAsync(clientId, topicFilters);
        }

        public static Task SubscribeAsync(this MqttServer server, string clientId, string topic)
        {
            if (server == null)
            {
                throw new ArgumentNullException(nameof(server));
            }

            if (clientId == null)
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            if (topic == null)
            {
                throw new ArgumentNullException(nameof(topic));
            }

            var topicFilters = new MqttTopicFilterBuilder().WithTopic(topic).Build();
            return server.SubscribeAsync(clientId, topicFilters);
        }
    }
}