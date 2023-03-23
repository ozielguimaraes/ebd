using Ebd.Mobile.Services.Implementations.Base;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Services.Requests.Aluno;
using Ebd.Mobile.Services.Responses;
using Ebd.Mobile.Services.Responses.Aluno;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Implementations
{
    public class AlunoService : BaseService, IAlunoService
    {
        private const string PathToService = "aluno";

        public AlunoService(ILoggerService loggerService, INetworkService networkService) : base(loggerService, networkService)
        {
        }

        public async Task<BaseResponse<IEnumerable<AlunoResponse>>> ObterPorTurmaIdAsync(int turmaId)
            => await GetAndRetry<IEnumerable<AlunoResponse>>($"{PathToService}/turma/{turmaId}", retryCount: DefaultRetryCount, OnRetry);

        public async Task<BaseResponse<AlunoResponse>> SalvarAsync(AlterarAlunoRequest request)
        {
            var requestUri = request.AlunoId is null ? PathToService : $"{PathToService}/{request.AlunoId}";
            return await PostAndRetry<AlterarAlunoRequest, AlunoResponse>(requestUri, request, OnRetry);
        }
    }
}
