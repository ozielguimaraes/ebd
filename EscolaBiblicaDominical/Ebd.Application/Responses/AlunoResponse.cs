using Ebd.Application.Responses.Base;
using FluentValidation.Results;

namespace Ebd.Application.Responses
{
    public class AlunoResponse : BaseResponse
    {
        public AlunoResponse(ValidationResult validationResult) : base(validationResult) { }

        public AlunoResponse(int alunoId) : base(new ValidationResult())
        {
            AlunoId = alunoId;
        }

        public int AlunoId { get; private set; }
    }
}
