using Ebd.Mobile.Services.Implementations.Base;
using Ebd.Mobile.Services.Interfaces;
using System.Threading.Tasks;

namespace Ebd.Mobile.Services.Implementations
{
    public class SyncService : BaseService, ISyncService
    {
        private readonly ITurmaService turmaService;
        private readonly IBairroService bairroService;

        public SyncService(ILoggerService loggerService, INetworkService networkService, ITurmaService turmaService, IBairroService bairroService) : base(loggerService, networkService)
        {
            this.turmaService = turmaService;
            this.bairroService = bairroService;
        }

        public async Task SyncDataAsync()
        {
            var turmasResponse = await turmaService.ObterTodasAsync();
            if (turmasResponse.IsSuccess) loggerService.LogError("Dados de turmas sincronizados");
            else loggerService.LogError("Erro ao tentar syncronizar as turmas", turmasResponse.Exception);

            var bairrosResponse = await bairroService.ObterTodosAsync();
            if (bairrosResponse.IsSuccess) loggerService.LogError("Dados de bairros sincronizados");
            else loggerService.LogError("Erro ao tentar syncronizar os bairros", bairrosResponse.Exception);
        }
    }
}
