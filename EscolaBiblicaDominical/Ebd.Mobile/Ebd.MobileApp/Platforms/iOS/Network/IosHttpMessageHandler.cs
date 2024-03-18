using Ebd.MobileApp.Network;
using Security;

namespace Ebd.MobileApp.Platforms.iOS.Network
{
    public class IosHttpMessageHandler : IPlatformHttpMessageHandler
    {
        public HttpMessageHandler GetHttpMessageHandler() =>
            new NSUrlSessionHandler
            {
                TrustOverrideForUrl = (NSUrlSessionHandler sender, string url, SecTrust trust) => url.StartsWith("https://localhost")
            };
    }
}
