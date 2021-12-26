using Ebd.Application.Requests.Revista;
using Ebd.Application.Responses.Base;
using Ebd.Application.Responses.Revista;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Application.Business.Interfaces
{
    public interface IRevistaBusiness
    {
        Task<BaseResponse> AdicionarAsync(AdicionarRevistaRequest request);
        Task<RevistaResponse> ObterPorId(int revistaId);
        Task<IEnumerable<RevistaResponse>> ObterPorPeriodo(int ano, int trimestre);
    }
}
