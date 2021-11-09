using System;

namespace Ebd.Mobile.Services.Responses
{
    public class BaseResponse<T>
    {
        public BaseResponse(T data)
        {
            IsSuccess = true;
            Data = data;
        }

        public BaseResponse(Exception exception)
        {
            IsSuccess = false;
            Exception = exception;
        }

        public bool IsSuccess { get; private set; }
        public bool HasError => !IsSuccess;
        public T Data { get; private set; }

        public Exception Exception { get; private set; }
    }
}
