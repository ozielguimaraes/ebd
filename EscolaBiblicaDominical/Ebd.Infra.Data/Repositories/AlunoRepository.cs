using Ebd.Domain.Core.Entities;
using Ebd.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebd.Infra.Data.Repositories
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(MainContext context) : base(context) { }

        public async Task<Aluno> Adicionar(Aluno aluno)
        {
            DbSet.Add(aluno);
            await Db.SaveChangesAsync();

            return aluno;
        }

        public async Task Atualizar(Aluno aluno)
        {
            var entry = Db.Entry(aluno);
            DbSet.Attach(aluno);
            entry.State = EntityState.Modified;

            await Db.SaveChangesAsync();
        }

        public async Task<Aluno> ObterPorId(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<ICollection<Aluno>> Pesquisar(string pesquisa)
        {
            return await DbSet
                .Where(x => x.Pessoa.Nome.Contains(pesquisa) || x.Responsavel.Nome.Contains(pesquisa))
                .ToListAsync();
        }
    }
}
