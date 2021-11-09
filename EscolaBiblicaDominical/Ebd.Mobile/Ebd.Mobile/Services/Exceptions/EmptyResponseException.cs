using System;

namespace Ebd.Mobile.Services.Exceptions
{
    public class EmptyResponseException : Exception
    {
        public EmptyResponseException() : base("O serviço não retornou as informações adequadamente") { }
        public EmptyResponseException(string message) : base(message) { }
    }
}
