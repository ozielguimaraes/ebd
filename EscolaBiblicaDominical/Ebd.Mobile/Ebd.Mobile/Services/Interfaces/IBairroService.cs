using Ebd.Mobile.Services.Responses;
using Ebd.Mobile.Services.Responses.Bairro;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Interfaces
{
    public interface IBairroService
    {
        Task<BaseResponse<IEnumerable<BairroResponse>>> ObterTodosAsync();
        Task<BaseResponse<IEnumerable<BairroResponse>>> PesquisarAsync(string pesquisa);
    }
}
