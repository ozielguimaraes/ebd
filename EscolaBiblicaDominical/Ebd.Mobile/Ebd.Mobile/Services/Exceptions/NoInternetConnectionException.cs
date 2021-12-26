using System;

namespace Ebd.Mobile.Services.Exceptions
{
    public class NoInternetConnectionException : Exception
    {
        public NoInternetConnectionException() : base("Por favor, conecte-se a internet.") { }
    }
}
