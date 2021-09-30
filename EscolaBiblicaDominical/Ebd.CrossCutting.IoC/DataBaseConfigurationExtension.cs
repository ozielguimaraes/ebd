using Ebd.Infra.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ebd.CrossCutting.IoC
{
    public static class DataBaseConfigurationExtension
    {
        public static IServiceCollection AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetConfiguration<DataBaseConfiguration>());
            return services;
        }
    }
}
