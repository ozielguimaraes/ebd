using Ebd.Application.Requests.Revista;
using FluentValidation;
using System;

namespace Ebd.Application.Validations.Revista
{
    public class AdicionarRevistaValidation : AbstractValidator<AdicionarRevistaRequest>
    {
        public AdicionarRevistaValidation()
        {
            RuleFor(c => c.Ano)
               .NotEmpty().WithMessage("Campo {0} é obrigatório")
               .GreaterThanOrEqualTo(DateTime.UtcNow.Year).WithMessage("{0} deve ser maior ou igual a {1}");
            RuleFor(c => c.Trimestre)
               .NotEmpty().WithMessage("Campo {0} é obrigatório")
               .ExclusiveBetween(1, 4).WithMessage("{0} informado não é valido");
            RuleFor(c => c.Sumario)
               .NotEmpty().WithMessage("Campo Sumário é obrigatório")
               .MinimumLength(10).WithMessage("Mínimo {1} caracteres");
        }
    }
}
