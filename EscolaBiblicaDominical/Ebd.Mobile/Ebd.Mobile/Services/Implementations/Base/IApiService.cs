using System;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Implementations.Base
{
    public interface IApiService
    {
        Task<T> GetAndRetry<T>(Uri uri, int retryCount, Func<Exception, int, Task> onRetry = null, string accessToken = null) where T : class;
        Task<T> GetAndRetry<T>(Uri uri, Func<int, TimeSpan> sleepDurationProvider, int retryCount, Func<Exception, TimeSpan, Task> onWaitAndRetry = null, string accessToken = null) where T : class;
    }
}
