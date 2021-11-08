using Ebd.Mobile.Constants;
using Ebd.Mobile.Services.Implementations.Logger;
using Ebd.Mobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                IgnoreReadOnlyProperties = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            _networkService = networkService;
        }

        public async Task<T> GetAndRetry<T>(string requestUri, int retryCount, Func<Exception, int, Task> onRetry = null, string accessToken = null) where T : class
        {
            TryAddAuthorization(accessToken);
            var func = new Func<Task<T>>(() => ProcessGetRequest<T>(requestUri));
            return await _networkService.Retry<T>(func, retryCount, onRetry);
        }

        public async Task<T> GetAndRetry<T>(string requestUri, Func<int, TimeSpan> sleepDurationProvider, int retryCount, Func<Exception, TimeSpan, Task> onWaitAndRetry = null, string accessToken = null) where T : class
        {
            TryAddAuthorization(accessToken);
            var func = new Func<Task<T>>(() => ProcessGetRequest<T>(requestUri));
            return await _networkService.WaitAndRetry<T>(func, sleepDurationProvider, retryCount, onWaitAndRetry);
        }

        private async Task<T> ProcessGetRequest<T>(string requestUri) where T : class
        {
            using HttpResponseMessage responseMessage = await HttpClient.GetAsync(requestUri);
            var responseContent = await responseMessage.Content.ReadAsStringAsync();

            try
            {
                if (!responseMessage.IsSuccessStatusCode)
                    ExceptionFromHttpStatusCode(responseMessage, responseContent);

                if (string.IsNullOrWhiteSpace(responseContent)) return default;

                return JsonSerializer.Deserialize<T>(responseContent, _jsonSerializerOptions);
            }
            catch (Exception ex)
            {
                LoggerService.Current.LogError("Erro ao processar request", ex,
                    new Dictionary<string, object> {
                        { "requestUri", requestUri },
                        { "responseMessage", responseMessage },
                        { "responseContent", responseContent },
                        { "isSuccessStatusCode", responseMessage.IsSuccessStatusCode }
                    });

                return default;
            }
        }

        private void TryAddAuthorization(string accessToken)
        {
            if (!string.IsNullOrWhiteSpace(accessToken))
                HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(scheme: AuthenticationScheme, parameter: accessToken);
        }

        private void ExceptionFromHttpStatusCode(HttpResponseMessage responseMessage, string responseContent)
        {
            throw responseMessage.StatusCode switch
            {
                HttpStatusCode.BadRequest => new InvalidOperationException(JsonSerializer.Deserialize<List<string>>(responseContent).FirstOrDefault()),
                HttpStatusCode.Unauthorized => new UnauthorizedAccessException(),
                _ => new InvalidOperationException("Erro desconhecido ao realizar essa operação"),
            };
        }
    }
}
