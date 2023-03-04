using Ebd.Application.Business.Interfaces;
using Ebd.Application.Mappers;
using Ebd.Application.Requests.Turma;
using Ebd.Application.Responses.Base;
using Ebd.Application.Responses.Turma;
using Ebd.Domain.Core.Entities;
using Ebd.Domain.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Application.Business.Implementation
{
    public class TurmaBusiness : ITurmaBusiness
    {
        private readonly ITurmaRepository _turmaRepository;

        public TurmaBusiness(ITurmaRepository turmaRepository)
        {
            _turmaRepository = turmaRepository;
        }

        public async Task<BaseResponse> AdicionarAsync(AdicionarTurmaRequest request)
        {
            //var validator = new AdicionarLicaoValidation();
            //var validationResult = validator.Validate(request);
            //if (!validationResult.IsValid) return new ValidationResponse(validationResult);

            var result = await _turmaRepository.Adicionar(new Turma(request.Nome, idadeMinima: request.IdadeMinima, request.IdadeMaxima));
            return TurmaMapper.FromEntityToResponse(result);
        }

        public async Task<IEnumerable<TurmaResponse>> ObterTodas()
        {
            var result = await _turmaRepository.ObterTodas();

            return TurmaMapper.FromEntityToResponse(result);
        }
    }
}
