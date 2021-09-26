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
            //services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient(typeof(IAlunoRepository), typeof(AlunoRepository));
            services.AddTransient(typeof(IBairroRepository), typeof(BairroRepository));
            services.AddTransient(typeof(IChamadaRepository), typeof(ChamadaRepository));
            services.AddTransient(typeof(IEnderecoRepository), typeof(EnderecoRepository));
            services.AddTransient(typeof(ILicaoRepository), typeof(LicaoRepository));
            services.AddTransient(typeof(IProfessorRepository), typeof(ProfessorRepository));
            services.AddTransient(typeof(IRevistaRepository), typeof(RevistaRepository));
            services.AddTransient(typeof(ITurmaRepository), typeof(TurmaRepository));

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
