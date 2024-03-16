using Ebd.Mobile.Services.Implementations.Base;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Services.Responses;
using Ebd.Mobile.Services.Responses.Cep;
using Ebd.MobileApp.Models.Extensions;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Implementations
{
    public class CepService : BaseService, ICepService
    {
        public CepService(ILoggerService loggerService, INetworkService networkService) : base(loggerService, networkService) { }

        public async Task<BaseResponse<CepResponse>> ObterAsync(string cep)
            => await GetAndRetry<CepResponse>($"https://viacep.com.br/ws/{cep.DigitsOnly()}/json", retryCount: DefaultRetryCount, OnRetry);
    }
}
