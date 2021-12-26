using Ebd.Mobile.Services.Implementations.Base;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Services.Requests.Revista;
using Ebd.Mobile.Services.Responses;
using Ebd.Mobile.Services.Responses.Revista;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Implementations
{
    public class RevistaService : ApiService, IRevistaService
    {
        private const string PathToService = "revista";

        public RevistaService(INetworkService networkService) : base(networkService) { }

        public async Task<BaseResponse<RevistaResponse>> AdicionarAsync(AdicionarRevistaRequest request)
            => await GetAndRetry<RevistaResponse>(PathToService, retryCount: DefaultRetryCount, OnRetry);

        public async Task<BaseResponse<RevistaResponse>> ObterPorIdAsync(int revistaId)
            => await GetAndRetry<RevistaResponse>($"{PathToService}/{revistaId}", retryCount: DefaultRetryCount, OnRetry);

        public async Task<BaseResponse<IEnumerable<RevistaResponse>>> ObterPorPeriodoAsync(int ano, int trimestre)
            => await GetAndRetry<IEnumerable<RevistaResponse>>($"{PathToService}/{trimestre}/{ano}", retryCount: DefaultRetryCount, OnRetry);
    }
}
