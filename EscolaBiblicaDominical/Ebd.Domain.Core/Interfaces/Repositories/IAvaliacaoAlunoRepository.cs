using Ebd.Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Domain.Core.Interfaces.Repositories
{
    public interface IAvaliacaoAlunoRepository
    {
        Task<AvaliacaoAluno> AdicionarAsync(AvaliacaoAluno avaliacaoAluno);
        Task AdicionarAsync(IEnumerable<AvaliacaoAluno> items);
    }
}