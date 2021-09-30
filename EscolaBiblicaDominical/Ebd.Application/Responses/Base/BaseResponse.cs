using FluentValidation.Results;

namespace Ebd.Application.Responses.Base
{
    public abstract class BaseResponse : BaseMessage
    {
        public BaseResponse(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }

        public ValidationResult ValidationResult { get; set; }
    }
}
