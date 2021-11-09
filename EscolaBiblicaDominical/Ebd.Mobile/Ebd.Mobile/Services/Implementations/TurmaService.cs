using Ebd.Mobile.Services.Implementations.Base;
using Ebd.Mobile.Services.Implementations.Log;
using Ebd.Mobile.Services.Implementations.Logger;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Services.Responses;
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

        public async Task<BaseResponse<IEnumerable<TurmaResponse>>> ObterTodasAsync()
            => await GetAndRetry<IEnumerable<TurmaResponse>>(PathToService, retryCount: DefaultRetryCount, OnRetry);
    }
}
