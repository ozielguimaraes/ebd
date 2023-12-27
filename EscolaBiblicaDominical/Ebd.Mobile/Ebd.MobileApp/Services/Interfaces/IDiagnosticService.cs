using System;
using System.Collections.Generic;

namespace Ebd.Mobile.Services.Interfaces
{
    public interface IDiagnosticService
    {
        void TrackError(Exception exception);
        void TrackError(Exception exception, string message);
        void TrackError(Exception exception, IDictionary<string, string> properties);
        void TrackError(Exception exception, string message, IDictionary<string, string> properties);
    }
}
