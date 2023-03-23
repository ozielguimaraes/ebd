using Ebd.Mobile.Services.Interfaces;

namespace Ebd.Mobile.Services.Implementations.Base
{
    public abstract class BaseService : ApiService
    {
        protected readonly ILoggerService loggerService;

        protected BaseService(ILoggerService loggerService, INetworkService networkService) : base(networkService, loggerService)
        {
            this.loggerService = loggerService;
        }
    }
}
