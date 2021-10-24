using Ebd.Mobile.Constants;
using Ebd.Mobile.Services.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Implementations.Base
{
    public abstract class ApiService : IApiService
    {
        private const string AuthenticationScheme = "Bearer";
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly INetworkService _networkService;
        internal const int DefaultRetryCount = 2;
        protected readonly HttpClient HttpClient;

        public ApiService(INetworkService networkService)
        {
            HttpClient = new HttpClient
            {
                BaseAddress = new Uri(AppConstant.BaseUrl)
            };
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                IgnoreReadOnlyProperties = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            _networkService = networkService;
        }

        public async Task<T> GetAndRetry<T>(Uri uri, int retryCount, Func<Exception, int, Task> onRetry = null, string accessToken = null) where T : class
        {
            TryAddAuthorization(accessToken);
            var func = new Func<Task<T>>(() => ProcessGetRequest<T>(uri));
            return await _networkService.Retry<T>(func, retryCount, onRetry);
        }

        public async Task<T> GetAndRetry<T>(Uri uri, Func<int, TimeSpan> sleepDurationProvider, int retryCount, Func<Exception, TimeSpan, Task> onWaitAndRetry = null, string accessToken = null) where T : class
        {
            TryAddAuthorization(accessToken);
            var func = new Func<Task<T>>(() => ProcessGetRequest<T>(uri));
            return await _networkService.WaitAndRetry<T>(func, sleepDurationProvider, retryCount, onWaitAndRetry);
        }

        private async Task<T> ProcessGetRequest<T>(Uri requestUri) where T : class
        {
            var response = await HttpClient.GetAsync(requestUri);
            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(responseContent, _jsonSerializerOptions);
        }

        private void TryAddAuthorization(string accessToken)
        {
            if (!string.IsNullOrWhiteSpace(accessToken))
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: AuthenticationScheme, parameter: accessToken);
        }
    }
}
