using Ebd.Mobile.Services.Implementations.Base;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Services.Responses.Turma;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Implementations
{
    public class TurmaService : ApiService, ITurmaService
    {
        private const string PathToService = "turma";

        public TurmaService(INetworkService networkService) : base(networkService)
        {
        }

        public async Task<IEnumerable<TurmaResponse>> ObterTodasAsync()
        {
            var response = await GetAndRetry<IEnumerable<TurmaResponse>>(PathToService, retryCount: DefaultRetryCount, OnRetry);

            return response;
        }

        private Task OnRetry(Exception e, int retryCount)
        {
            return Task.Factory.StartNew(() => {
                System.Diagnostics.Debug.WriteLine($"Retry - Attempt #{retryCount} to get classes.");
            });
        }
    }
}
