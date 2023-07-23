using System.Collections.Generic;

namespace System.Data.NMQTT
{
    public sealed class DispatchApplicationMessageResult
    {
        public DispatchApplicationMessageResult(int reasonCode, bool closeConnection, string reasonString, List<MqttUserProperty> userProperties)
        {
            ReasonCode = reasonCode;
            CloseConnection = closeConnection;
            ReasonString = reasonString;
            UserProperties = userProperties;
        }

        public bool CloseConnection { get; }

        public int ReasonCode { get; }

        public string ReasonString { get; }

        public List<MqttUserProperty> UserProperties { get; }
    }
}