using System;

namespace System.Data.NMQTT
{
    public sealed class InjectedMqttApplicationMessage
    {
        public InjectedMqttApplicationMessage(MqttApplicationMessage applicationMessage)
        {
            ApplicationMessage = applicationMessage ?? throw new ArgumentNullException(nameof(applicationMessage));
        }

        public string SenderClientId { get; set; } = string.Empty;

        public MqttApplicationMessage ApplicationMessage { get; set; }
    }
}