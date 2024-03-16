using System;
using System.Diagnostics;
using System.Text;

namespace Ebd.CrossCutting.Common.Extensions
{
    public static class ExceptionExtension
    {
        public static string GetFullException(this Exception exception)
        {
            Exception innerException = exception;
            StringBuilder s = new();
            while (innerException != null)
            {
                s.AppendLine("Exception type: " + innerException.GetType()?.FullName);
                s.AppendLine("Message       : " + innerException.Message);
                s.AppendLine("Stacktrace    :");
                s.AppendLine(innerException.StackTrace);
                s.AppendLine();
                innerException = innerException.InnerException;
            }
            return s.ToString();
        }
        public static void Log(this Exception exception)
        {
            Log($"Error: {exception.Message}");
        }

        public static void Log(this Exception exception, string method)
        {
            Log($"Method: {method}");
            Log(exception);
        }

        public static void LogFullException(this Exception exception)
        {
            Log(exception.GetFullException());
        }

        public static void LogFullException(this Exception exception, string method)
        {
            Log($"Method: {method}");
            Log(exception.GetFullException());
        }

        private static void Log(string message)
        {
#if DEBUG
            Debug.WriteLine(message);
#endif
        }
    }
}
