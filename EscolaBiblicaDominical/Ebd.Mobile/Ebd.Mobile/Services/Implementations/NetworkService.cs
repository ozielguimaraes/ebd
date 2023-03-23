using Ebd.Mobile.Services.Interfaces;
using Polly;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Ebd.Mobile.Services.Implementations
{
    public class NetworkService : INetworkService
    {
        private readonly ILoggerService _loggerService;

        public NetworkService(ILoggerService loggerService)
        {
            _loggerService = loggerService;
        }

        public async Task<bool> HasInternetConnection()
        => await Task.FromResult(Connectivity.NetworkAccess == NetworkAccess.Internet);

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
                    _loggerService.LogWarning($"Retry #{i} due to exception '{(e.InnerException ?? e).Message}'");
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
                    _loggerService.LogWarning($"Retrying in {t:g} due to exception '{(e.InnerException ?? e).Message}'");
                });
            });

            return await Policy.Handle<Exception>().WaitAndRetryAsync(retryCount, sleepDurationProvider, onRetryAsync ?? onRetryInner).ExecuteAsync<T>(func);
        }
        #endregion
    }
}
