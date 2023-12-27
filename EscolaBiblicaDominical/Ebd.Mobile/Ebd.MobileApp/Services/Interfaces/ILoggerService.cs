using System;
using System.Collections.Generic;

namespace Ebd.Mobile.Services.Interfaces
{
    public interface ILoggerService
    {
        void LogInformation(string message);
        void LogInformation(string message, Dictionary<string, object> parameters);
        void LogError(string message);
        void LogError(string message, Dictionary<string, object> parameters);
        void LogError(string message, Exception exception, Dictionary<string, object> parameters);
        void LogError(string message, Exception exception);
        void LogWarning(string message);
        void LogWarning(string message, Dictionary<string, object> parameters);
    }
}
