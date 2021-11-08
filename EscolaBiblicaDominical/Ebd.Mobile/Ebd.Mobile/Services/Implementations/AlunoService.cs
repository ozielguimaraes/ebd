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
        private const string PathToService = "aluno";

        public AlunoService(INetworkService networkService) : base(networkService)
        {
        }

        public async Task<IEnumerable<AlunoResponse>> ObterPorTurmaIdAsync(int turmaId)
        {
            var response = await GetAndRetry<IEnumerable<AlunoResponse>>($"{PathToService}/turma/{turmaId}", retryCount: DefaultRetryCount, OnRetry);

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
