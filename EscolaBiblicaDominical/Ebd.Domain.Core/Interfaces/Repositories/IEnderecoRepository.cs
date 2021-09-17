using Ebd.Domain.Core.Entities;
using System.Threading.Tasks;

namespace Ebd.Domain.Core.Interfaces.Repositories
{
    public interface IEnderecoRepository
    {
        Task<Endereco> Adicionar(Endereco endereco);
        Task Atualizar(Endereco endereco);
        Task<Endereco> ObterPorId(int id);
    }
}