using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Services.Requests.Revista;
using Ebd.Mobile.Services.Responses;
using Ebd.Mobile.Services.Responses.Revista;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Mocks
{
    internal class RevistaMock : IRevistaService
    {
        private readonly List<RevistaResponse> items;

        public async Task<BaseResponse<RevistaResponse>> AdicionarAsync(AdicionarRevistaRequest request)
        {
            var response = new RevistaResponse();
            items.Add(response);
            return await Task.FromResult(new BaseResponse<RevistaResponse>(response));
        }

        public async Task<BaseResponse<RevistaResponse>> ObterPorIdAsync(int revistaId)
        {
            return await Task.FromResult(new BaseResponse<RevistaResponse>(items.FirstOrDefault(x => x.RevistaId == revistaId)));
        }

        public async Task<BaseResponse<RevistaResponse>> ObterPorPeriodoAsync(int turmaId, int ano, int trimestre)
        {
            return await Task.FromResult(new BaseResponse<RevistaResponse>(items.FirstOrDefault(x => x.Trimestre == trimestre && x.Ano == ano)));
        }
    }
}
