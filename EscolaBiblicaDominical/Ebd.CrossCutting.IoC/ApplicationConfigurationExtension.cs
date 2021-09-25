using Ebd.Infra.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Ebd.CrossCutting.IoC
{
    public static class ApplicationConfigurationExtension
    {
        public static IServiceCollection AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetConfiguration<DataBaseConfiguration>());
            return services;
        }
    }
}
