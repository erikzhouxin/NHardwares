using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace System.Data.NMQTT
{
    public sealed class MqttClientOptionsBuilderTlsParameters
    {
        public bool UseTls { get; set; }

        public Func<MqttClientCertificateValidationEventArgs, bool> CertificateValidationHandler { get; set; }

#if NET40 || NET45 || NETStd
        public SslProtocols SslProtocol { get; set; } = (SslProtocols)0xC00 /*Tls12*/ | (SslProtocols)0x00003000 /*Tls13*/;
#else
        public SslProtocols SslProtocol { get; set; } = SslProtocols.Tls12 | SslProtocols.Tls13;
#endif

#if WINDOWS_UWP
        public IEnumerable<IEnumerable<byte>> Certificates { get; set; }
#else
        public IEnumerable<X509Certificate> Certificates { get; set; }
#endif

#if NETCOREAPP3_1 || NET5_0_OR_GREATER
        public List<SslApplicationProtocol> ApplicationProtocols { get;set; }
#endif

        public bool AllowUntrustedCertificates { get; set; }

        public bool IgnoreCertificateChainErrors { get; set; }

        public bool IgnoreCertificateRevocationErrors { get; set; }
    }
}
