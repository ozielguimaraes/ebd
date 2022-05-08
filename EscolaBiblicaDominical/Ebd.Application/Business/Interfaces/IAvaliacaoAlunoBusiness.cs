using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Application.Business.Interfaces
{
    public interface IAvaliacaoAlunoBusiness
    {
        Task AdicionarAsync(int alunoId, int licaoId, bool estavaPresente, IEnumerable<int> idsAvaliacao);
    }
}
