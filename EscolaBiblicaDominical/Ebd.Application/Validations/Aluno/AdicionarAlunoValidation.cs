using Ebd.Application.Requests.Aluno;
using Ebd.CrossCutting.Common.Extensions;
using FluentValidation;
using System;
using System.Linq;

namespace Ebd.Application.Validations.Aluno
{
    public class AdicionarAlunoValidation : AbstractValidator<AdicionarAlunoRequest>
    {
        public AdicionarAlunoValidation()
        {
            RuleFor(c => c.Nome)
               .NotEmpty().WithMessage("Campo Nome é obrigatório")
               .MinimumLength(10).WithMessage("Mínimo 10 caracteres")
               .MaximumLength(50).WithMessage("Máximo 50 caracteres");

            RuleFor(c => c.NascidoEm)
                .Must(x => x > DateOnly.FromDateTime(DateTime.UtcNow).AddYears(-120)).WithMessage($"Data de nascimento não deve ser menor que {DateTime.Now.AddYears(-110):dd/MM/yyyy}")
                .NotEmpty().WithMessage("Campo Nome é obrigatório")
                .Must(x => x < DateOnly.FromDateTime(DateTime.Today.AddDays(-1))).WithMessage("Campo Nascimento não pode ser maior que atual");

            RuleFor(c => c.Contatos)
                .NotEmpty().WithMessage("Campo Contatos é obrigatório");

            RuleFor(c => c.Enderecos)
                .NotEmpty().WithMessage("Campo Endereços é obrigatório");

            RuleFor(c => c.TurmaId)
                .GreaterThan(0).WithMessage("Campo Turma é obrigatório");

            RuleFor(c => c.Responsaveis)
                .Must(x => x.Any()).When(x => x.NascidoEm.EhMaiorOuIgual18Anos()).WithMessage("Responsável deve ser maior de idade");
        }
    }
}
