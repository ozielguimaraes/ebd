using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging.AzureAppServices;

namespace Ebd.CrossCutting.IoC
{
    public static class BootstrapperExtension
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AzureFileLoggerOptions>(configuration.GetSection("AzureLogging"));

            services.AddDataBaseConfiguration(configuration);
            services.AddApplicationConfiguration();
            services.AddRepositoryConfiguration(configuration);
        }
    }
}
