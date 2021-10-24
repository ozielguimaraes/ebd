using Ebd.Mobile.Services.Implementations.Base;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Services.Responses.Aluno;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Implementations
{
    public class AlunoService : ApiService, IAlunoService
    {
        public AlunoService(INetworkService networkService) : base(networkService)
        {
        }

        public async Task<IEnumerable<AlunoResponse>> ObterTodosAsync()
        {
            var response = await GetAndRetry<IEnumerable<AlunoResponse>>(uri: new Uri("aluno"), retryCount: DefaultRetryCount, OnRetry);

            return response;
        }

        private Task OnRetry(Exception e, int retryCount)
        {
            return Task.Factory.StartNew(() => {
                System.Diagnostics.Debug.WriteLine($"Retry - Attempt #{retryCount} to get students.");
            });
        }
    }
}
