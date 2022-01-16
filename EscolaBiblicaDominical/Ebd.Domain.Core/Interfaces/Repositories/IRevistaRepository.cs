using Ebd.Domain.Core.Entities;
using System.Threading.Tasks;

namespace Ebd.Domain.Core.Interfaces.Repositories
{
    public interface IRevistaRepository
    {
        Task<Revista> Adicionar(Revista revista);
        Task Atualizar(Revista revista);
        Task<Revista> ObterPorId(int id);
        Task<Revista> ObterPorPeriodo(int turmaId, int ano, int trimestre);
    }
}