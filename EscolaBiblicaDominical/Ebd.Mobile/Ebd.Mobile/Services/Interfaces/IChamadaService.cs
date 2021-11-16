using Ebd.Mobile.Services.Requests.Chamada;
using Ebd.Mobile.Services.Responses;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Interfaces
{
    public interface IChamadaService
    {
        Task<EmptyResponse> EfetuarChamadaAsync(ChamadaRequest request);
    }
}
