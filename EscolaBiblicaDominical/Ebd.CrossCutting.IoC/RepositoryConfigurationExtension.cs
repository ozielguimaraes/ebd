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
            services.AddScoped(typeof(IAlunoRepository), typeof(AlunoRepository));
            services.AddScoped(typeof(IAvaliacaoRepository), typeof(AvaliacaoRepository));
            services.AddScoped(typeof(IAvaliacaoAlunoRepository), typeof(AvaliacaoAlunoRepository));
            services.AddScoped(typeof(IBairroRepository), typeof(BairroRepository));
            services.AddScoped(typeof(IChamadaRepository), typeof(ChamadaRepository));
            services.AddScoped(typeof(IEnderecoRepository), typeof(EnderecoRepository));
            services.AddScoped(typeof(ILicaoRepository), typeof(LicaoRepository));
            services.AddScoped(typeof(IProfessorRepository), typeof(ProfessorRepository));
            services.AddScoped(typeof(IRevistaRepository), typeof(RevistaRepository));
            services.AddScoped(typeof(ITurmaRepository), typeof(TurmaRepository));

            services.AddDbContext<MainContext>();
            services.AddScoped<IEntityFrameworkContext, MainContext>();

            return services;
        }
    }
}
