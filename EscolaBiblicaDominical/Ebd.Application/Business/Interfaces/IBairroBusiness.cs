using Ebd.Application.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Application.Business.Interfaces
{
    public interface IBairroBusiness
    {
        Task<BairroResponse> ObterPorIdAsync(int id);
        Task<IEnumerable<BairroResponse>> ObterTodosAsync();
        Task<IEnumerable<BairroResponse>> PesquisarAsync(string pesquisa);
    }
}
