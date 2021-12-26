using Ebd.Application.Responses.Base;
using FluentValidation.Results;

namespace Ebd.Application.Responses
{
    public class AlunoResponse : BaseResponse
    {
        public AlunoResponse(ValidationResult validationResult) : base(validationResult) { }
        public AlunoResponse(int alunoId, string nome) : base(new ValidationResult())
        {
            AlunoId = alunoId;
            Nome = nome;
        }

        public int AlunoId { get; private set; }
        public string Nome { get; private set; }
    }
}
