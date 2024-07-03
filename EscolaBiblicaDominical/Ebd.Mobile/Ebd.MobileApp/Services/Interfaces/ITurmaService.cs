using Ebd.Mobile.Services.Responses;
using Ebd.Mobile.Services.Responses.Turma;

namespace Ebd.Mobile.Services.Interfaces;

internal interface ITurmaService
{
    Task<BaseResponse<IEnumerable<TurmaResponse>>> ObterTodasAsync();
    Task<BaseResponse<IEnumerable<TurmaResponse>>> ObterPeloUsuarioAsync();
}
