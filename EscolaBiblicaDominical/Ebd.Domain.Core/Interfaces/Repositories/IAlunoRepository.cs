using Ebd.Domain.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Domain.Core.Interfaces.Repositories
{
    public interface IAlunoRepository
    {
        Task<Aluno> Adicionar(Aluno aluno);
        Task Atualizar(Aluno aluno);
        Task<Aluno> ObterPorId(int id);
        Task<ICollection<Aluno>> Pesquisar(string pesquisa);
    }
}