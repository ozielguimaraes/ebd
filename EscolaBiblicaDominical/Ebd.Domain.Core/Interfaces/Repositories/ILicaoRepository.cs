using Ebd.Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Domain.Core.Interfaces.Repositories
{
    public interface ILicaoRepository
    {
        Task<Licao> Adicionar(Licao licao);
        Task Atualizar(Licao licao);
        Task<Licao> ObterPorId(int id);
        Task<ICollection<Licao>> Pesquisar(string pesquisa);
    }
}