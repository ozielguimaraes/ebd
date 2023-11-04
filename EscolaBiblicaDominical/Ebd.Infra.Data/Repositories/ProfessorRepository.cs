using Ebd.Domain.Core.Entities;
using Ebd.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebd.Infra.Data.Repositories
{
    public class ProfessorRepository : Repository<Professor>, IProfessorRepository
    {
        public ProfessorRepository(MainContext context) : base(context)
        {
        }

        public async Task<Professor> Adicionar(Professor professor)
        {
            DbSet.Add(professor);
            await Db.SaveChangesAsync();

            return professor;
        }

        public async Task Atualizar(Professor professor)
        {
            var entry = Db.Entry(professor);
            DbSet.Attach(professor);
            entry.State = EntityState.Modified;

            await Db.SaveChangesAsync();
        }

        public async Task<Professor> ObterPorId(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<ICollection<Professor>> Pesquisar(string pesquisa)
        {
            return await DbSet
                .Where(x => x.Pessoa.Nome.ToUpper().Contains(pesquisa.ToUpper()))
                .ToListAsync();
        }
    }
}
