using Ebd.Domain.Core.Entities;
using Ebd.Domain.Core.Interfaces.Repositories;
using System.Threading.Tasks;

namespace Ebd.Infra.Data.Repositories
{
    public class ChamadaRepository : BaseRepository<Chamada>, IChamadaRepository
    {
        public ChamadaRepository(MainContext context) : base(context)
        {
        }

        public async Task<Chamada> Adicionar(Chamada chamada)
        {
            DbSet.Add(chamada);
            await Db.SaveChangesAsync();

            return chamada;
        }
    }
}
