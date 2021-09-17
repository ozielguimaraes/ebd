using Ebd.Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Domain.Core.Interfaces.Repositories
{
    public interface IBairroRepository
    {
        Task<Bairro> Adicionar(Bairro bairro);
        Task Atualizar(Bairro bairro);
        Task<Bairro> ObterPorId(int id);
        Task<ICollection<Bairro>> ObterTodos();
    }
}