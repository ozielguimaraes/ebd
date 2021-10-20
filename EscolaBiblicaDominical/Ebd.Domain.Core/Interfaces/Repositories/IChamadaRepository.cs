using Ebd.Domain.Core.Entities;
using System.Threading.Tasks;

namespace Ebd.Domain.Core.Interfaces.Repositories
{
    public interface IChamadaRepository
    {
        Task<Chamada> AdicionarAsync(Chamada chamada);
    }
}