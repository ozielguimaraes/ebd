using Ebd.Domain.Core.Entities;
using Ebd.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebd.Infra.Data.Repositories
{
    public class BairroRepository : Repository<Bairro>, IBairroRepository
    {
        public BairroRepository(MainContext context) : base(context)
        {
        }

        public async Task<Bairro> Adicionar(Bairro bairro)
        {
            DbSet.Add(bairro);
            await Db.SaveChangesAsync();

            return bairro;
        }

        public async Task Atualizar(Bairro entity)
        {
            var entry = Db.Entry(entity);
            DbSet.Attach(entity);
            entry.State = EntityState.Modified;

            await Db.SaveChangesAsync();
        }

        public async Task<Bairro> ObterPorId(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.BairroId == id);
        }

        public async Task<ICollection<Bairro>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<ICollection<Bairro>> PesquisarAsync(string pesquisa)
        {
            return await DbSet.Where(x => x.Nome.Contains(pesquisa)).ToListAsync();
        }
    }
}
