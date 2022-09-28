using System.Collections.Generic;

namespace Ebd.Mobile.Services.Responses
{
    public class BaseListResponse<T> : BaseResponse<IList<T>>
    {
        public BaseListResponse(IList<T> data) : base(data) { }
    }
}
