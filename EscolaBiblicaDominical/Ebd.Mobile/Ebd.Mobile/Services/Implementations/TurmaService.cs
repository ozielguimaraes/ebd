using Ebd.Mobile.Extensions;
using Ebd.Mobile.Repository;
using Ebd.Mobile.Services.Implementations.Base;
using Ebd.Mobile.Services.Interfaces;
using Ebd.Mobile.Services.Responses;
using Ebd.Mobile.Services.Responses.Turma;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Implementations
{
    public class TurmaService : BaseService, ITurmaService
    {
        private const string PathToService = "turma";
        private readonly IRepository repository;

        public TurmaService(ILoggerService loggerService, INetworkService networkService, IRepository repository) : base(loggerService, networkService)
        {
            this.repository = repository;
        }

        public async Task<BaseResponse<IEnumerable<TurmaResponse>>> ObterTodasAsync()
        {
            loggerService.LogInformation("Obtendo todas turmas");
            IEnumerable<TurmaResponse> items = repository.ObterTodos<TurmaResponse>();
            if (items.Any()) return new BaseResponse<IEnumerable<TurmaResponse>>(items);

            var result = await GetAndRetry<IEnumerable<TurmaResponse>>(PathToService, retryCount: DefaultRetryCount, OnRetry);

            if (result.IsSuccess)
            {
                loggerService.LogInformation("Guardar turmas no banco local");
                var foiAtualizado = repository.Upsert(result.Data);
                if (foiAtualizado.Not())
                    loggerService.LogError("Não foi possível adicionar as turmas no banco local");
            }
            else loggerService.LogError($"{nameof(TurmaService)}::{nameof(ObterTodasAsync)} - Não foi possível obter as turmas");
            return result;
        }
    }
}
