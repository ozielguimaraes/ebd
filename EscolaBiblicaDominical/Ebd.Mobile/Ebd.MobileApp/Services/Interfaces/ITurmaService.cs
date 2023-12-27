using Ebd.Mobile.Services.Responses;
using Ebd.Mobile.Services.Responses.Turma;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Interfaces
{
    public interface ITurmaService
    {
        Task<BaseResponse<IEnumerable<TurmaResponse>>> ObterTodasAsync();
    }
}
