using Ebd.Mobile.Services.Requests.Aluno;
using Ebd.Mobile.Services.Responses;
using Ebd.Mobile.Services.Responses.Aluno;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Interfaces
{
    public interface IAlunoService
    {
        Task<BaseResponse<IEnumerable<AlunoResponse>>> ObterPorTurmaIdAsync(int turmaId);
        Task<BaseResponse<AlunoResponse>> SalvarAsync(AlterarAlunoRequest request);
    }
}
