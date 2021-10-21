using Ebd.Domain.Core.Entities;
using Ebd.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Infra.Data.Repositories
{
    public class AvaliacaoRepository : Repository<Avaliacao>, IAvaliacaoRepository
    {
        public AvaliacaoRepository(MainContext context) : base(context) { }

        public async Task<Avaliacao> AdicionarAsync(Avaliacao avaliacao)
        {
            DbSet.Add(avaliacao);
            await Db.SaveChangesAsync();

            return avaliacao;
        }

        public async Task<ICollection<Avaliacao>> ObterTodasAsync()
            => await DbSet.ToListAsync();
    }
}
