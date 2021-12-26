using Ebd.Domain.Core.Entities;
using Ebd.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebd.Infra.Data.Repositories
{
    public class RevistaRepository : Repository<Revista>, IRevistaRepository
    {
        public RevistaRepository(MainContext context) : base(context)
        {
        }

        public async Task<Revista> Adicionar(Revista revista)
        {
            DbSet.Add(revista);
            await Db.SaveChangesAsync();

            return revista;
        }

        public async Task Atualizar(Revista revista)
        {
            var entry = Db.Entry(revista);
            DbSet.Attach(revista);
            entry.State = EntityState.Modified;

            await Db.SaveChangesAsync();
        }

        public async Task<Revista> ObterPorId(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<Revista> ObterPorPeriodo(int ano, int trimestre)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Ano == ano && x.Trimestre == trimestre);
        }
    }
}
