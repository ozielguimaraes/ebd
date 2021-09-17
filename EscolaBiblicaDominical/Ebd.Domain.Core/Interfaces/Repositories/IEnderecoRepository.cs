using Ebd.Domain.Core.Entities;

namespace Ebd.Domain.Core.Interfaces.Repositories
{
    public interface IEnderecoRepository
    {
        Endereco Adicionar(Endereco endereco);
        void Atualizar(Endereco endereco);
        Endereco ObterPorId(int id);
    }
}