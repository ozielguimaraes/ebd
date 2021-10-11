using System;
using System.Collections.Generic;
using System.Text;

namespace Ebd.Presentation.Extension
{
    public static class ExceptionExtension
    {
        public static string FullException(this Exception exception)
        {
            Exception e = exception;
            StringBuilder s = new();
            while (e is not null)
            {
                s.AppendLine("Exception type: " + e.GetType()?.FullName);
                s.AppendLine("Message       : " + e.Message);
                s.AppendLine("Stacktrace:");
                s.AppendLine(e.StackTrace);
                s.AppendLine();
                e = e.InnerException;
            }
            return s.ToString();
        }
    }
}
