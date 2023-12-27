using Ebd.Mobile.Services.Implementations.Base;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Services.Responses;
using Ebd.Mobile.Services.Responses.Avaliacao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Implementations
{
    public class AvaliacaoService : BaseService, IAvaliacaoService
    {
        private const string PathToService = "avaliacao";

        public AvaliacaoService(ILoggerService loggerService, INetworkService networkService) : base(loggerService, networkService) { }

        public async Task<BaseResponse<IEnumerable<AvaliacaoResponse>>> ObterTodasAsync()
            => await GetAndRetry<IEnumerable<AvaliacaoResponse>>(PathToService, retryCount: DefaultRetryCount, OnRetry);
    }
}
