using Ebd.Application.Requests.Licao;
using Ebd.Application.Responses.Base;
using Ebd.Application.Responses.Licao;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Application.Business.Interfaces
{
    public interface ILicaoBusiness
    {
        Task<BaseResponse> AdicionarAsync(AdicionarLicaoRequest request);
        Task<IEnumerable<LicaoResponse>> ObterPorRevista(int revistaId);
    }
}
