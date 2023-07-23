using System;

namespace System.Data.NMQTT
{
    public sealed class ApplicationMessageNotConsumedEventArgs : EventArgs
    {
        public ApplicationMessageNotConsumedEventArgs(MqttApplicationMessage applicationMessage, string senderId)
        {
            ApplicationMessage = applicationMessage ?? throw new ArgumentNullException(nameof(applicationMessage));
            SenderId = senderId;
        }

        /// <summary>
        ///     Gets the application message which was not consumed by any client.
        /// </summary>
        public MqttApplicationMessage ApplicationMessage { get; }

        /// <summary>
        ///     Gets the ID of the client which has sent the affected application message.
        /// </summary>
        public string SenderId { get; }
    }
}