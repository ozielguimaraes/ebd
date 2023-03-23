using Ebd.Mobile.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace Ebd.Mobile.Services.Implementations.Diagnostic
{
    internal sealed class DiagnosticService : IDiagnosticService
    {
        public void TrackError(Exception exception)
        {
            //TODO Implement track events
        }

        public void TrackError(Exception exception, string message)
        {
            //TODO Implement track events
        }

        public void TrackError(Exception exception, IDictionary<string, string> properties)
        {
            //TODO Implement track events
        }

        public void TrackError(Exception exception, string message, IDictionary<string, string> properties)
        {
            //TODO Implement track events
        }
    }
}
