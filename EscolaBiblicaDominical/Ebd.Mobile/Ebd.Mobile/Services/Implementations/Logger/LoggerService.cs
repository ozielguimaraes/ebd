using Ebd.Mobile.Extensions;
using Ebd.Mobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace Ebd.Mobile.Services.Implementations.Logger
{
    internal sealed class LoggerService : ILoggerService
    {
        public static readonly ILoggerService Current = DependencyService.Get<ILoggerService>();

        public void LogError(string message)
        {
            WriteLog(LogType.Error, message);
        }

        public void LogError(string message, Dictionary<string, object> parameters)
        {
            WriteLog(LogType.Error, message, parameters);
        }

        public void LogError(string message, Exception exception)
        {
            WriteLog(LogType.Error, message, exception);
        }

        public void LogError(string message, Exception exception, Dictionary<string, object> parameters)
        {
            WriteLog(LogType.Error, message, exception, parameters);
        }

        public void LogInformation(string message)
        {
            WriteLog(LogType.Information, message);
        }

        public void LogInformation(string message, Dictionary<string, object> parameters)
        {
            WriteLog(LogType.Information, message, parameters);
        }

        public void LogWarning(string message)
        {
            WriteLog(LogType.Warning, message);
        }

        public void LogWarning(string message, Dictionary<string, object> parameters)
        {
            WriteLog(LogType.Warning, message, parameters);
        }

        private void WriteLog(LogType logType, string value)
        {
            StartWriteLog(logType);
            Debug.WriteLine(value);
            FinishWriteLog();
        }

        private void WriteLog(LogType logType, string message, Exception exception)
        {
            StartWriteLog(logType);
            Debug.WriteLine(message);
            WriteException(exception);
            FinishWriteLog();
        }

        private void WriteLog(LogType logType, string message, Exception exception, Dictionary<string, object> parameters)
        {
            StartWriteLog(logType);
            Debug.WriteLine(message);
            WriteException(exception);
            WriteParameters(parameters);
            FinishWriteLog();
        }

        private void WriteLog(LogType logType, string value, Dictionary<string, object> parameters)
        {
            StartWriteLog(logType);
            Debug.WriteLine(value);
            WriteParameters(parameters);
            FinishWriteLog();
        }

        private void WriteParameters(Dictionary<string, object> parameters)
        {
            foreach (var item in parameters.Keys)
            {
                Debug.WriteLine($"{item}: {parameters[item]}");
            }
        }

        private void WriteException(Exception exception)
        {
            Debug.WriteLine(exception.GetFullException());
        }

        private static void StartWriteLog(LogType logType)
        {
            Debug.WriteLine(string.Empty);
            Debug.WriteLine($"------------  {DateTime.Now:O}  ------------");
            Debug.WriteLine($"------------  {logType}  ------------");
        }

        private static void FinishWriteLog()
        {
            Debug.WriteLine("------------------------------------------------------");
        }
    }
}
