using Ebd.Mobile.Services.Requests.Chamada;
using Ebd.Mobile.Services.Responses;
using Ebd.Mobile.Services.Responses.Chamada;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Interfaces
{
    public interface IChamadaService
    {
        Task<BaseResponse<ChamadaResponse>> EfetuarChamadaAsync(ChamadaRequest request);
    }
}
