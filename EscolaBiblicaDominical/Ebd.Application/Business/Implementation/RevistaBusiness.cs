using Ebd.Application.Business.Interfaces;
using Ebd.Application.Mappers;
using Ebd.Application.Requests.Revista;
using Ebd.Application.Responses.Base;
using Ebd.Application.Responses.Revista;
using Ebd.Application.Validations.Revista;
using Ebd.Domain.Core.Interfaces.Repositories;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Application.Business.Implementation
{
    public class RevistaBusiness : IRevistaBusiness
    {
        private readonly IRevistaRepository _revistaRepository;

        public RevistaBusiness(IRevistaRepository revistaRepository)
        {
            _revistaRepository = revistaRepository;
        }

        public async Task<BaseResponse> AdicionarAsync(AdicionarRevistaRequest request)
        {
            var validator = new AdicionarRevistaValidation();
            var validationResult = validator.Validate(request);
            if (!validationResult.IsValid) return new ValidationResponse(validationResult);

            if (await ExistePorPeriodo(request.TurmaId, request.Ano, request.Trimestre))
                return new ValidationResponse(new ValidationResult(new List<ValidationFailure>
                {
                    new ValidationFailure("RevistaId", "Já existe uma revista adicionada nesse trimestre.")
                }));

            var result = await _revistaRepository.Adicionar(RevistaMapper.FromRequestToEntity(request));
            return RevistaMapper.FromEntityToResponse(result);
        }

        public async Task<RevistaResponse> ObterPorId(int revistaId)
        {
            var result = await _revistaRepository.ObterPorId(revistaId);
            return RevistaMapper.FromEntityToResponse(result);
        }

        public async Task<bool> ExistePorPeriodo(int turmaId, int ano, int trimestre) =>
            await _revistaRepository.ExistePorPeriodo(turmaId, ano, trimestre);

        public async Task<RevistaResponse> ObterPorPeriodo(int turmaId, int ano, int trimestre)
        {
            var result = await _revistaRepository.ObterPorPeriodo(turmaId, ano, trimestre);
            return RevistaMapper.FromEntityToResponse(result);
        }
    }
}
