using System.Security.Authentication;

namespace System.Data.NMQTT
{
    public sealed class MqttServerTlsTcpEndpointOptions : MqttServerTcpEndpointBaseOptions
    {
        public MqttServerTlsTcpEndpointOptions()
        {
            Port = 8883;
        }

#if !WINDOWS_UWP
        public System.Net.Security.RemoteCertificateValidationCallback RemoteCertificateValidationCallback { get; set; }
#endif
        public ICertificateProvider CertificateProvider { get; set; }

        public bool ClientCertificateRequired { get; set; }

        public bool CheckCertificateRevocation { get; set; }

        public SslProtocols SslProtocol { get; set; } = (SslProtocols)0xC00;
        
#if NETCOREAPP3_1 || NET5_0_OR_GREATER
        public System.Net.Security.CipherSuitesPolicy CipherSuitesPolicy { get; set; }
#endif
    }
}
