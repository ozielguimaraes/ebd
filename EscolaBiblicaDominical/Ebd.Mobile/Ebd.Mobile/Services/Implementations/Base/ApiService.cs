using Ebd.Mobile.Constants;
using Ebd.Mobile.Services.Exceptions;
using Ebd.Mobile.Services.Implementations.Logger;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Services.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
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
        internal const int DefaultRetryCount = 1;
        protected readonly HttpClient HttpClient;

        public ApiService(INetworkService networkService)
        {
            HttpClient = new HttpClient
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
        }

        public async Task<BaseResponse<T>> GetAndRetry<T>(string requestUri, int retryCount, Func<Exception, int, Task> onRetry = null, string accessToken = null) where T : class
        {
            if (!await _networkService.HasInternetConnection())
                return new BaseResponse<T>(new NoInternetConnectionException());

            TryAddAuthorization(accessToken);
            var func = new Func<Task<BaseResponse<T>>>(() => ProcessGetRequest<T>(requestUri));
            return await _networkService.Retry(func, retryCount, onRetry);
        }

        public async Task<EmptyResponse> PostAndRetry<TRequest>(string requestUri, TRequest request, Func<Exception, int, Task> onRetry = null, string accessToken = null)
            where TRequest : class
        {
            if (!await _networkService.HasInternetConnection())
                return new EmptyResponse(new NoInternetConnectionException());

            TryAddAuthorization(accessToken);
            var func = new Func<Task<EmptyResponse>>(() => ProcessPostRequest(requestUri, request));
            return await _networkService.Retry(func, DefaultRetryCount, onRetry);
        }

        public async Task<BaseResponse<TResponse>> PostAndRetry<TRequest, TResponse>(string requestUri, TRequest request, Func<Exception, int, Task> onRetry = null, string accessToken = null)
            where TRequest : class
            where TResponse : class
        {
            if (!await _networkService.HasInternetConnection())
                return new BaseResponse<TResponse>(new NoInternetConnectionException());

            TryAddAuthorization(accessToken);
            var func = new Func<Task<BaseResponse<TResponse>>>(() => ProcessPostRequest<TRequest, TResponse>(requestUri, request));
            return await _networkService.Retry(func, DefaultRetryCount, onRetry);
        }

        public async Task<BaseResponse<T>> GetAndRetry<T>(string requestUri, Func<int, TimeSpan> sleepDurationProvider, int retryCount, Func<Exception, TimeSpan, Task> onWaitAndRetry = null, string accessToken = null) where T : class
        {
            if (!await _networkService.HasInternetConnection())
                return new BaseResponse<T>(new NoInternetConnectionException());

            TryAddAuthorization(accessToken);
            var func = new Func<Task<BaseResponse<T>>>(() => ProcessGetRequest<T>(requestUri));
            return await _networkService.WaitAndRetry(func, sleepDurationProvider, retryCount, onWaitAndRetry);
        }

        protected virtual Task OnRetry(Exception e, int retryCount)
        {
            return Task.Factory.StartNew(() =>
            {
                LoggerService.Current.LogWarning($"Retry - Attempt #{retryCount} to get classes.");
            });
        }

        private async Task<BaseResponse<T>> ProcessGetRequest<T>(string requestUri) where T : class
        {
            using HttpResponseMessage responseMessage = await HttpClient.GetAsync(requestUri);
            var responseContent = await responseMessage.Content.ReadAsStringAsync();

            try
            {
                if (!responseMessage.IsSuccessStatusCode)
                    ExceptionFromHttpStatusCode(responseMessage, responseContent);

                if (string.IsNullOrWhiteSpace(responseContent)) return default;

                return new BaseResponse<T>(JsonSerializer.Deserialize<T>(responseContent, _jsonSerializerOptions));
            }
            catch (Exception ex)
            {
                LoggerService.Current.LogError("Erro ao processar request", ex,
                    new Dictionary<string, object> {
                        { "requestUri", requestUri },
                        { "responseMessage", responseMessage },
                        { "responseContent",JsonSerializer.Serialize(responseContent) },
                        { "isSuccessStatusCode", responseMessage.IsSuccessStatusCode }
                    });

                return new BaseResponse<T>(ex);
            }
        }

        private async Task<BaseResponse<TResponse>> ProcessPostRequest<TRequest, TResponse>(string requestUri, TRequest request)
            where TResponse : class
            where TRequest : class
        {
            var contentRequest = JsonSerializer.Serialize(request);
            using HttpResponseMessage responseMessage = await HttpClient.PostAsync(
                requestUri,
                new StringContent(contentRequest, Encoding.UTF8, ApplicationJson)
                );
            var responseContent = await responseMessage.Content.ReadAsStringAsync();

            try
            {
                if (!responseMessage.IsSuccessStatusCode)
                    ExceptionFromHttpStatusCode(responseMessage, responseContent);

                if (string.IsNullOrWhiteSpace(responseContent))
                    return new BaseResponse<TResponse>(new EmptyResponseException());

                return new BaseResponse<TResponse>(JsonSerializer.Deserialize<TResponse>(responseContent, _jsonSerializerOptions));
            }
            catch (Exception ex)
            {
                LoggerService.Current.LogError("Erro ao processar request", ex,
                    new Dictionary<string, object> {
                        { "requestUri", requestUri },
                        { "requestBody", JsonSerializer.Serialize(request) },
                        { "responseMessage", JsonSerializer.Serialize(responseMessage) },
                        { "responseContent", responseContent },
                        { "isSuccessStatusCode", responseMessage.IsSuccessStatusCode }
                    });

                return new BaseResponse<TResponse>(ex);
            }
        }

        private async Task<EmptyResponse> ProcessPostRequest<TRequest>(string requestUri, TRequest request)
            where TRequest : class
        {
            using HttpResponseMessage responseMessage = await HttpClient.PostAsync(
                requestUri,
                new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, ApplicationJson)
                );
            var responseContent = await responseMessage.Content.ReadAsStringAsync();

            try
            {
                if (!responseMessage.IsSuccessStatusCode)
                    ExceptionFromHttpStatusCode(responseMessage, responseContent);

                return new EmptyResponse();
            }
            catch (Exception ex)
            {
                LoggerService.Current.LogError("Erro ao processar request", ex,
                    new Dictionary<string, object> {
                        { "requestUri", requestUri },
                        { "requestBody", JsonSerializer.Serialize(request) },
                        { "responseMessage", JsonSerializer.Serialize(responseMessage) },
                        { "responseContent", responseContent },
                        { "isSuccessStatusCode", responseMessage.IsSuccessStatusCode }
                    });

                return new EmptyResponse(ex);
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
