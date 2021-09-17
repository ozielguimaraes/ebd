using Ebd.Domain.Core.Entities;
using System.Collections.Generic;

namespace Ebd.Domain.Core.Interfaces.Repositories
{
    public interface IProfessorRepository
    {
        Professor Adicionar(Professor professor);
        void Atualizar(Professor professor);
        Professor ObterPorId(int id);
        ICollection<Professor> Pesquisar(string pesquisa);
    }
}