using Ebd.Mobile.Services.Implementations.Logger;
using Ebd.Mobile.Services.Interfaces;
using Polly;
using System;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Implementations
{
    public class NetworkService : INetworkService
    {
        public async Task<T> Retry<T>(Func<Task<T>> func)
        {
            return await RetryInner(func);
        }

        public async Task<T> Retry<T>(Func<Task<T>> func, int retryCount)
        {
            return await RetryInner(func, retryCount);
        }

        public async Task<T> Retry<T>(Func<Task<T>> func, int retryCount, Func<Exception, int, Task> onRetry)
        {
            return await RetryInner(func, retryCount, onRetry);
        }

        public async Task<T> WaitAndRetry<T>(Func<Task<T>> func, Func<int, TimeSpan> sleepDurationProvider)
        {
            return await WaitAndRetryInner<T>(func, sleepDurationProvider);
        }

        public async Task<T> WaitAndRetry<T>(Func<Task<T>> func, Func<int, TimeSpan> sleepDurationProvider, int retryCount)
        {
            return await WaitAndRetryInner<T>(func, sleepDurationProvider, retryCount);
        }

        public async Task<T> WaitAndRetry<T>(Func<Task<T>> func, Func<int, TimeSpan> sleepDurationProvider, int retryCount, Func<Exception, TimeSpan, Task> onRetryAsync)
        {
            return await WaitAndRetryInner<T>(func, sleepDurationProvider, retryCount, onRetryAsync);
        }

        #region Inner Methods

        private async Task<T> RetryInner<T>(Func<Task<T>> func, int retryCount = 1, Func<Exception, int, Task> onRetry = null)
        {
            var onRetryInner = new Func<Exception, int, Task>((e, i) =>
            {
                return Task.Factory.StartNew(() =>
                {
                    LoggerService.Current.LogWarning($"Retry #{i} due to exception '{(e.InnerException ?? e).Message}'");
                });
            });

            return await Policy.Handle<Exception>().RetryAsync(retryCount, onRetry ?? onRetryInner).ExecuteAsync<T>(func);
        }

        private async Task<T> WaitAndRetryInner<T>(Func<Task<T>> func, Func<int, TimeSpan> sleepDurationProvider, int retryCount = 1, Func<Exception, TimeSpan, Task> onRetryAsync = null)
        {
            var onRetryInner = new Func<Exception, TimeSpan, Task>((e, t) =>
            {
                return Task.Factory.StartNew(() =>
                {
                    LoggerService.Current.LogWarning($"Retrying in {t:g} due to exception '{(e.InnerException ?? e).Message}'");
                });
            });

            return await Policy.Handle<Exception>().WaitAndRetryAsync(retryCount, sleepDurationProvider, onRetryAsync ?? onRetryInner).ExecuteAsync<T>(func);
        }
        #endregion
    }
}
