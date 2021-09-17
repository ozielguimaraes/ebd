using Ebd.Domain.Core.Entities;

namespace Ebd.Domain.Core.Interfaces.Repositories
{
    public interface IChamadaRepository
    {
        Chamada Adicionar(Chamada chamada);
    }
}