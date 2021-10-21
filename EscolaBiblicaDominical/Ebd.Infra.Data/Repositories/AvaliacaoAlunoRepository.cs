using Ebd.Domain.Core.Entities;
using Ebd.Domain.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Infra.Data.Repositories
{
    public class AvaliacaoAlunoRepository : Repository<AvaliacaoAluno>, IAvaliacaoAlunoRepository
    {
        public AvaliacaoAlunoRepository(MainContext context) : base(context) { }

        public async Task<AvaliacaoAluno> AdicionarAsync(AvaliacaoAluno avaliacaoAluno)
        {
            DbSet.Add(avaliacaoAluno);
            await Db.SaveChangesAsync();

            return avaliacaoAluno;
        }

        public async Task AdicionarAsync(IEnumerable<AvaliacaoAluno> items)
        {
            await DbSet.AddRangeAsync(items);
            await Db.SaveChangesAsync();
        }
    }
}
