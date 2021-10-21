using Ebd.Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Domain.Core.Interfaces.Repositories
{
    public interface IAvaliacaoRepository
    {
        Task<Avaliacao> AdicionarAsync(Avaliacao avaliacao);
        Task<ICollection<Avaliacao>> ObterTodasAsync();
    }
}