using Ebd.MobileApp.Network;
using System.Net.Security;
using Xamarin.Android.Net;

namespace Ebd.MobileApp.Platforms.Android.Network
{
    public class AndroidHttpMessageHandler : IPlatformHttpMessageHandler
    {
        public HttpMessageHandler GetHttpMessageHandler() =>
            new AndroidMessageHandler
            {
                ServerCertificateCustomValidationCallback = (httpRequestMessage, certificate, chain, sslPolicyErrors) => certificate?.Issuer == "CN=localhost" || sslPolicyErrors == SslPolicyErrors.None
            };
    }
}

