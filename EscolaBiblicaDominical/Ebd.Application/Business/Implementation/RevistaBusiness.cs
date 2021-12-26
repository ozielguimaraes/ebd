using Ebd.Application.Business.Interfaces;
using Ebd.Application.Mappers;
using Ebd.Application.Requests.Revista;
using Ebd.Application.Responses.Base;
using Ebd.Application.Responses.Revista;
using Ebd.Application.Validations.Revista;
using Ebd.Domain.Core.Entities;
using Ebd.Domain.Core.Interfaces.Repositories;
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

            var result = await _revistaRepository.Adicionar(new Revista(
                revistaId: request.RevistaId,
                sumario: request.Sumario,
                ano: request.Ano,
                trimestre: request.Trimestre
                ));
            return RevistaMapper.FromEntityToResponse(result);
        }

        public async Task<RevistaResponse> ObterPorId(int revistaId)
        {
            var result = await _revistaRepository.ObterPorId(revistaId);
            return RevistaMapper.FromEntityToResponse(result);
        }

        public async Task<IEnumerable<RevistaResponse>> ObterPorPeriodo(int ano, int trimestre)
        {
            var result = await _revistaRepository.ObterPorPeriodo(ano, trimestre);
            return RevistaMapper.FromEntityToResponse(result);
        }
    }
}
