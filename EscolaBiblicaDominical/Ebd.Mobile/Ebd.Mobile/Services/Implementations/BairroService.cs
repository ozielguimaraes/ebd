using Ebd.Mobile.Services.Implementations.Base;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Services.Responses;
using Ebd.Mobile.Services.Responses.Bairro;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Implementations
{
    public class BairroService : ApiService, IBairroService
    {
        private const string PathToService = "bairro";

        public BairroService(INetworkService networkService) : base(networkService) { }

        public async Task<BaseResponse<IEnumerable<BairroResponse>>> ObterTodosAsync()
            => await GetAndRetry<IEnumerable<BairroResponse>>(PathToService, retryCount: DefaultRetryCount, OnRetry);

        public async Task<BaseResponse<IEnumerable<BairroResponse>>> PesquisarAsync(string pesquisa)
            => await GetAndRetry<IEnumerable<BairroResponse>>($"{PathToService}/pesquisar/{pesquisa}", retryCount: DefaultRetryCount, OnRetry);
    }
}
