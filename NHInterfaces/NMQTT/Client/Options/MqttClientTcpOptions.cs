using System.Net;
using System.Net.Sockets;

namespace System.Data.NMQTT
{
    public sealed class MqttClientTcpOptions : IMqttClientChannelOptions
    {
        public AddressFamily AddressFamily { get; set; } = AddressFamily.Unspecified;

        /// <summary>
        /// Gets the local endpoint (network card) which is used by the client.
        /// Set it to _null_ to let the OS select the network card.
        /// </summary>
        public EndPoint LocalEndpoint { get; set; }
        
        public int BufferSize { get; set; } = 8192;

        /// <summary>
        /// Gets or sets whether the underlying socket should run in dual mode.
        /// Leaving this _null_ will avoid setting this value at socket level.
        /// Setting this a value other than _null_ will throw an exception when only IPv4 is supported on the machine.
        /// </summary>
        public bool? DualMode { get; set; }

        public LingerOption LingerState { get; set; } = new LingerOption(true, 0);

        public bool NoDelay { get; set; } = true;

        public int? Port { get; set; }
        
        public string Server { get; set; }

        public MqttClientTlsOptions TlsOptions { get; set; } = new MqttClientTlsOptions();

        public override string ToString()
        {
            return Server + ":" + this.GetPort();
        }
    }
}