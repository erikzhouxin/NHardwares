using System.Collections.Generic;

namespace System.Data.NMQTT
{
    public sealed class UnsubscribeResult
    {
        public List<MqttUnsubscribeReasonCode> ReasonCodes { get; } = new List<MqttUnsubscribeReasonCode>(128);
        
        public bool CloseConnection { get; set; }
    }
}