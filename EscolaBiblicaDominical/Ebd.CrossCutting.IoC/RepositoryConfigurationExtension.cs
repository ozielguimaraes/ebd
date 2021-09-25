using Ebd.Domain.Core.Interfaces.Repositories;
using Ebd.Infra.Data;
using Ebd.Infra.Data.Context.Interfaces;
using Ebd.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Ebd.CrossCutting.IoC
{
    public static class RepositoryConfigurationExtension
    {
        public static IServiceCollection AddRepositoryConfiguration(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));




            //services.AddRepository<IRepository, Repository, object>();
            
            
            services.AddDbContext<MainContext>();
            services.AddTransient<IEntityFrameworkContext, MainContext>();
            return services;
        }

        private static void AddRepository<TInterface, TRepository, TEntity>(this IServiceCollection services)
            where TInterface : IRepository<TEntity>
            where TRepository : TInterface
            where TEntity : class
        {
            //services.AddScoped<TInterface, TRepository>();
           // services.AddScoped<IRepository<TEntity>, TRepository>();
        }
    }
}
