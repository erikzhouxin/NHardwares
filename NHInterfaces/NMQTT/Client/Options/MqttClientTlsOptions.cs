using System;
using System.Collections.Generic;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace System.Data.NMQTT
{
    public sealed class MqttClientTlsOptions
    {
        public Func<MqttClientCertificateValidationEventArgs, bool> CertificateValidationHandler { get; set; }

        public bool UseTls { get; set; }

        public bool IgnoreCertificateRevocationErrors { get; set; }

        public bool IgnoreCertificateChainErrors { get; set; }

        public bool AllowUntrustedCertificates { get; set; }

        public X509RevocationMode RevocationMode { get; set; } = X509RevocationMode.Online;

#if WINDOWS_UWP
        public List<byte[]> Certificates { get; set; }
#else
        public List<X509Certificate> Certificates { get; set; }
#endif

#if NETCOREAPP3_1 || NET5_0_OR_GREATER
        public List<System.Net.Security.SslApplicationProtocol> ApplicationProtocols { get; set; }
        
        public System.Net.Security.CipherSuitesPolicy CipherSuitesPolicy { get; set; }
#endif

#if NET40 || NET45 || NETStd
        public SslProtocols SslProtocol { get; set; } = (SslProtocols)0xC00 /*Tls12*/ | (SslProtocols)0x00003000 /*Tls13*/;
#else
        public SslProtocols SslProtocol { get; set; } = SslProtocols.Tls12 | SslProtocols.Tls13;
#endif
    }
}