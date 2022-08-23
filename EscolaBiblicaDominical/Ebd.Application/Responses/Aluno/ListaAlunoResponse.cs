using Ebd.Application.Responses.Base;
using FluentValidation.Results;

namespace Ebd.Application.Responses.Aluno
{
    public class ListaAlunoResponse : BaseResponse
    {
        public ListaAlunoResponse(ValidationResult validationResult) : base(validationResult) { }
        public ListaAlunoResponse(int alunoId, string nome) : base(new ValidationResult())
        {
            AlunoId = alunoId;
            Nome = nome;
        }

        public int AlunoId { get; private set; }
        public string Nome { get; private set; }
    }
}
