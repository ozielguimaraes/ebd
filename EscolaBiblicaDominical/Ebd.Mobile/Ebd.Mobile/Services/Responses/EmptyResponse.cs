using System;

namespace Ebd.Mobile.Services.Responses
{
    public class EmptyResponse : BaseResponse<string>
    {
        public EmptyResponse(string data = "") : base(data) { }

        public EmptyResponse(Exception exception) : base(exception) { }
    }
}