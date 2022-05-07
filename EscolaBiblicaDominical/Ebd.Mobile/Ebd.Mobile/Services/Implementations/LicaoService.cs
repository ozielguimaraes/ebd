using Ebd.Mobile.Services.Implementations.Base;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Services.Requests.Licao;
using Ebd.Mobile.Services.Responses;
using Ebd.Mobile.Services.Responses.Licao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Implementations
{
    public class LicaoService : ApiService, ILicaoService
    {
        private const string PathToService = "licao";

        public LicaoService(INetworkService networkService) : base(networkService) { }

        public async Task<BaseResponse<LicaoResponse>> AdicionarAsync(AdicionarLicaoRequest request)
            => await PostAndRetry<AdicionarLicaoRequest, LicaoResponse>(PathToService, request, OnRetry);

        public async Task<BaseResponse<IEnumerable<LicaoResponse>>> ObterPorRevistaAsync(int revistaId)
            => await GetAndRetry<IEnumerable<LicaoResponse>>($"{PathToService}/revista/{revistaId}", retryCount: DefaultRetryCount, OnRetry);
    }
}
