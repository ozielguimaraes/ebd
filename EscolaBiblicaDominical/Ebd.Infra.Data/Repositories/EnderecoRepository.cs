using Ebd.Domain.Core.Entities;
using Ebd.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ebd.Infra.Data.Repositories
{
    public class EnderecoRepository : BaseRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MainContext context) : base(context)
        {
        }

        public async Task<Endereco> Adicionar(Endereco endereco)
        {
            DbSet.Add(endereco);
            await Db.SaveChangesAsync();

            return endereco;
        }

        public async Task Atualizar(Endereco endereco)
        {
            var entry = Db.Entry(endereco);
            DbSet.Attach(endereco);
            entry.State = EntityState.Modified;

            await Db.SaveChangesAsync();
        }

        public async Task<Endereco> ObterPorId(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.EnderecoId == id);
        }
    }
}
