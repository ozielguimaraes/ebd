using Ebd.Domain.Core.Entities;
using System.Collections.Generic;

namespace Ebd.Domain.Core.Interfaces.Repositories
{
    public interface IBairroRepository
    {
        Bairro Adicionar(Bairro bairro);
        void Atualizar(Bairro bairro);
        Bairro ObterPorId(int id);
        ICollection<Bairro> ObterTodos();
    }
}