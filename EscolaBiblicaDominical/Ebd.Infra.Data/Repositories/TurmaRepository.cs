using Ebd.Domain.Core.Entities;
using Ebd.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ebd.Infra.Data.Repositories
{
    public class TurmaRepository : Repository<Turma>, ITurmaRepository
    {
        public TurmaRepository(MainContext context) : base(context)
        {
        }

        public async Task<Turma> Adicionar(Turma turma)
        {
            DbSet.Add(turma);
            await Db.SaveChangesAsync();

            return turma;
        }

        public async Task Atualizar(Turma turma)
        {
            var entry = Db.Entry(turma);
            DbSet.Attach(turma);
            entry.State = EntityState.Modified;

            await Db.SaveChangesAsync();
        }

        public async Task<Turma> ObterPorId(int id)
        {
            return await DbSet.FindAsync(id);
        }
    }
}
