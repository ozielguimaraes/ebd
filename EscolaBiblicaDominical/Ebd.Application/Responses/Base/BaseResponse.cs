using FluentValidation.Results;

namespace Ebd.Application.Responses.Base
{
    public abstract class BaseResponse : BaseMessage
    {
        protected BaseResponse() { }
        protected BaseResponse(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }

        public ValidationResult? ValidationResult { get; set; }
        public bool IsValid() => ValidationResult is null || ValidationResult.IsValid;
    }
}
