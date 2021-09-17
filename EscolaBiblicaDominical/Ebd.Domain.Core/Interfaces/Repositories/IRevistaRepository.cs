using Ebd.Domain.Core.Entities;
using System.Collections.Generic;

namespace Ebd.Domain.Core.Interfaces.Repositories
{
    public interface IRevistaRepository
    {
        Revista Adicionar(Revista revista);
        void Atualizar(Revista revista);
        Revista ObterPorId(int id);
        Revista ObterPorPeriodo(int ano, int trimestre);
        ICollection<Revista> ObterTodas();
    }
}