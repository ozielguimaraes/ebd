﻿using System;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Interfaces
{
    public interface INetworkService
    {
        Task<bool> HasInternetConnection();
        Task<T> Retry<T>(Func<Task<T>> func);
        Task<T> Retry<T>(Func<Task<T>> func, int retryCount);
        Task<T> Retry<T>(Func<Task<T>> func, int retryCount, Func<Exception, int, Task> onRetry);
        Task<T> WaitAndRetry<T>(Func<Task<T>> func, Func<int, TimeSpan> sleepDurationProvider);
        Task<T> WaitAndRetry<T>(Func<Task<T>> func, Func<int, TimeSpan> sleepDurationProvider, int retryCount);
        Task<T> WaitAndRetry<T>(Func<Task<T>> func, Func<int, TimeSpan> sleepDurationProvider, int retryCount, Func<Exception, TimeSpan, Task> onRetryAsync);
    }
}
