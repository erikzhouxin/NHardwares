using System.Collections.Generic;
using System.Net;

namespace System.Data.NMQTT
{
    public sealed class MqttClientWebSocketOptions : IMqttClientChannelOptions
    {
        public CookieContainer CookieContainer { get; set; }
        
        public MqttClientWebSocketProxyOptions ProxyOptions { get; set; }

        public IDictionary<string, string> RequestHeaders { get; set; }

        public ICollection<string> SubProtocols { get; set; } = new List<string> { "mqtt" };

        public MqttClientTlsOptions TlsOptions { get; set; } = new MqttClientTlsOptions();
        
        public string Uri { get; set; }

        public override string ToString()
        {
            return Uri;
        }
    }
}