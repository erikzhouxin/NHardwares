using System.Collections.Generic;

namespace System.Data.NMQTT
{
    public sealed class SubscribeResult
    {
        public SubscribeResult(int topicsCount)
        {
            ReasonCodes = new List<MqttSubscribeReasonCode>(topicsCount);
        }
        
        public bool CloseConnection { get; set; }
        
        public List<MqttSubscribeReasonCode> ReasonCodes { get; set; }

        public string ReasonString { get; set; }

        public List<MqttRetainedMessageMatch> RetainedMessages { get; set; }

        public List<MqttUserProperty> UserProperties { get; set; }
    }
}