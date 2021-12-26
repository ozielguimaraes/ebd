using Ebd.Mobile.Services.Responses;
using Ebd.Mobile.Services.Responses.Avaliacao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Interfaces
{
    public interface IAvaliacaoService
    {
        Task<BaseResponse<IEnumerable<AvaliacaoResponse>>> ObterTodasAsync();
    }
}
