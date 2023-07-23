using System;
using System.Collections;

namespace System.Data.NMQTT
{
    public sealed class ClientDisconnectedEventArgs : EventArgs
    {
        public ClientDisconnectedEventArgs(string clientId, MqttClientDisconnectType disconnectType, string endpoint, IDictionary sessionItems)
        {
            ClientId = clientId ?? throw new ArgumentNullException(nameof(clientId));
            DisconnectType = disconnectType;
            Endpoint = endpoint;
            SessionItems = sessionItems ?? throw new ArgumentNullException(nameof(sessionItems));
        }

        /// <summary>
        ///     Gets the client identifier.
        ///     Hint: This identifier needs to be unique over all used clients / devices on the broker to avoid connection issues.
        /// </summary>
        public string ClientId { get; }

        public MqttClientDisconnectType DisconnectType { get; }

        public string Endpoint { get; }

        /// <summary>
        ///     Gets or sets a key/value collection that can be used to share data within the scope of this session.
        /// </summary>
        public IDictionary SessionItems { get; }
    }
}