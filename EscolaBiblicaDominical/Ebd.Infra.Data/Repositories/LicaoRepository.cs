using Ebd.Domain.Core.Entities;
using Ebd.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebd.Infra.Data.Repositories
{
    public class LicaoRepository : Repository<Licao>, ILicaoRepository
    {
        public LicaoRepository(MainContext context) : base(context)
        {
        }

        public async Task<Licao> Adicionar(Licao licao)
        {
            DbSet.Add(licao);
            await Db.SaveChangesAsync();

            return licao;
        }

        public async Task Atualizar(Licao licao)
        {
            var entry = Db.Entry(licao);
            DbSet.Attach(licao);
            entry.State = EntityState.Modified;

            await Db.SaveChangesAsync();
        }

        public async Task<Licao> ObterPorId(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.LicaoId == id);
        }

        public async Task<ICollection<Licao>> ObterPorRevista(int revistaId)
        {
            return await DbSet.Where(x => x.RevistaId == revistaId).ToListAsync();
        }

        public async Task<ICollection<Licao>> Pesquisar(string pesquisa)
        {
            return await DbSet.Where(x => x.Titulo.ToUpper().Contains(pesquisa.ToUpper())).ToListAsync();
        }
    }
}
