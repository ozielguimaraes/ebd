using System;
using System.Text;

namespace Ebd.Mobile.Extensions
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
    }
}
