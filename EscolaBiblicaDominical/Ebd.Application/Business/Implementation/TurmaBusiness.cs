using Ebd.Application.Business.Interfaces;
using Ebd.Application.Mappers;
using Ebd.Application.Responses.Turma;
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

        public async Task<IEnumerable<TurmaResponse>> ObterTodas()
        {
            var result = await _turmaRepository.ObterTodas();

            return TurmaMapper.FromEntityToResponse(result);
        }
    }
}
