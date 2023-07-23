using System.Security.Cryptography.X509Certificates;

namespace System.Data.NMQTT
{
    public interface ICertificateProvider
    {
        X509Certificate2 GetCertificate();
    }
}
