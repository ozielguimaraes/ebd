using Ebd.Mobile.Services.Implementations.Base;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Services.Requests.Revista;
using Ebd.Mobile.Services.Responses;
using Ebd.Mobile.Services.Responses.Bairro;
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
            => await PostAndRetry<AdicionarRevistaRequest, RevistaResponse>(PathToService, request, OnRetry);

        public async Task<BaseResponse<RevistaResponse>> ObterPorIdAsync(int revistaId)
            => await GetAndRetry<RevistaResponse>($"{PathToService}/{revistaId}", retryCount: DefaultRetryCount, OnRetry);

        public async Task<BaseResponse<RevistaResponse>> ObterPorPeriodoAsync(int turmaId, int ano, int trimestre)
            => await GetAndRetry<RevistaResponse>($"{PathToService}/turma/{turmaId}/trimestre/{trimestre}-{ano}", retryCount: DefaultRetryCount, OnRetry);
    }
    public class BairroService : ApiService, IBairroService
    {
        private const string PathToService = "bairro";

        public BairroService(INetworkService networkService) : base(networkService) { }

        public async Task<BaseResponse<IEnumerable<BairroResponse>>> ObterTodosAsync()
            => await GetAndRetry<BairroResponse>(PathToService, retryCount: DefaultRetryCount, OnRetry);

        public async Task<BaseResponse<IEnumerable<BairroResponse>>> PesquisarAsync(string pesquisa)
            => await GetAndRetry<BairroResponse>($"{PathToService}/{pesquisa}", retryCount: DefaultRetryCount, OnRetry);
    }
}
