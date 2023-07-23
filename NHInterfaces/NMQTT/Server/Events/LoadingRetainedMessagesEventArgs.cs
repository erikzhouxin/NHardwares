using System;
using System.Collections.Generic;

namespace System.Data.NMQTT
{
    public sealed class LoadingRetainedMessagesEventArgs : EventArgs
    {
        public List<MqttApplicationMessage> LoadedRetainedMessages { get; set; } = new List<MqttApplicationMessage>();
    }
}