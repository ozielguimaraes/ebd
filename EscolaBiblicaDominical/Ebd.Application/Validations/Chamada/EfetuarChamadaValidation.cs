using Ebd.Application.Requests.Chamada;
using FluentValidation;

namespace Ebd.Application.Validations.Chamada
{
    public class EfetuarChamadaValidation : AbstractValidator<EfetuarChamadaRequest>
    {
        public EfetuarChamadaValidation()
        {
            RuleFor(c => c.LicaoId) //TODO Validar se existe na base, se está ativo...
               .NotEmpty().WithMessage("Campo Lição é obrigatório");
            RuleFor(c => c.AlunoId) //TODO Validar se existe na base, se está ativo...
               .NotEmpty().WithMessage("Campo Aluno é obrigatório");
        }
    }
}
