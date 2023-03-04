using Ebd.Application.Requests.Turma;
using Ebd.Application.Responses.Base;
using Ebd.Application.Responses.Turma;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Application.Business.Interfaces
{
    public interface ITurmaBusiness
    {
        Task<BaseResponse> AdicionarAsync(AdicionarTurmaRequest request);
        Task<IEnumerable<TurmaResponse>> ObterTodas();
    }
}