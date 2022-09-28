using FluentValidation.Results;

namespace Ebd.Application.Responses.Base
{
    public class ValidationResponse : BaseResponse
    {
        public ValidationResponse(ValidationResult validationResult) : base(validationResult) { }

    }
}
