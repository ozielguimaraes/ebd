using Ebd.Mobile.Services.Responses;
using System;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Implementations.Base
{
    public interface IApiService
    {
        Task<BaseResponse<T>> GetAndRetry<T>(string requestUri, int retryCount, Func<Exception, int, Task> onRetry = null, string accessToken = null) where T : class;
        Task<BaseResponse<T>> GetAndRetry<T>(string requestUri, Func<int, TimeSpan> sleepDurationProvider, int retryCount, Func<Exception, TimeSpan, Task> onWaitAndRetry = null, string accessToken = null) where T : class;
    }
}
