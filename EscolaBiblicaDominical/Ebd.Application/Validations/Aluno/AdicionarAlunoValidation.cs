using Ebd.Application.Requests;
using FluentValidation;

namespace Ebd.Application.Validations.Aluno
{
    public class AdicionarAlunoValidation : AbstractValidator<AlunoRequest>
    {
        public AdicionarAlunoValidation()
        {
            RuleFor(c => c.Nome)
               .NotEmpty().WithMessage("Campo Nome é obrigatório")
               .MinimumLength(10).WithMessage("Máximo 50 caracteres")
               .MaximumLength(50).WithMessage("Máximo 50 caracteres");
        }
    }
}
