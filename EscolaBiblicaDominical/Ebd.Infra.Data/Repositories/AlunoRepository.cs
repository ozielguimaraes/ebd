using Ebd.Domain.Core.Entities;
using Ebd.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebd.Infra.Data.Repositories
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(MainContext context) : base(context) { }

        public async Task<Aluno> Adicionar(Aluno entity)
        {
            DbSet.Add(entity);
            await Db.SaveChangesAsync();

            return entity;
        }

        public async Task Atualizar(Aluno entity)
        {
            var entry = Db.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;

            await Db.SaveChangesAsync();
        }

        public async Task<Aluno> ObterPorId(int id)
        {
            return await DbSet
                .Include(x => x.Pessoa).ThenInclude(c => c.Enderecos)
                .Include(x => x.Pessoa).ThenInclude(c => c.Contatos)
                .Include(x => x.Responsavel).ThenInclude(c => c.Enderecos)
                .Include(x => x.Responsavel).ThenInclude(c => c.Contatos)
                .FirstOrDefaultAsync(f => f.AlunoId == id);
        }

        public async Task<ICollection<Aluno>> ObterPorTurma(int turmaId)
        {
            return await DbSet
                .Include(x => x.Pessoa)
                .Where(x => x.TurmaId == turmaId)
                .ToListAsync();
        }

        public async Task<ICollection<Aluno>> Pesquisar(string pesquisa)
        {
            return await DbSet
                .Where(x => x.Pessoa.Nome.Contains(pesquisa) || x.Responsavel.Nome.Contains(pesquisa))
                .ToListAsync();
        }
    }
}
