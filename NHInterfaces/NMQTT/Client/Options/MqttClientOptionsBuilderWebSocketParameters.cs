using System.Collections.Generic;
using System.Net;

namespace System.Data.NMQTT
{
    public class MqttClientOptionsBuilderWebSocketParameters
    {
        public IDictionary<string, string> RequestHeaders { get; set; }

        public CookieContainer CookieContainer { get; set; }
    }
}
