using Ebd.Mobile.Services.Requests.Revista;
using Ebd.Mobile.Services.Responses;
using Ebd.Mobile.Services.Responses.Revista;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Interfaces
{
    public interface IRevistaService
    {
        Task<BaseResponse<RevistaResponse>> AdicionarAsync(AdicionarRevistaRequest request);
        Task<BaseResponse<RevistaResponse>> ObterPorIdAsync(int revistaId);
        Task<BaseResponse<RevistaResponse>> ObterPorPeriodoAsync(int turmaId, int ano, int trimestre);
    }
}
