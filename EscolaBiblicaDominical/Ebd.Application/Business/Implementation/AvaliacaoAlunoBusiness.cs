using Ebd.Application.Business.Interfaces;
using Ebd.Domain.Core.Entities;
using Ebd.Domain.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebd.Application.Business.Implementation
{
    public class AvaliacaoAlunoBusiness : IAvaliacaoAlunoBusiness
    {
        private readonly IAvaliacaoAlunoRepository _avaliacaoAlunoRepository;

        public AvaliacaoAlunoBusiness(IAvaliacaoAlunoRepository avaliacaoAlunoRepository)
        {
            _avaliacaoAlunoRepository = avaliacaoAlunoRepository;
        }

        public async Task AdicionarAsync(int alunoId, IEnumerable<int> idsAvaliacao)
        {
            var avaliacoes = idsAvaliacao.Select(id => new AvaliacaoAluno(avaliacaoId: id, alunoId: alunoId));

            await _avaliacaoAlunoRepository.AdicionarAsync(avaliacoes);
        }
    }
}
