using Ebd.Mobile.Services.Implementations.Base;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Services.Requests.Chamada;
using Ebd.Mobile.Services.Responses;
using Ebd.Mobile.Services.Responses.Chamada;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Implementations
{
    public class ChamadaService : BaseService, IChamadaService
    {
        private const string PathToService = "chamada";

        public ChamadaService(ILoggerService loggerService, INetworkService networkService) : base(loggerService, networkService) { }

        public async Task<BaseResponse<ChamadaResponse>> EfetuarChamadaAsync(ChamadaRequest request)
        {
            return await PostAndRetry<ChamadaRequest, ChamadaResponse>(PathToService, request, OnRetry);
        }
    }
}
