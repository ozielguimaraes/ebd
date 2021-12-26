using Ebd.Mobile.Services.Requests.Licao;
using Ebd.Mobile.Services.Responses;
using Ebd.Mobile.Services.Responses.Licao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Interfaces
{
    public interface ILicaoService
    {
        Task<BaseResponse<LicaoResponse>> AdicionarAsync(AdicionarLicaoRequest request);
        Task<BaseResponse<IEnumerable<LicaoResponse>>> ObterPorRevistaAsync(int revistaId);
    }
}
