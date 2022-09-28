using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Services.Requests.Licao;
using Ebd.Mobile.Services.Responses;
using Ebd.Mobile.Services.Responses.Licao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Mocks
{
    public class LicaoMock : ILicaoService
    {
        private readonly List<LicaoResponse> items;

        public async Task<BaseResponse<LicaoResponse>> AdicionarAsync(AdicionarLicaoRequest request)
        {
            var response = new LicaoResponse();
            items.Add(response);
            return await Task.FromResult(new BaseResponse<LicaoResponse>(response));
        }

        public async Task<BaseResponse<IEnumerable<LicaoResponse>>> ObterPorRevistaAsync(int revistaId)
        {
            return await Task.FromResult(new BaseResponse<IEnumerable<LicaoResponse>>(items.Where(x => x.RevistaId == revistaId)));
        }
    }
}
