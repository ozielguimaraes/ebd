using Ebd.Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Domain.Core.Interfaces.Repositories
{
    public interface IProfessorRepository
    {
        Task<Professor> Adicionar(Professor professor);
        Task Atualizar(Professor professor);
        Task<Professor> ObterPorId(int id);
        Task<ICollection<Professor>> Pesquisar(string pesquisa);
    }
}