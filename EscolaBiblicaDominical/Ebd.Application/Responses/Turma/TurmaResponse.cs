using Ebd.Application.Responses.Base;
using FluentValidation.Results;

namespace Ebd.Application.Responses.Turma
{
    public class TurmaResponse : BaseResponse
    {
        public TurmaResponse(ValidationResult validationResult) : base(validationResult) { }

        public TurmaResponse(int turmaId, string nome, int idadeMinima, int idadeMaxima)
        {
            TurmaId = turmaId;
            Nome = nome;
            IdadeMinima = idadeMinima;
            IdadeMaxima = idadeMaxima;
        }

        public int TurmaId { get; private set; }
        public string Nome { get; private set; }
        public int IdadeMinima { get; private set; }
        public int IdadeMaxima { get; private set; }
    }
}
