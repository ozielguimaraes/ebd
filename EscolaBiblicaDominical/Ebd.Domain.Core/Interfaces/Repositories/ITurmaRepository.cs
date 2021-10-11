using Ebd.Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Domain.Core.Interfaces.Repositories
{
    public interface ITurmaRepository
    {
        Task<Turma> Adicionar(Turma turma);
        Task Atualizar(Turma turma);
        Task<Turma> ObterPorId(int id);
        Task<ICollection<Turma>> ObterTodas();
    }
}