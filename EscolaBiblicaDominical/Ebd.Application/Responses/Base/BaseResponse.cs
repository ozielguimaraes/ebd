using FluentValidation.Results;
using System.Collections.Generic;

namespace Ebd.Application.Responses.Base
{
    public abstract class BaseResponse : BaseMessage
    {
        protected BaseResponse() { }
        protected BaseResponse(ValidationResult validationResult)
        {
            SetValidationResult(validationResult);
        }

        private ValidationResult validationResult;

        public ValidationResult GetValidationResult()
        {
            return validationResult;
        }

        public IEnumerable<ValidationFailure> GetValidationFailures()
        {
            return validationResult.Errors;
        }

        public void SetValidationResult(ValidationResult value)
        {
            validationResult = value;
        }

        public bool IsValid() => GetValidationResult()?.IsValid ?? true;
    }
}
