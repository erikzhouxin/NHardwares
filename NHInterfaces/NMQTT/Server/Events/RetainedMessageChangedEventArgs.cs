using System;
using System.Collections.Generic;

namespace System.Data.NMQTT
{
    public sealed class RetainedMessageChangedEventArgs : EventArgs
    {
        public RetainedMessageChangedEventArgs(string clientId, MqttApplicationMessage changedRetainedMessage, List<MqttApplicationMessage> storedRetainedMessages)
        {
            ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
            ChangedRetainedMessage = changedRetainedMessage ?? throw new ArgumentNullException(nameof(changedRetainedMessage));
            StoredRetainedMessages = storedRetainedMessages ?? throw new ArgumentNullException(nameof(storedRetainedMessages));
        }

        public MqttApplicationMessage ChangedRetainedMessage { get; }

        public string ClientId { get; }

        public List<MqttApplicationMessage> StoredRetainedMessages { get; }
    }
}