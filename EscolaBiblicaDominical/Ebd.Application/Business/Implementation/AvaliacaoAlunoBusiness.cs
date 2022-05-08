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

        public async Task AdicionarAsync(int alunoId, int licaoId, bool estavaPresente, IEnumerable<int> idsAvaliacao)
        {
            var avaliacoes = new List<AvaliacaoAluno>();

            if (estavaPresente)
                foreach (var id in idsAvaliacao)
                {
                    avaliacoes.Add(new AvaliacaoAluno(avaliacaoId: id, alunoId: alunoId, licaoId: licaoId));
                }
            else
                avaliacoes.Add(new AvaliacaoAluno(avaliacaoId: ObterIdDaAvaliacaoPresenca(), alunoId: alunoId, licaoId: licaoId));

            await _avaliacaoAlunoRepository.AdicionarAsync(avaliacoes);
        }

        private int ObterIdDaAvaliacaoPresenca()
            => 1;
    }
}
