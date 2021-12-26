using Ebd.Application.Requests.Licao;
using FluentValidation;

namespace Ebd.Application.Validations.Licao
{
    public class AdicionarLicaoValidation : AbstractValidator<AdicionarLicaoRequest>
    {
        public AdicionarLicaoValidation()
        {
            RuleFor(c => c.RevistaId)
               .NotEmpty().WithMessage("Campo Revista é obrigatório");
            RuleFor(c => c.Titulo)
               .NotEmpty().WithMessage("Campo Título é obrigatório")
               .MinimumLength(5).WithMessage("Mínimo {1} caracteres");
        }
    }
}
