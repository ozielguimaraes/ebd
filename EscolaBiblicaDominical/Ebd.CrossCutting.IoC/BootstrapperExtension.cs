using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ebd.CrossCutting.IoC
{
    public static class BootstrapperExtension
    {
        public static void ConfigureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDataBaseConfiguration(configuration);
            services.AddApplicationConfiguration();
            services.AddRepositoryConfiguration();
        }
    }
}
