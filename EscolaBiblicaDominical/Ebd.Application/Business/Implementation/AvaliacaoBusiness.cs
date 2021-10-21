using Ebd.Application.Business.Interfaces;
using Ebd.Application.Responses.Avaliacao;
using Ebd.Domain.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebd.Application.Business.Implementation
{
    public class AvaliacaoBusiness : IAvaliacaoBusiness
    {
        private readonly IAvaliacaoRepository _avaliacaoRepository;

        public AvaliacaoBusiness(IAvaliacaoRepository avaliacaoRepository)
        {
            _avaliacaoRepository = avaliacaoRepository;
        }

        public async Task<IEnumerable<ObterTodasResponse>> ObterTodasAsync()
        {
            var result = await _avaliacaoRepository.ObterTodasAsync();

            return result.Select(x => new ObterTodasResponse(avaliacaoId: x.AvaliacaoId, nome: x.Nome, nota: x.Nota));
        }
    }
}
