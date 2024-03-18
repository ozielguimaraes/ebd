using Ebd.Mobile.Constants;

namespace Ebd.MobileApp.Network
{
    public static class DynamicBaseUrl
    {
        public static string GetAdjustedBaseUrl()
        {
            var baseUrl = AppConstant.BaseUrl;
            var uri = new Uri(baseUrl);
#if ANDROID
            if (uri.Host == "localhost" || uri.Host == "127.0.0.1")
            {
                baseUrl = baseUrl.Replace(uri.Host, "10.0.2.2");
            }
#elif IOS
            if (uri.Host == "10.0.2.2")
            {
                baseUrl = baseUrl.Replace(uri.Host, "localhost");
            }
#endif

            return baseUrl;
        }
    }
}
