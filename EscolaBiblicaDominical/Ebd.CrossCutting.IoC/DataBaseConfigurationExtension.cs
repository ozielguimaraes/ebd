using Ebd.Infra.Data;
using Ebd.Infra.Data.Context.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ebd.CrossCutting.IoC
{
    public static class DataBaseConfigurationExtension
    {
        public static IServiceCollection AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEntityFrameworkContext, MainContext>();

            var databaseConfig = configuration.GetConfiguration<DataBaseConfiguration>();
            services.AddSingleton(databaseConfig);

            services.AddDbContext<MainContext>();

            return services;
        }
    }
}
