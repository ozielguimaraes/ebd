using Ebd.Domain.Core.Entities;
using System.Collections.Generic;

namespace Ebd.Domain.Core.Interfaces.Repositories
{
    public interface ILicaoRepository
    {
        Licao Adicionar(Licao licao);
        void Atualizar(Licao licao);
        Licao ObterPorId(int id);
        ICollection<Licao> Pesquisar(string pesquisa);
    }
}