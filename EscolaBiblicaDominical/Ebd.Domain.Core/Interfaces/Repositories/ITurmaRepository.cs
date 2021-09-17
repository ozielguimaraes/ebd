using Ebd.Domain.Core.Entities;

namespace Ebd.Domain.Core.Interfaces.Repositories
{
    public interface ITurmaRepository
    {
        Turma Adicionar(Turma turma);
        void Atualizar(Turma turma);
        Turma ObterPorId(int id);
    }
}