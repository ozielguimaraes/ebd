using Ebd.Mobile.Constants;
using Ebd.Mobile.Extensions;
using Ebd.Mobile.Services.Exceptions;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Services.Responses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Implementations.Base
{
    public abstract class ApiService : IApiService
    {
        private const string AuthenticationScheme = "Bearer";
        private const string ApplicationJson = "application/json";
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        private readonly INetworkService _networkService;
        private readonly ILoggerService _loggerService;
        internal const int DefaultRetryCount = 1;
        protected readonly HttpClient HttpClient;

        public ApiService(INetworkService networkService, ILoggerService loggerService)
        {
            HttpClientHandler clientHandler = new()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };

            HttpClient = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(AppConstant.BaseUrl)
            };

            HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ApplicationJson));

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                IgnoreReadOnlyProperties = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            _networkService = networkService;
            _loggerService = loggerService;
        }

        public async Task<BaseResponse<T>> GetAndRetry<T>(string requestUri, int retryCount, Func<Exception, int, Task> onRetry = null, string accessToken = null) where T : class
        {
            if ((await _networkService.HasInternetConnection()).Not())
                return new BaseResponse<T>(new NoInternetConnectionException());

            TryAddAuthorization(accessToken);
            var func = new Func<Task<BaseResponse<T>>>(() => ProcessGetRequest<T>(requestUri));
            return await _networkService.Retry(func, retryCount, onRetry);
        }

        public async Task<EmptyResponse> PostAndRetry<TRequest>(string requestUri, TRequest request, Func<Exception, int, Task> onRetry = null, string accessToken = null)
            where TRequest : class
        {
            if ((await _networkService.HasInternetConnection()).Not())
                return new EmptyResponse(new NoInternetConnectionException());

            TryAddAuthorization(accessToken);
            var func = new Func<Task<EmptyResponse>>(() => ProcessPostRequest(requestUri, request));
            return await _networkService.Retry(func, DefaultRetryCount, onRetry);
        }

        public async Task<BaseResponse<TResponse>> PostAndRetry<TRequest, TResponse>(string requestUri, TRequest request, Func<Exception, int, Task> onRetry = null, string accessToken = null)
            where TRequest : class
            where TResponse : class
        {
            if ((await _networkService.HasInternetConnection()).Not())
                return new BaseResponse<TResponse>(new NoInternetConnectionException());

            TryAddAuthorization(accessToken);
            var func = new Func<Task<BaseResponse<TResponse>>>(() => ProcessPostRequest<TRequest, TResponse>(requestUri, request));
            return await _networkService.Retry(func, DefaultRetryCount, onRetry);
        }

        public async Task<BaseResponse<T>> GetAndRetry<T>(string requestUri, Func<int, TimeSpan> sleepDurationProvider, int retryCount, Func<Exception, TimeSpan, Task> onWaitAndRetry = null, string accessToken = null) where T : class
        {
            if ((await _networkService.HasInternetConnection()).Not())
                return new BaseResponse<T>(new NoInternetConnectionException());

            TryAddAuthorization(accessToken);
            var func = new Func<Task<BaseResponse<T>>>(() => ProcessGetRequest<T>(requestUri));
            return await _networkService.WaitAndRetry(func, sleepDurationProvider, retryCount, onWaitAndRetry);
        }

        protected virtual Task OnRetry(Exception exception, int retryCount)
        {
            return Task.Factory.StartNew(() =>
            {
                _loggerService.LogWarning($"Retry - Attempt #{retryCount}.");

                if (exception is not null)
                    _loggerService.LogError("Erro ao realizar o request", exception);
            });
        }

        private async Task<BaseResponse<T>> ProcessGetRequest<T>(string requestUri) where T : class
        {
            Random rnd = new();
            int randomId = rnd.Next(1000, 9999);

            _loggerService.LogInformation($"Request Uri-{randomId}: [HttpGet] {GetFullUri(requestUri)}");
            using HttpResponseMessage responseMessage = await HttpClient.GetAsync($"api/{requestUri}");
            string responseContent = null;

            try
            {
                responseContent = await responseMessage.Content.ReadAsStringAsync();
                LogUrlAndResponse(requestId: randomId, jsonResponse: responseContent, responseMessage.RequestMessage.Method, requestUri: responseMessage.RequestMessage.RequestUri, statusCode: responseMessage.StatusCode);

                if (responseMessage.IsSuccessStatusCode.Not())
                    ExceptionFromHttpStatusCode(responseMessage, responseContent);

                if (string.IsNullOrWhiteSpace(responseContent)) return default;

                return new BaseResponse<T>(JsonSerializer.Deserialize<T>(responseContent, _jsonSerializerOptions));
            }
            catch (Exception ex)
            {
                _loggerService.LogError("Erro ao processar request", ex,
                    new Dictionary<string, object> {
                        { "responseMessage", JsonSerializer.Serialize(responseMessage) }
                    });

                return new BaseResponse<T>(ex);
            }
        }

        private async Task<BaseResponse<TResponse>> ProcessPostRequest<TRequest, TResponse>(string requestUri, TRequest request)
            where TResponse : class
            where TRequest : class
        {
            Random rnd = new Random();
            int randomId = rnd.Next(1000, 9999);
            _loggerService.LogInformation($"Request Uri: [HttpPost] {GetFullUri(requestUri)}");
            var contentRequest = JsonSerializer.Serialize(request);
#if DEBUG
            Debug.WriteLine($"JSON request: {contentRequest}");
#endif
            using HttpResponseMessage responseMessage = await HttpClient.PostAsync(
                $"api/{requestUri}",
                new StringContent(contentRequest, Encoding.UTF8, ApplicationJson)
                );
            var responseContent = await responseMessage.Content.ReadAsStringAsync();
            LogUrlAndResponse(requestId: randomId, jsonResponse: responseContent, responseMessage.RequestMessage.Method, requestUri: responseMessage.RequestMessage.RequestUri, statusCode: responseMessage.StatusCode);

            try
            {
                if (responseMessage.IsSuccessStatusCode.Not())
                    ExceptionFromHttpStatusCode(responseMessage, responseContent);

                if (string.IsNullOrWhiteSpace(responseContent))
                    return new BaseResponse<TResponse>(new EmptyResponseException());

                return new BaseResponse<TResponse>(JsonSerializer.Deserialize<TResponse>(responseContent, _jsonSerializerOptions));
            }
            catch (Exception ex)
            {
                _loggerService.LogError("Erro ao processar request", ex,
                    new Dictionary<string, object> {
                        { "requestBody", contentRequest },
                        { "responseMessage", JsonSerializer.Serialize(responseMessage) }
                    });

                return new BaseResponse<TResponse>(ex);
            }
        }

        private async Task<EmptyResponse> ProcessPostRequest<TRequest>(string requestUri, TRequest request)
            where TRequest : class
        {
            Random rnd = new Random();
            int id = rnd.Next(1000, 9999);
            _loggerService.LogInformation($"Request Uri: [HttpPost] {GetFullUri(requestUri)}");

            var contentRequest = JsonSerializer.Serialize(request);
#if DEBUG
            Debug.WriteLine($"JSON request: {contentRequest}");
#endif
            using HttpResponseMessage responseMessage = await HttpClient.PostAsync(
                $"api/{requestUri}",
                new StringContent(contentRequest, Encoding.UTF8, ApplicationJson)
                );
            var responseContent = await responseMessage.Content.ReadAsStringAsync();
            LogUrlAndResponse(requestId: id, jsonResponse: responseContent, responseMessage.RequestMessage.Method, requestUri: responseMessage.RequestMessage.RequestUri, statusCode: responseMessage.StatusCode);

            try
            {
                if (!responseMessage.IsSuccessStatusCode)
                    ExceptionFromHttpStatusCode(responseMessage, responseContent);

                return new EmptyResponse();
            }
            catch (Exception ex)
            {
                _loggerService.LogError("Erro ao processar request", ex,
                    new Dictionary<string, object> {
                        { "requestBody", contentRequest },
                        { "responseMessage", JsonSerializer.Serialize(responseMessage) }
                    });

                return new EmptyResponse(ex);
            }
        }

        private void LogUrlAndResponse(int requestId, string jsonResponse, HttpMethod httpMethod, Uri requestUri, HttpStatusCode statusCode)
        {
#if DEBUG
            Debug.WriteLine($"Response Uri-{requestId}: [{httpMethod}] {requestUri} - {statusCode}");
            Debug.WriteLine($"JSON Response: {jsonResponse}");
#endif
        }

        private static void LogRequestUri(string requestUri)
        {
            Debug.WriteLine($"Request Uri: {AppConstant.BaseUrl}{requestUri}");
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
                HttpStatusCode.BadRequest => new InvalidOperationException(JsonSerializer.Deserialize<string>(responseContent)),
                HttpStatusCode.Unauthorized => new UnauthorizedAccessException(),
                _ => new InvalidOperationException("Erro desconhecido ao realizar essa operação"),
            };
        }

        private string GetFullUri(string uri) => $"{AppConstant.BaseUrl}/{uri}";
    }
}
